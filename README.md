## 🚧 Proje Mimarisi – 6 Katmanlı Yapı

Proje, SOLID prensiplerine uygun olarak katmanlara ayrılmıştır. Ayrıca tüm kodlar CleanCode prensiplerine uygun bir şekilde yazılmaya özen gösterilmiştir:

### 🧠 Business Layer
- **İş kurallarının** yazıldığı katmandır.
- Katmanlar arası bağımlılığı engellemek için servis arayüzleri kullanılmıştır.
- CRUD işlemleri, validasyonlar ve özel iş mantıkları burada barındırılır.

### 💾 Data Access Layer
- Veritabanı işlemlerinin (CRUD) gerçekleştirildiği alandır.
- `Entity Framework Core` kullanılarak repository yapısı ile çalışılmıştır.
- LINQ sorguları ile gelişmiş filtreleme ve listeleme işlemleri yapılmıştır.

### 📦 DTO Layer
- Veri transferi için kullanılan sadeleştirilmiş modellerdir.
- Katmanlar arası veri taşırken veri güvenliği ve performans artırımı sağlanır.

### 🧱 Entity Layer
- Projedeki temel varlıkların (Entity’lerin) bulunduğu katmandır.
- Örneğin: `Product`, `Category`, `Reservation`, `Order` gibi sınıflar burada tanımlanır.

### 🔗 API
- **RESTful mimarideki API'ler** bu katmanda yer alır.
- CRUD işlemleri sadece bu katman aracılığıyla yapılır.
- Swagger ile tüm API uç noktaları test edilebilir durumdadır.

### 🌐 Web UI
- Projenin son kullanıcıya gösterilen arayüzüdür.
- Razor Pages, jQuery, AJAX, JavaScript ve SignalR kullanılarak dinamikleştirilmiştir.
- Mobil uyumlu, kullanıcı dostu ve gerçek zamanlı güncellenen yapıya sahiptir.

---

## 🧩 Kullanılan Teknolojiler

- ASP.NET Core Web API
- Entity Framework Core
- SignalR
- Fluent Validation
- Identity (AppUser ile genişletilmiş)
- MailKit (Gerçek mail gönderimi)
- QR Code Generator
- RapidAPI – TastyAPI Entegrasyonu
- Swagger
- LINQ
- AJAX & JavaScript

---

## 🔄 Gerçek Zamanlı İşlemler (SignalR)

### 🔔 Rezervasyon Bildirimi
- Her 5 saniyede istemciden sunucuya istek atılır.
- Yeni rezervasyon var mı kontrol edilir, varsa anlık olarak kullanıcıya bildirim düşer.

### 🛎️ Masa Durumu
- Masaların `Dolu` veya `Boş` durumları anlık olarak UI'da güncellenir.
- Masa durumu değiştiğinde renk değişimi (Yeşil/Kırmızı) ile görsel olarak da belirtilir.

### 💬 Mesajlaşma
- `chat.js` dosyası üzerinden kullanıcılar arasında anlık mesajlaşma sistemi kuruldu.

### 👥 Anlık Ziyaretçi Takibi
- `OnConnectedAsync()` ve `OnDisconnectedAsync()` metodlarıyla kullanıcı sayısı gerçek zamanlı takip edilir.

### 📊 Canlı İstatistikler
- Kategoriye göre ürün sayısı
- En yüksek/en düşük fiyatlı ürün
- Ortalama hamburger fiyatı
- Toplam ve aktif sipariş sayısı
- Son sipariş tutarı
- Bu veriler, SignalR ile tarayıcı yenilemeden anlık olarak gösterilmektedir.

---

## 🛡️ Authentication & Authorization

- ASP.NET Core Identity yapısı entegre edilmiştir.
- `AppUser` sınıfı oluşturularak kullanıcıya `Name`, `Surname` gibi ekstra alanlar eklendi.
- Kimlik doğrulama ve yetkilendirme (rol bazlı erişim) sağlandı.
- Oluşan tablolar:
  - `AspNetUsers`
  - `AspNetRoles`
  - `AspNetUserRoles`
  - `AspNetUserClaims`
  - `AspNetRoleClaims`
  - `AspNetUserLogins`
  - `AspNetUserTokens`

---

## ✉️ Mail Gönderimi (MailKit)

- Google API Key kullanılarak kullanıcıya **gerçek mail gönderimi** sağlandı.
- Rezervasyon, şifre yenileme gibi işlemler için kullanılabilir yapıdadır.

---

## 🔐 Yetkisiz Erişim Engelleme

- Giriş yapmamış kullanıcılar otomatik olarak login ekranına yönlendirilir.
- Token tabanlı koruma ve kullanıcı oturumu yönetimi yapılmaktadır.

---

## 📦 Ek Özellikler

- **QR Kod oluşturma**: Masalar ve menüler için özel QR kod üretildi.
- **RapidAPI Tasty API**: Dünya mutfağından yemek tarifleri ve videolar entegre edildi.
- **Trigger Kullanımı**: Sipariş durumlarına özel tetikleyici (örnek: siparişe ürün eklenmesi).
- **AJAX ile dinamik ürün işlemleri**: Tıklanan ürün ID’sine göre veri işlemleri yapıldı.
- **404 Sayfası**: Hatalı sayfa isteklerine özel kullanıcı dostu hata ekranı eklendi.
- **Fluent Validation**: Eksik form alanları için kullanıcı uyarı sistemi kuruldu.

---

## 📸 Ekran Görüntüleri

![ImageAlt](https://github.com/SemihSanli/SignalRRestaurant/blob/426a59b1d98a91810089834ff42590e9c3b60fb5/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-05-20%20141714.png)
![ImageAlt](https://github.com/SemihSanli/SignalRRestaurant/blob/426a59b1d98a91810089834ff42590e9c3b60fb5/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-05-20%20141721.png)
![ImageAlt](https://github.com/SemihSanli/SignalRRestaurant/blob/426a59b1d98a91810089834ff42590e9c3b60fb5/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-05-20%20141728.png)
![ImageAlt](https://github.com/SemihSanli/SignalRRestaurant/blob/426a59b1d98a91810089834ff42590e9c3b60fb5/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-05-20%20141742.png)
![ImageAlt](https://github.com/SemihSanli/SignalRRestaurant/blob/426a59b1d98a91810089834ff42590e9c3b60fb5/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-05-20%20141749.png)
![ImageAlt](https://github.com/SemihSanli/SignalRRestaurant/blob/426a59b1d98a91810089834ff42590e9c3b60fb5/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-05-20%20141820.png)
![ImageAlt](https://github.com/SemihSanli/SignalRRestaurant/blob/426a59b1d98a91810089834ff42590e9c3b60fb5/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-05-20%20141832.png)
![ImageAlt](https://github.com/SemihSanli/SignalRRestaurant/blob/426a59b1d98a91810089834ff42590e9c3b60fb5/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-05-20%20141941.png)
![ImageAlt](https://github.com/SemihSanli/SignalRRestaurant/blob/426a59b1d98a91810089834ff42590e9c3b60fb5/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-05-20%20142013.png)
![ImageAlt](https://github.com/SemihSanli/SignalRRestaurant/blob/426a59b1d98a91810089834ff42590e9c3b60fb5/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-05-20%20142023.png)


![ImageAlt](https://github.com/SemihSanli/SignalRRestaurant/blob/426a59b1d98a91810089834ff42590e9c3b60fb5/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-05-20%20141418.png)
![ImageAlt](https://github.com/SemihSanli/SignalRRestaurant/blob/426a59b1d98a91810089834ff42590e9c3b60fb5/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-05-20%20141430.png)
![ImageAlt](https://github.com/SemihSanli/SignalRRestaurant/blob/426a59b1d98a91810089834ff42590e9c3b60fb5/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-05-20%20141459.png)
![ImageAlt](https://github.com/SemihSanli/SignalRRestaurant/blob/426a59b1d98a91810089834ff42590e9c3b60fb5/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-05-20%20141507.png) 
![ImageAlt](https://github.com/SemihSanli/SignalRRestaurant/blob/ac6e69744fdfa2b18e126fcdb2fed51e02f654d5/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-05-20%20141517.png) 
![ImageAlt](https://github.com/SemihSanli/SignalRRestaurant/blob/ac6e69744fdfa2b18e126fcdb2fed51e02f654d5/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-05-20%20141529.png) 
![ImageAlt](https://github.com/SemihSanli/SignalRRestaurant/blob/ac6e69744fdfa2b18e126fcdb2fed51e02f654d5/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-05-20%20141536.png) 
![ImageAlt](https://github.com/SemihSanli/SignalRRestaurant/blob/ac6e69744fdfa2b18e126fcdb2fed51e02f654d5/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-05-20%20141543.png) 
![ImageAlt](https://github.com/SemihSanli/SignalRRestaurant/blob/ac6e69744fdfa2b18e126fcdb2fed51e02f654d5/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-05-20%20141553.png) 
![ImageAlt](https://github.com/SemihSanli/SignalRRestaurant/blob/ac6e69744fdfa2b18e126fcdb2fed51e02f654d5/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-05-20%20141600.png) 
![ImageAlt](https://github.com/SemihSanli/SignalRRestaurant/blob/ac6e69744fdfa2b18e126fcdb2fed51e02f654d5/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-05-20%20141607.png) 
![ImageAlt](https://github.com/SemihSanli/SignalRRestaurant/blob/ac6e69744fdfa2b18e126fcdb2fed51e02f654d5/Images/WhatsApp%20G%C3%B6rsel%202025-05-19%20saat%2015.27.20_478b7ba6.jpg)
![ImageAlt](https://github.com/SemihSanli/SignalRRestaurant/blob/ac6e69744fdfa2b18e126fcdb2fed51e02f654d5/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-05-20%20141614.png) 
![ImageAlt](https://github.com/SemihSanli/SignalRRestaurant/blob/ac6e69744fdfa2b18e126fcdb2fed51e02f654d5/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-05-20%20141648.png) 
![ImageAlt](https://github.com/SemihSanli/SignalRRestaurant/blob/ac6e69744fdfa2b18e126fcdb2fed51e02f654d5/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-05-20%20141654.png) 
![ImageAlt](https://github.com/SemihSanli/SignalRRestaurant/blob/a6f0d8c6a466aa7566a777e122b99529937c0a27/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-05-20%20152628.png) 
