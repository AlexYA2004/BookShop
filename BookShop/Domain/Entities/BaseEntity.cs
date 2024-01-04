using System.ComponentModel.DataAnnotations;

namespace BookShop.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        protected int id;

        [Required]
        protected string name;

        
        protected BaseEntity() { }

    }
}
