using LibraryApp.Api.Controllers;
using LibraryApp.Api.Models;
using LibraryApp.Business.Abstract;
using LibraryApp.DataAccess.Common.Dtos.AuthorDtos;
using LibraryApp.DataAccess.Common.Dtos.BookDtos;
using LibraryApp.Entities.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Assert = NUnit.Framework.Assert;

namespace LibraryApp.Test;

[TestClass]
public class BookTest
{
    private readonly Mock<IBookService> _bookServiceMock;
    private readonly BookController _bookController;

    public BookTest()
    {
        _bookServiceMock = new Mock<IBookService>();
        _bookController = new BookController(_bookServiceMock.Object);
    }

    [TestMethod]
    public async Task GetBook_ReturnsOk()
    {
        var bookId = 1L;
        var book = new BookResponseModel() { Id = bookId };
        _bookServiceMock.Setup(s => s.GetEntityAsync(c => c.Id == bookId)).ReturnsAsync(book);

        var result = await _bookController.Get(bookId);

        Assert.NotNull(result);
        Assert.IsInstanceOf(result.GetType(), typeof(ActionResult<BookResponseModel>));
    } 
    
    [TestMethod]
    public async Task GetAllBooks_ReturnsOk()
    {
        var books = new List<BookResponseModel>()
        {
            new BookResponseModel() { Id = 1L },
            new BookResponseModel() { Id = 2L }
        };
        _bookServiceMock.Setup(s => s.GetEntitiesAsync(null)).ReturnsAsync(books);

        var result = await _bookController.GetAll();

        Assert.NotNull(result);
        Assert.IsInstanceOf(result.GetType(), typeof(ActionResult<List<BookResponseModel>>));
    }
    
    [TestMethod]
    public async Task AddBook_ReturnsOk()
    {
        var bookModel = new AddBookRequestModel()
        {
            Name = "Yaban"
        };

        var result = await _bookController.Add(bookModel);

        Assert.NotNull(result);
        Assert.IsInstanceOf(result.GetType(), typeof(IActionResult));
        _bookServiceMock.Verify(s => s.AddAsync(It.IsAny<Book>()), Times.Once);
    }
    
    [TestMethod]
    public async Task UpdateBook_ReturnsOk()
    {
        var bookModel = new UpdateBookRequestModel()
        {
            Id = 1L,
            Name = "Cenk"
        };

        var result = await _bookController.Update(bookModel);

        Assert.NotNull(result);
        Assert.IsInstanceOf(result.GetType(), typeof(IActionResult));
        _bookServiceMock.Verify(s => s.UpdateAsync(It.IsAny<Book>()), Times.Once);
    }
    
    [TestMethod]
    public async Task DeleteBook_ReturnsOk()
    {
        var bookId = 1L;
        var result = await _bookController.Delete(bookId);
        _bookServiceMock.Verify(s => s.DeleteByIdAsync(bookId), Times.Once);
    }
}