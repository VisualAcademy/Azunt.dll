# Azunt.dll

Azunt.dll is a general-purpose .NET utility library for networking, security, and more.

## Features

- IP Address Utilities
- Security Helpers
- Designed for .NET Standard 2.0
- Easy to use, easy to extend

## License

MIT

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

