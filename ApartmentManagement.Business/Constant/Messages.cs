using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Business.Constant
{
    public class Messages
    {
        public static string ExpenseTypeAdded = "Gider Türü Eklendi";
        public static string ExpenseTypeRemoved = "Gider Türü Kaldırıldı";
        public static string ExpenseTypeUpdated = "Gider Türü Güncellendı";
        public static string ExpenseTypeNotFound = "Gider Türü Bulunamadı";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string UserRemoved = "Kullanıcı Kaldırıldı";
        public static string PasswordError = "Şifre Hatalı";
        public static string UserLoginSuccessful = "Kullanıcı Girişi Başarılı";
        public static string UserAlreadyExist = "Bu Email ile Kayıtlı Kullanıcı Zaten Mevcut";
        public static string UserAddedWithInfos = "Yeni Kullanıcı Olusturuldu ve Bilgileri Kaydedildi";
        public static string UserPasswordReset = "Kullanıcı Şifresi Sıfırlandı";
        public static string UserUpdated = "Kullanıcı Bilgileri Güncelledi";
        public static string UserDetailNotFound="Kullanıcıya Ait Ayrıntılı Bilgi Bulunamadı";
        public static string UserDetailAlreadyExist= "Bu Kullanıcıya Ait Detay Bilgileri Zaten Mevcut";
        public static string UserDetailAdded="Kullanıcı Detayları Eklendi";
        public static string UserDetailRemoved = "Kullanıcı Detayları Kaldırıldı";
        public static string UserDetailUpdated= "Kullanıcı Detayları Güncelledi";
        public static string MessageSend = "Mesaj Gönderildi";
        public static string RecipientNotFound="Alıcı Bulunamadı";
        public static string UserAddFailed = "Kullanıcı Ekleme İşlemi Başarısız!";
        public static string UserDetailAddFailed = "Kullanıcı Detay Ekleme İşlemi Başarısız!";
        public static string MessageSendAll = "Tüm Kullanıcılara Mesaj Gönderildi";
        public static string UserMessageIncomingNotExist="Gelen Mesaj Kutunuz Boş";
        public static string UserMessageSentNotExist="Giden Mesaj Kutunuz Boş";
        public static string BlockLetterAlreadyExist = "Bu Blok İsmi Zaten Mevcut";
        public static string BlockAdded = "Yeni Blok İsmi Eklendi";
        public static string BlockNotFound = "Blok İsmi Bulunamadı";
        public static string BlockRemoved = "Blok İsmi Kaldırıldı";
        public static string BlockUpdated = "Block İsmi Güncellendi";
        public static string ApartmentAlreadyExist = "Bu Blok ve Numaraya Kayitli Bir Konut Zaten Mevcut";
        public static string ApartmentAdded = "Yeni Konut Bilgisi Eklendi";
        public static string ApartmentNotFound = "Konut Bilgisi Mevcut Değil!";
        public static string ApartmentUpdated = "Konut Bilgisi Güncellendi";
        public static string ApartmentDeleted = "Konunt Bilgisi Kaldırıldı";
        public static string ApartmentUserAlreadyExist="Konut-Kullanıcı Kaydi Zaten Mevcut Lütfen Güncelleme İşlemini Deneyiniz";
        public static string ApartmentUserAdded = "Konut-Kullanıcı Bilgisi Eklendi";
        public static string ApartmentUserOwnerNotFound="Konut-Kullanıcı Bilgisi Bulunamadı, Lütfen Önce Konut Sahibinin Bilgilerini Giriniz";
        public static string ApartmentUserUpdated = "Konut-Kullanıcı Bilgisi Güncellendi";
        public static string ApartmentUserRemoved = "Konut-Kullanıcı Bilgisi Kaldırıldı";
        public static string ApartmentUserNotFound="Konut-Kullanıcı Bilgisi Bulunamadı";
        public static string UserCarNotFound = "Kullanıcıya Aıt Araç Bulunamadı";
        public static string CarListNoxExist = "Araç Listesi Bulunmamakta";
        public static string CarAlreadyExist = "Bu Plakaya Kayıtlı Araç Bilgisi Zaten Mevcut";
        public static string CarAdded = "Araç Bilgisi Eklendi";
        public static string CarNotFound = "Belirtilen Plakada Araç Kaydı Bulunmamakta";
        public static string CarUpdated = "Araç Bilgisi Güncellendi";
        public static string CarRemoved = "Araç Bilgisi Kaldırıldı";
    }
}
