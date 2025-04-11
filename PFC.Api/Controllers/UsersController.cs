
using Microsoft.AspNetCore.Mvc;
using PFC.Application.Services;
using PFC.Dtos.Users;
using PFC.Infrastructure.DataModels.Common;

namespace PFC.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(IUsersService service) 
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string search, [FromQuery] int? offset, [FromQuery] int? limit)
    {
        var result = await service.ListAsync(new PagedFilter<UsersFilter>(new UsersFilter(search), offset, limit));
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var userDto = await service.GetAsync(id);
        return Ok(userDto);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUserDto createUserDto)
    {
        var id = await service.CreateAsync(createUserDto);
        return Ok(id);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateUserDto updateUserDto)
    {
        await service.UpdateAsync(id, updateUserDto);
        return Ok();
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> Path(Guid id, [FromBody] UpdateUserDto updateUserDto)
    {
        await service.UpdateAsync(id, updateUserDto);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await service.DeleteAsync(id);
        return Ok();
    }
}