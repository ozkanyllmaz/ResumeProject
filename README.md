# 📱 ResumeProject - Developer Portfolio & Admin Panel

Profesyonel bir portföy ve CV yönetim sistemi. Geliştiricilerin kendi web sitelerini kolayca oluşturabilmeleri, güncelleyebilmeleri ve yönetebilmeleri için tasarlanmış bir ASP.NET Core uygulaması.

## ✨ Özellikler

### 🎨 Frontend (Genel Kullanıcılar)
- **Responsive Portfolio Sayfası** - Tüm cihazlarda mükemmel görüntü
- **Dinamik İçerik** - Veritabanından gerçek zamanlı veri çekimi
- **Vegas Background Slideshow** - Ana sayfada değişen arka plan görselleri
- **PDF CV İndirme** - Türkçe karakter desteğiyle profesyonel CV indirmesi
- **Portfolio Galerisi** - Kategori bazlı proje filtreleme
- **İletişim Formu** - Ziyaretçi mesajları için

### 🔐 Admin Panel
- **Güvenli Giriş Sistemi** - Cookie Authentication ve Session yönetimi
- **Otomatik Logout** - Ayarlanabilir oturum süresi
- **Responsive Dashboard** - Mobil ve desktop uyumlu arayüz
- **Sidebar Navigasyon** - Türkçe menü seçenekleri
- **Dark Mode Desteği** - Light/Dark tema ayarları

### 📊 Yönetim Modülleri
- **Hakkımda (About)** - Kişisel bilgi ve özgeçmiş
- **Eğitimler (Education)** - Eğitim geçmişi yönetimi
- **Deneyimler (Experience)** - İş deneyimi kayıtları
- **Yetenekler (Skills)** - Beceri ve teknoloji proficiency seviyeleri
- **Hizmetler (Services)** - Sunulan hizmetlerin tanımı
- **Projeler (Portfolio)** - Portföy projelerinin ekle/düzenle/sil işlemleri
- **Referanslar (Testimonials)** - Müşteri referansları
- **Mesajlar (Messages)** - Ziyaretçi mesajlarını görüntüle

## 🛠️ Teknoloji Yığını

### Backend
- **ASP.NET Core 8.0** - Web framework
- **Entity Framework Core** - ORM
- **SQL Server** - Veritabanı
- **iTextSharp** - PDF oluşturma

### Frontend
- **Razor Views** - Server-side rendering
- **Tailwind CSS** - Styling
- **Bootstrap** - Responsive grid
- **Material Symbols** - İkon seti

### Diğer
- **Cookie Authentication** - Kullanıcı oturumu
- **ASP.NET Session** - Oturum yönetimi
- **Vegas.js** - Background slideshow

## 📋 Veritabanı Tabloları

```
Abouts

Educations

Experiences

Skills

Services

Portfolios

Categories

Testimonials

Messages

Auths

```
## Ekran Kaydı
https://github.com/user-attachments/assets/4f4a5e60-1b95-47aa-af45-a894bc1ae86d

## Admin Paneli Ekran Görüntüleri
<img width="1576" height="900" alt="Image" src="https://github.com/user-attachments/assets/c879247b-677f-49e8-a373-ae1be8756615" />
<img width="1576" height="900" alt="Image" src="https://github.com/user-attachments/assets/7c6e97eb-d7fc-417b-b4d0-f0b6cc813e77" />
<img width="1576" height="900" alt="Image" src="https://github.com/user-attachments/assets/a62a76d2-bac7-472c-9f72-38cc3ca57d71" />
<img width="1576" height="900" alt="Image" src="https://github.com/user-attachments/assets/27eb5838-2569-496d-8871-2767a6de6607" />
<img width="1576" height="900" alt="Image" src="https://github.com/user-attachments/assets/b8363a06-aa26-4609-a143-ec2a5995ea2f" />
<img width="1576" height="900" alt="Image" src="https://github.com/user-attachments/assets/33d356fb-9628-4202-9e20-d248c159b64a" />
<img width="1576" height="900" alt="Image" src="https://github.com/user-attachments/assets/a564028a-99cb-43f6-af23-dfc3d5733ed8" />
<img width="1576" height="900" alt="Image" src="https://github.com/user-attachments/assets/70a88052-e2f3-4247-85b1-5dd9e789b547" />




## 🚀 Başlangıç

### Gereksinimler
- .NET 8.0 SDK veya üzeri
- SQL Server 2019 veya üzeri
- Visual Studio 2022 (opsiyonel)

### Kurulum Adımları

1. **Projeyi klonla**
```bash
git clone https://github.com/kullaniciadi/ResumeProject.git
cd ResumeProject
```

2. **Veritabanını oluştur**
```bash
dotnet ef database update
```

3. **Gerekli paketleri yükle**
```bash
dotnet restore
```

4. **Uygulamayı başlat**
```bash
dotnet run
```

5. **Tarayıcıda aç**
```
https://localhost:7000
```

### İlk Giriş
- **URL:** `https://localhost:7000/Auth/Login`
- Admin hesabı oluşturmak için `/Auth/Register` sayfasını kullan

## 📖 Kullanıcı Rehberi

### Admin Paneli Erişim
1. `/Auth/Login` sayfasına git
2. Email ve şifre ile giriş yap
3. Admin paneline yönlendirileceksin
4. Sidebar'dan istediğin modülü seç

### CV İndirme (Frontend)
1. Ana sayfada "Download CV" butonuna tıkla
2. Veritabanında bulunan tüm bilgilerden oluşan PDF indirilecek
3. Türkçe karakterleri tam destekler

### Oturum Süresi
- Varsayılan: 2 saat
- `AuthController.Login()` methodunda değiştirebilirsin

## 🔒 Güvenlik Özellikleri

- ✅ Cookie Authentication
- ✅ Password hashing (uygulanması önerilir)
- ✅ [Authorize] attribute ile sayfa koruması
- ✅ [AllowAnonymous] ile public sayfalar
- ✅ CSRF protection (ASP.NET Core built-in)
- ✅ SQL Injection prevention (EF Core parametrized queries)

## 📝 Önemli Notlar

### Turkish Karakterleri (ş, ğ, ü, ö, ç)
PDF oluşturulurken Turkish karakterler desteklenir:
- Font: Arial.ttf (System Fonts klasöründen yüklenir)
- Encoding: UTF-8 + IDENTITY_H

### Responsive Design
- Mobile-first approach
- Grid layout (sm, md, lg, xl breakpoints)
- Touch-friendly buttons ve form elements

### Dark Mode
- localStorage'de tema ayarı kaydedilir
- Otomatik sistem tercihi algılanır
- Tailwind CSS ile yapılmış

## 👨‍💻 Katkı

Hataları raporla veya iyileştirme önerileri için pull request açabilirsin.

## 📄 Lisans

Bu proje MIT Lisansı altında sunulmaktadır.

## 📧 İletişim

 Linkedin: https://www.linkedin.com/in/devozkanyilmaz/

---

**Son Güncellenme:** Ocak 2026  
**Sürüm:** 1.0.0