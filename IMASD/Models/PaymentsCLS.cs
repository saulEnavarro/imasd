using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMASD.Models
{
    public class PaymentsCLS
    {
        [Display(Name = "Id Pago")]
        public int idPayment { get; set; }
        [Display(Name ="Id Empleado")]
        [Required]
        public int idEmployee { get; set; }

       
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode=true)]
        [Display(Name = "Fecha de pago")]
        public DateTime paymentDate { get; set; }


        [Display(Name = "Monto de pagado")]
        [Required]
        [Range(0, 9999999999.99 )]
        public decimal paymentAmount { get; set; }
        //Extra field
        [Display(Name = "Nombre")]
        public string nameEmployee { get; set;}
        public int idDepartment { get; set; }
    }
}