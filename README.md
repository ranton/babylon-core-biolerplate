# babylon-core-biolerplate

--------------------------
A dotnetcore ddd biolerplate

## Goals

--------------------------
To create a starting point for new dotnet core projects using [CleanArchitecture](https://8thlight.com/blog/uncle-bob/2012/08/13/the-clean-architecture.html) - [Domain Driven Design(DDD)](https://www.amazon.com/Domain-Driven-Design-Tackling-Complexity-Software/dp/0321125215).

### BabylonCore.Domain

--------------------------
This project will include all your:

* Domain entities
* Value Objects
* Validations

### BabylonCore.Application

--------------------------
This project includes all your Use Cases built in CQRS approach.

* DTO(Model) - Data Transfer Objects
* Mapping to Domain Entities

### BabylonCore.Infrastructure

--------------------------

This project will include all IO stuff: ie Mail services

### BabylonCore.Persistence

--------------------------
This project will include all your persistence(database) services, right now its using [CouchBase](https://www.couchbase.com/) as its database.

### BabylonCore.Common

--------------------------
This project will include all Cross-Cutting services that will be used across all projects. ie DateHelper

### Babylon.Api

--------------------------
This is the dotnet core web api includes the ff:
*Logging - [Serilog](https://serilog.net/)
*[Swagger](https://swagger.io/)

#### References / Inspirations

1. [Clean Architecture: Patterns, Practices, and Principles](https://www.pluralsight.com/courses/clean-architecture-patterns-practices-principles) by [Matthew Renze](http://www.matthewrenze.com/)
2. [Refactoring from Anemic Domain Model Towards a Rich One](https://www.pluralsight.com/courses/refactoring-anemic-domain-model) by [Vladimir Khorikov](http://enterprisecraftsmanship.com/)