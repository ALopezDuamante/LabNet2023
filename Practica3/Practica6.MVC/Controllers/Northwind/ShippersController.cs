using Practica7.Entities;
using Practica7.Logic;
using Practica7.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Practica7.MVC.Controllers
{
    public class ShippersController : Controller
    {
        ShippersLogic logic = new ShippersLogic();

        public ActionResult Index()
        {
            List<Shippers> shippers = logic.GetAll();

            List<ShippersView> shippersView = shippers.Select(s => new ShippersView
            {
                Id = s.ShipperID,
                CompanyName = s.CompanyName,
                Phone = s.Phone,
            }).ToList();

            return View(shippersView);
        }

        public ActionResult Update(int id)
        {
            Shippers shipper = logic.GetById(id);
            ShippersView shippersView = new ShippersView
            {
                Id = shipper.ShipperID,
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone
            };
            return View(shippersView);
        }
        [HttpPost]
        public ActionResult Update(ShippersView updateObject)
        {
            try
            {
                Shippers shippersEntity = new Shippers { ShipperID = updateObject.Id, CompanyName = updateObject.CompanyName, Phone = updateObject.Phone };
                logic.Update(shippersEntity);
                return RedirectToAction("Index");

            }catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");

            }
        }

        public ActionResult Insert() {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(ShippersView shippersView) {
            try
            {
                Shippers shippersEntity = new Shippers { CompanyName = shippersView.CompanyName, Phone = shippersView.Phone };
                logic.Add(shippersEntity);

                return RedirectToAction("Index");

            }catch (Exception ex)
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