# FizzBuzzApi

This is a .Net Core web application that implements an API that lets the user play the children's counting game 'Fizz Buzz': https://en.wikipedia.org/wiki/Fizz_buzz

Arbitrary replacement rules can be defined, beyond the standard rules that replace numbers divisible by 3 with Fizz and those divisible by 5 with Buzz. There are no default rules.

The FizzBuzzRule APIs are used to manage the game rules.

The FizzBuzzPlay API is used to play a game with the current ruleset.

## Getting started

Run locally using:

```bash
cd <your_path>/FizzBuzzApi
dotnet run
```

## API Reference

### Create Rule

Create a new FizzBuzz rule or update an existing one.

- **URL**

  /FizzBuzzRule/:Id

- **Method:**

  `PUT`

- **Data Params**

  ```json
  {
    "id": [value],
    "replaceWith": "[string]"
  }
  ```

  'Id' must match between the JSON payload and the URL.

- **Success Response:**

  - **Code:** 201 <br />
    **Content:**
    ```json
    {
      "id": [value],
      "replaceWith": "[string]"
    }
    ```

- **Sample Call:**

  ```sh
  curl --location --request PUT 'https://localhost:5001/api/FizzBuzzRule/2' \
  --header 'Content-Type: application/json' \
  --data-raw '{
  "Id": 2,
  "ReplaceWith":"Fizz"
  }'
  ```

### Delete Rule

Delete an existing FizzBuzz rule.

- **URL**

  /FizzBuzzRule/:Id

- **Method:**

  `DELETE`

- **Success Response:**

  - **Code:** 200 <br />
    **Content:**
    ```json
    {
      "id": [value],
      "replaceWith": "[string]"
    }
    ```

### Get Rule

Get an existing FizzBuzz rule.

- **URL**

  /FizzBuzzRule/:Id

- **Method:**

  `GET`

- **Success Response:**

  - **Code:** 200 <br />
    **Content:**
    ```json
    {
      "id": [value],
      "replaceWith": "[string]"
    }
    ```

### Get All Rules

Get all existing FizzBuzz rules.

- **URL**

  /FizzBuzzRule

- **Method:**

  `GET`

- **Success Response:**

  - **Code:** 200 <br />
    **Content:**
    ```json
    [
      {
        "id": [value0],
        "replaceWith": "[string0]"
      },
      {
        "id": [value1],
        "replaceWith": "[string1]"
      }
    ]
    ```

### Play FizzBuzz

Play the FizzBuzz game according to the current set of rules.

- **URL**

  /FizzBuzzPlay

- **Method:**

  `GET`

- **URL Params**

  **Required:**

  `start=[integer]`
  `count=[integer]`

- **Success Response:**

  - **Code:** 200 <br />
    **Content:**
    ```json
    [
      {
        "value": "1"
      },
      {
        "value": "Fizz"
      },
      {
        "value": "Buzz"
      },
      {
        "value": "Fizz"
      },
      {
        "value": "5"
      },
      {
        "value": "FizzBuzz"
      },
      {
        "value": "7"
      },
      {
        "value": "Fizz"
      },
      {
        "value": "Buzz"
      },
      {
        "value": "Fizz"
      }
    ]
    ```
