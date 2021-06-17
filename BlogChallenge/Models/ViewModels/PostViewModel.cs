using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogChallenge.Models.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Complete el título de la Publicación")]
        [MaxLength(100, ErrorMessage = "El título no debe contener mas de 100 caracteres")]
        [Display(Name = "Título")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Complete el título de la Publicación")]
        [Display(Name = "Contenido")]
        public string Contain { get; set; }

        [Display(Name = "Imagen")]
        public FormFile Image { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de creación")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Categoría")]
        public string Category { get; set; }
    }
}
