# ✈️ FlyDapper - Uçuş İstatistik Dashboard'u

ASP.NET Core 8.0 ve Dapper kullanılarak geliştirilmiş, 500.000+ uçuş kaydını analiz eden istatistik dashboard'u.

---

## 🖥️ Ekran Görüntüleri

> Giriş Paneli · Ana Dashboard · İptal & Gecikme Analizi

---

## 🚀 Özellikler

### 📊 Ana Dashboard
- Toplam uçuş sayısı ve günlük ortalama uçuş istatistikleri
- En çok uçuş yapılan havalimanı
- Aylara göre uçuş trendi (Line Chart)
- Haftanın günlerine göre yoğunluk analizi (Bar Chart)
- Saatlere göre uçuş yoğunluğu — yoğunluğa göre dinamik renklendirme
- En çok kullanılan 10 rota tablosu

### ❌ İptal & Gecikme Analizi
- Toplam iptal sayısı ve iptal oranı
- Toplam gecikme sayısı ve gecikme oranı
- İptal sebepleri dağılımı — Hava / Havayolu / NAS / Güvenlik (Doughnut Chart)
- Aylara göre iptal trendi (Line Chart)
- En çok geciken top 10 havayolu (Horizontal Bar Chart)
- En çok iptal olan top 10 rota tablosu

### 🔐 Kullanıcı Yönetimi
- ASP.NET Core Identity ile güvenli giriş sistemi
- Şifre değiştirme ekranı
- `[Authorize]` ile tüm sayfalar korumalı

---

## 🛠️ Kullanılan Teknolojiler

| Teknoloji | Açıklama |
|---|---|
| ASP.NET Core 8.0 | Web framework |
| Dapper | Micro ORM — SQL sorguları |
| Entity Framework Core | Identity için |
| ASP.NET Core Identity | Kullanıcı kimlik doğrulama |
| Microsoft SQL Server | Veritabanı |
| Chart.js | Grafik kütüphanesi |
| Bootstrap 5 | UI framework |
| Kaggle | Veri seti kaynağı |

---

## 📦 Veri Seti

[Kaggle](https://www.kaggle.com) üzerinden erişilen **500.000+ kayıt** içeren uçuş veri seti kullanılmıştır. Veri seti SQL Server'a aktarılmış ve Dapper ile sorgulanmıştır.

Veri setinde yer alan alanlar:

```
flight_id, fl_date, op_unique_carrier, origin, origin_city_name,
dest, dest_city_name, crs_dep_time, dep_time, dep_delay,
crs_arr_time, arr_time, arr_delay, cancelled, diverted,
distance, cancellation_code
```

---

## 🏗️ Proje Mimarisi

```
FlyDapper/
├── Controllers/
│   ├── HomeController.cs
│   ├── FlightController.cs
│   ├── CancellationController.cs
│   └── AccountController.cs
├── Models/
│   ├── DapperContext/
│   │   └── Context.cs
│   ├── IdentityContext/
│   │   └── AppIdentityContext.cs
│   ├── ViewModels/
│   │   ├── LoginViewModel.cs
│   │   └── ChangePasswordViewModel.cs
│   └── Dtos/
│       ├── AirportStat.cs
│       ├── FlightSummary.cs
│       ├── FlightByMonth.cs
│       ├── FlightByDayOfWeek.cs
│       ├── FlightByHour.cs
│       ├── TopRoute.cs
│       ├── FlightStatusSummary.cs
│       ├── CancellationByReason.cs
│       ├── CancellationByMonth.cs
│       ├── TopCancelledRoute.cs
│       └── TopDelayedAirline.cs
├── Repositories/
│   ├── IFlightRepository.cs
│   ├── FlightRepository.cs
│   ├── IFlightStatRepository.cs
│   └── FlightStatRepository.cs
└── Views/
    ├── Flight/
    ├── Cancellation/
    └── Account/
```

---

## ⚙️ Kurulum

### Gereksinimler
- .NET 8.0 SDK
- SQL Server
- Visual Studio 2022 veya VS Code

### Adımlar

**1. Repoyu klonla:**
```bash
git clone https://github.com/kullanici-adi/FlyDapper.git
cd FlyDapper
```

**2. Connection string'i ayarla:**

`appsettings.Development.json` dosyası oluştur:
```json
{
  "ConnectionStrings": {
    "connection": "Server=SERVER_ADI;Database=FlightDashboardDb;User Id=KULLANICI;Password=SIFRE;TrustServerCertificate=True;"
  }
}
```

**3. Identity migration'ı çalıştır:**
```
Add-Migration InitIdentity
Update-Database
```

**4. Uygulamayı başlat:**
```bash
dotnet run
```

Uygulama ilk başladığında otomatik olarak admin kullanıcısı oluşturulur:
```
Email    : admin@admin.com
Şifre    : Admin123!
```

---

## 📈 Repository Yapısı

Proje **Repository Pattern** ile geliştirilmiştir. Her istatistik için ayrı interface ve implementasyon mevcuttur. Dapper, raw SQL sorgularıyla çalışmakta; bağlantı yönetimi `using` bloğu ile otomatik yapılmaktadır.

```csharp
public async Task<AirportStat> GetMostDepartureAirportAsync()
{
    string query = @"
        SELECT TOP 1
            origin           AS AirportCode,
            origin_city_name AS CityName,
            COUNT(*)         AS TotalFlights
        FROM Flights
        GROUP BY origin, origin_city_name
        ORDER BY TotalFlights DESC";

    using var connection = _context.CreateConnection();
    return await connection.QueryFirstOrDefaultAsync<AirportStat>(query);
}
```

---

## 🔒 Güvenlik

- Tüm controller'lar `[Authorize]` attribute ile korumalıdır
- Şifreler Identity tarafından hash'lenerek saklanır

---

## 📄 Lisans

MIT License — dilediğiniz gibi kullanabilirsiniz.
