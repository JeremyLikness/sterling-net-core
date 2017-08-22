# Sterling Database (Port to .NET Core 2.0)

This is a port of the [Sterling Open Source NoSQL Database](https://github.com/jeremylikness/sterlingnosql).

> NOTE: This is not intended for production use.

The port was made to demonstrate the increased surface area of the .NET Core 2.0 APIs using .NET Standard 2.0.

The engine uses the following features that did not exist in 1.1:

* `BackgroundWorker` to save lists on a separate thread
* `Type` methods including:
  * `IsAssignableFrom`
  * `IsEnum`
* Reflection, including properties and fields
* Binary reader and writer
* Memory stream
