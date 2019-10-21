FROM mcr.microsoft.com/dotnet/core/aspnet:3.0.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build

ARG PROJECT_NAME

RUN dotnet tool install -g dotnet-ef
ENV PATH="/root/.dotnet/tools:${PATH}"

WORKDIR /src

ADD https://github.com/ufoscout/docker-compose-wait/releases/download/2.6.0/wait /wait
RUN chmod +x /wait

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