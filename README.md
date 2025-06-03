#  Bu Proje M&Y Akademi Danışmanlık  bünyesinde  ve  Murat Yücedağ'ın şuana kadar üstlendiği eğitimlerin tamamından yararlanarak yapılmıştır.
## ⚠️ Projede geliştirilecek yerler elbet vardır. Bu projeyi yapmamdaki amaç, MongoDb veri tabanını katmanlı mimari ile nasıl kullanıldığını öğrenmek ve pekiştirmek istemiş olmamdır.

# 🍽️ Restoran Rezervasyon ve Yönetim Sistemi

Bu proje, modern bir restoran için **N Katmanlı Mimari** ve **RESTful API** prensipleriyle geliştirilmiş  bir web uygulamasıdır. Kullanıcılar rezervasyon oluşturabilirken, yöneticiler de içerik yönetimini kolayca gerçekleştirebilir. Tüm sistem temiz kod anlayışıyla katmanlara ayrılmıştır.

---

## 🔧 Katmanlar

### 🧩 EntityLayer
- Uygulamadaki tüm veritabanı nesneleri (Entity'ler) burada tanımlanır.
- Örnek olarak: `Product`, `Category`, `Reservation`, `User` gibi sınıflar.
- Sadece veri taşır, herhangi bir iş mantığı içermez.

### 🗃️ DataAccessLayer
- Veritabanı işlemleri bu katmanda gerçekleştirilir.
- Hem **MongoDB** (NoSQL) hem de **MsSQL** (relational) veritabanlarına erişim içerir.
- **Generic Repository Design Pattern** kullanılarak tekrar eden kod azaltılmıştır ve kod test edilebilirliği artırılmıştır.

### ⚙️ BusinessLogicLayer
- Uygulamanın iş kurallarını içerir. Örneğin:
  - Rezervasyon saat kontrolü,
  - E-posta gönderimi,
  - Validasyon işlemleri.
- `Extensions` sınıfı üzerinden servis bağımlılıkları tanımlanarak `Program.cs` sadeleştirilmiştir.

### 🌐 APILayer
- Tüm frontend talepleri bu katmana gelir.
- REST prensiplerine uygun olarak HTTP metotları (GET, POST, PUT, DELETE) kullanılır.
- CRUD işlemleri gerçekleştirilir.
- Geriye sadece JSON veri döner.

### 🎨 ConsumeLayer (UI)
- Kullanıcı arayüzünün geliştirildiği katmandır.
- MVC mimarisi ile yapılandırılmıştır.
- Kullanıcılar:
  - Web sayfalarında gezinip restoran hakkında bilgi alabilir,
  - Rezervasyon yapabilir,
  - İletişim formu ile mesaj bırakabilir.

---

## 🔁 RESTful Yapı

Bu projede **RESTful API** prensiplerine tam uyum sağlanmıştır:

- 🎯 Backend işlemleri sadece API aracılığıyla yürütülür.
- 🔁 CRUD işlemleri için uygun HTTP metotları (GET, POST, PUT, DELETE) tercih edilmiştir.
- 🧱 Katmanlı mimariye uygun yapı korunmuştur.
- 🔗 Frontend ile Backend arasındaki iletişim yalnızca API üzerinden gerçekleşir.
- 🧼 Stateless yapı benimsenmiştir: Sunucu gelen her isteği bağımsız işler.
- 🔎 URL'ler kaynak odaklıdır. Örnek:  
  - `/api/products`  
  - `/api/reservations/5`  
  - `/api/users/login`

---

## 🗺️ Dinamik Harita Entegrasyonu
- Google Maps API ile restoranın lokasyonu dinamik olarak kullanıcı arayüzüne yansıtılır.
- Lokasyon verisi MongoDB'den çekilir ve canlı olarak harita üzerinde gösterilir.

---

## 🧰 Kullanılan Teknolojiler ve Özellikler
- .NET 8
- ASP.NET Core Web API
- ASP.NET Core MVC
- MongoDB
- Microsoft SQL Server
- MailKit
- Google Maps API
- Generic Repository Pattern
- N Katmanlı Mimari
- CleanCode Prensipleri
- SOLID Prensipleri

### 🏗️ Generic Repository Design Pattern
- Her entity için ayrı CRUD işlemleri yazmak yerine, generic yapılar kullanılarak kod tekrarı önlendi.
- Test edilebilirlik ve bakım kolaylığı sağlandı.

### 🛢️ Veritabanları
- **MongoDB**:  
  - Esnek yapısıyla restoran içeriği, ürünler ve dinamik sayfa verileri bu veritabanında tutulur.
  - ![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/b036e69c421eedef08a24ac2828203a1427c767e/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20190000.png)
- **MsSQL + Identity Library**:  
  - Kullanıcı kimlik doğrulama ve yetkilendirme işlemleri için kullanılır.
  - Kullanıcı kayıt, giriş ve rollerin yönetimi gerçekleştirilir.
   ![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/b036e69c421eedef08a24ac2828203a1427c767e/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20190055.png)
---

## ✉️ Mail Entegrasyonu (MailKit)

Rezervasyon yapıldığında, kullanıcıya aşağıdaki formatta otomatik e-posta gönderilir:
Sayın [Ad Soyad],

- **Rezervasyonunuz başarıyla alınmıştır**.
**Tarih: [Rezervasyon Tarihi]**

**Saat ve masa bilgisi için tarafımızdan aranacaksınız.**

**Teşekkürler**.


- Gönderilen bilgiler dinamik olarak kullanıcıdan alınır.
- Arka planda **MailKit** kütüphanesi ile gönderim yapılır.
  ![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/b036e69c421eedef08a24ac2828203a1427c767e/Images/WhatsApp%20G%C3%B6rsel%202025-06-03%20saat%2019.02.59_db54ebf8.jpg)
---

## 🔐 Erişim ve Güvenlik

- Giriş yapılmadıysa kullanıcılar otomatik olarak giriş sayfasına yönlendirilir.
- Giriş yapıldıktan sonra yalnızca yetkili olunan alanlara erişilebilir.
- Tanımsız veya yetkisiz URL erişim denemelerinde özel bir **404 - Sayfa Bulunamadı** ekranı gösterilir ve kullanıcı ana sayfaya yönlendirilir.

---

## 🧑‍💼 Admin Panel Özellikleri

Yönetici aşağıdaki Entity’ler üzerinde **CRUD** işlemleri gerçekleştirebilir:

- `About`, `BookATable`, `Category`, `ContactDetail`, `ContactUs`, `Feature`, `Gallery`, `OurSpecial`, `Product`, `Service`, `Team`, `Testimonial`, `WhyUs`

---

## 👥 Kullanıcı Arayüzü (UI) Özellikleri

- Ana sayfa, hakkımızda, menü, spesiyaller, hizmetler, ekip, galeri ve iletişim sayfalarında gezinebilir.
- **Rezervasyon Yap** alanından restoran rezervasyonu oluşturabilir.
- Rezervasyon yapıldığında anlık olarak bilgilendirme e-postası alır.
- Memnuniyet veya şikayet mesajlarını iletebilir.

---

## 📸 Görseller
 ![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/b036e69c421eedef08a24ac2828203a1427c767e/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20163859.png)
 
 ![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/b036e69c421eedef08a24ac2828203a1427c767e/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20163905.png)

 ![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/b036e69c421eedef08a24ac2828203a1427c767e/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20163910.png)

 ![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/b036e69c421eedef08a24ac2828203a1427c767e/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20164148.png)

 ![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/b036e69c421eedef08a24ac2828203a1427c767e/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20164154.png)

  ![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/b036e69c421eedef08a24ac2828203a1427c767e/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20164202.png)
  
 ![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/b036e69c421eedef08a24ac2828203a1427c767e/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20164211.png)
 
  ![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/b036e69c421eedef08a24ac2828203a1427c767e/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20164216.png)
  
 ![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/b036e69c421eedef08a24ac2828203a1427c767e/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20164221.png)

  ![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/b036e69c421eedef08a24ac2828203a1427c767e/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20163929.png)

   ![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/b036e69c421eedef08a24ac2828203a1427c767e/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20163940.png)
   
   ![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/b036e69c421eedef08a24ac2828203a1427c767e/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20163922.png)

  ![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/b036e69c421eedef08a24ac2828203a1427c767e/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20164136.png)

  ![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/b036e69c421eedef08a24ac2828203a1427c767e/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20164136.png)
  
![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/b036e69c421eedef08a24ac2828203a1427c767e/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20164237.png)
  ![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/b036e69c421eedef08a24ac2828203a1427c767e/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20164247.png)
    ![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/b036e69c421eedef08a24ac2828203a1427c767e/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20164253.png)
      ![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/b036e69c421eedef08a24ac2828203a1427c767e/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20164258.png)
![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/b036e69c421eedef08a24ac2828203a1427c767e/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20164306.png)
  ![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/b036e69c421eedef08a24ac2828203a1427c767e/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20164312.png)
    ![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/b036e69c421eedef08a24ac2828203a1427c767e/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20164318.png)
      ![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/b036e69c421eedef08a24ac2828203a1427c767e/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20164324.png)
![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/b036e69c421eedef08a24ac2828203a1427c767e/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20164335.png)
  ![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/b036e69c421eedef08a24ac2828203a1427c767e/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20164344.png)
    ![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/b036e69c421eedef08a24ac2828203a1427c767e/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20164352.png)
      ![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/b036e69c421eedef08a24ac2828203a1427c767e/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20164358.png)
 ![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/b036e69c421eedef08a24ac2828203a1427c767e/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20164403.png)
    ![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/b036e69c421eedef08a24ac2828203a1427c767e/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20164419.png)

   ![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/0e168b6ab5eefdc3fbd02bef6000cc931e709d66/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20183930.png)
 ![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/0e168b6ab5eefdc3fbd02bef6000cc931e709d66/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20183910.png)
    ![ImageAlt](https://github.com/SemihSanli/MongoNoSQLRestaurant/blob/0e168b6ab5eefdc3fbd02bef6000cc931e709d66/Images/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-06-03%20183850.png)

   


