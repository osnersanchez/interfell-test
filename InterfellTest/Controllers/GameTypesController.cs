using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InterfellTest;

namespace InterfellTest.Controllers
{
    public class GameTypesController : Controller
    {
        private ApiContext db = new ApiContext();

        // GET: GameTypes
        public ActionResult Index()
        {
            return View(db.GameTypes.ToList());
        }

        // GET: GameTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameType gameType = db.GameTypes.Find(id);
            if (gameType == null)
            {
                return HttpNotFound();
            }
            return View(gameType);
        }

        // GET: GameTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameTypes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title")] GameType gameType)
        {
            if (ModelState.IsValid)
            {
                db.GameTypes.Add(gameType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gameType);
        }

        // GET: GameTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameType gameType = db.GameTypes.Find(id);
            if (gameType == null)
            {
                return HttpNotFound();
            }
            return View(gameType);
        }

        // POST: GameTypes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title")] GameType gameType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gameType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gameType);
        }

        // GET: GameTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameType gameType = db.GameTypes.Find(id);
            if (gameType == null)
            {
                return HttpNotFound();
            }
            return View(gameType);
        }

        // POST: GameTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GameType gameType = db.GameTypes.Find(id);
            db.GameTypes.Remove(gameType);
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
