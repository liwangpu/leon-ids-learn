FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["App.Order.Server/App.Order.Server.csproj", "App.Order.Server/"]
RUN dotnet restore "App.Order.Server/App.Order.Server.csproj"
COPY . .
#WORKDIR "/src/App.Order.Server"
#RUN dotnet build "App.Order.Server.csproj" -c Release -o /app/build

FROM build AS publish
WORKDIR "/src/App.Order.Server"
RUN dotnet publish "App.Order.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "App.Order.Server.dll"]
