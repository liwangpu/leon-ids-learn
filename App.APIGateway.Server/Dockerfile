FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["App.APIGateway.Server/App.APIGateway.Server.csproj", "App.APIGateway.Server/"]
RUN dotnet restore "App.APIGateway.Server/App.APIGateway.Server.csproj"
COPY . .
#WORKDIR "/src/App.APIGateway.Server"
#RUN dotnet build "App.APIGateway.Server.csproj" -c Release -o /app/build

FROM build AS publish
WORKDIR "/src/App.APIGateway.Server"
RUN dotnet publish "App.APIGateway.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "App.APIGateway.Server.dll"]