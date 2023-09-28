using System.Runtime.CompilerServices;
using LibraryApp.Api.Models;
using LibraryApp.Business.Abstract;
using LibraryApp.DataAccess.Common.Dtos.AuthorDtos;
using LibraryApp.Entities.Domain;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Api.Controllers;

public class AuthorController : BaseController
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorResponseModel>> Get([FromQuery] long id)
    {
        return Ok(await _authorService.GetEntityAsync(c => c.Id == id));
    }

    [HttpGet]
    public async Task<ActionResult<List<AuthorResponseModel>>> GetAll()
    {
        return Ok(await _authorService.GetEntitiesAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddAuthorRequestModel model)
    {
        await _authorService.AddAsync(new Author
        {
            Name = model.Name,
            Surname = model.Surname,
            Birthdate = model.Birthdate
        });
        
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAuthorRequestModel model)
    {
        await _authorService.UpdateAsync(new Author
        {
            Id = model.Id,
            Name = model.Name,
            Surname = model.Surname,
            Birthdate = model.Birthdate
        });

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] long id)
    {
        await _authorService.DeleteAuthorWithBooks(id);
        return Ok();
    }
}