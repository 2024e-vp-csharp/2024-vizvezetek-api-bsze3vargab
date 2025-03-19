using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vizvezetek.API.Data;
using Vizvezetek.API.DTOs;
using Vizvezetek.API.Models;

namespace Vizvezetek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MunkalapokController : ControllerBase
    {
        private readonly VizvezetekContext _context;

        public MunkalapokController(VizvezetekContext context)
        {
            _context = context;
        }


        // GET: api/Munkalap
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MunkalapDto>>> GetMunkalapok()
        {
           var munkalapok = await _context.Munkalapok

                .Include(m => m.Hely)
                .Include(m => m.Szerelo)
                .Select(m => new MunkalapDto
                {
                    Id = m.Id,
                    BeadasDatum = m.BeadasDatum,
                    JavitasDatum = m.JavitasDatum,
                    Helyszin = m.Hely.Telepules + ", " + m.Hely.Utca,
                    Szerelo = m.Szerelo.Nev,
                    Munkaora = m.Munkaora,
                    Anyagar = m.Anyagar
                })
                .ToListAsync();


            return munkalapok;

        }


        // 6.
        [HttpGet("{id}")]
        public async Task<ActionResult<MunkalapDto>> GetMunkalapById(int id)
        {
            var munkalap = await _context.Munkalapok

                .Include(m => m.Hely)
                .Include(m => m.Szerelo)
                .Where(m => m.Id == id)
                .Select(m => new MunkalapDto
                {
                    Id = m.Id,
                    BeadasDatum = m.BeadasDatum,
                    JavitasDatum = m.JavitasDatum,
                    Helyszin = m.Hely.Telepules + ", " + m.Hely.Utca,
                    Szerelo = m.Szerelo.Nev,
                    Munkaora = m.Munkaora,
                    Anyagar = m.Anyagar
                })
                .FirstOrDefaultAsync();


            if (munkalap == null)
            {
                return NotFound();
            }


            return munkalap;

        }


        // 7. 
        [HttpPost]
        public async Task<ActionResult<IEnumerable<MunkalapDto>>> SearchMunkalapok([FromBody] MunkalapKeresesDto keres)
        {
            var munkalapok = await _context.Munkalapok

                .Include(m => m.Hely)
                .Include(m => m.Szerelo)
                .Where(m => m.HelyId == keres.HelyId && m.SzereloId == keres.SzereloId)
                .Select(m => new MunkalapDto
                {
                    Id = m.Id,
                    BeadasDatum = m.BeadasDatum,
                    JavitasDatum = m.JavitasDatum,
                    Helyszin = m.Hely.Telepules + ", " + m.Hely.Utca,
                    Szerelo = m.Szerelo.Nev,
                    Munkaora = m.Munkaora,
                    Anyagar = m.Anyagar
                })
                .ToListAsync();


            return munkalapok;


        }


        // 8.
        [HttpGet("ev/{ev}")]
        public async Task<ActionResult<IEnumerable<MunkalapDto>>> GetMunkalapokByYear(int ev)
        {
            var munkalapok = await _context.Munkalapok

                .Include(m => m.Hely)
                .Include(m => m.Szerelo)
                .Where(m => m.JavitasDatum.Year == ev)
                .Select(m => new MunkalapDto
                {
                    Id = m.Id,
                    BeadasDatum = m.BeadasDatum,
                    JavitasDatum = m.JavitasDatum,
                    Helyszin = m.Hely.Telepules + ", " + m.Hely.Utca,
                    Szerelo = m.Szerelo.Nev,
                    Munkaora = m.Munkaora,
                    Anyagar = m.Anyagar
                })
                .ToListAsync();


            return munkalapok;

        }

    }

}