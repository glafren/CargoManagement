# Kargo Şirketi Uygulaması

Bu proje, ASP.NET MVC kullanarak geliştirilen bir kargo şirketi uygulamasıdır. Uygulama, kargo girişi, çıkışı ve durumuyla ilgili işlemleri yönetmek için Repository Pattern ve Unit of Work tasarım desenlerini kullanmaktadır.

## Özellikler

- Kargo girişi ve çıkışı yapma
- Kargonun durumunu değiştirme
- Kargo takip numarası oluşturma
- Kullanıcı yetkilendirme sistemi (giriş yapma, kayıt olma)
- Müşterilerin kargo durumunu takip etme

## Teknolojiler ve Araçlar

- ASP.NET MVC
- Entity Framework
- Microsoft SQL Server
- HTML, CSS, JavaScript
- jQuery
- GitHub
- Ajax
- Repository Pattern
- Unit Of Work

## Proje Yapısı

- **Models**: Veritabanı tablolarını ve veri yapılarını tanımlayan sınıflar
- **Repository**: Projede Repository Pattern kullanılarak, kargo verileriyle ilgili işlemler için ayrı Repository sınıfları oluşturulmuştur. Bu sınıflar, veritabanı işlemlerini yönetmek ve kodu daha düzenli hale getirmek için kullanılır.
- **Unit Of Work**: Projede Unit of Work tasarım desenini kullanarak, Repository sınıflarının birleşik bir iş birimi altında çalışmasını sağlamış ve veritabanı işlemlerini yönetmiş olursunuz.
- **Controllers**: Uygulama iş mantığını ve yönlendirmeleri içeren kontrolcü sınıflar
- **Views**: Kullanıcı arayüzünü oluşturan görünüm dosyaları
- **Migrations**: Entity Framework ile veritabanı migrasyonlarını yönetmek için kullanılan dosyalar

## Kurulum

1. Proje dosyalarını bilgisayarınıza indirin veya kopyalayın.
2. Microsoft SQL Server'da yeni bir veritabanı oluşturun.
3. `appsettings.json` dosyasında veritabanı bağlantı dizesini güncelleyin.
4. Visual Studio veya başka bir geliştirme ortamında projeyi açın.
5. Gerekli NuGet paketlerini geri yükleyin.
6. Veritabanı migrasyonlarını uygulayın.
7. Uygulamayı çalıştırın ve tarayıcınızda `http://localhost:port` adresine gidin.

Bu proje, kargo şirketleri için temel bir uygulama sağlamak amacıyla oluşturulmuştur. İhtiyaçlarınıza ve gereksinimlerinize göre geliştirilebilir veya özelleştirilebilir.

**Not**: Projeyle ilgili herhangi bir sorunuz veya geri bildiriminiz varsa, lütfen iletişime geçmekten çekinmeyin.
**E-mail**: metinyeni33@gmail.com
