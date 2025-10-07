# Hume C# Library

[![fern shield](https://img.shields.io/badge/%F0%9F%8C%BF-Built%20with%20Fern-brightgreen)](https://buildwithfern.com?utm_source=github&utm_medium=github&utm_campaign=readme&utm_source=https%3A%2F%2Fgithub.com%2FHumeAI%2Fhume-dotnet-sdk)
[![nuget shield](https://img.shields.io/nuget/v/Hume)](https://nuget.org/packages/Hume)

The Hume C# library provides convenient access to the Hume APIs from C#.

## Requirements

This SDK requires:

## Installation

```sh
dotnet add package Hume
```

## Reference

A full reference for this library is available [here](https://github.com/HumeAI/hume-dotnet-sdk/blob/HEAD/./reference.md).

## Usage

Instantiate and use the client with the following:

```csharp
using Hume.Tts;
using Hume;

var client = new HumeClient("API_KEY");
await client.Tts.Voices.CreateAsync(
    new PostedVoice { GenerationId = "795c949a-1510-4a80-9646-7d0863b023ab", Name = "David Hume" }
);
```

## Exception Handling

When the API returns a non-success status code (4xx or 5xx response), a subclass of the following error
will be thrown.

```csharp
using Hume;

try {
    var response = await client.Tts.Voices.CreateAsync(...);
} catch (HumeClientApiException e) {
    System.Console.WriteLine(e.Body);
    System.Console.WriteLine(e.StatusCode);
}
```

## Pagination

List endpoints are paginated. The SDK provides an async enumerable so that you can simply loop over the items:

```csharp
using Hume.Tts;
using Hume;

var client = new HumeClient("API_KEY");
var items = await client.Tts.Voices.ListAsync(
    new VoicesListRequest { Provider = Hume.Tts.VoiceProvider.CustomVoice }
);

await foreach (var item in items)
{
    // do something with item
}
```

## Advanced

### Retries

The SDK is instrumented with automatic retries with exponential backoff. A request will be retried as long
as the request is deemed retryable and the number of retry attempts has not grown larger than the configured
retry limit (default: 2).

A request is deemed retryable when any of the following HTTP status codes is returned:

- [408](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/408) (Timeout)
- [429](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/429) (Too Many Requests)
- [5XX](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/500) (Internal Server Errors)

Use the `MaxRetries` request option to configure this behavior.

```csharp
var response = await client.Tts.Voices.CreateAsync(
    ...,
    new RequestOptions {
        MaxRetries: 0 // Override MaxRetries at the request level
    }
);
```

### Timeouts

The SDK defaults to a 30 second timeout. Use the `Timeout` option to configure this behavior.

```csharp
var response = await client.Tts.Voices.CreateAsync(
    ...,
    new RequestOptions {
        Timeout: TimeSpan.FromSeconds(3) // Override timeout to 3s
    }
);
```

## Contributing

While we value open-source contributions to this SDK, this library is generated programmatically.
Additions made directly to this library would have to be moved over to our generation code,
otherwise they would be overwritten upon the next generated release. Feel free to open a PR as
a proof of concept, but know that we will not be able to merge it as-is. We suggest opening
an issue first to discuss with us!

On the other hand, contributions to the README are always very welcome!