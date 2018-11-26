using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using EducationDepartment.Domain.Core.Domain.Entities;
using EducationDepartment.Domain.Core.Dto;
using EducationDepartment.Domain.Core.Dto.GatewayResponses.Repositories;
using EducationDepartment.Domain.Core.Interfaces.Gateways.Repositories;
using EducationDepartment.Infrastructure.Entityframework.Data.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EducationDepartment.Infrastructure.Entityframework.Data.EntityFramework.Repositories
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserRepository(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<CreateUserResponse> Create(User user, string password)
        {
            var appUser = _mapper.Map<AppUser>(user);
            var identityResult = await _userManager.CreateAsync(appUser, password);
            return new CreateUserResponse(appUser.Id, identityResult.Succeeded, identityResult.Succeeded ? null : identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
        }
        public async Task<User> CreateUserFromFacebook(Domain.Core.Dto.UseCaseRequests.FacebookLoginRequest userInfo, string password)
        {
            var newUser = new AppUser
            {
                FirstName = userInfo.FirstName,
                LastName = userInfo.LastName,
                FacebookId = userInfo.Id,
                Email = userInfo.Email,
                UserName = userInfo.Email,
                PictureUrl = userInfo.Url
            };
            var identityResult = await _userManager.CreateAsync(newUser, password);
            return identityResult.Succeeded ? _mapper.Map<User>(newUser) : null;
        }

        public async Task<User> FindByName(string userName)
        {
            return _mapper.Map<User>(await _userManager.FindByNameAsync(userName));
        }

        public async Task<bool> CheckPassword(User user, string password)
        {
            return await _userManager.CheckPasswordAsync(_mapper.Map<AppUser>(user), password);
        }

        public async Task<User> FindByEmail(string email)
        {
            return _mapper.Map<User>(await _userManager.FindByEmailAsync(email));

        }

        public async Task<List<string>> GetAllMails()
        {
            return await _userManager.Users.Select(x => x.Email).ToListAsync();
        }
    }
}
