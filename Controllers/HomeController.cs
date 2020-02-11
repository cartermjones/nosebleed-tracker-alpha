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

        //This method fetches bleed events from the database in descending chronological order.
        private async Task<List<dto.Bleed>> GetBleeds()
        {
            var ret = new List<dto.Bleed>();

            var cmd = this.MySqlDatabase.Connection.CreateCommand() as MySqlCommand;

            cmd.CommandText = @"CALL spGetAllBleedsChronologicalDescending()";

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

        //This method allows users to log new bleeds and corrals the datetime into the appropriate format.
        [HttpPost]
        public IActionResult LogBleed()
        {
            //Pull data from form
            var severity = Request.Form["Severity"];
            string comment = Request.Form["Comment"];
            string unsafeBleedDateTime = Request.Form["BleedDateTime"];
            string bleedDateTime = unsafeBleedDateTime.Replace('T', ' ');

            //To prevent possible SQL injection attacks. Not the strongest technique, but better than nothing.
            if (comment.Contains(";"))
            {
                comment = "Illegal character in comment.";
            }
          
            var cmd = this.MySqlDatabase.Connection.CreateCommand();
            cmd.CommandText = @"CALL spLogBleed(@Int, @Text, @DateTime);";
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
