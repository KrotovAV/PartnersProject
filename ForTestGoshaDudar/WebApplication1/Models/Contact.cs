using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Contact
    {
        [Display(Name = "Введите имя")]
        [Required(ErrorMessage = "Поле обязательное для ввода")]
        public string Name { get; set; }

        [Display(Name = "Введите фамилию")]
        [Required(ErrorMessage = "Поле обязательное для ввода")]
        public string Surname { get; set; }

        [Display(Name = "Введите возраст")]
        [Required(ErrorMessage = "Поле обязательное для ввода")]
        public int Age { get; set; }

        [Display(Name = "Введите адрес почты")]
        [Required(ErrorMessage = "Поле обязательное для ввода")]
        public string Email { get; set; }

        [Display(Name = "Введите сообщение")]
        [Required(ErrorMessage = "Поле обязательное для ввода")]
        [StringLength(45, ErrorMessage ="Текст должен быть не более 45 символов")]

        public string Message { get; set; }
    }
}
