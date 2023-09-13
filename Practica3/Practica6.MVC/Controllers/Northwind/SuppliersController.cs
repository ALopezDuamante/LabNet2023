using Practica7.Entities;
using Practica7.Logic;
using Practica7.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Practica7.MVC.Controllers
{
    public class SuppliersController : Controller
    {
        SuppliersLogic logic = new SuppliersLogic();
        
        public ActionResult Index()
        {
            List<Suppliers> suppliers = logic.GetAll();

            List<SuppliersView> suppliersView = suppliers.Select(s => new SuppliersView
            {
                Id = s.SupplierID,
                CompanyName = s.CompanyName,
                ContactName = s.ContactName,
                Phone = s.Phone,
                
            }).ToList();

            return View(suppliersView);
        }

        public ActionResult Update(int id)
        {
            Suppliers suppliers = logic.GetById(id);
            SuppliersView suppliersView = new SuppliersView
            {
                Id = suppliers.SupplierID,
                CompanyName = suppliers.CompanyName,
                ContactName = suppliers.ContactName,
                Phone = suppliers.Phone
            };
            return View(suppliersView);
        }
        [HttpPost]
        public ActionResult Update(SuppliersView updateObject)
        {
            try
            {
                Suppliers suppliersEntity = new Suppliers { SupplierID = updateObject.Id, 
                    CompanyName = updateObject.CompanyName,
                    ContactName = updateObject.ContactName, 
                    Phone = updateObject.Phone };

                logic.Update(suppliersEntity);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");

            }
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(SuppliersView suppliersView)
        {
            try
            {
                Suppliers suppliersEntity = new Suppliers { CompanyName = suppliersView.CompanyName,
                    ContactName = suppliersView.ContactName, 
                    Phone = suppliersView.Phone };

                logic.Add(suppliersEntity);

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Delete(int id)
        {
            logic.Delete(id);
            return RedirectToAction("Index");
        }
    }
}