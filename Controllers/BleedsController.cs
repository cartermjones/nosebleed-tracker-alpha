using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using dto = NosebleedTrackerAlpha.Models;

namespace NosebleedTrackerAlpha.Controllers
{
    public class BleedsController : Controller
    {
        private MySqlDatabase MySqlDatabase { get; set; }
        public BleedsController(MySqlDatabase mySqlDatabase)
        {
            this.MySqlDatabase = mySqlDatabase;
        }

        //Fetch the average severity of all bleeds for a user.
        private dto.Report GetReport()
        {

            var cmd = this.MySqlDatabase.Connection.CreateCommand();

            cmd.CommandText = @"CALL spAverageSeverity(@user_id);";

            //Right now the application only supports one user... User 0.
            cmd.Parameters.AddWithValue("@user_id", 0);
            
            var reader = cmd.ExecuteReader();
            
            reader.Read();

            var report = new dto.Report()
            {
                Average = decimal.ToInt32(reader.GetFieldValue<decimal>(0))
            };

            return report;

        }
        
        public IActionResult Report()
        {
            return View(this.GetReport());
        }

    }
}