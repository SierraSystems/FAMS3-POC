# FAMS3 Integration

The `SearchApi` takes a piece of information from a person and will execute a `search` against data providers.

## Note

- Projects are to be based on .NET Core 2.2
- Message Broker is rabbitMq
- All projects should have a corresponding test project

## Architecture Goal

![image](docs/searchapi.flow.png)

## Project Structure

    .
    ├── app                     # Application Source Files.
    ├── docs                    # Contains application documentations.
    ├── .gitignore              # Git ignore.
    ├── docker-compose.yml      # Docker Compose definition.
    └── README.md               # This file.

## Run

```bash
docker-compose up
```

Check the health status of the api [here](http://localhost:8081/health)

Download OpenAPi specification [here](http://localhost:8081/swagger/v1/swagger.json)

Access RabbitMq console [here](http://localhost:15672), use default rabbitmq username and password.

Access Redis-Commander [here](http://localhost:8090) to access Redis data.

You can interact with the search api using the following [Postman Collection](docs/BcGovSearchApi.postman_collection.json) and [Postman Environment](docs/BcGovApi.postman_environment.json)

When a POST request is send to the people api, a message is send the the `InvestigatePerson` exchange

## Projects

### SearchAPI

_This is the API that will be called by the Scheduler Plugin to search for person sought_

### SearchAPI.Test

_This is the test project for the Search API project_

### JobManager

_This is the  Scheduler Plugin_

### JobManager.Test

_This is the test project for the  Scheduler Plugin_

## Libs

### SearchApi.Core

This class lib project encapsulate reusable components accross search api applications.