using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Domain.Entities
{
    public class Operationship : BaseEntity
    {
        [Required]
        public int BookID { get; set; }

        [Required]
        public int OperationID { get; set; }

        public Operation Operation { get; set; }

        public Book Book { get; set; }
    }
}
