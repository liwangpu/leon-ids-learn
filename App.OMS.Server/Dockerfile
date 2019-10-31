FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["App.OMS.Server/App.OMS.Server.csproj", "App.OMS.Server/"]
RUN dotnet restore "App.OMS.Server/App.OMS.Server.csproj"
COPY . .
#WORKDIR "/src/App.OMS.Server"
#RUN dotnet build "App.OMS.Server.csproj" -c Release -o /app/build

FROM build AS publish
WORKDIR "/src/App.OMS.Server"
RUN dotnet publish "App.OMS.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "App.OMS.Server.dll"]
