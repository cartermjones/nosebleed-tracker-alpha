using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NosebleedTrackerAlpha.Controllers
{
    public class BleedsController : Controller
    {
        private MySqlDatabase MySqlDatabase { get; set; }
        public BleedsController(MySqlDatabase mySqlDatabase)
        {
            this.MySqlDatabase = mySqlDatabase;
        }
    }
}