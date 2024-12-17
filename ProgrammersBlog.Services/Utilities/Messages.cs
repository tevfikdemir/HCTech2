using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Utilities
{
    public static class Messages
    {
        public static class General
        {
            public static string ValidationError()
            {
                return $"Bir veya daha fazla validasyon hatası ile karşılaşıldı.";
            }
        }
        public static class Category
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir kategori bulunamadı.";
                return "Böyle bir kategori bulunamadı.";
            }
            public static string NotFoundById(int categoryId)
            {
                return $"{categoryId} kategori koduna ait bir kategori bulunamadı.";
            }
            public static string Add(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla eklenmiştir.";
            }

            public static string Update(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla güncellenmiştir.";
            }
            public static string Delete(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla silinmiştir.";
            }
            public static string HardDelete(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla veritabanından silinmiştir.";
            }
            public static string UndoDelete(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla arşivden geri getirilmiştir.";
            }
        }
        public static class Personel
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir personel bulunamadı.";
                return "Böyle bir personel bulunamadı.";
            }
            public static string NotFoundById(int categoryId)
            {
                return $"{categoryId} personel koduna ait bir personel bulunamadı.";
            }
            public static string Add(string categoryName)
            {
                return $"{categoryName} adlı personel başarıyla eklenmiştir.";
            }

            public static string Update(string categoryName)
            {
                return $"{categoryName} adlı personel başarıyla güncellenmiştir.";
            }
            public static string Delete(string categoryName)
            {
                return $"{categoryName} adlı personel başarıyla silinmiştir.";
            }
            public static string HardDelete(string categoryName)
            {
                return $"{categoryName} adlı personel başarıyla veritabanından silinmiştir.";
            }
            public static string UndoDelete(string categoryName)
            {
                return $"{categoryName} adlı personel başarıyla arşivden geri getirilmiştir.";
            }
        }
        public static class Gorevler
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir gorev bulunamadı.";
                return "Böyle bir gorev bulunamadı.";
            }
            public static string NotFoundById(int gorevId)
            {
                return $"{gorevId} gorev koduna ait bir kategori bulunamadı.";
            }
            public static string Add(string gorevName)
            {
                return $"{gorevName} adlı gorev başarıyla eklenmiştir.";
            }

            public static string Update(string gorevName)
            {
                return $"{gorevName} adlı gorev başarıyla güncellenmiştir.";
            }
            public static string Delete(string gorevName)
            {
                return $"{gorevName} adlı gorev başarıyla silinmiştir.";
            }
            public static string HardDelete(string gorevName)
            {
                return $"{gorevName} adlı gorev başarıyla veritabanından silinmiştir.";
            }
            public static string UndoDelete(string gorevName)
            {
                return $"{gorevName} adlı gorev başarıyla arşivden geri getirilmiştir.";
            }
        }
        public static class Departman
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir departman bulunamadı.";
                return "Böyle bir departman bulunamadı.";
            }
            public static string NotFoundById(int departmanId)
            {
                return $"{departmanId} departman koduna ait bir departman bulunamadı.";
            }
            public static string Add(string departmanName)
            {
                return $"{departmanName} adlı departman başarıyla eklenmiştir.";
            }

            public static string Update(string departmanName)
            {
                return $"{departmanName} adlı departman başarıyla güncellenmiştir.";
            }
            public static string Delete(string departmanName)
            {
                return $"{departmanName} adlı kategori başarıyla silinmiştir.";
            }
            public static string HardDelete(string departmanName)
            {
                return $"{departmanName} adlı departman başarıyla veritabanından silinmiştir.";
            }
            public static string UndoDelete(string departmanName)
            {
                return $"{departmanName} adlı departman başarıyla arşivden geri getirilmiştir.";
            }
        }
        public static class Order
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir sipariş bulunamadı.";
                return "Böyle bir sipariş bulunamadı.";
            }
            public static string NotFoundById(int orderId)
            {
                return $"{orderId} sipariş koduna ait bir departman bulunamadı.";
            }
            public static string Add(string siparisName)
            {
                return $"{siparisName} adlı sipariş başarıyla eklenmiştir.";
            }

            public static string Update(string siparisName)
            {
                return $"{siparisName} adlı sipariş başarıyla güncellenmiştir.";
            }
            public static string Delete(string siparisName)
            {
                return $"{siparisName} adlı sipariş başarıyla silinmiştir.";
            }
            public static string HardDelete(string siparisName)
            {
                return $"{siparisName} adlı sipariş başarıyla veritabanından silinmiştir.";
            }
            public static string UndoDelete(string siparisName)
            {
                return $"{siparisName} adlı sipariş başarıyla arşivden geri getirilmiştir.";
            }
        }
        public static class OrderSize
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir sipariş bulunamadı.";
                return "Böyle bir sipariş bulunamadı.";
            }
            public static string NotFoundById(int orderId)
            {
                return $"{orderId} sipariş koduna ait bir departman bulunamadı.";
            }
            public static string Add(string siparisName)
            {
                return $"{siparisName} adlı sipariş başarıyla eklenmiştir.";
            }

            public static string Update(string siparisName)
            {
                return $"{siparisName} adlı sipariş başarıyla güncellenmiştir.";
            }
            public static string Delete(string siparisName)
            {
                return $"{siparisName} adlı sipariş başarıyla silinmiştir.";
            }
            public static string HardDelete(string siparisName)
            {
                return $"{siparisName} adlı sipariş başarıyla veritabanından silinmiştir.";
            }
            public static string UndoDelete(string siparisName)
            {
                return $"{siparisName} adlı sipariş başarıyla arşivden geri getirilmiştir.";
            }
        }
        public static class Bedenler
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir beden bulunamadı.";
                return "Böyle bir beden bulunamadı.";
            }
            public static string NotFoundById(int bedenId)
            {
                return $"{bedenId} beden koduna ait bir beden bulunamadı.";
            }
            public static string Add(string bedenName)
            {
                return $"{bedenName} adlı beden başarıyla eklenmiştir.";
            }

            public static string Update(string bedenName)
            {
                return $"{bedenName} adlı beden başarıyla güncellenmiştir.";
            }
            public static string Delete(string bedenName)
            {
                return $"{bedenName} adlı beden başarıyla silinmiştir.";
            }
            public static string HardDelete(string bedenName)
            {
                return $"{bedenName} adlı beden başarıyla veritabanından silinmiştir.";
            }
            public static string UndoDelete(string bedenName)
            {
                return $"{bedenName} adlı beden başarıyla arşivden geri getirilmiştir.";
            }
        }
        public static class Operation
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir operasyon bulunamadı.";
                return "Böyle bir operasyon bulunamadı.";
            }
            public static string NotFoundById(int operasyonId)
            {
                return $"{operasyonId} operasyon koduna ait bir operasyon bulunamadı.";
            }
            public static string Add(string operasyonName)
            {
                return $"{operasyonName} adlı operasyon başarıyla eklenmiştir.";
            }

            public static string Update(string operasyonName)
            {
                return $"{operasyonName} adlı operasyon başarıyla güncellenmiştir.";
            }
            public static string Delete(string operasyonName)
            {
                return $"{operasyonName} adlı operasyon başarıyla silinmiştir.";
            }
            public static string HardDelete(string operasyonName)
            {
                return $"{operasyonName} adlı operasyon başarıyla veritabanından silinmiştir.";
            }
            public static string UndoDelete(string operasyonName)
            {
                return $"{operasyonName} adlı operasyon başarıyla arşivden geri getirilmiştir.";
            }
        }
        public static class Firmalar
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir firma bulunamadı.";
                return "Böyle bir firma bulunamadı.";
            }
            public static string NotFoundById(int firmaId)
            {
                return $"{firmaId} firma koduna ait bir firma bulunamadı.";
            }
            public static string Add(string firmaName)
            {
                return $"{firmaName} adlı firma başarıyla eklenmiştir.";
            }

            public static string Update(string firmaName)
            {
                return $"{firmaName} adlı firma başarıyla güncellenmiştir.";
            }
            public static string Delete(string firmaName)
            {
                return $"{firmaName} adlı firma başarıyla silinmiştir.";
            }
            public static string HardDelete(string firmaName)
            {
                return $"{firmaName} adlı firma başarıyla veritabanından silinmiştir.";
            }
            public static string UndoDelete(string firmaName)
            {
                return $"{firmaName} adlı firma başarıyla arşivden geri getirilmiştir.";
            }
        }
        public static class Article
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Makaleler bulunamadı.";
                return "Böyle bir makale bulunamadı.";
            }
            public static string NotFoundById(int articleId)
            {
                return $"{articleId} makale koduna ait bir makale bulunamadı.";
            }
            public static string Add(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla eklenmiştir.";
            }

            public static string Update(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla güncellenmiştir.";
            }
            public static string Delete(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla silinmiştir.";
            }
            public static string HardDelete(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla veritabanından silinmiştir.";
            }
            public static string UndoDelete(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla arşivden geri getirilmiştir.";
            }
            public static string IncreaseViewCount(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale'nin okunma sayısı başarıyla arttırılmıştır.";
            }
        }
        public static class Comment
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir yorum bulunamadı.";
                return "Böyle bir yorum bulunamadı.";
            }

            public static string Approve(int commentId)
            {
                return $"{commentId} no'lu yorum başarıyla onaylanmıştır.";
            }
            public static string Add(string createdByName)
            {
                return $"Sayın {createdByName}, yorumunuz başarıyla eklenmiştir.";
            }

            public static string Update(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla güncellenmiştir.";
            }
            public static string Delete(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla silinmiştir.";
            }
            public static string HardDelete(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla veritabanından silinmiştir.";
            }
            public static string UndoDelete(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla arşivden geri getirilmiştir.";
            }
        }
        public static class User
        {
            //public static string NotFound(bool isPlural)
            //{
            //    if (isPlural) return "Hiç bir kategori bulunamadı.";
            //    return "Böyle bir kategori bulunamadı.";
            //}
            public static string NotFoundById(int userId)
            {
                return $"{userId} kullanıcı koduna ait bir kullanıcı bulunamadı.";
            }
            //public static string Add(string categoryName)
            //{
            //    return $"{categoryName} adlı kategori başarıyla eklenmiştir.";
            //}

            //public static string Update(string categoryName)
            //{
            //    return $"{categoryName} adlı kategori başarıyla güncellenmiştir.";
            //}
            //public static string Delete(string categoryName)
            //{
            //    return $"{categoryName} adlı kategori başarıyla silinmiştir.";
            //}
            //public static string HardDelete(string categoryName)
            //{
            //    return $"{categoryName} adlı kategori başarıyla veritabanından silinmiştir.";
            //}
            //public static string UndoDelete(string categoryName)
            //{
            //    return $"{categoryName} adlı kategori başarıyla arşivden geri getirilmiştir.";
            //}
        }
    }
}
