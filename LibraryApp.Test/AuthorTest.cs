using System.Net;
using LibraryApp.Api.Controllers;
using LibraryApp.Api.Models;
using LibraryApp.Business.Abstract;
using LibraryApp.DataAccess.Common.Dtos.AuthorDtos;
using LibraryApp.Entities.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Assert = NUnit.Framework.Assert;

namespace LibraryApp.Test;

[TestClass]
public class AuthorTest
{
    private readonly Mock<IAuthorService> _authorServiceMock;
    private readonly AuthorController _authorController;

    public AuthorTest()
    {
        _authorServiceMock = new Mock<IAuthorService>();
        _authorController = new AuthorController(_authorServiceMock.Object);
    }

    [TestMethod]
    public async Task GetAuthor_ReturnsOk()
    {
        var authorId = 1L;
        var author = new AuthorResponseModel() { Id = authorId };
        _authorServiceMock.Setup(s => s.GetEntityAsync(c => c.Id == authorId)).ReturnsAsync(author);

        var result = await _authorController.Get(authorId);

        Assert.NotNull(result);
        Assert.IsInstanceOf(result.GetType(), typeof(ActionResult<AuthorResponseModel>));
    } 
    
    [TestMethod]
    public async Task GetAllAuthors_ReturnsOk()
    {
        var authors = new List<AuthorResponseModel>()
        {
            new AuthorResponseModel() { Id = 1L },
            new AuthorResponseModel() { Id = 2L }
        };
        _authorServiceMock.Setup(s => s.GetEntitiesAsync(null)).ReturnsAsync(authors);

        var result = await _authorController.GetAll();

        Assert.NotNull(result);
        Assert.IsInstanceOf(result.GetType(), typeof(ActionResult<List<AuthorResponseModel>>));
    }
    
    [TestMethod]
    public async Task AddAuthor_ReturnsOk()
    {
        var authorModel = new AddAuthorRequestModel()
        {
            Name = "Cenk",
            Surname = "Kemal",
            Birthdate = new DateTime(1981, 1, 1)
        };

        var result = await _authorController.Add(authorModel);

        Assert.NotNull(result);
        Assert.IsInstanceOf(result.GetType(), typeof(IActionResult));
        _authorServiceMock.Verify(s => s.AddAsync(It.IsAny<Author>()), Times.Once);
    }
    
    [TestMethod]
    public async Task UpdateAuthor_ReturnsOk()
    {
        var authorModel = new UpdateAuthorRequestModel()
        {
            Id = 1L,
            Name = "Cenk",
            Surname = "Kemal",
            Birthdate = new DateTime(1999, 1, 1)
        };

        var result = await _authorController.Update(authorModel);

        Assert.NotNull(result);
        Assert.IsInstanceOf(result.GetType(), typeof(IActionResult));
        _authorServiceMock.Verify(s => s.UpdateAsync(It.IsAny<Author>()), Times.Once);
    }
    
    [TestMethod]
    public async Task DeleteAuthor_ReturnsOk()
    {
        var authorId = 1L;
        var result = await _authorController.Delete(authorId);
        _authorServiceMock.Verify(s => s.DeleteAuthorWithBooks(authorId), Times.Once);
    }
}