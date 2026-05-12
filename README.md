# 🚗 RentCarApp - Masaüstü Araç Kiralama Otomasyonu

## 📌 Proje Özeti
Bu proje, araç kiralama şirketlerinin operasyonel süreçlerini yönetebilmesi için geliştirilmiş, **C# Windows Forms** tabanlı bir masaüstü otomasyon uygulamasıdır. Proje; role dayalı yetkilendirme (Admin/Kullanıcı), detaylı form doğrulama (TC Kimlik algoritması vb.) ve ADO.NET üzerinden SQL Server veritabanı entegrasyonu içermektedir.

## ⚙️ Temel Özellikler (Modüller)
* **🔐 Rol Bazlı Yetkilendirme:** Sisteme giriş yapan kullanıcının rolüne göre (`administrator` veya normal kullanıcı) yetki sınırlandırması ve dinamik arayüz yönetimi.
* **👥 Müşteri/Kullanıcı Yönetimi:** Kullanıcı kayıt (TC, Telefon, E-posta validasyonlu), listeleme, güncelleme ve silme (CRUD) işlemleri. Sistem yöneticisi (ID=1) hesaplarının silinmesine karşı güvenlik koruması.
* **🚘 Araç Yönetimi:** Filonun marka, model, yıl, plaka ve günlük fiyat bilgileriyle sisteme eklenmesi ve güncellenmesi.
* **🔑 Kiralama ve Teslim Sistemi:** Araçların anlık durumlarının (`Durum: True/False`) takibi. Kiralanmış bir aracın tekrar kiralanamaması için arayüz seviyesinde (buton inaktifleşmesi) ve veritabanı seviyesinde güvenlik önlemleri.

## 🛠 Kullanılan Teknolojiler
* **Programlama Dili:** C# (.NET Framework)
* **Arayüz:** Windows Forms (WinForms)
* **Veritabanı:** Microsoft SQL Server
* **Veri Erişimi:** ADO.NET (`System.Data.SqlClient`)

## 🚀 Kurulum Adımları
Veritabanı (RentCarDB) yapısını kendi yerel SQL Server'ınızda oluşturarak projeyi çalıştırabilirsiniz:

1. Repoyu bilgisayarınıza klonlayın:
   ```bash
   git clone [https://github.com/erenyakut35/AracKiralamaProje.git](https://github.com/erenyakut35/AracKiralamaProje.git)
