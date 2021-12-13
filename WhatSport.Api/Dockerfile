#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WhatSport.Api/WhatSport.Api.csproj", "WhatSport.Api/"]
COPY ["WhatSport.Infrastructure/WhatSport.Infrastructure.csproj", "WhatSport.Infrastructure/"]
COPY ["WhatSport.Domain/WhatSport.Domain.csproj", "WhatSport.Domain/"]
COPY ["WhatSport.Application/WhatSport.Application.csproj", "WhatSport.Application/"]
RUN dotnet restore "WhatSport.Api/WhatSport.Api.csproj"
COPY . .
WORKDIR "/src/WhatSport.Api"
RUN dotnet build "WhatSport.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WhatSport.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WhatSport.Api.dll"]
