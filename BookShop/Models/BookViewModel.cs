using System.ComponentModel.DataAnnotations;
using BookShop.Domain.Entities;

namespace BookShop.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Автор")]
        public string AuthorName { get; set; }

        [Display(Name = "Стоимость")]
        public int Price { get; set; }

        public byte[]? Image { get; set; }


    }
}
