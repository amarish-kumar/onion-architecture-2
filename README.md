# onion-architecture
Onion Architecture Sample Project

This is about software architecture that is structured like the layers of an onion.

Onion Architecture is a set of principles that defines how we design a piece of software. It allow us to design software that is testable, maintainable, and independent of infrastructure.

The benefit of Onion Architecture is that we end up with an software application that is loosely coupled, is testable, is maintainable, it does not depends on infrastructure, is focused on the business rules, has a structure that is easy to follow,  and dependencies points inwards

In the traditional N-Layer architecture, the layers depends heavily on the layers below, the core of the application is the database or other infrastructure, so the application is developed around the database and not around the business domain. In this kind of architecture we end up with tight coupling, which in turn creates an application that is difficult to test, difficult to maintain, and depends heavily on infrastructure. When the database changes the business logic also changes.

Onion Architecture principles.
•	Outer layers depend on inner layers
•	Domain Model sits at the center
•	Inner layers defines contracts; outer layers implement those contracts
•	Infrastructure and UI concerns are pushed to the edge

Core
•	Everything unique to business: Domain model, validation rules, business workflows
•	Defines technical implementations as interfaces, it does not contains technology specific code
•	Does not depend on any external libraries

Core: the core has logic unique to the business problem, it does not contains any infrastructure concerns (it does not depend on any external libraries). Application Service Layer: contains the implementation of the business logic
Domain: Service Contracts: here we find the interfaces to be implemented by the application services and infrastructure Repository Contracts: here we find the interface to be implemented by the data access Model: business objects of the application, or domain entities

Infrastructure
•	Provides implementations for core interfaces
•	Calls web services, access database, performs logging
•	Can reference external libraries to provide implementations
•	Only technology specific code (non-business) belongs at the infrastructure

Outer Layer: Infrastructure: contains the implementation of technology-specific code (code that has no business logic) ex: storage, logging, external libraries, web services, data mapping, etc. Tests: since the core is free from infrastructure, we can easily unit-test the core application services. Also since the components of the application are loosely-coupled we can unit-test infrastructure, API services, and UI. API Services: here is where the core and the infra. meets to expose the application to the world. UI: interacts with the app. by consuming the API services.
