using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvCrud.Models;
using System.Data.Entity;
using System.Data;

namespace MvCrud.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente/Index
        public ActionResult Index()
        {
            using (DbModel dbModel = new DbModel())
            {
                return View(dbModel.Clientes.ToList());
            }
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {

            using (DbModel dbModel = new DbModel())
            {
                return View(dbModel.Clientes.Where(x => x.Id == id).FirstOrDefault());
            }
           
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                using (DbModel dbModel = new DbModel())
                {
                    dbModel.Clientes.Add(cliente);
                    dbModel.SaveChanges();
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModel dbModel = new DbModel())
            {
                return View(dbModel.Clientes.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Cliente cliente)
        {
            try
            {
                using (DbModel dbmodel = new DbModel())
                {
                    dbmodel.Entry(cliente).State = EntityState.Modified;
                    dbmodel.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModel dbModel = new DbModel())
            {
                return View(dbModel.Clientes.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DbModel dbModel = new DbModel())
                {
                    Cliente cliente = dbModel.Clientes.Where(x => x.Id == id).FirstOrDefault();
                    dbModel.Clientes.Remove(cliente);
                    dbModel.SaveChanges();
                }
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
