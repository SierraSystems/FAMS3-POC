FROM mcr.microsoft.com/dotnet/core/runtime:2.2-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["SearchApi.Tracker.csproj", "SearchApi.Tracker/"]
RUN dotnet restore "SearchApi.Tracker/SearchApi.Tracker.csproj"
COPY . Search.ApiTracker/
WORKDIR "/src/Search.ApiTracker"
RUN dotnet build "SearchApi.Tracker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SearchApi.Tracker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SearchApi.Tracker.dll"]