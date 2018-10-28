using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using EducationDepartment.EXT.ASP.Models.Request;
using static EducationDepartment.EXT.ASP.Models.Facebook.FacebookApiResponses;
using EducationDepartment.EXT.ASP.Models.Facebook;
using EducationDepartment.Domain.Core.Dto.UseCaseRequests;
using EducationDepartment.Domain.Core.Interfaces.UseCases;
using EducationDepartment.EXT.ASP.Presenters;

namespace EducationDepartment.EXT.ASP.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ExternalAuthController : Controller
    {
        private readonly IFacebookLoginUseCase _loginUseCase;
        private readonly LoginPresenter _loginPresenter;
        private readonly FacebookAuthSettings _fbAuthSettings;
        private static readonly HttpClient Client = new HttpClient();

        public ExternalAuthController(IOptions<FacebookAuthSettings> fbAuthSettingsAccessor, IFacebookLoginUseCase loginUseCase, LoginPresenter loginPresenter)
        {
            _fbAuthSettings = fbAuthSettingsAccessor.Value;
            _loginUseCase = loginUseCase;
            _loginPresenter = loginPresenter;
        }

        // POST api/externalauth/facebook
        [HttpPost]
        public async Task<IActionResult> Facebook([FromBody]FacebookAuthViewModel model)
        {
            // 1.generate an app access token
            var appAccessTokenResponse = await Client.GetStringAsync($"https://graph.facebook.com/oauth/access_token?client_id={_fbAuthSettings.AppId}&client_secret={_fbAuthSettings.AppSecret}&grant_type=client_credentials");
            var appAccessToken = JsonConvert.DeserializeObject<FacebookAppAccessToken>(appAccessTokenResponse);
            // 2. validate the user access token
            var userAccessTokenValidationResponse = await Client.GetStringAsync($"https://graph.facebook.com/debug_token?input_token={model.AccessToken}&access_token={appAccessToken.AccessToken}");
            var userAccessTokenValidation = JsonConvert.DeserializeObject<FacebookUserAccessTokenValidation>(userAccessTokenValidationResponse);

            if (!userAccessTokenValidation.Data.IsValid)
            {
                _loginUseCase.Fail("Invalid facebook token.", _loginPresenter);
                return _loginPresenter.ContentResult;
            }

            // 3. we've got a valid token so we can request user data from fb
            var userInfoResponse = await Client.GetStringAsync($"https://graph.facebook.com/v2.8/me?fields=id,email,first_name,last_name,name,gender,locale,birthday,picture&access_token={model.AccessToken}");
            var userInfo = JsonConvert.DeserializeObject<FacebookUserData>(userInfoResponse);
            if (userInfo.Picture != null)
            {
                await _loginUseCase.Handle(new FacebookLoginRequest(
                    userInfo.Id, userInfo.Name, userInfo.Email, userInfo.FirstName, userInfo.LastName, userInfo.Gender, userInfo.Locale, userInfo.Picture.Data.Url, userInfo.Picture.Data.Height, userInfo.Picture.Data.Width, userInfo.Picture.Data.IsSilhouette),
                    _loginPresenter);
            }
            else
            {
                await _loginUseCase.Handle(new FacebookLoginRequest(
                    userInfo.Id, userInfo.Name, userInfo.Email, userInfo.FirstName, userInfo.LastName, userInfo.Gender, userInfo.Locale),
                    _loginPresenter);
            }
            return _loginPresenter.ContentResult;
        }
    }
}