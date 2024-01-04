using System.ComponentModel.DataAnnotations;

namespace BookShop.Domain.Entities
{
    public class Operation : BaseEntity
    {
        [Required]
        [Key]
        public int OperationId
        {
            get;

            set;
        }

        [Required]
        public int QuantityChange
            
        {
            get;

            set;
        }

        [Required]
        public DateTime OperationDate { get; set; }

        public Operation() 
        {
         

        }

        public ICollection<Operationship> Operationships { get; set; }
    }
}
