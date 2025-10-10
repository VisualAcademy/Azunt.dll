# Azunt.dll

Azunt.dll is a general-purpose .NET utility library for networking, security, and more.

## Features

- IP Address Utilities
- Security Helpers
- Designed for .NET Standard 2.0
- Easy to use, easy to extend

## License

MIT

## All 프로젝트 생성

### All 이름으로 .NET Standard 프로젝트 생성 후 웹 프로젝트에 프로젝트 참조 추가

https://youtu.be/cRXXzDcgvSo

VisualAcademy 솔루션에서는 먼저 `All`이라는 이름으로 .NET Standard 프로젝트를 생성하고, 웹 프로젝트에 해당 프로젝트를 참조 추가하여 공통 기능(Azunt.dll)을 활용하는 방식으로 강의가 진행됩니다.

이 방식은 초기 개발 및 테스트를 위한 설정이며, 이후에는 **Azunt NuGet 패키지**를 통해 별도 프로젝트 생성 없이 라이브러리를 직접 설치하여 사용할 수 있도록 전환될 예정입니다.

## IEmailSender 인터페이스 파일을 Azunt 프로젝트에 추가

https://youtu.be/dryTN9ydj5o

`IEmailSender` 인터페이스는 이메일 전송 기능을 표준화하기 위해 `Azunt.Services` 네임스페이스에 추가되었습니다.  
이를 통해 다양한 프로젝트에서 일관된 규격으로 이메일 기능을 구현할 수 있습니다.

- **파일 경로**  
  `src/Azunt/Azunt/Services/Interfaces/IEmailSender.cs`

- **주요 기능**  
  - 비동기 이메일 전송 메서드 제공  
    ```csharp
    Task SendEmailAsync(string email, string subject, string message, bool isBodyHtml = true);
    ```

- **관련 추가 항목**  
  - `IMailchimpEmailSender` 인터페이스도 함께 추가되었으며, Mailchimp 기반 이메일 전송 기능을 제공합니다.

`IEmailSender` 인터페이스 추가를 통해 Azunt 프로젝트의 이메일 전송 로직을 보다 일관성 있고 확장성 있게 관리할 수 있습니다.

## ITwilioSender 인터페이스 파일을 Azunt 프로젝트에 추가

https://youtu.be/JiXhL9eXFyM

`ITwilioSender` 인터페이스는 SMS 전송 기능을 표준화하기 위해 `Azunt.Services` 네임스페이스에 추가되었습니다.  
이를 통해 다양한 프로젝트에서 일관된 방식으로 문자 메시지 발송 기능을 구현할 수 있습니다.

- **파일 경로**  
  `src/Azunt/Azunt/Services/Interfaces/ITwilioSender.cs`

- **주요 기능**  
  - 비동기 SMS 전송 메서드 제공  
    ```csharp
    Task SendSmsAsync(string phoneNumber, string message);
    ```

`ITwilioSender` 인터페이스 추가를 통해 Azunt 프로젝트는 SMS 발송 로직을 통합적으로 관리할 수 있으며, 향후 다양한 문자 메시지 서비스와의 연동도 용이해졌습니다.

## ISmsSender 인터페이스 파일을 Azunt 프로젝트에 추가

`ISmsSender` 인터페이스는 SMS 전송 기능을 추상화하기 위해 `Azunt.Services` 네임스페이스에 추가되었습니다.  
이 인터페이스를 통해 SMS 발송 기능을 구현할 때 일관성과 확장성을 확보할 수 있습니다.

- **파일 경로**  
  `src/Azunt/Azunt/Services/Interfaces/ISmsSender.cs`

- **주요 기능**  
  - 비동기 SMS 전송 메서드 제공  
    ```csharp
    Task SendSmsAsync(string number, string message);
    ```

`ISmsSender` 인터페이스를 도입함으로써, 다양한 문자 메시지 서비스와의 연동이나 교체가 용이해지고, 프로젝트 전반에 걸쳐 SMS 발송 로직의 일관성을 높일 수 있게 되었습니다.

## IStorageServiceBase 인터페이스 파일을 Azunt 프로젝트에 추가

`IStorageServiceBase` 인터페이스는 파일 및 디렉터리 관리 기능을 표준화하기 위해 `Azunt.Services.Interfaces` 네임스페이스에 추가되었습니다.  
이를 통해 다양한 저장소 시스템에 대해 일관된 방식으로 파일 업로드, 다운로드, 삭제 기능을 구현할 수 있습니다.

- **파일 경로**  
  `src/Azunt/Azunt/Services/Interfaces/IStorageServiceBase.cs`

- **주요 기능**  
  - 디렉터리 생성 및 삭제  
    ```csharp
    Task<bool> CreateDirectory(string folderPath);
    Task<bool> DeleteDirectoryAsync(string folderPath);
    ```
  - 파일 업로드 및 다운로드  
    ```csharp
    Task<string> UploadAsync(byte[] bytes, string fileName, string folderPath, bool overwrite);
    Task<byte[]> DownloadAsync(string fileName, string folderPath);
    ```
  - 메타데이터 조회 및 경로 관리  
    ```csharp
    Task<IDictionary<string, string>> GetMetadataAsync(string fileName, string folderPath);
    string GetFolderPath(string ownerType, long ownerId, string fileType);
    ```

`IStorageServiceBase` 인터페이스를 통해 파일 관리 기능을 추상화함으로써, 로컬 파일 시스템뿐만 아니라 클라우드 스토리지 등 다양한 저장소 구현체와의 연동이 용이해졌습니다.


## Verification

### ManageMessageId 열거형 파일을 Azunt 프로젝트에 추가

https://youtu.be/n5u15dE-qWk

`ManageMessageId` 열거형은 사용자 계정 관리 작업의 결과를 나타내기 위해 `Azunt.Models.Enums` 네임스페이스에 추가되었습니다.  
계정 관리 과정에서 발생할 수 있는 다양한 성공 및 오류 메시지를 코드 상에서 명확하게 구분하고 처리할 수 있도록 지원합니다.

- **파일 경로**  
  `src/Azunt/Azunt/Models/Enums/ManageMessageId.cs`

- **정의된 항목**  
  - `AddPhoneSuccess` : 전화번호 추가 성공
  - `AddLoginSuccess` : 외부 로그인 추가 성공
  - `ChangePasswordSuccess` : 비밀번호 변경 성공
  - `SetTwoFactorSuccess` : 2단계 인증 설정 성공
  - `SetPasswordSuccess` : 비밀번호 설정 성공
  - `RemoveLoginSuccess` : 외부 로그인 제거 성공
  - `RemovePhoneSuccess` : 전화번호 제거 성공
  - `Error` : 오류 발생

`ManageMessageId`를 사용함으로써, 사용자 계정 관리 기능의 결과 메시지를 일관성 있고 타입 안전한 방식으로 처리할 수 있습니다.

## Azunt.Repositories.IRepositoryBase 사용

[Azunt/Repositories/IRepositoryBase.cs](https://github.com/VisualAcademy/Azunt.dll/blob/main/src/Azunt/Azunt/Repositories/IRepositoryBase.cs)

`IRepositoryBase<T, TId>`는 Azunt 전역에서 기본 CRUD(Create, Read, Update, Delete) 작업을 표준화하기 위해 사용되는 최상위 공통 리포지토리 인터페이스입니다.

```csharp
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azunt.Repositories
{
    /// <summary>
    /// Defines a generic repository interface for basic CRUD operations.
    /// This is the base abstraction used across the Azunt ecosystem to unify data access logic.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <typeparam name="TId">The identifier type (e.g., int, long, Guid, string).</typeparam>
    public interface IRepositoryBase<T, TId> where T : class
    {
        /// <summary>
        /// Adds a new entity to the data store.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity with any generated values populated.</returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Retrieves all entities of the specified type.
        /// </summary>
        /// <returns>A collection of all entities.</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Retrieves a single entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <returns>The entity if found; otherwise, null.</returns>
        Task<T> GetByIdAsync(TId id);

        /// <summary>
        /// Updates an existing entity in the data store.
        /// </summary>
        /// <param name="entity">The entity with updated values.</param>
        /// <returns>True if the update was successful; otherwise, false.</returns>
        Task<bool> UpdateAsync(T entity);

        /// <summary>
        /// Deletes an entity based on its unique identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity to delete.</param>
        /// <returns>True if the deletion was successful; otherwise, false.</returns>
        Task<bool> DeleteAsync(TId id);
    }
}
```

## Validators

`Azunt.Utilities.Validation` 네임스페이스에는 사용자 입력값의 유효성을 검사하는 다양한 Validator 클래스가 포함되어 있습니다.
이 유틸리티들은 .NET Standard 2.0 환경에서도 동작하며, 사용자의 입력 데이터가 규칙에 맞는지 검사하는 데에 사용됩니다.

### UsernameValidator

`UsernameValidator`는 사용자 이름에 허용되지 않는 문자가 포함되어 있는지 검사합니다.
공백이나 특수문자가 포함된 사용자 이름을 방지하는 데 유용합니다.

* **파일 경로**
  `src/Azunt/Azunt/Utilities/Validation/UsernameValidator.cs`

* **지원 기능**

  ```csharp
  public static bool IsValid(string username);
  ```

* **금지 문자 목록**
  `\`, `/`, `:`, `?`, `*`, `"`, `<`, `>`, `|`, `(space)`, `'`, `%`, `&`, `+`

### EmailValidator

`EmailValidator`는 기본적인 형식의 이메일 주소를 정규식을 통해 검사합니다.
복잡한 유효성 검사를 필요로 하지 않는 상황에서 빠르고 간단하게 사용할 수 있습니다.

* **파일 경로**
  `src/Azunt/Azunt/Utilities/Validation/EmailValidator.cs`

* **지원 기능**

  ```csharp
  public static bool IsValid(string email);
  ```

* **정규식 기반 기본 포맷 검사**

  * 예: `user@example.com`, `john.doe@domain.co`

### PasswordValidator

`PasswordValidator`는 강력한 보안 요건을 만족하는 비밀번호인지 검사합니다.
다음 조건을 모두 만족해야 유효한 비밀번호로 간주됩니다:

* 최소 8자 이상

* 대문자 1개 이상 포함

* 소문자 1개 이상 포함

* 숫자 1개 이상 포함

* 특수 문자 1개 이상 포함

* **파일 경로**
  `src/Azunt/Azunt/Utilities/Validation/PasswordValidator.cs`

* **지원 기능**

  ```csharp
  public static bool IsValid(string password);
  ```

이러한 Validator 클래스를 활용하면 회원가입, 로그인, 설정 페이지 등에서 보다 신뢰할 수 있는 사용자 입력 검증 로직을 손쉽게 구현할 수 있습니다.

## 파일 → 미디어 타입(MIME) 매핑 가이드

`Azunt.Utilities.Media.FileMediaTypeResolver` 는 **파일명(또는 확장자)** 을 받아 적절한 **Content-Type(MIME)** 문자열을 반환하는 가벼운 헬퍼입니다.
프로젝트마다 흩어져 있던 스위치문/딕셔너리를 대체해 **일관성**과 **가독성**을 높입니다.

### 언제 쓰나요?

* ASP.NET Core에서 `File(...)` 응답 시 `contentType` 지정
* 파일 다운로드/미리보기, 첨부파일 저장소 등에서 확장자 기반 MIME 판별이 필요할 때
* 모르는 확장자는 안전하게 `application/octet-stream`으로 처리하고 싶을 때

### 기본 사용

```csharp
using Azunt.Utilities.Media;

// 파일명 전체를 넘겨도 되고, ".pdf" 같은 확장자만 넘겨도 됩니다.
var mediaType1 = FileMediaTypeResolver.GetMediaType("report.pdf"); // "application/pdf"
var mediaType2 = FileMediaTypeResolver.GetMediaType(".png");       // "image/png"

// 알 수 없는 확장자 → 기본값 지정 가능 (미지정 시 application/octet-stream)
var fallback = FileMediaTypeResolver.GetMediaType("archive.unknown", defaultMediaType: "application/octet-stream");
```

### ASP.NET Core Controller 예시

```csharp
using Azunt.Utilities.Media;

public async Task<IActionResult> Download(string filePath, string fileName)
{
    var mediaType = FileMediaTypeResolver.GetMediaType(fileName);
    var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
    return File(bytes, mediaType, fileName);
}
```

### 대용량 파일: 스트리밍 권장

```csharp
using Azunt.Utilities.Media;

public IActionResult DownloadStream(string filePath, string fileName)
{
    var mediaType = FileMediaTypeResolver.GetMediaType(fileName);
    var stream = System.IO.File.OpenRead(filePath);
    return File(stream, mediaType, fileName); // FileStreamResult → 메모리 사용 최소화
}
```

### 결과 확인(검증) API

```csharp
using Azunt.Utilities.Media;

if (FileMediaTypeResolver.TryGetMediaType(".xlsx", out var mt))
{
    // mt == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
}
else
{
    // 미지정 확장자 처리
    mt = "application/octet-stream";
}
```

### 특징

* **.NET Standard 2.0 지원**: 넓은 호환성
* **보수적인 기본값**: 알 수 없는 확장자는 `application/octet-stream`
* **자주 쓰는 유형 포함**: pdf, doc/docx, xls/xlsx, ppt/pptx, txt, jpg/jpeg, png, gif 등
* **간단한 API**: `GetMediaType(...)`, `TryGetMediaType(...)` 두 가지로 충분

> 이미 `FileExtensionContentTypeProvider`를 사용 중이라면 그대로 유지해도 되지만, **간단한 의존성**과 **일관된 기본값**이 필요하다면 `FileMediaTypeResolver`가 더 가볍고 쓰기 편합니다.
