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

## Quickstart (works on any platform)

You must have [.NET Core 2.0](https://github.com/dotnet/core/blob/master/release-notes/download-archive.md) installed.

Clone the repository:

`https://github.com/JeremyLikness/sterling-net-core.git`

Navigate to the test directory:

`cd sterling-net-core/sterling-console-test`

Build the project:

`dotnet build -c Release`

> There is not a NuGet package for the Sterling .NET Core database as of this writing. Instead, the test project has a relative path reference to the `sterling-core` source.

Navigate to the build directory:

`cd bin/Release/netcoreapp2.0/`

Run the test:

`dotnet sterling-console-test.dll`

You're in business!