using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;
using Microsoft.EntityFrameworkCore;

namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context context;

        public HomeController(Context DBContext)
        {
            context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = context.Leagues
                .Where(l => l.Sport.Contains("Baseball"));
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.FemaleLeagues = context.Leagues
                .Where(l => l.Name.Contains("Womens'"));
            ViewBag.HockeyLeagues = context.Leagues
                .Where(h => h.Sport.Contains("Hockey"));
            ViewBag.NFLeagues = context.Leagues
                .Where( NF => !NF.Sport.Contains("Football"));
            ViewBag.ConferenceLeague = context.Leagues
                .Where(l => l.Name.Contains("Conference"));
            ViewBag.AtlanticLeague = context.Leagues
                .Where(l => l.Name.Contains("Atlantic"));
            ViewBag.DallasTeams = context.Teams
                .Where(team => team.Location.Contains("Dallas"));
            ViewBag.Raptors = context.Teams
                .Where(team => team.TeamName.Contains("Raptors"));
            ViewBag.UrbanTeams = context.Teams
                .Where(team => team.Location.Contains("City"));
            ViewBag.TNamedTeams = context.Teams
                .Where(team => team.TeamName.StartsWith('T'));
            ViewBag.alphaOrder = context.Teams
                .OrderBy(team => team.Location);
            ViewBag.reverseLOrder = context.Teams
                .OrderByDescending(team => team.Location);
            ViewBag.Cooper = context.Players
                .Where(player => player.LastName.Contains("Cooper"));
            ViewBag.Joshua = context.Players
                .Where(player => player.FirstName.Contains("Joshua"));
            ViewBag.CoopNotJ = context.Players
                .Where(p => p.LastName.Contains("Cooper")
                            && !p.FirstName.Contains("Joshua"));
            ViewBag.AW = context.Players
                .Where(p => p.FirstName.Contains("Alexander") || p.FirstName.Contains("Wyatt"));
            return View(); 
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}