using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMASD.Models;

namespace IMASD.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<EmployeeCLS> listEmployee = null;
            using (var db=new Nomina2018Entities5())
            {
                listEmployee = (from employee in db.Employee
                                join department in db.Department
                                on employee.IdDepartment equals department.IdDepartment
                                join salary in db.Salary 
                                on employee.IdSalary equals salary.IdSalary
                                where employee.IsActive==1
                                                   select new EmployeeCLS
                                                   {
                                                       idEmployee = employee.IdEmployee,
                                                       name = employee.Name,
                                                       lastName = employee.LastName,
                                                       phoneNumber = employee.PhoneNumber,
                                                       mail = employee.Mail,
                                                       direction = employee.Direction,
                                                       typeUser = employee.TypeUser,
                                                       departmentName=department.Department1,
                                                       amoutSalary=salary.Amount.ToString()+" "+ salary.Currency.ToString(),
                                                       
                                                   }).ToList();
            }
                return View(listEmployee);
        }
        public ActionResult Agregar()
        {
            LlenarDepartamentos();
            LlenarSalario();
            ViewBag.listDepartment = listDepartments;
            ViewBag.listSalaries = listSalaries;
            return View();
        }

        List<SelectListItem> listDepartments;
        List<SelectListItem> listSalaries;
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
                listDepartments.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
            }
        }
        public void LlenarSalario()
        {
            using (var db = new Nomina2018Entities5())
            {
                listSalaries = (from salaries in db.Salary
                                where salaries.IsActive == 1
                                select new SelectListItem
                                   {
                                       Text = salaries.Amount.ToString()+" "+salaries.Currency.ToString(),
                                       Value = salaries.IdSalary.ToString()
                                   }).ToList();
                listSalaries.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
            }
        }

        [HttpPost]
        public ActionResult Agregar(EmployeeCLS sEmployeeCLS)
        {

            if (!ModelState.IsValid)
            {
                LlenarDepartamentos();
                LlenarSalario();
               ViewBag.listDepartment = listDepartments;
               ViewBag.listSalaries = listSalaries;

                return View(sEmployeeCLS);
            }
            else
            {
                LlenarDepartamentos();
                LlenarSalario();
                ViewBag.listDepartment = listDepartments;
                ViewBag.listSalaries = listSalaries;
                using (var db = new Nomina2018Entities5())
                {
                    Employee sEmployee = new Employee();
                    sEmployee.Name = sEmployeeCLS.name;
                    sEmployee.LastName = sEmployeeCLS.lastName;
                    sEmployee.Mail = sEmployeeCLS.mail;
                    sEmployee.PhoneNumber = sEmployeeCLS.phoneNumber;
                    sEmployee.Direction = sEmployeeCLS.direction;
                    sEmployee.TypeUser = sEmployeeCLS.typeUser;
                    sEmployee.IdDepartment = sEmployeeCLS.idDepartment;
                    sEmployee.IdSalary = sEmployeeCLS.idSalary;
                    sEmployee.IsActive = 1;
                    db.Employee.Add(sEmployee);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
           
        }
        public ActionResult Editar(int id)
        {
            EmployeeCLS sEmployeeCLS = new EmployeeCLS();
            LlenarDepartamentos();
            LlenarSalario();
            ViewBag.listDepartment = listDepartments;
            ViewBag.listSalaries = listSalaries;

            using (var db =new Nomina2018Entities5())
            {
                Employee sEmployee = db.Employee.Where(employee => employee.IdEmployee.Equals(id)).First();
                sEmployeeCLS.idEmployee = sEmployee.IdEmployee;
                sEmployeeCLS.name = sEmployee.Name;
                sEmployeeCLS.lastName = sEmployee.LastName;
                sEmployeeCLS.phoneNumber = sEmployee.PhoneNumber;
                sEmployeeCLS.mail = sEmployee.Mail;
                sEmployeeCLS.direction = sEmployee.Direction;
                sEmployeeCLS.typeUser = sEmployee.TypeUser;
                sEmployeeCLS.idDepartment = (int)sEmployee.IdDepartment;
                sEmployeeCLS.idSalary = (int)sEmployee.IdSalary;

                
            }
                return View(sEmployeeCLS);
        }
        [HttpPost]
        public ActionResult Editar(EmployeeCLS sEmployeeCLS)
        {
            if (!ModelState.IsValid)
            {
                LlenarDepartamentos();
                LlenarSalario();
                ViewBag.listDepartment = listDepartments;
                ViewBag.listSalaries = listSalaries;
                return View(sEmployeeCLS);
            }
            else
            {
                LlenarDepartamentos();
                LlenarSalario();
                ViewBag.listDepartment = listDepartments;
                ViewBag.listSalaries = listSalaries;
                int idEmployee = sEmployeeCLS.idEmployee;
            using(var db = new Nomina2018Entities5())
            {
                Employee sEmployee = db.Employee.Where(employee => employee.IdEmployee.Equals(idEmployee)).First();
                sEmployee.Name = sEmployeeCLS.name;
                sEmployee.LastName = sEmployeeCLS.lastName;
                sEmployee.PhoneNumber = sEmployeeCLS.phoneNumber;
                sEmployee.Mail = sEmployeeCLS.mail;
                sEmployee.Direction = sEmployeeCLS.direction;
                sEmployee.TypeUser = sEmployeeCLS.typeUser;
                sEmployee.IdDepartment = sEmployeeCLS.idDepartment;
                sEmployee.IdSalary = sEmployeeCLS.idSalary;
                    db.SaveChanges(); 
            }
            return RedirectToAction("Index");
            }
        }
        public ActionResult Eliminar(int id)
        {
            using (var db=new Nomina2018Entities5())
            {
                Employee sEmployee = db.Employee.Where(employee=>employee.IdEmployee.Equals(id)).First();
                sEmployee.IsActive = 0;
                db.SaveChanges();
                
            }
            return RedirectToAction("Index");
        }
    }
}