using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FizzBuzzApi.Models;

namespace FizzBuzzApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FizzBuzzRuleController : ControllerBase
    {
        private readonly FizzBuzzContext _context;

        public FizzBuzzRuleController(FizzBuzzContext context)
        {
            _context = context;
        }

        // GET: api/FizzBuzzRule
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FizzBuzzRule>>> GetFizzBuzzRules()
        {
            return await _context.FizzBuzzRules.ToListAsync();
        }

        // GET: api/FizzBuzzRule/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FizzBuzzRule>> GetFizzBuzzRule(long id)
        {
            var fizzBuzzRule = await _context.FizzBuzzRules.FindAsync(id);

            if (fizzBuzzRule == null)
            {
                return NotFound();
            }

            return fizzBuzzRule;
        }

        // PUT: api/FizzBuzzRule/5
        [HttpPut("{id}")]
        public async Task<ActionResult<FizzBuzzRule>> PutFizzBuzzRule(long id, FizzBuzzRule fizzBuzzRule)
        {
            if (id != fizzBuzzRule.Id)
            {
                return BadRequest();
            }

            var existingRule = await _context.FizzBuzzRules.FindAsync(id);

            try
            {
                if (existingRule == null)
                {
                    _context.FizzBuzzRules.Add(fizzBuzzRule);
                }
                else
                {
                    _context.Entry(existingRule).CurrentValues.SetValues(fizzBuzzRule);
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return CreatedAtAction("GetFizzBuzzRule", new { id = fizzBuzzRule.Id }, fizzBuzzRule);
        }

        // DELETE: api/FizzBuzzRule/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FizzBuzzRule>> DeleteFizzBuzzRule(long id)
        {
            var fizzBuzzRule = await _context.FizzBuzzRules.FindAsync(id);
            if (fizzBuzzRule == null)
            {
                return NotFound();
            }

            _context.FizzBuzzRules.Remove(fizzBuzzRule);
            await _context.SaveChangesAsync();

            return fizzBuzzRule;
        }

        private bool FizzBuzzRuleExists(long id)
        {
            return _context.FizzBuzzRules.Any(e => e.Id == id);
        }
    }
}
