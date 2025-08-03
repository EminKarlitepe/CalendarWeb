# 🗓️ CalendarWeb - Etkinlik ve Takvim Yönetim Uygulaması

## 📌 Proje Hakkında  
**CalendarWeb**, kullanıcıların etkinlik ve kategori yönetimi yapabildiği, etkinlikleri takvim üzerinde 🎯 **sürükle-bırak** yöntemiyle planlayabildiği modern bir **ASP.NET MVC tabanlı web uygulamasıdır**.  
Kategorilere renk atanabilir, etkinlikler görsel olarak listelenebilir ve kullanıcı dostu arayüz ile tüm veriler kolayca yönetilebilir.

---

## ⚙️ Kullanılan Teknolojiler  

| Teknoloji             | Açıklama                                   |
|-----------------------|---------------------------------------------|
| 🧰 ASP.NET MVC 5       | Backend ve View katmanlarının yönetimi     |
| 🛠️ Entity Framework    | ORM, Code First veri tabanı işlemleri      |
| 🗄️ SQL Server          | Veritabanı yönetimi                        |
| 💡 jQuery             | Frontend etkileşimleri                     |
| 📆 FullCalendar.js     | Takvim görünümü ve drag-drop desteği       |
| 🎨 Bootstrap 4         | Responsive ve modern kullanıcı arayüzü     |
| 🧱 AdminLTE            | Hazır yönetim paneli teması                |

---

## 🧪 Kullanım Senaryoları  

### 🎨 1. Kategori Yönetimi  
- ➕ Yeni kategori eklenebilir (isim + renk seçimi)  
- 🧱 Kategoriler, kendilerine ait renklerle veri tabanına kaydedilir

### 🗓️ 2. Etkinlik Yönetimi  
- ➕ Yeni etkinlik oluşturulabilir (başlık + kategori)  
- 🌈 Etkinlikler, ait olduğu kategori rengiyle takvimde gösterilir  
- 🔄 Takvim üzerinden farklı tarihlere taşınabilir
- 📦 Etkinlikler ay bazında kartlarla listelenir  

### 🖱️ 3. Takvim Üzerinde Sürükle-Bırak  
- 🎯 Sol paneldeki dış etkinlik kutuları takvime sürüklenebilir  
- 📝 Takvimde tarih değiştirildiğinde veritabanı otomatik güncellenir  

---

## 👤 Kullanıcı Akışı  
1. 🎨 **Kategori Ekle:** Renk ve isim belirle, kategori oluştur  
2. ➕ **Etkinlik Ekle:** Başlık ve kategori seçimi ile etkinlik oluştur  
3. 📆 **Takvimde Görüntüle:** Renk kodlu, düzenli takvim görünümü  
4. 🚚 **Sürükle-Bırak:** Takvim üzerinde tarih değiştir  
5. ✏️ **Sil:** Kartlar üzerinden işlem yap  
6. 🧱 **Kart Görünüm:** Tüm veriler modern kart yapısında listelenir  

---

## 🛠️ Geliştirme Aşamaları  
✅ Entity ve Migration yapısı oluşturuldu  
✅ Controller ve View katmanları yapılandırıldı  
✅ FullCalendar ile takvim ve drag-drop entegrasyonu sağlandı  
✅ Kategori ve Etkinlik CRUD işlemleri tamamlandı  
✅ Kart yapısı ile modern görsel listeleme geliştirildi  
✅ Veritabanı ile senkron, tam fonksiyonel sistem kuruldu  

## 🖼️ Proje Görselleri
<img width="1913" height="954" alt="Events" src="https://github.com/user-attachments/assets/6644ba69-ab78-4951-9014-eaa7a5537488" />
<img width="1916" height="954" alt="Categories" src="https://github.com/user-attachments/assets/72bc0bde-980f-4657-ab37-00492e8698a9" />
