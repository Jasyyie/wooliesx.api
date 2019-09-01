# wooliesx.api

WooliesX Technical challenge

# ![.net core 2.0](http://csharpcorner.mindcrackerinc.netdna-cdn.com/UploadFile/MinorCatImages/062632AM.png.ashx?width=64&height=64) Wooliesx API

NET Core 2.2 Web API services the request returning back the response from Wooliesx resource api's.

### Getting started

- The Web API is hosted on [Azure](https://wooliex-jasmine.azurewebsites.net/swagger/index.html) and is publicily available
- Clone the project on [Github](https://github.com/Jasyyie/wooliesx.api) via Http/SSH and pull the repository locally to view the source code

### Building

You are required to have alteast the following to be able to run the code

- .NET Core 2.0 installed on the system
- Visual Studio 2017 with the LATEST update (at least version 15.5.3)

### Structure

The project is structure to enable extensibility and ease of development. The structure is as follows:

#### wooliesx.api

- Accepts the request and calls the particular service for processing the request.
- UserController injected with dependency IExercise1Service invokes Exercise1Service.
- SortController injected with dependency IExercise2Service invokes Exercise2Service.

#### wooliesx.service

- Process the request based on service.
- UserResponse returned by Exercise1Service uses GetUser method to process GET request.
- SortedProduct returned by Exercise2Service uses SortProducts method to process GET request.
- Response is returned as json string that is deserailaized as object.
- Uses HTTPClient to send request to Wooliesx resource Api.

#### wooliesx.model

- Data structure for response returned by services.
- Product object prodcut data structure.
- UserReponse has user data structure: name and token.
- Customer has customer data structure: customer Id and product list.

#### wooliesx.test

- NSubstitute tests the serice and controller layer.
- Substitute.ForPartsOf service class to create instance of service class.
- Substitute.For serviceInterface to returned mocked interface.
- Testing HTTPCLient by mocking HttpMessageHandler.
