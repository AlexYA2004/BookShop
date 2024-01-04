using System.ComponentModel.DataAnnotations;

namespace BookShop.Domain.Entities
{
    public class Book : BaseEntity
    {
        [Required]
        [Key]
        public int BookId
        {
            get;

            set;
        }

        [Required]
        public string BookTitle 
        {
            get;

            set;
        }

        [Required]
        public int BookPrice { get; set; }

        public ICollection<Authorship> Authorships { get; set; }

        public ICollection<Operationship> Operationships { get; set; }
    }
}
