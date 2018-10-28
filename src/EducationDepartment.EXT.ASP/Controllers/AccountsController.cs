﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EducationDepartment.Domain.Core.Dto.UseCaseRequests;
using EducationDepartment.Domain.Core.Interfaces.UseCases;
using EducationDepartment.EXT.ASP.Presenters;

namespace EducationDepartment.EXT.ASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IRegisterUserUseCase _registerUserUseCase;
        private readonly RegisterUserPresenter _registerUserPresenter;

        public AccountsController(IRegisterUserUseCase registerUserUseCase, RegisterUserPresenter registerUserPresenter)
        {
            _registerUserUseCase = registerUserUseCase;
            _registerUserPresenter = registerUserPresenter;
        }

        // POST api/accounts
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Models.Request.RegisterUserRequest request)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            await _registerUserUseCase.Handle(new RegisterUserRequest(request.FirstName,request.LastName,request.Email, request.UserName,request.Password), _registerUserPresenter);
            return _registerUserPresenter.ContentResult;
        }
    }
}
