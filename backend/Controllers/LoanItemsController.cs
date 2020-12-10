using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoanApi.Models;

namespace LoanApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LoanItemsController : ControllerBase
    {
        private readonly LoanContext _context;

        public LoanItemsController(LoanContext context)
        {
            _context = context;
        }

        // GET: api/LoanItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanItem>>> GetLoanItems()
        {
            return await _context.LoanItems.ToListAsync();
        }

        // GET: api/LoanItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanItem>> GetLoanItem(long id)
        {
            var loanItem = await _context.LoanItems.FindAsync(id);

            if (loanItem == null)
            {
                return NotFound();
            }

            //loanItem.MonthlyPayment = loanItem.Balance * (loanItem.Rate/1200) / (1 - Math.Pow((1 + loanItem.Rate/1200), (-1 * loanItem.Term)));
            return loanItem;
        }

        // PUT: api/LoanItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoanItem(long id, LoanItem loanItem)
        {
            if (id != loanItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(loanItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LoanItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LoanItem>> PostLoanItem(LoanItem loanItem)
        {
            _context.LoanItems.Add(loanItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetLoanItem", new { id = loanItem.Id }, loanItem);
            //loanItem.MonthlyPayment = loanItem.Balance * (loanItem.Rate/1200) / (1 - Math.Pow((1 + loanItem.Rate/1200), (-1 * loanItem.Term)));
            return CreatedAtAction(nameof(GetLoanItem), new { id = loanItem.Id }, loanItem);
        }

        // DELETE: api/LoanItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LoanItem>> DeleteLoanItem(long id)
        {
            var loanItem = await _context.LoanItems.FindAsync(id);
            if (loanItem == null)
            {
                return NotFound();
            }

            _context.LoanItems.Remove(loanItem);
            await _context.SaveChangesAsync();

            return loanItem;
        }

        public async Task<ActionResult<List<List<double>>>> getLoanChart(LoanItem loanItem){
            _context.LoanItems.Add(loanItem);
            await _context.SaveChangesAsync();


            return loanItem.getLoanPaymentChart();
        }

        private bool LoanItemExists(long id)
        {
            return _context.LoanItems.Any(e => e.Id == id);
        }
    }
}
