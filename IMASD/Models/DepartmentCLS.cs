using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMASD.Models
{
    public class DepartmentCLS
    {
        [Display(Name = "Id Departamento")]
        public int idDepartment { get; set; }
        [Display(Name = "Departamento")]
        [Required]
        [StringLength(50, ErrorMessage = "La longitud máxima son 50 dígitos")]
        public string department { get; set; }
        [Display(Name = "Ubicacion")]
        [Required]
        [StringLength(50,ErrorMessage ="La longitud máxima son 50 dígitos")]
        public string location { get; set; }
        public int isActive { get; set; }
    }
}