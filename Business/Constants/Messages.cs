using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
   public static class Messages
    {
        public static string CarAdded = "Araç Eklendi.";
        public static string CarNameInvalid = "Araç açıklaması geçersiz.";
        public static string CarPriceInvalid = "Araç fiyatı geçersiz.";
        public  static string  MaintenanceTime = "Bakım zamanı daha sonra tekrar deneyin.";
        public static string CarsListed = "Araçlar listelendi.";
        public static string CarsListedByColorId = "Araçlar RenkId'ye göre listelendi.";
        public static string CarsListedByBrandId = "Araçlar MarkaId'ye göre listelendi.";
        public static string CarsListedByDailyPrice = "Araçlar günlük fiyata göre listelendi.";
        public static string CarDeleted = "Araç silindi.";
        public static string CarUpdated = "Araç güncellendi.";
        public static string BrandNameInvalid = "Marka adı en az iki karakter olmalıdır. ";
        public static string BrandAdded = "Marka eklendi.";
        public static string BrandsListed = "Markalar listelendi.";
        public static string BrandsListedByName = "Markalar isme göre  listelendi.";
        public static string BrandsListedById = "Markalar Id'ye göre listelendi.";
        public static string BrandDeleted = "Marka silindi.";
        public static string BrandUpdated = "Marka güncellendi.";
        public static string ColorNameInvalid = "Renk adı en az iki karakter olmalıdır. ";
        public static string ColorsListedByName = "Renkler isme göre  listelendi.";
        public static string ColorAdded = "Renk eklendi.";
        public static string ColorsListed = "Renkler listelendi.";
        public static string ColorDeleted = "Renk silindi.";
        public static string ColorUpdated = "Renk güncellendi.";
        public static string PictureInvalid = "Bir arabaya en fazla 5 tane resim eklenebilir.";
        public static string EditCarImageMessage = "Araç resmi başarıyla güncellendi";
        public static string AddCarImageMessage = "Araç resmi başarıyla eklendi";
        public static string DeleteCarImageMessage = "Araç resmi başarıyla silindi";
        public static string ImagesAdded = "Resim eklendi.";
        public static string FailAddedImageLimit = "Resim limitine erişildi!";
        public static string CarImageLimitExceeded = "Arabaya resim ekleme limitine ulaşıldı";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kayıt olundu";
        public static string UserNotFound="Kullanıcı bulunamadı";
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string UserAlreadyExists="Kullanıcı zaten mevcut";
        public static string SuccessfulLogin="Başarılı giriş";
        public static string PasswordError="Parola Hatası";
        public static string UserListed="Kullanıcılar listelendi";
        public static string UserDeleted="Kullanıcı Silindi";
        public static string UserAdded="Kullanıcı Eklendi";
        public static string UserUpdated="Kullanıcı güncellendi";
    }
}
