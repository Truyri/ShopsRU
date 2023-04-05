## ShopRU Project Explanation

.Net 6 is used for project.

## Architecture

![alt text](https://i.stack.imgur.com/YzmEa.png)

-Onion architecture can solve problem of separation of concern and tightly coupled components from N-layered architecture.\
-All layers are depended on inner layer.\
-The core of the application is the domain layer.\
-Provide more testability than N-layered architecture.

## Layers

#### <font color="green"> Domain Layer </font>
This layer does not depend on any other layer. This layer contains entities, enums, specifications etc.

#### <font color="green"> Application Layer </font>
This layer contains business logic, services, service interfaces, request and response models.
Third party service interfaces are also defined in this layer.
This layer depends on domain layer.

#### <font color="green"> Infrastructure Layer </font>
This layer contains database related logic (Repositories and DbContext), and third party library implementation (like a logger and email service).
This implementation is based on domain and infrastructure layer.

#### <font color="green"> Presentation Layer </font>
This layer contains Webapi or UI.

## Database

#### InMemoryDatabase

This database provider allows Entity Framework Core to be used with an in-memory database./
But it is not persistent after closing the application. All data gonna be deleted /
For initiate entities, seeds are used for this project.

```sh
dotnet add package Microsoft.EntityFrameworkCore.InMemory
```

## Logic

#### Factory Pattern

![alt text](https://refactoring.guru/images/patterns/content/factory-method/factory-method-en-2x.png?id=b3961995a4449fb90820a693013511df)

`Factory pattern` is a creational pattern as this pattern provides one of the best ways to create an object.
In Factory pattern, we create object without exposing the creation logic to the client and refer to newly created object using a common interface.

A factory method or class is responsible for creating objects of a certain type based on specific conditions. The factory method or class encapsulates the details of object creation, allowing the client code to simply specify the desired type of object and its properties without having to know how the object is created.

The advantages of using the Factory Pattern include making code more modular, extensible, and easier to maintain. It also allows for the creation of objects without the need for direct instantiation, which can make code more flexible and adaptable to changes in requirements.


## Run Project

### From Shell Script

```sh
cd src/WebApi/ShopsRU.WebApi
sh projectRun.sh
```

## Test

`xUnit` is a popular open-source unit testing framework for .NET languages such as C# and F#. It provides a simple and consistent way to write and run automated tests, allowing developers to quickly and easily verify the correctness of their code. xUnit includes features such as support for test fixtures, parameterized tests, and test categorization, making it a versatile tool for testing different types of code.

`Moq`  It allows developers to create mock objects that simulate the behavior of real objects, enabling them to test their code in isolation from external dependencies. Moq provides a simple and intuitive API for creating mock objects, allowing developers to set up expectations and verify behavior with ease.

<font color="green">You can find CoverageReport in this path: </font>

`src/Test/ShopRU.UnitTest/TestResults/15b94ad9-13f4-4483-bf50-59c13f46864c/coveragereport/index.html`

#### Test Dependencies

```sh
npm install -g xunit-viewer@7.2.0
```

```sh
dotnet tool install --global coverlet.console
```

```sh
dotnet tool install --global dotnet-reportgenerator-globaltool --version 5.1.13
```

---

## Run

### From Shell Script

```sh
cd ShopsRU/src/Test/ShopRU.UnitTest/
sh ./test.sh -d ShopRU
```

### Manually

#### Run Tests

```sh
dotnet test \
        --logger:"junit;LogFilePath=./TestResults/test_result.xml" \
        --logger "console;verbosity=detailed" \
        --collect:"XPlat code coverage" \

```
After that, you can see the `TestResults` directory in the `ShopRU.UnitTest` directory.

#### Generate Run Report

```sh
xunit-viewer  \
        --results=./TestResults/test_result.xml \
        --output=./TestResults/test_results.html \
        --title=" ShopRU Case Study" \
        
```

#### Generate Code Coverage Report

```sh
reportgenerator \
        -reports:coverage.cobertura.xml \
        -targetdir:coveragereport
```