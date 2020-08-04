using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SamataCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamataCalculator.Controllers
{
    public class SamataController : Controller
    {
        JobDone jobDone = new JobDone();

        public int GetTotalPrice()
        {
            int quantity;
            if (jobDone.Meters != 0)
            {
                quantity = jobDone.Meters;
            }
            else
            {
                quantity = jobDone.Quantity;
            }
            return quantity * jobDone.Price;
        }

        public JobDone PopulateJobDoneModel(SamataPostData data)
        {
            jobDone.Category = data.Category;
            jobDone.JobType = data.JobType;
            jobDone.JobName = data.JobName;
            jobDone.Price = int.Parse(data.Price);
            if (data.Quantity != "")
            {
                jobDone.Quantity = int.Parse(data.Quantity);
            }
            if (data.Meters != "")
            {
                jobDone.Meters = int.Parse(data.Meters);
            }

            return jobDone;
        }

        [HttpPost]
        public JsonResult GetData([FromBody] SamataPostData data)
        {
            PopulateJobDoneModel(data);


            return Json(new
            {
                msg = "Kaina uz darbus: " + GetTotalPrice()
            }); ;
        }
    }
}
