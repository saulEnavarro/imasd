using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMASD.Models;

namespace IMASD.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index(PaymentsCLS sPaymentsCLS)
        {

            List<PaymentsCLS> listPayments = null;

            LlenarDepartamentos();
            ViewBag.listDepartment=listDepartments;
            LlenarEmployee();
            ViewBag.listEmployee = listEmployee;
            int idDepartment= sPaymentsCLS.idDepartment;
            int idEmployee= sPaymentsCLS.idEmployee;
            using (var db    = new Nomina2018Entities5())
            {
                if (idDepartment == 0 && idEmployee == 0)
                {

                    listPayments = (from payment in db.Payment
                                    join employee in db.Employee
                                    on payment.IdEmployee equals employee.IdEmployee
                                    select new PaymentsCLS
                                    {
                                        idPayment = payment.IdPayment,
                                        idEmployee = payment.IdEmployee,
                                        paymentAmount = payment.PaymentAmount,
                                        paymentDate = payment.PaymentDate,
                                        nameEmployee = employee.Name
                                    }).ToList();
                }
                else if(idDepartment != 0 && idEmployee == 0)
                {

                    listPayments = (from payment in db.Payment
                                    join employee in db.Employee
                                    on payment.IdEmployee equals employee.IdEmployee
                                    join department in db.Department
                                    on employee.IdDepartment equals department.IdDepartment
                                    where department.IsActive==1 && department.IdDepartment== idDepartment
                                    select new PaymentsCLS
                                    {
                                        idPayment = payment.IdPayment,
                                        idEmployee = payment.IdEmployee,
                                        paymentAmount = payment.PaymentAmount,
                                        paymentDate = payment.PaymentDate,
                                        nameEmployee = employee.Name
                                    }).ToList();
                }
                else
                {
                    listPayments = (from payment in db.Payment
                                    join employee in db.Employee
                                    on payment.IdEmployee equals employee.IdEmployee
                                    join department in db.Department
                                    on employee.IdDepartment equals department.IdDepartment
                                    where employee.IdEmployee== idEmployee
                                    select new PaymentsCLS
                                    {
                                        idPayment = payment.IdPayment,
                                        idEmployee = payment.IdEmployee,
                                        paymentAmount = payment.PaymentAmount,
                                        paymentDate = payment.PaymentDate,
                                        nameEmployee = employee.Name
                                    }).ToList();
                }
                return View(listPayments);

            }
        }

        public ActionResult Agregar()
        {
            LlenarEmployee();
            ViewBag.listEmployee = listEmployee;
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(PaymentsCLS sPaymentCLS)
        {
            if (!ModelState.IsValid)
            {
                LlenarEmployee();
                ViewBag.listEmployee = listEmployee;
                return View(sPaymentCLS);
            }
            else
            {
                LlenarEmployee();
                ViewBag.listEmployee = listEmployee;

                Payment sPayment = new Payment();
                using(var db = new Nomina2018Entities5())
                {
                    sPayment.IdEmployee=sPaymentCLS.idEmployee;
                    sPayment.PaymentAmount=sPaymentCLS.paymentAmount;
                    sPayment.PaymentDate = sPaymentCLS.paymentDate;
                    db.Payment.Add(sPayment);
                    db.SaveChanges();
                }
                    return RedirectToAction("Index");
            }
            
        }
        List<SelectListItem> listEmployee;
        private void LlenarEmployee()
        {
            using(var db =new Nomina2018Entities5())
            {
                listEmployee = (from employee in db.Employee
                                where employee.IsActive == 1
                                select new SelectListItem
                                {
                                    Text=employee.Name.ToString()+" "+employee.LastName.ToString(),
                                    Value=employee.IdEmployee.ToString()
                                }
                               ).ToList();
                listEmployee.Insert(0, new SelectListItem { Text = "Todos", Value = "" });
            }
        }

        List<SelectListItem> listDepartments;
        public void LlenarDepartamentos()
        {
            using (var db=new Nomina2018Entities5())
            {
                listDepartments = (from department in db.Department
                                   where department.IsActive==1
                                   select new SelectListItem
                                   {
                                       Text = department.Department1,
                                       Value = department.IdDepartment.ToString()
                                   }).ToList();
                listDepartments.Insert(0, new SelectListItem { Text = "Todos", Value = "" });
            }
        }
    
        public ActionResult Editar(int id)
        {
            LlenarEmployee();
            ViewBag.listEmployee = listEmployee;
            PaymentsCLS sPaymentsCLS = new PaymentsCLS();
            using (var db = new Nomina2018Entities5())
            {
                Payment sPayment = db.Payment.Where(payment => payment.IdPayment.Equals(id)).First();
                sPaymentsCLS.idPayment = sPayment.IdPayment;
                sPaymentsCLS.idEmployee = sPayment.IdEmployee;
                sPaymentsCLS.paymentAmount = sPayment.PaymentAmount;
                sPaymentsCLS.paymentDate = sPayment.PaymentDate;
            }
            return View(sPaymentsCLS);
        }
        [HttpPost]
        public ActionResult Editar(PaymentsCLS sPaymentsCLS)
        {
            LlenarEmployee();
            ViewBag.listEmployee = listEmployee;
            if (!ModelState.IsValid)
            {
                LlenarEmployee();
                ViewBag.listEmployee = listEmployee;
                return View(sPaymentsCLS);
            }
            else
            {
                LlenarEmployee();
                ViewBag.listEmployee = listEmployee;
                int idPayment = sPaymentsCLS.idPayment;
                using (var db = new Nomina2018Entities5())
                {
                    Payment sPayments = db.Payment.Where(payment => payment.IdPayment.Equals(idPayment)).First();
                    sPayments.PaymentAmount = sPaymentsCLS.paymentAmount;
                    sPayments.PaymentDate = sPaymentsCLS.paymentDate;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");

            }

            
        }
    }
}