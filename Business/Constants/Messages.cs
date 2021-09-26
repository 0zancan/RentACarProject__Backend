using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        //Car
        public static string CarAdded = "Araba eklendi.";
        public static string CarNameInvalid = "Araba adı geçersiz.";
        public static string CarsListed = "Arabalar listelendi.";
        public static string CarDeleted = "Araba silindi";
        public static string CarUpdated = "Araba güncellendi";

        //Brand
        public static string BrandNameInvalid = "Marka adı geçersiz.";
        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandsListed = "Markalar listelendi.";

        //Rental
        public static string RentalAdded = "Kiralama eklendi";
        public static string RentalDeleted = "Kiralama silindi";
        public static string RentalUpdated = "Kiralama güncellendi";
        public static string RentalsListed = "Kiralama listelendi.";

        //Color
        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorsListed = "Renkler listelendi.";

        //Color
        public static string CustomerListed = "Müşteriler listelendi";
        public static string CustomerAdded = "Müşteriler eklendi";
        public static string CustomerDeleted = "Müşteriler silindi";
        public static string CustomerUpdated = "Müşteriler güncellendi";

        //CarImage
        public static string CarImagAdded = "Araba görseli eklendi.";
        public static string CarImageDeleted = "Araba görseli kaldırıldı.";
        public static string CarImageUpdated = "Araba görseli güncellendi.";
        public static string CarImageNotFound = "Girilen parametlere uygun kayıt bulunamadı.";
        public static string CarImagesListed = "Araba görselleri listelenedi.";
        public static string ImagePathExist = "Görsel pathi bulunamadı.";

        //General
        public static string MaintenanceTime = "Sistem Bakımda.";


        public static string AuthorizationDenied = "Yetkisi yok.";
        internal static string UserRegistered = "Kullanıcı kayıt oldu.";
        internal static string UserNotFound = "Kullanıcı bulunamadı.";
        internal static string PasswordError = "Şifre hatalı.";
        internal static string SuccessfulLogin = "Giriş yapıldı.";
        internal static string UserAlreadyExists = "Kullanıcı zaten mevcut.";
        internal static string AccessTokenCreated = "Token oluşturuldu.";
    }
}
