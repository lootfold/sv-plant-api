# App URL

Project is deployed at `https://svplant.azurewebsites.net/index.html`

# Features implemented

- Entity framework code first approach with sqlite for managing DB
- Unit of Work & Repository pattern for data access
- Service classes for handling application logic
- Api controllers for managing requests
- custom exceptions and exception filter for handling errors

# Launching project

run the following command from the root directory of the project:

`dotnet run --project SVPlant.csproj`

Api should be available on `https://localhost:5001`

Project is configured to run migrations on launch. It will create a `SVPlant.db` file in the root directory.

# API details

## Plants

**Get all plants**

endpoint to fetch all plants with details

> Get: {baseUrl}/api/plants

Response: Ok

```
[
    {
        "id": 2,
        "name": "Plant2",
        "isGettingWatered": false,
        "lastWatered": "2022-02-15T00:40:13.0295543",
        "wateringLogs": [
            {
                "id": 4,
                "plantId": 2,
                "startTime": "2022-02-14T22:00:11.5724452",
                "stopTime": "2022-02-14T22:00:19.5437142"
            },
        ]
    }
]
```

**Start Watering**

endpoint to start watering a plant

> POST: {baseUrl}/api/plants/{plantId}/start

Response: OK

Response: NotFound

```
{
    "message": "Plant with id {id} not found in the database."
}
```

Response: BadRequest

```
{
    "message": "{plantName} is already getting watered."
}
```

```
{
    "message": "Please wait 30 seconds before watering the plant again."
}
```

**Stop Watering**

endpoint to stop watering a plant

> POST: {baseUrl}/api/plants/{plantId}/stop

Response: OK

Response: NotFound

```
{
    "message": "Plant with id {id} not found in the database."
}
```

Response: BadRequest

```
{
    "message": "{plantName} is not getting watered."
}
```
