using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Buyers
    {
        [Key]
        public int id { get; set; }
        [Required]
        [DisplayName("Имя")]
        public string name { get; set; }
        [Required]
        [DisplayName("Фамилия")]
        public string surname { get; set; }
        [Required]
        [DisplayName("Адрес")]

        public string adress { get; set; }
        [Required]
        [DisplayName("Почтовый индекс")]
        public int index_mail { get; set; }
        [Required]
        [DisplayName("Телефон")]
        public string phone { get; set; }
    }
}