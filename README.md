# Introduction 

Mines API for the CloudTrader project.

# Getting Started

## Running locally with Visual Studio

Open the project from the solution file, run, and access the API at `https://localhost:1190`.

### Swagger UI

Once running, access Swagger UI at https://localhost:1190/swagger.

## Running with docker

Build the image

```bash
docker build . -t cloudtrader-mines:latest
```

Start the container

```bash
docker run -p 1190:80 cloudtrader-mines:latest`
```

Access the API at `http://localhost:1190`.

### Swagger UI

Once running, access Swagger UI at http://localhost:1190/swagger.


# Running Tests

Run `dotnet test`.
