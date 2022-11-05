using BackEnd_BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackEnd_BD.Controllers
{
    public class ProfesoresController : Controller
    {
        // GET: Profesores
        public ActionResult Index()
        {
            using(AlumnoDbContext dbProfesores = new AlumnoDbContext())
            {
                //Select * from alumnos
                return View(dbProfesores.Profesores.ToList());
            }
        }

        public ActionResult Details(int id)
        {
            using (AlumnoDbContext dbProfesores = new AlumnoDbContext())
            {
                Profesores profesores = dbProfesores.Profesores.Find(id);
                if (profesores == null)
                {
                    return HttpNotFound();
                }

                return View(profesores);
            }
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(Profesores profe)
        {
            using (AlumnoDbContext dbProfesores = new AlumnoDbContext())
            {
                dbProfesores.Profesores.Add(profe);
                dbProfesores.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            using (AlumnoDbContext dbProfesores = new AlumnoDbContext())
            {
                return View(dbProfesores.Profesores.Where(x => x.Id == id).FirstOrDefault());
            }
        }
        [HttpPost]

        public ActionResult Edit(Profesores profe)
        {
            using (AlumnoDbContext dbProfesores = new AlumnoDbContext())
            {
                dbProfesores.Entry(profe).State = System.Data.Entity.EntityState.Modified;
                dbProfesores.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            using (AlumnoDbContext dbProfesores = new AlumnoDbContext())
            {
                return View(dbProfesores.Profesores.Where(x => x.Id == id).FirstOrDefault());
            }
        }
        [HttpPost]

        public ActionResult Delete(Profesores profe, int id)
        {
            using (AlumnoDbContext dbProfesores = new AlumnoDbContext())
            {
                Profesores pro = dbProfesores.Profesores.Where(x => x.Id == id).FirstOrDefault();
                dbProfesores.Profesores.Remove(pro);
                dbProfesores.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}