using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WhatSport.Application.Commands.Users;
using WhatSport.Application.Models;
using WhatSport.Application.Queries.Users;
using WhatSport.Domain.Extensions;

namespace WhatSport.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<UsersController> logger;
        private readonly IMediator mediator;

        public UsersController(IConfiguration configuration, ILogger<UsersController> logger, IMediator mediator)
        {
            this.configuration = configuration;
            this.logger = logger;
            this.mediator = mediator;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<object>> Login([FromBody] LoginQuery loginQuery)
        {
            logger.LogInformation(
               "----- Sending command: {CommandName} - {IdProperty}: {CommandId}",
               loginQuery.GetGenericTypeName(),
               nameof(loginQuery.Login),
               loginQuery.Login);

            var user = await mediator.Send(loginQuery);

            return new { Token = GenerateJwtToken(user), user = user };
        }

        [HttpGet]
        public async Task<ActionResult<User>> Get()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
            var query = new UserByIdQuery(userId);
            
            logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                query.GetGenericTypeName(),
                nameof(query.Id),
                query.Id,
                query);

            return await mediator.Send(query);
        }

        [HttpGet("Friend")]
        public async Task<ActionResult<User[]>> GetFriends()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
            var query = new UserQuery();

            logger.LogInformation(
               "----- Sending command: {CommandName}: ({@Command})",
               query.GetGenericTypeName(),
               query);

            return await mediator.Send(query);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<User[]>> GetAll()
        {
            var query = new UserQuery();

            logger.LogInformation(
               "----- Sending command: {CommandName}: ({@Command})",
               query.GetGenericTypeName(),
               query);

            return await mediator.Send(query);
        }

        [HttpPut("ChangeStatus")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<bool>> ChangeUserStatus([FromBody] ChangeUserStatusCommand command)
        {
            logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                command.GetGenericTypeName(),
                nameof(command.UserId),
                command.UserId,
                command);

            return await mediator.Send(command);
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(configuration["SymmetricSecurityKey"]);

            var claims = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role),
            });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
