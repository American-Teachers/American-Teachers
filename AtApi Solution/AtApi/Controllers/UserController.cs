using AtApi.Extensions;
using AtApi.Framework;
using AtApi.Model;
using AtApi.Models.UserViewModels;
using AtApi.Service.Authorization;
using AtApi.Service.Factory;
using AtApi.Service.Identity;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
namespace AtApi.Controllers
{

    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IPersonManager _personManager;
        private readonly IAuthService _authService;

        public UserController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ILogger<AccountController> logger,
            IMapper mapper,
            IPersonManager personManager,
            IAuthService authService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
            _mapper = mapper;
            _personManager = personManager;
            _authService = authService;
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        public async Task<ActionResult<RegisterResponse>> Register(RegisterRequest model)
        {
            var response = new RegisterResponse();
            if (ModelState.IsValid && model.AgreeToTermsAndCondition)
            {
                var user = _mapper.Map<ApplicationUser>(model);
                //    new ApplicationUser
                //{.
                //    UserName = model.Email,
                //    Email = model.Email,
                //    FirstName = model.FirstName,
                //    LastName = model.LastName,
                //    AgreeToTermsAndCondition = model.AgreeToTermsAndCondition
                //};
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                    await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("User created a new account with password.");
                    response.UserName = model.Email;
                    return Ok(response);
                }
                AddErrors(result);
                return BadRequest(ModelState);
            }

            // If we got this far, something failed, redisplay form
            return BadRequest(response);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("ExternalRegister")]
        public async Task<ActionResult<ExternalRegisterResponse>> ExternalRegister(ExternalRegisterRequest model)
        {
            var response = new ExternalRegisterResponse();
            if (ModelState.IsValid && model.AgreeToTermsAndCondition)
            {
                // Get the information about the user from the external login provider
                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    throw new ApplicationException("Error loading external login information during confirmation.");
                }
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    AgreeToTermsAndCondition = model.AgreeToTermsAndCondition
                };
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await _userManager.AddLoginAsync(user, info);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        _logger.LogInformation("User created an account using {Name} provider.", info.LoginProvider);
                        response.UserName = user.UserName;
                        response.UserId = user.Id;
                        return Ok(response);
                    }
                }
                AddErrors(result);
                return BadRequest(ModelState);

            }
            return BadRequest(response);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        [HttpPost]
        [Route("RegisterUser")]
        // [AllowAnonymous]
        public async Task<ActionResult<RegisterUserResponse>> RegisterUser(RegisterUserRequest model)
        {
            var response = new RegisterUserResponse();
            if (ModelState.IsValid)
            {
                var user = await _authService.ValidateAsync(User);
                if (user == null)
                {
                    return NotFound(model.UserName);
                }
                if (model.UserName != user.UserName)
                {
                    return BadRequest("Token.UserName != Model.UserName");
                }

                var personRequest = _mapper.Map<PersonRequest>(model);
                personRequest.AspUserId = user.Id;
                personRequest.FirstName = user.FirstName;
                personRequest.LastName = user.LastName;
                PersonResponse personRespone = await _personManager.CreateAsync(personRequest);
                response.PersonId = personRespone.PersonId;
                return Ok(response);
            }
            return Ok(response);
        }
    }
}