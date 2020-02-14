using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using dto = NosebleedTrackerAlpha.Models;

namespace NosebleedTrackerAlpha.Controllers
{
    public class ReportsController : Controller
    {
        private MySqlDatabase MySqlDatabase { get; set; }

        public ReportsController(MySqlDatabase mySqlDatabase)
        {
            this.MySqlDatabase = mySqlDatabase;
        }

        //Fetch the average severity of all bleeds for a user.
        private dto.Report GetAverage()
        {

            var cmd = this.MySqlDatabase.Connection.CreateCommand();

            cmd.CommandText = @"CALL spAverageSeverity(@user_id)";

            //Right now the application only supports one user... User 0.
            cmd.Parameters.AddWithValue("@user_id", 0);
            
            var reader = cmd.ExecuteReader();
            
            reader.Read();

            var report = new dto.Report()
            {
                Average = decimal.ToInt32(reader.GetFieldValue<decimal>(0))
            };

            reader.Close();

            return report;

        }

        //This will fetch the monthly frequency of bleeds for the current month.
        private dto.Report GetFrequency()
        {
            var cmd = this.MySqlDatabase.Connection.CreateCommand();

            cmd.CommandText = @"CALL spThisMonthBleedFrequency(@user_id)";

            cmd.Parameters.AddWithValue("@user_id", 0);

            var reader = cmd.ExecuteReader();

            reader.Read();

            var report = new dto.Report()
            {
                Frequency = reader.GetFieldValue<long>(0)
            };

            reader.Close();

            return report;
        }

        //This aggregates the two above reports to pass into the View.
        private dto.Report AggregateReport()
        {
            dto.Report average = GetAverage();
            dto.Report frequency = GetFrequency();

            var report = new dto.Report()
            {
                Average = average.Average,
                Frequency = frequency.Frequency
            };

            return report;
        }
        
        public IActionResult Reports()
        {
            return View(AggregateReport());
        }

    }
}