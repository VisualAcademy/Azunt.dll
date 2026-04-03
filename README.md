# Azunt.dll

Azunt.dll is a general-purpose .NET utility library for reusable application building blocks such as validation, date/time helpers, media type resolution, identifier utilities, repository abstractions, and service contracts.

It is designed to help reduce duplicate code across ASP.NET Core, Blazor, MVC, Razor Pages, Web API, and other .NET applications.

## Target Framework

- .NET Standard 2.0

This makes Azunt broadly compatible with many modern .NET applications.

## Package Highlights

Azunt provides reusable helpers and abstractions in areas such as:

- Validation helpers
- Date and time formatting helpers
- MIME/content-type resolution
- Identifier and number utilities
- Repository abstractions
- Service interfaces for email, SMS, and storage
- Common enums and shared models

## Installation

Install via NuGet:

```bash
dotnet add package Azunt
```

Or via Package Manager Console:

```powershell
Install-Package Azunt
```

## Recommended Usage

Azunt is best used as a shared utility library across multiple applications and modules.

Typical usage scenarios:

- ASP.NET Core MVC applications
- Razor Pages applications
- Blazor Server applications
- Web API projects
- Shared library projects

## Namespace Overview

Common namespaces include:

- `Azunt.Utilities.DateTimes`
- `Azunt.Utilities.Validation`
- `Azunt.Utilities.Media`
- `Azunt.Utilities.Identifiers`
- `Azunt.Repositories`
- `Azunt.Services`
- `Azunt.Services.Interfaces`
- `Azunt.Models.Enums`

---

## Quick Start

### Date and Time Helpers

```csharp
using Azunt.Utilities.DateTimes;

var nowText = DateTimeUtility.ShowTimeOrDate(DateTime.Now);
var dateText = DateTimeUtility.ShowDate(DateTime.Now);
var agoText = DateTimeUtility.TimeAgo(DateTime.Now.AddMinutes(-10), useKorean: true);
```

### Validation Helpers

```csharp
using Azunt.Utilities.Validation;

bool validUserName = UsernameValidator.IsValid("visualacademy");
bool validEmail = EmailValidator.IsValid("user@example.com");
bool validPassword = PasswordValidator.IsValid("P@ssw0rd!");
```

### File Media Type Resolver

```csharp
using Azunt.Utilities.Media;

var pdfType = FileMediaTypeResolver.GetMediaType("report.pdf");
var pngType = FileMediaTypeResolver.GetMediaType(".png");

if (FileMediaTypeResolver.TryGetMediaType(".xlsx", out var mediaType))
{
    // Use mediaType here
}
```

### License Number Utility

`LicenseNumberUtility` helps increment the trailing numeric portion of a license or identifier string.

Examples:

- `1234` -> `1235`
- `LN-1234` -> `LN-1235`
- `2026-LN-1234` -> `2026-LN-1235`

If the input is null, empty, whitespace, or does not end with digits, it returns `string.Empty`.

```csharp
using Azunt.Utilities.Identifiers;

var next1 = LicenseNumberUtility.GetNext("1234");           // 1235
var next2 = LicenseNumberUtility.GetNext("LN-1234");        // LN-1235
var next3 = LicenseNumberUtility.GetNext("2026-LN-1234");   // 2026-LN-1235
var next4 = LicenseNumberUtility.GetNext("LN-0099");        // LN-0100
var next5 = LicenseNumberUtility.GetNext("ABC");            // ""
```

This utility is useful when:

- generating the next visible license number
- preserving a prefix while incrementing the last number
- scanning previous employee/license records to determine the next available number

---

## Repository Abstractions

### `IRepositoryBase<T, TId>`

`IRepositoryBase<T, TId>` is a generic repository abstraction for basic CRUD operations across the Azunt ecosystem.

```csharp
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azunt.Repositories
{
    public interface IRepositoryBase<T, TId> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(TId id);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(TId id);
    }
}
```

Use this interface when you want to standardize data access patterns across modules.

---

## Service Interfaces

Azunt includes reusable service contracts for common integration points.

### `IEmailSender`

```csharp
Task SendEmailAsync(string email, string subject, string message, bool isBodyHtml = true);
```

Namespace:

```csharp
Azunt.Services
```

### `ITwilioSender`

```csharp
Task SendSmsAsync(string phoneNumber, string message);
```

Namespace:

```csharp
Azunt.Services
```

### `ISmsSender`

```csharp
Task SendSmsAsync(string number, string message);
```

Namespace:

```csharp
Azunt.Services
```

### `IStorageServiceBase`

Used to abstract file and directory management logic.

Examples of supported responsibilities:

- create/delete directories
- upload/download files
- retrieve metadata
- generate folder paths

---

## Verification

### `ManageMessageId`

`ManageMessageId` is an enum used to represent account-management result states in a strongly typed manner.

Examples include:

- `AddPhoneSuccess`
- `AddLoginSuccess`
- `ChangePasswordSuccess`
- `SetTwoFactorSuccess`
- `SetPasswordSuccess`
- `RemoveLoginSuccess`
- `RemovePhoneSuccess`
- `Error`

Namespace:

```csharp
Azunt.Models.Enums
```

---

## Validators

### `UsernameValidator`

Validates whether a username contains disallowed characters.

```csharp
bool isValid = UsernameValidator.IsValid("myusername");
```

Disallowed characters include:

- `\`
- `/`
- `:`
- `?`
- `*`
- `"`
- `<`
- `>`
- `|`
- space
- `'`
- `%`
- `&`
- `+`

### `EmailValidator`

Performs simple regex-based email validation.

```csharp
bool isValid = EmailValidator.IsValid("user@example.com");
```

### `PasswordValidator`

Checks whether a password satisfies common security rules:

- at least 8 characters
- at least one uppercase letter
- at least one lowercase letter
- at least one number
- at least one special character

```csharp
bool isValid = PasswordValidator.IsValid("P@ssw0rd!");
```

---

## File to MIME Type Mapping Guide

`Azunt.Utilities.Media.FileMediaTypeResolver` returns the appropriate MIME type from a file name or extension.

### Basic Example

```csharp
using Azunt.Utilities.Media;

var mediaType1 = FileMediaTypeResolver.GetMediaType("report.pdf");
var mediaType2 = FileMediaTypeResolver.GetMediaType(".png");
var fallback = FileMediaTypeResolver.GetMediaType("archive.unknown", "application/octet-stream");
```

### ASP.NET Core Controller Example

```csharp
using Azunt.Utilities.Media;

public async Task<IActionResult> Download(string filePath, string fileName)
{
    var mediaType = FileMediaTypeResolver.GetMediaType(fileName);
    var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
    return File(bytes, mediaType, fileName);
}
```

### Streaming Example

```csharp
using Azunt.Utilities.Media;

public IActionResult DownloadStream(string filePath, string fileName)
{
    var mediaType = FileMediaTypeResolver.GetMediaType(fileName);
    var stream = System.IO.File.OpenRead(filePath);
    return File(stream, mediaType, fileName);
}
```

---

## Design Notes

Azunt focuses on:

- simple APIs
- low ceremony
- reusable helpers
- wide compatibility through .NET Standard 2.0
- easy adoption in existing enterprise applications

The library is intended to be practical rather than overly abstract.

---

## Testing

Azunt includes MSTest-based test coverage for utility classes.

Typical test coverage areas include:

- date and time formatting
- relative time helpers
- return URL normalization
- identifier increment logic such as `LicenseNumberUtility`

When adding a new utility, adding a corresponding test class is recommended.

---

## Versioning

Azunt follows package version updates through the project file.

Example:

```xml
<VersionPrefix>1.2.3</VersionPrefix>
```

---

## Project Notes

In earlier VisualAcademy solution examples, a separate `All` project was sometimes created and referenced from a web application for shared code usage. That setup was useful during early development and demonstrations, but the recommended long-term direction is to consume Azunt directly as a reusable package.

---

## Contributing

Contributions are welcome.

Recommended contribution flow:

1. Add or update the utility/service/interface
2. Add or update tests
3. Update the README when public-facing functionality changes
4. Keep APIs simple and easy to understand

---

## License

MIT
