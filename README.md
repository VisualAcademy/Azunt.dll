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

VisualAcademy 솔루션에서는 먼저 `All`이라는 이름으로 .NET Standard 프로젝트를 생성하고, 웹 프로젝트에 해당 프로젝트를 참조 추가하여 공통 기능(Azunt.dll)을 활용하는 방식으로 강의가 진행됩니다.

이 방식은 초기 개발 및 테스트를 위한 설정이며, 이후에는 **Azunt NuGet 패키지**를 통해 별도 프로젝트 생성 없이 라이브러리를 직접 설치하여 사용할 수 있도록 전환될 예정입니다.

## IEmailSender 인터페이스 파일을 Azunt 프로젝트에 추가

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
