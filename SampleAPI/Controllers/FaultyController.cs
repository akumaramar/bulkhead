using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Polly;
using Polly.Bulkhead;
using System.Timers;
using System.Diagnostics;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaultyController : ControllerBase
    {
        private static BulkheadPolicy bulkHeadPolicy = Policy
            .Bulkhead(2, 2, context => {
                Debug.WriteLine("More than 2 parallel calls are rejected");
            });

        // public FaultyController()
        // {
             
        // }

        [HttpGet(Name = "GetFaulty")]
        public String GetAllData(String name){


            // //DateTime timeSpan = DateTime.Now;
            // DateTime timeAfterFiveSec = DateTime.Now.AddSeconds(2);


            // while (DateTime.Now < timeAfterFiveSec)
            // {
            //     double result = 0;

            //     // perform a computationally intensive task
            //     for (int i = 1; i < 100000; i++)
            //     {
            //         result += Math.Sqrt(i);
            //     }
                
            //     Console.WriteLine("Result: " + result);
            // }
            
            // return "Time's up!";

            //return bulkHeadPolicy.ExecuteAndCapture(() => faultyCode()).Result;
            return faultyCode();
            
        }

        private string faultyCode(){

            //DateTime timeSpan = DateTime.Now;
            DateTime timeAfterFiveSec = DateTime.Now.AddSeconds(2);


            while (DateTime.Now < timeAfterFiveSec)
            {
                double result = 0;

                // perform a computationally intensive task
                for (int i = 1; i < 100000; i++)
                {
                    result += Math.Sqrt(i);
                }
                
                Console.WriteLine("Result: " + result);
            }
            
            return "Time's up!";

        }
    }
}
