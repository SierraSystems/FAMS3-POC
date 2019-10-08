FROM mcr.microsoft.com/dotnet/core/runtime:2.2-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["JobManager.csproj", "JobManager/"]
RUN dotnet restore "JobManager/JobManager.csproj"
COPY . JobManager/
WORKDIR "/src/JobManager"
RUN dotnet build "JobManager.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "JobManager.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "JobManager.dll"]