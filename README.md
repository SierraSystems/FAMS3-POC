# FAMS3 Integration

## Note

- Projects are to be based on .NET Core 2.2
- Message Broker has not been chosen, likely RabbitMQ
- All projects should have a corresponding test project

## Project Structure

    .
    ├── app                     # Application Source Files
    ├── .gitignore              # Git ignore
    ├── docker-compose.yml      # Docker Compose definition
    └── README.md               # This file

## Run

```bash
docker-compose up
```
Check the health status of the api [here](http://localhost:8081/health)

Download OpenAPi specification [here](http://localhost:8081/swagger/v1/swagger.json)

Access RabbitMq console [here](http://localhost:15672), use default rabbitmq username and password.

Access Redis-Commander [here](http://localhost:8090) to access Redis data.

## Projects

### SearchAPI

_This is the API that will be called by the Scheduler Plugin to search for person sought_

### SearchAPI.Test

_This is the test project for the Search API project_

### JobManager

_This is the  Scheduler Plugin_

### JobManager.Test

_This is the test project for the  Scheduler Plugin_