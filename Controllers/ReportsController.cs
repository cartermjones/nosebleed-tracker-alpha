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

        //This will fetch the monthly frequency of bleeds for the current month.
        private dto.Report GetTotalDuration()
        {
            var cmd = this.MySqlDatabase.Connection.CreateCommand();

            cmd.CommandText = @"SELECT SUM(Duration) AS TotalDuration FROM bleeds";

            var reader = cmd.ExecuteReader();

            reader.Read();

            var report = new dto.Report()
            {
               Duration = decimal.ToInt32(reader.GetFieldValue<decimal>(0))
            };

            reader.Close();

            return report;
        }

        //This aggregates the two above reports to pass into the View.
        private dto.Report AggregateReport()
        {
            dto.Report average = GetAverage();
            dto.Report frequency = GetFrequency();
            dto.Report totalDuration = GetTotalDuration();
            dto.Report customAverage = GetMonthlySeverityReport();
            dto.Report customFrequency = GetMonthlyFrequencyReport();

            var report = new dto.Report()
            {
                Average = average.Average,
                Frequency = frequency.Frequency,
                Duration = totalDuration.Duration,
                CustomAverage = customAverage.CustomAverage,
                CustomFrequency = customFrequency.CustomFrequency
            };

            return report;
        }

        public IActionResult Reports()
        {
            return View(AggregateReport());
        }

        [HttpPost]
        public dto.Report GetMonthlySeverityReport()
        {
            try
            {
                var month = Request.Form["SeverityMonth"];
                string formattedMonth = "0000-" + month.ToString() + "-00";

                var cmd = this.MySqlDatabase.Connection.CreateCommand();

                cmd.CommandText = @"CALL spUserSpecifiedMonthBleedSeverity(@month)";

                cmd.Parameters.AddWithValue("@month", formattedMonth);

                var reader = cmd.ExecuteReader();

                reader.Read();

                var report = new dto.Report()
                {
                    CustomAverage = decimal.ToInt32(reader.GetFieldValue<decimal>(0))
                };

                reader.Close();

                return report;

            }

            catch
            {
                var tempReport = new dto.Report()
                {
                    CustomAverage = 0
                };

            return tempReport;
            }   
            
        }

        [HttpPost]
        public dto.Report GetMonthlyFrequencyReport()
        {
            try
            {
                var month = Request.Form["SeverityMonth"];
                string formattedMonth = "0000-" + month.ToString() + "-00";

                if (formattedMonth is null)
                {
                    formattedMonth = DateTime.Now.ToString("yyyy-mm-dd");
                }

                var cmd = this.MySqlDatabase.Connection.CreateCommand();

                cmd.CommandText = @"CALL spUserSpecifiedMonthBleedFrequency(@month)";

                cmd.Parameters.AddWithValue("@month", formattedMonth);

                var reader = cmd.ExecuteReader();

                reader.Read();

                var report = new dto.Report()
                {
                    CustomFrequency = reader.GetFieldValue<long>(0)
                };

                reader.Close();

                return report;
            }

            catch
            {
                var tempReport = new dto.Report()
                {
                    CustomFrequency = 0
                };
                return tempReport;
            }
            

        }

    }
}