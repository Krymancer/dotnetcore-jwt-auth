#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["dotnetcore-jwt-authentication/dotnetcore-jwt-authentication.csproj", "dotnetcore-jwt-authentication/"]
RUN dotnet restore "dotnetcore-jwt-authentication/dotnetcore-jwt-authentication.csproj"
COPY . .
WORKDIR "/src/dotnetcore-jwt-authentication"
RUN dotnet build "dotnetcore-jwt-authentication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dotnetcore-jwt-authentication.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dotnetcore-jwt-authentication.dll"]