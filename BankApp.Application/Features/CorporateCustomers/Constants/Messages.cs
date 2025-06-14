namespace BankApp.Application.Features.CorporateCustomers.Constants
{
    /// <summary>
    /// Kurumsal müşteriler için sabit mesajlar.
    /// </summary>
    public static class Messages
    {
        public const string CorporateCustomerNotFound = "Kurumsal müşteri bulunamadı.";
        public const string CorporateCustomerAlreadyExists = "Bu vergi numarasına sahip bir kurumsal müşteri zaten mevcut.";
        public const string CorporateCustomerCreated = "Kurumsal müşteri başarıyla oluşturuldu.";
        public const string CorporateCustomerUpdated = "Kurumsal müşteri başarıyla güncellendi.";
        public const string CorporateCustomerDeleted = "Kurumsal müşteri başarıyla silindi.";
        public const string InvalidTaxNumber = "Geçersiz vergi numarası.";
        public const string InvalidPhoneNumber = "Geçersiz telefon numarası.";
        public const string InvalidEmail = "Geçersiz email adresi.";
        public const string InvalidAnnualRevenue = "Geçersiz yıllık gelir.";
        public const string InvalidNumberOfEmployees = "Geçersiz çalışan sayısı.";
        public const string RequiredFields = "Lütfen tüm zorunlu alanları doldurun.";
    }
} 