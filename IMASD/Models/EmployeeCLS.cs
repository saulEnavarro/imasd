using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMASD.Models
{
    public class EmployeeCLS
    {
        [Display(Name = "Id Empleado")]
        public int idEmployee { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        [StringLength(50,ErrorMessage ="La longitud máxima es 50")]
        public string name { get; set; }
        [Display(Name = "Apellido")]
        [Required]
        [StringLength(50, ErrorMessage = "La longitud máxima es 50")]
        public string lastName { get; set; }
        [Display(Name = "Teléfono")]
        [StringLength(50, ErrorMessage = "La longitud máxima es 10")]
        public string phoneNumber { get; set; }
        [Display(Name = "Correo")]
        [Required]
        [StringLength(50, ErrorMessage = "La longitud máxima es 50")]
        [EmailAddress(ErrorMessage ="Email no válido")]
        public string mail { get; set; }
        [Display(Name = "Dirección")]
        [StringLength(50, ErrorMessage = "La longitud máxima es 80")]
        public string direction { get; set; }
        [Display(Name = "Cargo")]
        [Required]
        public int typeUser { get; set; }
        [Display(Name ="Departamento")]
        public int idDepartment { get; set; }
        [Display(Name = "Sueldo")]
        public int idSalary{ get; set; }
        public int isActive { get; set; }

        //Aditional Fields
        public string departmentName { get; set; }
        public string amoutSalary { get; set; }
        
    }
}