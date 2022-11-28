using HotelBooking.BL;
using HotelBooking.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelBooking.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<User> _userManager;
    public UserController(IConfiguration configuration,UserManager<User> userManager)
    {
        _configuration = configuration;
        _userManager = userManager;
    }

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<TokenDTO>> Login(LoginCredential input)
    {
        var user = await _userManager.FindByNameAsync(input.UserName);
        if (user == null)
        {
            return BadRequest(new { message = "user not found" });

        }
        var Islocked = await _userManager.IsLockedOutAsync(user);
        if (Islocked)
        {
            return BadRequest(new { message = "You  are Locked Out" });
        }
        bool PasswordCheckResualt=await _userManager.CheckPasswordAsync(user,input.Password);
        if (!PasswordCheckResualt)
        {
            await _userManager.AccessFailedAsync(user);
            return Unauthorized();
        }

        var UserClaims = await _userManager.GetClaimsAsync(user);

        var KeyFromConfig = _configuration.GetValue<string>("SecretKey");
        var KeyInBytes=Encoding.ASCII.GetBytes(KeyFromConfig);
        var secretKey = new SymmetricSecurityKey(KeyInBytes);

        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);

        var Jwt = new JwtSecurityToken
            (
                claims: UserClaims,
                expires: DateTime.Now.AddMinutes(30),
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials
            );


        var tokenHandler = new JwtSecurityTokenHandler();
        return new TokenDTO
        {
            Token = tokenHandler.WriteToken(Jwt)
        };

    }

    [HttpPost]
    [Route("Register")]
    public async Task<ActionResult> Register (UserRegisterDTO input)
    {
        var NewUser = new User
        {
            UserName = input.UserName,
            Email = input.Email,
            address = input.address,
            PhoneNumber = input.PhoneNumber
        };
        var creationResult = await _userManager.CreateAsync(NewUser, input.password);

        if (!creationResult.Succeeded)
        {
            return BadRequest(creationResult.Errors);

        }
        var claims = new List<Claim>
            {
               new Claim(ClaimTypes.NameIdentifier,NewUser.Id.ToString()),
               new Claim(ClaimTypes.Role,"Client")
            };

        var claimsResult = await _userManager.AddClaimsAsync(NewUser, claims);
        if (!claimsResult.Succeeded)
        {
            return BadRequest(claimsResult.Errors);
        }
        return Ok();
    }
}
