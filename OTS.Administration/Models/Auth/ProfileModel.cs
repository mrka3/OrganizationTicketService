﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OTS.Administration.Models.Auth
{
    public class ProfileModel
    {
        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Не указана электронная почта")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Не указан логин")]
        public string Login { get; set; }
        
        public IList<ProfileEventsModel> Events { get; set; }

        public ProfileModel()
        {
            Events = new List<ProfileEventsModel>();
        }
    }
}