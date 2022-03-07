FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DemoNetAndSqlDocker.csproj", "./"]
RUN dotnet restore "DemoNetAndSqlDocker.csproj"
COPY . .

RUN dotnet build "DemoNetAndSqlDocker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DemoNetAndSqlDocker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DemoNetAndSqlDocker.dll"]
