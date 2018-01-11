
# RESTFUL API WITH SWAGGER (2018)

A RESTFUL application that exposes web api endpoints, by leveraging Swagger, ElasticSearch and ASP.NET Core.
This app allow to search data indexed in ElasticSearch.

Postman client to test available web api endpoints :

![alt capture1](https://github.com/danmgs/WebApplicationDotNetCore/blob/master/img/screenshot1.PNG)

<br />

## Available api endpoints


| Web Method   | API Endpoint URL              | Description                                                      | Example
| :----------: | ----------------------------- | ---------------------------------------------------------------- | -----------------------------
| GET          | /api/product/                 | get all products                                                 | /api/product/
| GET          | /api/product/search/value     | search a product by the value search term (based on name field)  | /api/product/search/wine
| GET          | /api/product/id               | get a product by id                                              | /api/product/1


## Folders Organisation

### Overview

Schema below will show the main elements :

```
| -- /Api.Demo.Core                       -> contains ElasticSearch client wrappers
     | -- /Interfaces
          | -- IManagerClient.cs
          | -- ISearchClient.cs
     | -- AbsractBaseElastic.cs
     | -- ElasticManagerClient.cs
     | -- ElasticSearchClient.cs 

| -- /Api.Demo.Models                     -> contains all models shared accross projects
     | -- Person.cs

| -- /Api.Demo.Tests
     | -- /Controllers
          | -- ProductControllerTest.cs
     | -- /Elastic
          | -- ElasticMonitorClientTest.cs
          | -- ElasticSearchClientTest.cs

| -- /WebApplicationDotNetCore
     | -- /Controllers 
          | -- ProductController.cs
     | -- /Models                         
          | -- /Config                    -> contains all models for web app settings
		        | -- ElasticSearchSettings.cs
     | -- /Views 
     | -- appsettings.json
     | -- bower.json
     | -- bundleconfig.json
     | -- Program.cs
     | -- Startup.cs              

```

## Prerequisites and setup

### Seed ElastictSearch cluster with data.

1. Start elasticsearch cluster first.

2. In order to create the **product** index, the data file is available in **SolutionItems\datasamples** directory. 

Command to bulk insert products from file **products-bulk.json** under kibana dev tool :
```
POST /product/default/_bulk
[put here file content]
```

## How to generate the swagger proxy client :

There are many ways to generate the proxy client from the deployed api url.\
Note in my case, API is deployed under http://localhost:53626/

### 1. Use of Swagger editor website

1.1 Swagger configuration is setup in class **WebApplicationDotNetCore\Startup.cs**

1.2 Launch WebApplicationDotNetCore and access api endpoint: http://localhost:53626/swagger/v1/swagger.json via postman, in order to retrieve return API meta-data in json.

1.3 Go to http://editor.swagger.io/  and copy this json content.

1.4 Click Generate Client

### 2. Use of command line with **swagger-codegen-cli-x.y.z.jar**:

Download swagger-codegen-cli here : https://swagger.io/docs/swagger-tools/

```
java -jar swagger-codegen-cli-2.2.1.jar generate -i http://localhost:53626/swagger/v1/swagger.json -l csharp
```

### 3. Use of autorest

https://dzimchuk.net/generating-clients-for-your-apis-with-autorest/

```
C:\Apps\Tools\Autorest>autorest --input-file=swagger.yaml --csharp --output-folder=CSharp_MyClient --namespace=MyClientNamesp
```

The generated codes sources has been put into directory **\Demo.Swagger.Generated.Client**
<br />

## Useful Links

### Swagger

Use of proxy client (configuration url ..etc)\
http://visualbean.io/blog/how-to-use-the-autogenerated-swagger-client/

https://github.com/Azure/autorest/blob/master/docs/generating-a-client.md

https://scotch.io/tutorials/speed-up-your-restful-api-development-in-node-js-with-swagger

https://docs.microsoft.com/en-us/aspnet/core/migration/webapi

https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?tabs=visual-studio-mac%2Cvisual-studio

https://stackoverflow.com/questions/227624/asp-net-mvc-controller-actions-that-return-json-or-partial-html

https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?tabs=visual-studio

https://github.com/domaindrivendev/Swashbuckle.AspNetCore

https://github.com/swagger-api/swagger-codegen


### Intro ASP.NET Core
http://rdonfack.developpez.com/tutoriels/dotnet/nouveautes-aspnet-core-2/

### Dependency Injection
https://hassantariqblog.wordpress.com/2017/02/20/asp-net-core-step-by-step-guide-to-access-appsettings-json-in-web-project-and-class-library/

https://cmatskas.com/net-core-dependency-injection-with-constructor-parameters-2/

### ASP.NET Core Routing
https://docs.microsoft.com/en-us/aspnet/core/fundamentals/routing

https://stormpath.com/blog/routing-in-asp-net-core

### ElasticSearch Nest C#
https://github.com/youthpassion0732/ElasticSearchConsoleApp

https://hassantariqblog.wordpress.com/2016/09/21/elastic-search-getting-document-using-nest-in-net/

https://www.devbridge.com/articles/getting-started-with-elastic-using-net-nest-library-part-two/#

### Hosting in .NET Core (Program.cs)
https://docs.microsoft.com/fr-fr/aspnet/core/fundamentals/hosting?tabs=aspnetcore2x

### Bower
https://msdn.microsoft.com/fr-fr/magazine/mt573714.aspx

### AOP logging
https://dotnetthoughts.net/aop-with-aspnet-core/


## TODO

- [ ] id "00000000-0000-0000-0000-000000000000" (GUID), id not retrieving.

- [ ] startup config retrive config (es index + es url) to create clients

- [ ] review routing

- [ ] voir comment specifier loption fuzzyness pour la recherche (approximate search)
http://localhost:53626/api/product/search/big => should return some results with "bag".

