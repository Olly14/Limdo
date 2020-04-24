using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Limdo.Data;
using Limdo.Domain;
using Limdo.Data.Infrastructure.Repositories.IAppUsers;
using AutoMapper;
using System.Threading;
using Limdo.Web.Api.DtoModels;

namespace Limdo.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PcoLicenceDetailsController : ControllerBase
    {
        private readonly LimdoDbContext _context;
        private readonly IPcoLicenceDetailRepository _pcoLicenceDetailRepository;

        private readonly IMapper _mapper;
        private CancellationToken _cancellationToken;
        public PcoLicenceDetailsController(LimdoDbContext context,
            IPcoLicenceDetailRepository pcoLicenceDetailRepository,
            IMapper mapper)
        {
            _pcoLicenceDetailRepository = pcoLicenceDetailRepository;
            _mapper = mapper;

            _cancellationToken = new CancellationToken();
            _context = context;
        }

        // GET: api/PcoLicenceDetails
        [HttpGet]
        public async Task<IEnumerable<PcoLicenceDetailDto>> GetPcoDetails()
        {
            return _mapper.Map<IEnumerable<PcoLicenceDetailDto>>(await _pcoLicenceDetailRepository.FindAllAsync());
            //return await _context.PcoDetails.ToListAsync();
        }

        // GET: api/PcoLicenceDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PcoLicenceDetailDto>> GetPcoLicenceDetail(string id)
        {
            var pcoLicenceDetail = _mapper.Map<PcoLicenceDetailDto>(await _pcoLicenceDetailRepository.FindAsync(id));
            //var pcoLicenceDetail = await _context.PcoDetails.FindAsync(id);

            if (pcoLicenceDetail == null)
            {
                return NotFound();
            }

            return pcoLicenceDetail;
        }

        // PUT: api/PcoLicenceDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPcoLicenceDetail(string id, PcoLicenceDetail pcoLicenceDetail)
        {
            if (id != pcoLicenceDetail.PcoId)
            {
                return BadRequest();
            }

            _context.Entry(pcoLicenceDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PcoLicenceDetailExists(id))
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

        // POST: api/PcoLicenceDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PcoLicenceDetail>> PostPcoLicenceDetail(PcoLicenceDetail pcoLicenceDetail)
        {
            _context.PcoDetails.Add(pcoLicenceDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPcoLicenceDetail", new { id = pcoLicenceDetail.PcoId }, pcoLicenceDetail);
        }

        // DELETE: api/PcoLicenceDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PcoLicenceDetail>> DeletePcoLicenceDetail(string id)
        {
            var pcoLicenceDetail = await _context.PcoDetails.FindAsync(id);
            if (pcoLicenceDetail == null)
            {
                return NotFound();
            }

            _context.PcoDetails.Remove(pcoLicenceDetail);
            await _context.SaveChangesAsync();

            return pcoLicenceDetail;
        }

        private bool PcoLicenceDetailExists(string id)
        {
            return _context.PcoDetails.Any(e => e.PcoId == id);
        }
    }
}
