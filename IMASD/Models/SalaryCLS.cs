using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMASD.Models
{
    public class SalaryCLS
    {
       
        [Key]
        [Display(Name = "Id Salario")]
        public int idSalary { get; set; }
        [Display(Name = "Cantidad")]
        [Required]
        [Range(0, 9999999999.99)]
        public decimal amount { get; set; }
        [Display(Name = "Moneda")]
        [Required]
        [StringLength(10, ErrorMessage = "Longitud máxima es 10 dígitos")]
        public string currency { get; set; }
        public int isActive { get; set; }
    }
}