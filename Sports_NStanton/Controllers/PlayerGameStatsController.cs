using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sports_NStanton.Models;

namespace Sports_NStanton.Controllers
{
    public class PlayerGameStatsController : Controller
    {
        private Sports_NStantonContext db = new Sports_NStantonContext();

        // GET: PlayerGameStats
        public ActionResult Index()
        {
            var playerGameStats = db.PlayerGameStats.Include(p => p.Game).Include(p => p.Player);
            return View(playerGameStats.ToList());
        }

        // GET: PlayerGameStats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerGameStat playerGameStat = db.PlayerGameStats.Find(id);
            if (playerGameStat == null)
            {
                return HttpNotFound();
            }
            return View(playerGameStat);
        }

        // GET: PlayerGameStats/Create
        public ActionResult Create()
        {
            ViewBag.GameID = new SelectList(db.Games, "GameID", "Name");
            ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "Name");
            return View();
        }

        // POST: PlayerGameStats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayerGameStatID,GameID,PlayerID,ShotsOnGoal,CreateDate")] PlayerGameStat playerGameStat)
        {
            if (ModelState.IsValid)
            {
                playerGameStat.CreateDate = DateTime.Now;
                bool hasGameAndPlayer = false;
                foreach(PlayerGameStat stat in db.PlayerGameStats)
                {
                    if ((stat.GameID == playerGameStat.GameID) && (stat.PlayerID == playerGameStat.PlayerID))
                    {
                        hasGameAndPlayer = true;
                    }
                }

                if (!hasGameAndPlayer)
                {
                    db.PlayerGameStats.Add(playerGameStat);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            ViewBag.GameID = new SelectList(db.Games, "GameID", "Name", playerGameStat.GameID);
            ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "Name", playerGameStat.PlayerID);
            return View(playerGameStat);
        }

        // GET: PlayerGameStats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerGameStat playerGameStat = db.PlayerGameStats.Find(id);
            if (playerGameStat == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameID = new SelectList(db.Games, "GameID", "Name", playerGameStat.GameID);
            ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "Name", playerGameStat.PlayerID);
            return View(playerGameStat);
        }

        // POST: PlayerGameStats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayerGameStatID,GameID,PlayerID,ShotsOnGoal,CreateDate")] PlayerGameStat playerGameStat)
        {
            if (ModelState.IsValid)
            {
                bool hasGameAndPlayer = false;
                foreach (PlayerGameStat stat in db.PlayerGameStats)
                {
                    if ((stat.GameID == playerGameStat.GameID) && (stat.PlayerID == playerGameStat.PlayerID))
                    {
                        hasGameAndPlayer = true;
                    }
                }

                if (!hasGameAndPlayer)
                {
                    db.Entry(playerGameStat).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            ViewBag.GameID = new SelectList(db.Games, "GameID", "Name", playerGameStat.GameID);
            ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "Name", playerGameStat.PlayerID);
            return View(playerGameStat);
        }

        // GET: PlayerGameStats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerGameStat playerGameStat = db.PlayerGameStats.Find(id);
            if (playerGameStat == null)
            {
                return HttpNotFound();
            }
            return View(playerGameStat);
        }

        // POST: PlayerGameStats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayerGameStat playerGameStat = db.PlayerGameStats.Find(id);
            db.PlayerGameStats.Remove(playerGameStat);
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
