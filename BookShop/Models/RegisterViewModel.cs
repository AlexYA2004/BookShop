using System.ComponentModel.DataAnnotations;

namespace BookShop.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Введите имя пользователя")]
        [MaxLength(20, ErrorMessage ="Имя пользователя должно иметь длину менее 20 символов")]
        [MinLength(3, ErrorMessage = "Имя пользователя должно иметь длину более 3 символов")]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Введите пароль")]
        [MaxLength(10, ErrorMessage ="Пароль должен иметь длинну менее 10 символов")]
        [MinLength(4, ErrorMessage = "Пароль должен иметь длинну более 4 символов.")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Подтвердите пароль")]
        [Compare("Password" ,ErrorMessage ="Пароли не совпадают") ]
        [Display(Name = "Подтвердите пароль")]
        public string ConfirmPassword { get; set; }


    }
}
