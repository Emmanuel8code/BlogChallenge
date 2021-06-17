using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogChallenge.Models.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Complete el nombre de la categoría")]
        [MaxLength(100, ErrorMessage = "El nombre no debe contener mas de 100 caracteres")]
        [Display(Name = "Nombre")]
        public string Title { get; set; }
    }
}
