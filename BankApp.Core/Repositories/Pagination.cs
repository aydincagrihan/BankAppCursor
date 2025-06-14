namespace BankApp.Core.Repositories
{
    /// <summary>
    /// Generic sayfalama sınıfı. Tüm entity'ler için sayfalama işlemlerini yönetir.
    /// </summary>
    /// <typeparam name="T">Sayfalanacak entity tipi</typeparam>
    public class Pagination<T>
    {
        /// <summary>
        /// Mevcut sayfa numarası
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// Sayfa başına gösterilecek kayıt sayısı
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Toplam kayıt sayısı
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Toplam sayfa sayısı
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Önceki sayfa var mı?
        /// </summary>
        public bool HasPreviousPage => PageIndex > 1;

        /// <summary>
        /// Sonraki sayfa var mı?
        /// </summary>
        public bool HasNextPage => PageIndex < TotalPages;

        /// <summary>
        /// Sayfadaki kayıtlar
        /// </summary>
        public IList<T> Items { get; set; } = new List<T>();
    }
} 