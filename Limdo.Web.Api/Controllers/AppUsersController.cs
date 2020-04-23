using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Limdo.Data;
using Limdo.Data.Infrastructure.Repositories.IAppUsers;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Limdo.Web.Api.DtoModels;
using Limdo.Domain;
using Limdo.Data.Infrastructure.Repositories;
using System.Threading;
using Microsoft.AspNetCore.Components;
//using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Limdo.Web.Api.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]

    //[Authorize]
    public class AppUsersController : ControllerBase
    {
        private readonly LimdoDbContext _context;
        private readonly IAppUserRepository _appUserRepository;
        private readonly IUnitOfWork<AppUser> _unitOfWorkAppUser;
        private readonly IMapper _mapper;

        private readonly CancellationToken _cancellationToken;

        public AppUsersController(LimdoDbContext context,
             IAppUserRepository appUserRepository,
             IUnitOfWork<AppUser> unitOfWork,
             IMapper mapper)
        {
            _appUserRepository = appUserRepository;
            _mapper = mapper;
            _unitOfWorkAppUser = unitOfWork;
            _context = context;

            _cancellationToken = new CancellationToken();
        }

        // GET: api/AppUsers

        //[HttpGet("GetAppUsers")]
        [HttpGet]
        //[Route("GetAppUsers")]
        //[Route("api/AppUsers/GetAppUsers")]
        public async Task<IEnumerable<AppUserDto>> GetAppUsers()
        {
            return _mapper.Map<IEnumerable<AppUserDto>>(await _appUserRepository.FindAllAsync());
            //return await _context.AppUsers.ToListAsync();
        }

        // GET: api/AppUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUserDto>> GetAppUser(string id)
        {
            //var appUser = await _context.AppUsers.FindAsync(id);
            var appUser = _mapper.Map<AppUserDto>(await _appUserRepository.FindAsync(id));
            if (appUser == null)
            {
                return NotFound();
            }
                                                                                                                   
            return appUser;
        }

        [HttpGet("GetByAppUserId/{id}")]
        //[Route("GetByAppUserId/{id}")]
        public async Task<ActionResult<AppUserDto>> GetByAppUserId(string id)
        {
            //var appUser = await _context.AppUsers.FindAsync(id);
            var appUser = _mapper.Map<AppUserDto>(await _appUserRepository.FindByAppUserIdAsync(id));
            if (appUser == null)
            {
                return NotFound();
            }

            return appUser;
        }

        // PUT: api/AppUsers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppUser(string id, AppUserDto appUser)
        {
            if (id != appUser.AppUserId)
            {
                return BadRequest();
            }

            _context.Entry(appUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppUserExists(id))
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

        // POST: api/AppUsers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPost("AppUsers/PostAppUser")]
        //[Route("AppUsers/PostAppUser")]
        [HttpPost]
        public async Task<ActionResult<AppUserDto>> PostAppUser(AppUserDto appUser)
        {
            await _appUserRepository.AddAsync(_mapper.Map<AppUser>(appUser));
            await _unitOfWorkAppUser.CommitAsync(_cancellationToken);

            return CreatedAtAction("GetAppUser", new { id = appUser.AppUserId }, appUser);
        }

        // DELETE: api/AppUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AppUserDto>> DeleteAppUser(string id)
        {
            var appUser = _mapper.Map<AppUserDto>(await _appUserRepository.FindAsync(id));
            //var appUser = await _context.AppUsers.FindAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }
            await _appUserRepository.RemoveAsync( _mapper.Map<AppUser>(appUser));
            //_context.AppUsers.Remove(appUser);
            await _context.SaveChangesAsync();

            return appUser;
        }

        private bool AppUserExists(string id)
        {
            return _context.AppUsers.Any(e => e.AppUserId == id);
        }
    }
}
