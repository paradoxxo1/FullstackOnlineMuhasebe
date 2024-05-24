# Muhasebe Programı (Full Stack) 

Bu proje, Clean Architecture prensiplerine dayalı olarak bir muhasebe programı geliştirmeyi amaçlamaktadır. Hem Angular (front-end) hem de .NET Core 8 (back-end) kullanarak bir full-stack uygulama oluşturuyoruz.

## Proje Yapısı

1. **Presentation Layer (Sunum Katmanı)**:
   - Angular ile kullanıcı arayüzünü oluşturun.
   - Kullanıcılar için giriş, muhasebe hesapları, faturalar gibi sayfaları içerir.

2. **Application Layer (Uygulama Katmanı)**:
   - İş mantığını yönetir.
   - Kullanıcı girişi, hesap işlemleri, fatura yönetimi gibi servisleri içerir.

3. **Domain Layer (Alan Katmanı)**:
   - Temel iş mantığını içerir.
   - Muhasebe hesapları, faturalar, kullanıcılar gibi temel nesneleri tanımlar.

4. **Infrastructure Layer (Altyapı Katmanı)**:
   - Veritabanı erişimi, dış servislerle iletişim gibi altyapı işlemlerini yönetir.
   - .NET Core 8 ile oluşturulan veritabanı bağlantısı, API servisleri, günlük kayıtları gibi işlemleri içerir.

## Kurulum

1. **Angular Uygulaması**:
   - `client` klasörü içindeki Angular projesini başlatın:
     ```
     cd client
     npm install
     ng serve
     ```

2. **.NET Core Uygulaması**:
   - `server` klasörü içindeki .NET Core projesini başlatın:
     ```
     cd server
     dotnet restore
     dotnet run
     ```

3. **Veritabanı Ayarları**:
   - Veritabanı bağlantısını `appsettings.json` dosyasında yapılandırın.

## Katkıda Bulunma

- Lütfen katkıda bulunmak için bir çekme isteği (pull request) gönderin.
- Hata raporları veya öneriler için GitHub sorunlarını kullanın.
