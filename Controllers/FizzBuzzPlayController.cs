using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FizzBuzzApi.Models;


namespace FizzBuzzApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FizzBuzzPlayController : ControllerBase
    {
        private readonly FizzBuzzContext _context;

        public FizzBuzzPlayController(FizzBuzzContext context)
        {
            _context = context;
        }

        // GET: api/FizzBuzzPlay?start$count
        [HttpGet]
        public ActionResult<IEnumerable<FizzBuzzResult>> GetFizzBuzzPlay([Required, FromQuery] long start, [Required, FromQuery] long count)
        {
            long i;
            var fbResultArr = new FizzBuzzResult[count];
            for (i = 0; i < count; i++)
            {
                fbResultArr[i] = new FizzBuzzResult();
                fbResultArr[i].value = FizzBuzzCheckRules(start + i);
            }
            return fbResultArr;
        }

        private string FizzBuzzCheckRules(long value)
        {
            string result = "";
            var rules = _context.FizzBuzzRules.Where(r => ((value % r.Id) == 0));

            if (rules != null)
            {
                var count = rules.Count();
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        FizzBuzzRule rule = rules.ToList().ElementAt(i);
                        result += rule.ReplaceWith;
                    }
                }
                else
                {
                    result = value.ToString();
                }
            }
            return result;
        }
    }
}
