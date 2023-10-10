using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PizzeriaNana.Models;

namespace PizzeriaNana.Controllers
{
    public class DettaglioOrdiniController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: DettaglioOrdini
        public ActionResult Index()
        {
            var dettaglioOrdini = db.DettaglioOrdini.Include(d => d.Ordini).Include(d => d.Prodotti);
            return View(dettaglioOrdini.ToList());
        }

        // GET: DettaglioOrdini/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DettaglioOrdini dettaglioOrdini = db.DettaglioOrdini.Find(id);
            if (dettaglioOrdini == null)
            {
                return HttpNotFound();
            }
            return View(dettaglioOrdini);
        }

        // GET: DettaglioOrdini/Create
        public ActionResult Create()
        {
            ViewBag.IdOrdine = new SelectList(db.Ordini, "IdOrdine", "Indirizzo");
            ViewBag.IdProdotto = new SelectList(db.Prodotti, "IdProdotto", "NomeP");
            return View();
        }

        // POST: DettaglioOrdini/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDettaglio,IdProdotto,Quantità,IdOrdine")] DettaglioOrdini dettaglioOrdini)
        {
            if (ModelState.IsValid)
            {
                db.DettaglioOrdini.Add(dettaglioOrdini);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdOrdine = new SelectList(db.Ordini, "IdOrdine", "Indirizzo", dettaglioOrdini.IdOrdine);
            ViewBag.IdProdotto = new SelectList(db.Prodotti, "IdProdotto", "NomeP", dettaglioOrdini.IdProdotto);
            return View(dettaglioOrdini);
        }

        // GET: DettaglioOrdini/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DettaglioOrdini dettaglioOrdini = db.DettaglioOrdini.Find(id);
            if (dettaglioOrdini == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdOrdine = new SelectList(db.Ordini, "IdOrdine", "Indirizzo", dettaglioOrdini.IdOrdine);
            ViewBag.IdProdotto = new SelectList(db.Prodotti, "IdProdotto", "NomeP", dettaglioOrdini.IdProdotto);
            return View(dettaglioOrdini);
        }

        // POST: DettaglioOrdini/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDettaglio,IdProdotto,Quantità,IdOrdine")] DettaglioOrdini dettaglioOrdini)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dettaglioOrdini).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdOrdine = new SelectList(db.Ordini, "IdOrdine", "Indirizzo", dettaglioOrdini.IdOrdine);
            ViewBag.IdProdotto = new SelectList(db.Prodotti, "IdProdotto", "NomeP", dettaglioOrdini.IdProdotto);
            return View(dettaglioOrdini);
        }

        // GET: DettaglioOrdini/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DettaglioOrdini dettaglioOrdini = db.DettaglioOrdini.Find(id);
            if (dettaglioOrdini == null)
            {
                return HttpNotFound();
            }
            return View(dettaglioOrdini);
        }

        // POST: DettaglioOrdini/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DettaglioOrdini dettaglioOrdini = db.DettaglioOrdini.Find(id);
            db.DettaglioOrdini.Remove(dettaglioOrdini);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
