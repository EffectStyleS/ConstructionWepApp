using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class BudgetsController : ControllerBase
    {
        private readonly FFAContext _context;
        public BudgetsController(FFAContext context)
        {
            _context = context;
            if (!_context.Budget.Any())
            {
                _context.Budget.Add(new Budget
                {
                    StartDate = DateTime.Now,
                    TimePeriodId = 16
                });
                _context.SaveChanges();
            }
        }

        // GET: api/Budgets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Budget>>> GetBudget()
        {
            return await _context.Budget.Include(u => u.TimePeriod).ToListAsync();
        }

        // GET: api/Budgets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Budget>> GetBudget(int id)
        {
            var budget = await _context.Budget.FindAsync(id);

            if (budget == null)
            {
                return NotFound();
            }

            return budget;
        }

        // POST: api/Budgets
        [HttpPost]
        public async Task<ActionResult<Budget>> PostBudget(Budget budget)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Budget.Add(budget);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetBudgets", new { id = budget.Id }, budget);
        }

        // PUT: api/Budgets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBudget(int id, Budget budget)
        {
            if (id != budget.Id)
            {
                return BadRequest();
            }
            _context.Entry(budget).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BudgetExists(id))
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
        private bool BudgetExists(int id)
        {
            return _context.Budget.Any(b => b.Id == id);
        }

        // DELETE: api/Budgets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBudget(int id)
        {
            var budget = await _context.Budget.FindAsync(id);
            if (budget == null)
            {
                return NotFound();
            }
            _context.Budget.Remove(budget);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
