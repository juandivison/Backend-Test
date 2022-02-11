namespace BackendApi.Models
{
    using BackendApi.Data.Entities;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.ComponentModel.DataAnnotations;    
    public class BookViewModel : Books
    {
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Codigo")]        
        public int Id { get; set; }
        
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Titulo")]        
        public string Title { get; set; }        

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "#Páginas")]        
        public int PageCount { get; set; }
                
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Excerpt")]        
        public string Excerpt { get; set; }
        
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Fecha de Publicación")]        

        public DateTime PublishDate { get; set; }        
    }
}
