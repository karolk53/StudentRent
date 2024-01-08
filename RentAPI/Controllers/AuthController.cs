using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentAPI.DTOs;
using RentAPI.Interfaces;
using RentAPI.Models;

namespace RentAPI.Controllers;

public class AuthController : BaseApiController
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public AuthController(UserManager<AppUser> userManager, ITokenService tokenService, IMapper mapper)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _mapper = mapper;
    }
    
    [HttpPost("register")]
    public async Task<ActionResult<string>> RegisterNewUser(RegisterDto registerDto)
    {
        if (await UserExists(registerDto.Email)) return BadRequest("Email already taken");

        var user = new AppUser
        {
            UserName = registerDto.UserName,
            Email = registerDto.Email
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);
        if (!result.Succeeded) return BadRequest(result.Errors);

        var roleResult = await _userManager.AddToRoleAsync(user, "Member");
        if (!roleResult.Succeeded) return BadRequest(roleResult.Errors);

        return await _tokenService.CreateToken(user);

    }

    private async Task<bool> UserExists(string email)
    {
        return await _userManager.Users.AnyAsync(x => x.Email.Equals(email));
    }
}