using System.ComponentModel.DataAnnotations;


namespace BookShop.Domain.Entities
{
    public class Author : BaseEntity
    {
        [Required]
        [Key]
        public int AuthorId
        {
            get;

            set;
        }

        [Required]
        public string AuthorName
        {
            get;

            set;
        }


        public ICollection<Authorship> Authorships { get; set; }
    }
}
