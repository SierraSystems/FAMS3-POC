FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build

ARG PROJECT_NAME

WORKDIR /src
COPY . .
RUN dotnet restore "${PROJECT_NAME}/${PROJECT_NAME}.csproj"

WORKDIR "/src/${PROJECT_NAME}"
RUN dotnet build "${PROJECT_NAME}.csproj" -c Release -o /app

FROM build AS publish
ARG PROJECT_NAME
RUN dotnet publish "${PROJECT_NAME}.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
ARG PROJECT_NAME
ENV DLL_NAME="${PROJECT_NAME}.dll"
COPY --from=publish /app .

ENTRYPOINT ["sh","-c","dotnet ${DLL_NAME}"]