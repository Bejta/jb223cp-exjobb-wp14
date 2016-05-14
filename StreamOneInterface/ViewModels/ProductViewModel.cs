using StreamOneInterface.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StreamOneInterface.ViewModels
{
    public class ProductViewModel
    {
        [Display(Name = "Product ID")]
        [Required(ErrorMessage = "Required field")]
        public int Id { get; set; }

        [Display(Name ="Stream One Number")]
        [Required(ErrorMessage = "Required field")]
        public string StreamOneNumber { get; set; }

        [Display(Name = "Share Number")]
        [Required(ErrorMessage = "Required field")]
        public string ShareNumber { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Required field")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Required field")]
        public string Description { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Required field")]
        public bool Active { get; set; }

        public ProductViewModel()
        {
            //Empty
        }
        public ProductViewModel(Product entity)
        {
            Id = entity.Id;
            StreamOneNumber = entity.StreamOneNumber;
            ShareNumber = entity.ShareNumber;
            Name = entity.Name;
            Description = entity.Description;
            Active = entity.Active;         
        }
    }
}