# Muhasebe Programı (Full Stack)

Bu proje, Clean Architecture prensiplerine dayalı olarak bir muhasebe programı geliştirmeyi amaçlamaktadır. Hem Angular (front-end) hem de .NET Core 8 (back-end) kullanarak bir full-stack uygulama oluşturuyoruz.

## Proje Yapısı

1. **Presentation Layer (Sunum Katmanı)**:
   - Angular ile kullanıcı arayüzünü oluşturur.
   - Kullanıcılar için giriş, muhasebe hesapları, faturalar gibi sayfaları içerir.

2. **WebAPI Layer (WebAPI Katmanı)**:
   - RESTful API'ları oluşturur ve sunar.
   - Kullanıcılar, muhasebe hesapları, faturalar gibi verilerle etkileşimi sağlar.

3. **Application Layer (Uygulama Katmanı)**:
   - İş mantığını yönetir.
   - Kullanıcı girişi, hesap işlemleri, fatura yönetimi gibi servisleri içerir.
   - FluentValidation ile girdi doğrulaması yapılır.

4. **Domain Layer (Alan Katmanı)**:
   - Temel iş mantığını içerir.
   - Muhasebe hesapları, faturalar, kullanıcılar gibi temel nesneleri tanımlar.

5. **Infrastructure Layer (Altyapı Katmanı)**:
   - Dış servislerle iletişim gibi altyapı işlemlerini yönetir.
   - .NET Core 8 ile oluşturulan API servisleri, günlük kayıtları gibi işlemleri içerir.

6. **Persistence Layer (Kalıcı Katmanı)**:
   - Veritabanı erişimini yönetir.
   - .NET Core 8 ile oluşturulan veritabanı bağlantısı ve veri saklama işlemlerini içerir.

7. **Unit Test Layer (Birim Test Katmanı)**:
   - Uygulamanın iş mantığını ve veri katmanlarını test etmek için kullanılır.
   - Moq, xUnit/NUnit gibi test araçlarını içerir.

## Kurulum

1. **Angular Uygulaması**:
   - `client` klasörü içindeki Angular projesini başlatın:
     ```sh
     cd client
     npm install
     ng serve
     ```

2. **.NET Core Uygulaması**:
   - `server` klasörü içindeki .NET Core projesini başlatın:
     ```sh
     cd server
     dotnet restore
     dotnet run
     ```

3. **Veritabanı Ayarları**:
   - Veritabanı bağlantısını `appsettings.json` dosyasında yapılandırın.


![1](https://github.com/paradoxxo1/FullstackOnlineMuhasebe/assets/124463263/31457375-d1ef-4493-9cc5-d3d9d808e69e)
![3](https://github.com/paradoxxo1/FullstackOnlineMuhasebe/assets/124463263/02342328-e7f7-4f83-a7eb-469b2cde797b)
![4](https://github.com/paradoxxo1/FullstackOnlineMuhasebe/assets/124463263/142304fd-eb68-4e42-97ee-54c6b0537e0e)
![11 (2)](https://github.com/paradoxxo1/FullstackOnlineMuhasebe/assets/124463263/3f1a3221-dba3-4826-95c0-feecd89d3503)
![11 (4)](https://github.com/paradoxxo1/FullstackOnlineMuhasebe/assets/124463263/dc801a04-cf3d-4056-9977-6d28f3d5d778)
![11 (3)](https://github.com/paradoxxo1/FullstackOnlineMuhasebe/assets/124463263/9ab74c26-4295-4a95-bd86-f8f37e5f2602)
![11 (5)](https://github.com/paradoxxo1/FullstackOnlineMuhasebe/assets/124463263/03918c2d-3b01-43e1-a80d-1d1a7e53e1e5)
![11 (6)](https://github.com/paradoxxo1/FullstackOnlineMuhasebe/assets/124463263/ff628e6d-476c-4c6f-bdd1-ac5601890980)
![11 (1)](https://github.com/paradoxxo1/FullstackOnlineMuhasebe/assets/124463263/187a2b78-ff92-413c-8b29-ee37d444faa6)





## Birimler ve Araçlar

- **FluentValidation**: Application Layer'da giriş doğrulamalarını yapmak için kullanılır.
- **Moq**: Unit testleri yazarken bağımlılıkları izole etmek için kullanılır.
- **Unit Testler**: Uygulamanın iş mantığını ve veri katmanlarını test etmek için Moq ve xUnit/NUnit kullanılır.
- **CancellationToken**: Uzun süren işlemleri iptal edebilmek için kullanılır.

## Katkıda Bulunma

- Lütfen katkıda bulunmak için bir çekme isteği (pull request) gönderin.
- Hata raporları veya öneriler için GitHub sorunlarını kullanın.

## Örnek Kodlar

### FluentValidation Örneği

```csharp
using FluentValidation;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.Email).NotEmpty().EmailAddress();
        RuleFor(user => user.Password).NotEmpty().MinimumLength(6);
    }
}
```

### Moq ile Unit Test Örneği

```csharp
using Moq;
using Xunit;

public class AccountServiceTests
{
    [Fact]
    public async Task CreateAccount_ShouldReturnSuccess()
    {
        var accountRepositoryMock = new Mock<IAccountRepository>();
        var accountService = new AccountService(accountRepositoryMock.Object);
        
        var result = await accountService.CreateAccount(new Account());

        Assert.True(result.IsSuccess);
    }
}
```

### CancellationToken Kullanımı

```csharp
public async Task<IActionResult> GetAccounts(CancellationToken cancellationToken)
{
    var accounts = await _accountService.GetAccountsAsync(cancellationToken);
    return Ok(accounts);
}
```

Bu örnekler, projenin çeşitli katmanlarında nasıl çalışıldığını ve hangi araçların kullanıldığını göstermektedir. Detaylı dokümantasyon ve ek bilgiler için projenin kaynak koduna göz atabilirsiniz.
