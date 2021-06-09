using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    //static new lememek için
    public static class Messages
    {
        public static string DeviceAdded = "Cihaz Eklendi";
        public static string DeviceNameInvalid = "Cihaz ismi geçersiz";
        public static string MaintenanceTime="Sistem bakımda";
        public static string DevicesListed="Urunler listelendi";
        public static string DeviceAddressAlreadyExist="Bu Adreste kayılı bir cihazınız bulunmakta(Adresler Farklı Olmalıdır!!!)";
        public static string EmployeeLimitExceted="Elaman ekleme limiti aşıldı";
        public static string AuthorizationDenied="Yetkiniz Yoktur";
        public static string UserRegistered="Kullanıcı Kayıt Edildi";
        public static string UserNotFound="Kullanıcı Bulunamadı";
        public static string PasswordError = "Sifre Hatali";
        public static string SuccessfulLogin = "Giris Basarili";
        public static string UserAlreadyExists = "Kullanıcı Zaten Kayıtlı";
        public static string AccessTokenCreated = "Giris Basarili";

    }
    
}
