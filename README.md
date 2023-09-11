# UseCase1
Test task for Generative AI survey. UseCase #1.

## Description
This application serves as a robust and intuitive tool to query information on different countries efficiently. Utilizing ASP.NET Core WebAPI, it fetches comprehensive data from an external source, offers multiple filters like population and country name, and enables sorting and limiting the number of records to cater to various user needs. The application makes sure to handle different types of errors and provides clear messages to aid troubleshooting, ensuring a seamless user experience.

The architecture of this application revolves around a well-structured and modular approach, promoting maintainability and scalability. At its core, it leverages interfaces and dependency injection to allow smooth integration and unit testing. The CountryProcessingService class plays a pivotal role in filtering, sorting, and limiting the records based on user inputs, facilitating more targeted and refined search results.

(I know this description is too epic for this test project, but I kinda like how ChatGPT decided to go full flattering mode here XD)

## Installation

1. Clone the repository.
```sh
git clone https://github.com/KravtsovDV/UseCase1.git
```

2. Navigate to the root folder in the console and execute the following commands to build and run the application:
```sh
dotnet build
dotnet run --project UseCase1/UseCase1.csproj
```

## Endpoints Usage
The primary endpoint for this application is the `GET /api/countries` endpoint which provides a variety of query parameters to filter and sort the country data retrieved from the external API. Below are examples of how to utilize this endpoint with various parameter combinations:

1. To get all countries data:
   ```
   http://localhost:5001/api/countries
   ```

2. To filter countries by name (e.g., "India"):
   ```
   http://localhost:5001/api/countries?countryNameFilter=India
   ```
   **NOTE** that the value of 'countryNameFilter' allows whitespaces and is case-insensitive. E.g., 'UnItEd KiN' will return "United Kingdom".

3. To filter countries by population less than 10 million:
   ```
   http://localhost:5001/api/countries?countryPopulationFilter=10
   ```
   **NOTE** that value of 'countryPopulationFilter' is in millions. I.e., countryPopulationFilter=10 means countries with population less then 10 million. This parameter is an integer.

4. To sort countries by name in descending order:
   ```
   http://localhost:5001/api/countries?sortOrder=descend
   ```

5. To limit the number of records retrieved to 5:
   ```
   http://localhost:5001/api/countries?recordLimit=5
   ```

6. To filter countries by name (e.g., "Canada") and sort in ascending order:
   ```
   http://localhost:5001/api/countries?countryNameFilter=Canada&sortOrder=ascend
   ```

7. To filter countries by population less than 50 million and limit the records to 10:
   ```
   http://localhost:5001/api/countries?countryPopulationFilter=50&recordLimit=10
   ```

8. To filter countries by name (e.g., "United st") and population less than 100 million:
   ```
   http://localhost:5001/api/countries?countryNameFilter=United%20st&countryPopulationFilter=100
   ```

9. To get countries with a population less than 20 million, sorted in descending order and limited to 5 records:
   ```
   http://localhost:5001/api/countries?countryPopulationFilter=20&sortOrder=descend&recordLimit=5
   ```

10. To get countries that has "est" in their name, with a population less than 30 million, sorted in ascending order, and limited to 3 records:
    ```
    http://localhost:5001/api/countries?countryNameFilter=est&countryPopulationFilter=30&sortOrder=ascend&recordLimit=3
    ```

Remember, the port number (5001 here) might vary based on your setup. Please check the console output after running the `dotnet run` command from the [Installation](#Installation) section for the correct port number.
