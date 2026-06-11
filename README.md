# ✈️ FlyDapper - Uçuş İstatistik Dashboard'u

ASP.NET Core 8.0 ve Dapper kullanılarak geliştirilmiş, 500.000+ uçuş kaydını analiz eden istatistik dashboard'u.

---

## 🖥️ Ekran Görüntüleri

> Giriş Paneli · Ana Dashboard · İptal & Gecikme Analizi
<img width="1551" height="862" alt="image" src="https://github.com/user-attachments/assets/5f7874cf-b7e1-4a0a-ac45-9caa9d80e2a5" />
<img width="1868" height="967" alt="image" src="https://github.com/user-attachments/assets/5e61b60e-897f-40c3-bdae-07276e8b7acc" />
<img width="1887" height="915" alt="image" src="https://github.com/user-attachments/assets/97148ab4-481e-453a-9bb1-53b5cdd7f359" />
<img width="1878" height="912" alt="image" src="https://github.com/user-attachments/assets/fee7856e-7903-41a9-91a0-380c667ead39" />
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


## 🔒 Güvenlik

- Tüm controller'lar `[Authorize]` attribute ile korumalıdır
- Şifreler Identity tarafından hash'lenerek saklanır

---

