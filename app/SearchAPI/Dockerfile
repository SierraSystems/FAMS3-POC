FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["SearchAPI.csproj", "SearchAPI/"]
RUN dotnet restore "SearchAPI/SearchAPI.csproj"
COPY . SearchAPI/
WORKDIR "/src/SearchAPI"
RUN dotnet build "SearchAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SearchAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SearchAPI.dll"]