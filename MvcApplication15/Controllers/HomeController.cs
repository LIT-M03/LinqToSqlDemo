using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoGames.Data;

namespace MvcApplication15.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var repo = new VideoGameRepository(Properties.Settings.Default.ConStr);
            return View(repo.GetAll());
        }

        [HttpPost]
        public ActionResult AddGame(VideoGame videoGame)
        {
            var repo = new VideoGameRepository(Properties.Settings.Default.ConStr);
            repo.AddGame(videoGame);
            return Json(videoGame);
        }

        [HttpPost]
        public ActionResult Update(VideoGame videoGame)
        {
            var repo = new VideoGameRepository(Properties.Settings.Default.ConStr);
            repo.UpdateGame(videoGame);
            return Json(videoGame);
        }

        [HttpPost]
        public void Delete(int gameId)
        {
            var repo = new VideoGameRepository(Properties.Settings.Default.ConStr);
            repo.DeleteGame(gameId);
        }

        public ActionResult Different()
        {
            return View();
        }

    }
}
