using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMASD.Models;

namespace IMASD.Controllers
{
    public class SalaryController : Controller
    {
        // GET: Salary
        public ActionResult Index()
        { List<SalaryCLS> listSalary = null;
            using (var db = new Nomina2018Entities5())
            {
                listSalary = (from salary in db.Salary
                              where salary.IsActive==1
                              select new SalaryCLS
                              {
                                  idSalary = salary.IdSalary,
                                  amount = salary.Amount,
                                  currency = salary.Currency
                              }).ToList();
            }
            return View(listSalary);
        }
        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(SalaryCLS sSalaryCLS)
        {
            if (!ModelState.IsValid)
            {
                return View(sSalaryCLS);
            }
            else
            {
                using (var db = new Nomina2018Entities5())
                {
                    Salary salary = new Salary();
                    salary.IdSalary = sSalaryCLS.idSalary;
                    salary.Amount = sSalaryCLS.amount;
                    salary.Currency = sSalaryCLS.currency;
                    db.Salary.Add(salary);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

        }
        public ActionResult Editar(int id)
        {
            SalaryCLS sSalaryCLS = new SalaryCLS();
            using (var db = new Nomina2018Entities5())
            {
                Salary sSalary = db.Salary.Where(salary => salary.IdSalary.Equals(id)).First();
                sSalaryCLS.idSalary = sSalary.IdSalary;
                sSalaryCLS.amount = sSalary.Amount;
                sSalaryCLS.currency = sSalary.Currency;
            }
            return View(sSalaryCLS);
        }
        [HttpPost]
        public ActionResult Editar(SalaryCLS sSalaryCLS)
        {
            int idSalary = sSalaryCLS.idSalary;
            if (!ModelState.IsValid)
            {
                return View(sSalaryCLS);
            }
            else
            {
                using (var db=new Nomina2018Entities5())
                {
                    Salary sSalary= db.Salary.Where(salary=>salary.IdSalary.Equals(idSalary)).First();
                    sSalary.Amount = sSalaryCLS.amount;
                    sSalary.Currency = sSalaryCLS.currency;
                    db.SaveChanges();
                }
                    return RedirectToAction("Index");
            }
        }
        public ActionResult Eliminar(int id)
        {
            using (var db =new Nomina2018Entities5())
            {
                Salary sSalary = db.Salary.Where(salary => salary.IdSalary.Equals(id)).First();
                sSalary.IsActive = 0;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
        }
    }
}