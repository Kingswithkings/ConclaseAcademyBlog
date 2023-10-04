using ConclaseAcademyBlog.DTO.RequestDto;
using ConclaseAcademyBlog.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConclaseAcademyBlog.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public UserAccountController(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUserAsync(UserRegistrationRequestDto model) 
        {
            if (ModelState.IsValid)
            {
                return Ok(await _userAccountRepository.RegisterAsync(model)); 
            }

            //todo: use fluent validation or a global entity validation
            return BadRequest("Invalid payload.");
        }

        [HttpPut]
        [Route("update/{userId}")]
        public async Task<IActionResult> UpdateUserAsync(string userId, UpdateUserRequestDto model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _userAccountRepository.UpdateAsync(userId, model));
            }

            //todo: use fluent validation or a global entity validation
            return BadRequest("Invalid payload.");
        }
    }
}
