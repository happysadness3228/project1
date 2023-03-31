using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        [Required]
        [DisplayName("Артикул")]
        public string article { get; set; }
        [Required]
        [DisplayName("Название")]
        public string name { get; set; }
        [Required]
        [DisplayName("Цена")]

        public string price { get; set; }
        [Required]
        [DisplayName("Размер")]
        public string size { get; set; }
        [Required]
        [DisplayName("Цвет")]
        public string color { get; set; }

        [Key]
        [DisplayName("categories_id")]
        public int categories_id { get; set; }
        [Key]
        [DisplayName("recept_of_products_id")]
        public int recept_of_products_id { get; set; }
    }
}