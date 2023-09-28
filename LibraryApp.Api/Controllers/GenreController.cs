using LibraryApp.Api.Models;
using LibraryApp.Business.Abstract;
using LibraryApp.DataAccess.Common.Dtos.GenreDtos;
using LibraryApp.Entities.Domain;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Api.Controllers;

public class GenreController : BaseController
{
    private readonly IGenreService _genreService;

    public GenreController(IGenreService genreService)
    {
        _genreService = genreService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GenreResponseModel>> Get([FromQuery] long id)
    {
        return Ok(await _genreService.GetEntityAsync(c => c.Id == id));
    }

    [HttpGet]
    public async Task<ActionResult<List<GenreResponseModel>>> GetAll()
    {
        return Ok(await _genreService.GetEntitiesAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddGenreRequestModel model)
    {
        await _genreService.AddAsync(new Genre
        {
            Name = model.Name
        });
        
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateGenreRequestModel model)
    {
        await _genreService.UpdateAsync(new Genre
        {
            Id = model.Id,
            Name = model.Name
        });
        
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] long id)
    {
        await _genreService.DeleteByIdAsync(id);
        return Ok();
    }
}