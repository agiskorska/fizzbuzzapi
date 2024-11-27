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
                fbResultArr[i].value = FizzBuzzCheckRules(start + i, start);
            }
            return fbResultArr;
        }
        private long AssessIfPower(long value, long rule) {
            if (value < rule) {
                return value;
            }
            while (value % rule == 0 )
            {
                value /= rule;
            }
            return (value == 1) ? 0 : value;

        }
        // private long AssessIfFibonacci(long value, long start) {
        // // TODO: Fix!
        //     long a = start;
        //     long b = start * 2;
        //     long c = 0;
        //     if (value % start <= 1){
        //         return 0;
        //     }
        //     while (a < value)
        //     {
        //         c = a + b;
        //         a = b;
        //         b = c;
        //     }
        //     return (c == value) ? 0 : value;

        // }

        private string ReplaceAllRules(long value, IEnumerable<FizzBuzzRule> ruleList, string suffix) {
            var res = "";
             for (int i = 0; i < ruleList.Count(); i++)
                {
                    FizzBuzzRule rule = ruleList.ToList().ElementAt(i);
                    res += rule.ReplaceWith + suffix;
                }
            return res;
        }
        private string FizzBuzzCheckRules(long value, long start)
        {
            string result = "";
            var allRules = _context.FizzBuzzRules.ToList();
            var powers = allRules.Where(r => (AssessIfPower(value, r.Id) == 0));
            var rules = allRules.Where(r => ((value % r.Id) == 0 ));
            var lastDigRules = allRules.Where(r => ((value % 10) == r.Id ));
            // var fibonacci = AssessIfFibonacci(value, start);
            // Console.Write("Fibonacci: " + value + (fibonacci == 0));
            var count = rules.Count();
            var powerCount = powers.Count();
            var digCount = lastDigRules.Count();
            
            if (powerCount > 0) {
                result += ReplaceAllRules(value, powers, "Power");
            }
            if (digCount > 0)
            {
                result += ReplaceAllRules(value, rules, "DIGthis!");
            }
            // if (fibonacci == 0)
            // {
            //     result += "Fibonacci";
            // }
            if (count > 0)
            {
                result += ReplaceAllRules(value, rules, "");
            }
            else
            {
                result = value.ToString();
            }
            return result;
        }
    }
}
