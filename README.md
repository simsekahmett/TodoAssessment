# TodoAssessment

## Acknowledgements

 - [Angular v12.0.2 as Frontend Project](https://angular.io/)
 - [.Net Core 7.0 as Backend Project](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
 - [Entity Framework Core - InMemory Database](https://learn.microsoft.com/en-us/ef/core/providers/in-memory/?tabs=dotnet-core-cli)
 - [Swashbuckle Swagger Documentation for API](https://learn.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-7.0&tabs=visual-studio)

## API Reference

> **Note**
> Sample postman requests can be found here >>
[Postman sample collection](https://api.postman.com/collections/6313898-0abaaffe-895b-4ed9-b2bd-bec05227058b?access_key=PMAT-01GJATGQV391NRQ5ZMENTVCCKY)

#### Get all todo entries

| Request Type | Request Endpoint     | Description                |
| :-------- | :------- | :------------------------- |
| `GET` | `/todo/all` | Returns list of all todo entries as json |

#### Get all todo entries by status

| Request Type | Request Endpoint     | Description                |
| :-------- | :------- | :------------------------- |
| `GET` | `/todo/status` | Returns list of all todo entries as json |

Request details:

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `status`      | `int` | **Required**. Corresponding int value of status that will be used as filter |

Todo entry status enum values;

| Value | Description                       |
| :------- | :-------------------------------- |
| `0` | Pending |
| `1` | Overdue |
| `2` | Done |

#### Add new todo entry

| Request Type | Request Endpoint     | Description                |
| :-------- | :------- | :------------------------- |
| `POST` | `/todo/add` | Add new todo entry to database |

Request details:

| Body | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Json`      | `TodoEntry` | **Required**. Todo entry object as json string |

```json
  {
    "id": "{{$guid}}",
    "title": "Todo entry title",
    "createDate": "1992-11-21T15:24:29.0615225+03:00",
    "dueDate": "2023-04-19T15:24:29.0639718+03:00",
    "status": 0
  }
```

#### Update existing todo entry

| Request Type | Request Endpoint     | Description                |
| :-------- | :------- | :------------------------- |
| `PATCH` | `/todo/update` | Update existing todo entry with the TodoEntry object passed as body |

Request details:

| Body | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Json`      | `TodoEntry` | **Required**. Todo entry object as json string with updated details (dueDate, status)|

##### Updated details will be applied to matching entry by id

```json
  {
    "id": "{{$guid}}",
    "title": "Todo entry title",
    "createDate": "1992-11-21T15:24:29.0615225+03:00",
    "dueDate": "2023-04-19T15:24:29.0639718+03:00",
    "status": 0
  }
```

## Screenshots

- Home page containing Swaggerhub documentation as iframe

![Home page](TodoAssessment/ClientApp/screenshots/home.png?raw=true)

- Create todo entry page

![Create entry page](TodoAssessment/ClientApp/screenshots/create.png?raw=true)

- Update todo entry page

![Update entry page](TodoAssessment/ClientApp/screenshots/update.png?raw=true)

- List todo entries page with filter options (List > All, Pending, Overdue, Done items)

![List entries page](TodoAssessment/ClientApp/screenshots/list.png?raw=true)


