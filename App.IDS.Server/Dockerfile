FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["App.IDS.Server/App.IDS.Server.csproj", "App.IDS.Server/"]
RUN dotnet restore "App.IDS.Server/App.IDS.Server.csproj"
COPY . .
#WORKDIR "/src/App.IDS.Server"
#RUN dotnet build "App.IDS.Server.csproj" -c Release -o /app/build

FROM build AS publish
WORKDIR /src/App.IDS.Server
RUN dotnet publish "App.IDS.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "App.IDS.Server.dll"]