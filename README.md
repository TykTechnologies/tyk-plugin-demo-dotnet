.NET gRPC backend
==

This repository provides a sample [gRPC](http://www.grpc.io/) backend, written in .NET, intended to work as part of [Tyk](https://tyk.io/). This is written in C# and has been tested using [.NET Core](https://dotnet.github.io/).

The project implements a simple request dispatcher, based on [Tyk custom middleware hooks](https://tyk.io/docs/tyk-api-gateway-v1-9/javascript-plugins/middleware-scripting/).
A class takes care of this process, and also implements these hooks methods.

A [sample authentication layer](Auth.cs), based on Microsoft SQL Server is provided. This could be a useful reference for similar .NET integrations.

The featured hooks are as follows:

### MyPreMiddleware

This hook is very simple. It injects a header before the authentication step is performed. You may test this hook without any database setup.

### MyAuthCheck

This hook will extract the authorization header and pass it to the authentication layer. The authentication layer initializes a basic SQL Server client, and performs a SQL query to check if the token is valid.
A test database dump is included in this repository, in case you want to replicate this scenario, without modifying the authentication layer code.

### MyPostMiddleware

This hook will be called after the authentication check.

## Setup

## Building a bundle

When using gRPC for plugin bundles, the manifest file (`manifest.json`) is limited to the custom middleware definition. The gRPC server files are independent from this, just like the gRPC server itself.

Check the [sample manifest file](manifest.json) for reference.

To build a bundle use:

```
tyk-cli bundle build
```

## Additional documentation
- [An overview of gRPC support in Tyk](https://github.com/TykTechnologies/tyk/blob/develop/coprocess/grpc/README.md)
- [Introduction to gRPC and C#](http://www.grpc.io/docs/tutorials/basic/csharp.html)