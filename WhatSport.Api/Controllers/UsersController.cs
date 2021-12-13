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
            var userByIdQuery = new UserByIdQuery(userId);
            
            logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                userByIdQuery.GetGenericTypeName(),
                nameof(userByIdQuery.Id),
                userByIdQuery.Id,
                userByIdQuery);

            return await mediator.Send(userByIdQuery);
        }

        [HttpPut("ChangeStatus")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<bool>> ChangeUserStatus([FromBody] ChangeUserStatusCommand changeUserStatusCommand)
        {
            logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                changeUserStatusCommand.GetGenericTypeName(),
                nameof(changeUserStatusCommand.UserId),
                changeUserStatusCommand.UserId,
                changeUserStatusCommand);

            return await mediator.Send(changeUserStatusCommand);
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
