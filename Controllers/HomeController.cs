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

            cmd.CommandText = @"SELECT BleedId, Severity, Comment, Date FROM bleeds";

            using (var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                {
                    var t = new dto.Bleed()
                    {
                        BleedId = reader.GetFieldValue<int>(0),
                        Comment = reader.GetFieldValue<string>(2)
                    };
                    if (!reader.IsDBNull(2))
                        t.Date = reader.GetFieldValue<DateTime>(3);

                    ret.Add(t);
                }
            return ret;
        }

        public async Task<IActionResult> Index()
        {
            return View(await this.GetBleeds());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new dto.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
