# Unirest for Windows 8

Unirest is a set of lightweight HTTP libraries available in multiple languages.

This is a port of the .NET library to Windows 8.

Documentation
-------------------

### Installing
Is easy as pie. Kidding. It's as easy as downloading from [NuGet](https://nuget.org/packages/Unirest-Net/1.0.0-beta).

### Creating Request
So you're probably wondering how using Unirest makes creating requests in .NET easier, here is a basic POST request that will explain everything:

```C#
HttpResponse<MyClass> jsonResponse = Unirest.post("http://httpbin.org/post")
  .header("accept", "application/json")
  .field("parameter", "value")
  .field("foo", "bar")
  .asJson<MyClass>();
```

Requests are made when `as[Type]()` is invoked, possible types include `Json`, `Binary`, `String`. If the request supports this, a body  can be passed along with `.body(String)` or `body<T>(T)` to serialize an arbitary object to JSON. If you already have a dictionary of parameters or do not wish to use seperate field methods for each one there is a `.fields(Dictionary<string, object> parameters)` method that will serialize each key - value to form parameters on your request.

`.headers(Dictionary<string, string> headers)` is also supported in replacement of multiple header methods.

### Asynchronous Requests
Sometimes, well most of the time, you want your application to be asynchronous and not block, Unirest supports this in .NET with the TPL pattern and async/await:

```C#
Task<HttpResponse<MyClass>> myClassTask = Unirest.post("http://httpbin.org/post")
  .header("accept", "application/json")
  .field("param1", "value1")
  .field("param2", "value2")
  .asJsonAsync<MyClass>();
```

### File Uploads
Creating `multipart` requests with .NET is trivial, simply pass along a `Stream` Object as a field:

```C#
HttpResponse<MyClass> myClass = Unirest.post("http://httpbin.org/post")
  .header("accept", "application/json")
  .field("parameter", "value")
  .field("file", new MemoryStream("/tmp/file"))
  .asJson<MyClass>();
```

### Custom Entity Body

```C#
HttpResponse<MyClass> myClass = Unirest.post("http://httpbin.org/post")
  .header("accept", "application/json")
  .body("{\"parameter\":\"value\", \"foo\":\"bar\"}")
  .asJson<MyClass>();
```

### Request Reference

The .NET Unirest library follows the builder style conventions. You start building your request by creating a `HttpRequest` object using one of the following:

```C#
HttpRequest request = Unirest.get(String url);
HttpRequest request = Unirest.post(String url);
HttpRequest request = Unirest.put(String url);
HttpRequest request = Unirest.patch(String url);
HttpRequest request = Unirest.delete(String url);
```

### Response Reference

Upon recieving a response Unirest returns the result in the form of an Object, this object should always have the same keys for each language regarding to the response details.

- `.Code` - HTTP Response Status Code (Example 200)
- `.Headers` - HTTP Response Headers
- `.Body` - Parsed response body where applicable, for example JSON responses are parsed to Objects / Associative Arrays.
- `.Raw` - Un-parsed response body

