# Sterling Database (Port to .NET Core 2.0)

This is a port of the [Sterling Open Source NoSQL Database](https://github.com/jeremylikness/sterlingnosql).

Read the related blog post: [.NET Core 20 is Ready and Sterling Proves It!](https://blog.jeremylikness.com/https-blog-jeremylikness-com-net-core-2-0-is-ready-and-sterling-proves-it-41350afd18a9)

> NOTE: Sterling is not currently intended for production use. It was ported to demonstrate [what's new in .NET Core 2.0](https://docs.microsoft.com/dotnet/core/whats-new/) and the increased surface area of the [.NET Standard 2.0 APIs](https://github.com/dotnet/standard/blob/master/docs/versions/netstandard2.0.md). 

The engine uses the following features that did not exist in .NET Core 1.0:

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
