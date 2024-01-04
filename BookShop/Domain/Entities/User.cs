using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Domain.Entities
{
    public class User : BaseEntity
    {
        
        [Key]
        public int UserId {  get; set; }

        [Required]
        public string UserName 
        {
            get;

            set;
        }
        [Required]
        public string Password
        {
            get;

            set;
        }

        public User()
        {

        }

        public User (string inputName, string inputPassword)
        {
            UserName = inputName;

            Password = inputPassword;
        }
    }
}
