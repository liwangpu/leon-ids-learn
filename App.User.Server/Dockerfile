FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["App.User.Server/App.User.Server.csproj", "App.User.Server/"]
RUN dotnet restore "App.User.Server/App.User.Server.csproj"
COPY . .
#WORKDIR "/src/App.User.Server"
#RUN dotnet build "App.User.Server.csproj" -c Release -o /app/build

FROM build AS publish
WORKDIR "/src/App.User.Server"
RUN dotnet publish "App.User.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "App.User.Server.dll"]
