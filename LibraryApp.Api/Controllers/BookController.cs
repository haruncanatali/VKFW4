using LibraryApp.Api.Models;
using LibraryApp.Business.Abstract;
using LibraryApp.DataAccess.Common.Dtos.AuthorDtos;
using LibraryApp.DataAccess.Common.Dtos.BookDtos;
using LibraryApp.Entities.Domain;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Api.Controllers;

public class BookController : BaseController
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookResponseModel>> Get([FromQuery] long id)
    {
        return Ok(await _bookService.GetEntityAsync(c => c.Id == id));
    }

    [HttpGet]
    public async Task<ActionResult<List<AuthorResponseModel>>> GetAll()
    {
        return Ok(await _bookService.GetEntitiesAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddBookRequestModel model)
    {
        await _bookService.AddAsync(new Book
        {
            Name = model.Name,
            ISBN = model.ISBN,
            PageCount = model.PageCount,
            BookStatus = model.BookStatus,
            GenreId = model.GenreId,
            AuthorId = model.AuthorId
        });
        
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBookRequestModel model)
    {
        await _bookService.UpdateAsync(new Book
        {
            Id = model.Id,
            Name = model.Name,
            ISBN = model.ISBN,
            PageCount = model.PageCount,
            BookStatus = model.BookStatus,
            GenreId = model.GenreId,
            AuthorId = model.AuthorId
        });
        
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] long id)
    {
        await _bookService.DeleteByIdAsync(id);
        return Ok();
    }
}