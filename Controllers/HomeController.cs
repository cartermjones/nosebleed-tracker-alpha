using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using dto = NosebleedTrackerAlpha.Models;

namespace NosebleedTrackerAlpha.Controllers
{
    public class HomeController : Controller
    {

        private MySqlDatabase MySqlDatabase { get; set; }

        public HomeController(MySqlDatabase mySqlDatabase)
        {
            this.MySqlDatabase = mySqlDatabase;
        }

        private async Task<List<dto.Bleed>> GetBleeds()
        {
            var ret = new List<dto.Bleed>();

            var cmd = this.MySqlDatabase.Connection.CreateCommand() as MySqlCommand;

            cmd.CommandText = @"SELECT BleedId, Severity, Comment, BleedDateTime FROM bleeds";

            using (var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                {
                    var bleed = new dto.Bleed()
                    {
                        BleedId = reader.GetFieldValue<int>(0),
                        Severity = reader.GetFieldValue<int>(1),
                        Comment = reader.GetFieldValue<string>(2),
                        BleedDate = reader.GetFieldValue<DateTime>(3)
                    };

                    ret.Add(bleed);
                }

            return ret;
        }

       

        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await this.GetBleeds());
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogBleed()
        {
            //Pull data from form
            var severity = Request.Form["Severity"];
            var comment = Request.Form["Comment"];
            string unsafeBleedDateTime = Request.Form["BleedDateTime"];
            string bleedDateTime = unsafeBleedDateTime.Replace('T', ' ');
          
            var cmd = this.MySqlDatabase.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO bleeds(Severity,Comment,BleedDateTime) VALUES (@Int, @Text,STR_TO_DATE(@DateTime, '%Y-%m-%d %H:%i'));";
            cmd.Parameters.AddWithValue("@Int", severity);
            cmd.Parameters.AddWithValue("@Text", comment);
            cmd.Parameters.AddWithValue("@DateTime", bleedDateTime);

            var recs = cmd.ExecuteNonQuery();
           
            Console.WriteLine(recs);
           
            return View(Index());
        }

        [HttpPost]
        public void DeleteBleed(dto.BleedIdentifier input)
        {
            var cmd = this.MySqlDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM bleeds WHERE BleedID = @BleedId";
            cmd.Parameters.AddWithValue("@BleedId", input.BleedId);

            var recs = cmd.ExecuteNonQuery();
            Console.WriteLine(recs);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new dto.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
