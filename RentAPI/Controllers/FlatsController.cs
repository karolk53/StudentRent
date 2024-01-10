using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentAPI.DTOs.Flats;
using RentAPI.Extensions;
using RentAPI.Interfaces;
using RentAPI.Models;

namespace RentAPI.Controllers;

public class FlatsController : BaseApiController
{
    private readonly IUserRepository _userRepository;
    private readonly IFlatRepository _flatRepository;
    private readonly IFlatStatusRepository _flatStatusRepository;
    private readonly IMapper _mapper;

    public FlatsController(IUserRepository userRepository,IFlatRepository flatRepository, IFlatStatusRepository flatStatusRepository , IMapper mapper)
    {
        _userRepository = userRepository;
        _flatRepository = flatRepository;
        _flatStatusRepository = flatStatusRepository;
        _mapper = mapper;
    }
    
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Flat>> AddNewFlat(FlatAddDto flatAddDto)
    {
        var user = await _userRepository.GetUserByIdAsync(User.GetUserId());
        if (user == null) return Unauthorized();
        
        var flat = new Flat();
        var address = new Address();

        _mapper.Map(flatAddDto, address);
        _mapper.Map(flatAddDto, flat);
        flat.Address = address;
        flat.Status = await _flatStatusRepository.GetStatusByName("FOR_RENT");

        _flatRepository.AddNewFlat(flat);

        if (await _flatRepository.SaveAllAsync()) return Ok(flat);
        
        return BadRequest("Failed to add flat");
    }
}