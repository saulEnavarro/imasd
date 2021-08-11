using IMASD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMASD.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            List<DepartmentCLS> listDepartmetns=null;
            using (var db = new Nomina2018Entities5())
            {
                listDepartmetns = (from departments in db.Department
                                   where departments.IsActive==1
                                   select new DepartmentCLS
                                   {
                                       idDepartment = departments.IdDepartment,
                                       department = departments.Department1,
                                       location=departments.Location

                                   }).ToList();
            }


                return View(listDepartmetns );
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(DepartmentCLS sdepartmentCLS)
        {
            if (!ModelState.IsValid)
            {
                return View(sdepartmentCLS);
            }
            else
            {
                using (var db = new Nomina2018Entities5()){
                    Department department = new Department();
                    department.Department1 = sdepartmentCLS.department;
                    department.Location = sdepartmentCLS.location;
                    department.IsActive = 1;
                    db.Department.Add(department);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
        }
        public ActionResult Editar(int id)
        {
            DepartmentCLS sDepartmenCLS = new DepartmentCLS();

            using (var db = new Nomina2018Entities5())
            {
                Department sDepartment = db.Department.Where(department=>department.IdDepartment.Equals(id)).First();
                sDepartmenCLS.idDepartment = sDepartment.IdDepartment;
                sDepartmenCLS.department = sDepartment.Department1;
                sDepartmenCLS.location = sDepartment.Location;

            }
                return View(sDepartmenCLS);
        }

        [HttpPost]
        public ActionResult Editar(DepartmentCLS sDepartmentCLS)
        {
            int idDepartment=sDepartmentCLS.idDepartment;
            if (!ModelState.IsValid)
            {
                return View(sDepartmentCLS);
            }
            else
            {
                using (var db = new Nomina2018Entities5())
                {
                    Department sDepartment = db.Department.Where(department=>department.IdDepartment.Equals(idDepartment)).First();
                    sDepartment.Department1 = sDepartmentCLS.department;
                    sDepartment.Location = sDepartmentCLS.location;
                    db.SaveChanges();
                }
                    return RedirectToAction("Index");
            }
        }
        public ActionResult Eliminar(int id)
        {
            using (var db =new Nomina2018Entities5())
            {
                Department sDepartment = db.Department.Where(department=>department.IdDepartment.Equals(id)).First();
                sDepartment.IsActive=0;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}