using System.ComponentModel.DataAnnotations;

namespace OTS.Administration.Models.Users.CreateEdit
{
    public class UserForm
    {
        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Не указана электронная почта")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Не указан логин")]
        public string Login { get; set; }
        public bool IsAdmin { get; set; }

    }
}