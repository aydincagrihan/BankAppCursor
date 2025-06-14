namespace BankApp.Application.Features.IndividualCustomers.Constants
{
    /// <summary>
    /// Bireysel müşteriler için sabit mesajlar.
    /// </summary>
    public static class Messages
    {
        public const string IndividualCustomerNotFound = "Bireysel müşteri bulunamadı.";
        public const string IndividualCustomerAlreadyExists = "Bu TC kimlik numarasına sahip bir bireysel müşteri zaten mevcut.";
        public const string IndividualCustomerCreated = "Bireysel müşteri başarıyla oluşturuldu.";
        public const string IndividualCustomerUpdated = "Bireysel müşteri başarıyla güncellendi.";
        public const string IndividualCustomerDeleted = "Bireysel müşteri başarıyla silindi.";
        public const string InvalidIdentityNumber = "Geçersiz TC kimlik numarası.";
        public const string InvalidPhoneNumber = "Geçersiz telefon numarası.";
        public const string InvalidEmail = "Geçersiz email adresi.";
        public const string InvalidMonthlyIncome = "Geçersiz aylık gelir.";
        public const string RequiredFields = "Lütfen tüm zorunlu alanları doldurun.";
    }
} 