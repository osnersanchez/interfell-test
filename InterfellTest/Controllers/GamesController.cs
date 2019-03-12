using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InterfellTest;
using Business;
using DTO;

namespace InterfellTest.Controllers
{
    public class GamesController : Controller
    {
        private IGameService _gameService;
        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        // GET: Games
        public ActionResult Index()
        {
            return View(_gameService.GetList());
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameDTO game = (GameDTO) _gameService.Get(id.Value);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            ViewBag.GameTypeId = new SelectList(_gameService.GetGameTypes(), "Id", "Title");
            return View();
        }

        // POST: Games/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,GameTypeId")] GameAddOrEditDTO game)
        {
            if (ModelState.IsValid)
            {
                _gameService.Add(game);
                return RedirectToAction("Index");
            }

            ViewBag.GameTypeId = new SelectList(_gameService.GetGameTypes(), "Id", "Title", game.GameTypeId);
            return View(game);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameAddOrEditDTO game = (GameAddOrEditDTO) _gameService.Get(id.Value);
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameTypeId = new SelectList(_gameService.GetGameTypes(), "Id", "Title", game.GameTypeId);
            return View(game);
        }

        // POST: Games/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,GameTypeId")] GameAddOrEditDTO game)
        {
            if (ModelState.IsValid)
            {
                _gameService.Put(game);
                return RedirectToAction("Index");
            }
            ViewBag.GameTypeId = new SelectList(_gameService.GetGameTypes(), "Id", "Title", game.GameTypeId);
            return View(game);
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            GameDTO game = (GameDTO) _gameService.Get(id.Value);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _gameService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
