using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController: ControllerBase 
    {
        private readonly BdContext _context;
         public TareasController(BdContext bdContext)
        {
            _context = bdContext;
        }

        // GET: api/tareas
        [HttpGet]
        public async Task<ActionResult> getAll()
        {
            var items =await _context.Tareas.ToArrayAsync();
             return Ok(items);
        }

        // GET: api/tareas/5
        [HttpGet("{cod_tarea}")]
        public async Task<ActionResult<Tarea>> getItem(int cod_tarea)
        {
            var item = await _context.Tareas.FindAsync(cod_tarea);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
        //Crea
        // POST: api/tareas
        [HttpPost]
        public async Task<ActionResult<Tarea>> create(Tarea item)
        {
            _context.Tareas.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(getItem), new { cod_tarea = item.cod_tarea }, item);
        }
        //Modifica
        // PUT: api/tareas/5 
        [HttpPut("{cod_tarea}")]
        public async Task<IActionResult> update(int cod_tarea, Tarea item)
        {
            if (cod_tarea != item.cod_tarea)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //ELIMINAR
        //DELETE: api/tareas/5 
        [HttpDelete("{cod_tarea}")]
        public async Task<IActionResult> eliminar(int cod_tarea)
        {
            var item = await _context.Tareas.FindAsync(cod_tarea);
            if(item == null)
            {
                return NotFound();
            }

            _context.Tareas.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}