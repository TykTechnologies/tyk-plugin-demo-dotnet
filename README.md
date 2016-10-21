.NET gRPC backend
==

This project provides a sample gRPC backend, written in .NET, intended to work as part of Tyk. This is written in C# and has been tested using .NET Core, under Apple OS X.

The project implements a simple request dispatcher, based on Tyk hooks.
A class takes care of this process, and also implements these hooks methods.

A sample authentication layer, based on Microsoft SQL Server is provided. This could be a useful reference for similar .NET integrations.

The featured hooks are as follows:

### MyPreMiddleware

This hook is very simple. It injects a header before the authentication step is performed. You may test this hook without any database setup.

### MyAuthCheck

This hook will extract the authorization header and pass it to the authentication layer. The authentication layer initializes a basic SQL Server client, and performs a SQL query to check if the token is valid.
A test database dump is included in this repository, in case you want to replicate this scenario, without modifying the authentication layer code.

### MyPostMiddleware

This hook will be called after the authentication check.
