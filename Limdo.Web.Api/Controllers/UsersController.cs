﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Limdo.Data;
using Limdo.Domain;
using System.Threading;
using Limdo.Data.Infrastructure.Repositories;
using Limdo.Data.Infrastructure.Repositories.IAppUsers;
using AutoMapper;
using Limdo.Web.Api.DtoModels;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Limdo.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserIdentityDbContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork<User> _unitOfWorkUser;
        private CancellationToken _cancellationToken;
        private readonly IMapper _mapper;
        public UsersController(UserIdentityDbContext context, IMapper mapper, IUserRepository userRepository, IUnitOfWork<User> unitOfWork)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _unitOfWorkUser = unitOfWork;
            _context = context;
            //_username = string.Empty;
            _cancellationToken = new CancellationToken(); ;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            return _mapper.Map<IEnumerable<UserDto>>(await _userRepository.FindAllAsync());
            //return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        //[HttpGet]
        [HttpGet("{id}")]
        //[Route("GetUser/{id}")]
        public async Task<ActionResult<UserDto>> GetUser(string id)
        {
            var user = _mapper.Map<UserDto>(await _userRepository.FindUserByUserNameAsync(id));
            //var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        [HttpGet]
        [Route("GetByUserId/{id}")]
        public async Task<ActionResult<UserDto>> GetByUserId(string id)
        {
            var user = _mapper.Map<UserDto>(await _userRepository.FindAsync(id));
            //var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        // PUT: api/Users/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(string id, User user)
        {
            if (id != user.SubjectId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            await _userRepository.AddAsync(_mapper.Map<User>(user));
            await _unitOfWorkUser.CommitAsync(_cancellationToken);

            return CreatedAtAction("GetUser", new { id = user.SubjectId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(string id)
        {
            return _context.Users.Any(e => e.SubjectId == id);
        }
    }
}
