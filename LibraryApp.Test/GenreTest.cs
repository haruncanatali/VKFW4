using LibraryApp.Api.Controllers;
using LibraryApp.Api.Models;
using LibraryApp.Business.Abstract;
using LibraryApp.DataAccess.Common.Dtos.GenreDtos;
using LibraryApp.Entities.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Assert = NUnit.Framework.Assert;

namespace LibraryApp.Test;

public class GenreTest
{
    private readonly Mock<IGenreService> _genreServiceMock;
    private readonly GenreController _genreController;

    public GenreTest()
    {
        _genreServiceMock = new Mock<IGenreService>();
        _genreController = new GenreController(_genreServiceMock.Object);
    }
    
    [TestMethod]
    public async Task GetGenre_ReturnsOk()
    {
        var genreId = 1L;
        var genre = new GenreResponseModel { Id = genreId };
        _genreServiceMock.Setup(s => s.GetEntityAsync(c => c.Id == genreId)).ReturnsAsync(genre);

        var result = await _genreController.Get(genreId);

        Assert.NotNull(result);
        Assert.IsInstanceOf(result.GetType(), typeof(ActionResult<GenreResponseModel>));
    } 
    
    [TestMethod]
    public async Task GetAllGenres_ReturnsOk()
    {
        var genres = new List<GenreResponseModel>()
        {
            new GenreResponseModel() { Id = 1L },
            new GenreResponseModel() { Id = 2L }
        };
        _genreServiceMock.Setup(s => s.GetEntitiesAsync(null)).ReturnsAsync(genres);

        var result = await _genreController.GetAll();

        Assert.NotNull(result);
        Assert.IsInstanceOf(result.GetType(), typeof(ActionResult<List<GenreResponseModel>>));
    }
    
    [TestMethod]
    public async Task AddGenre_ReturnsOk()
    {
        var genreModel = new AddGenreRequestModel()
        {
            Name = "Polisiye"
        };

        var result = await _genreController.Add(genreModel);

        Assert.NotNull(result);
        Assert.IsInstanceOf(result.GetType(), typeof(IActionResult));
        _genreServiceMock.Verify(s => s.AddAsync(It.IsAny<Genre>()), Times.Once);
    }
    
    [TestMethod]
    public async Task UpdateGenre_ReturnsOk()
    {
        var genreModel = new UpdateGenreRequestModel()
        {
            Id = 1L,
            Name = "Polisiye"
        };

        var result = await _genreController.Update(genreModel);

        Assert.NotNull(result);
        Assert.IsInstanceOf(result.GetType(), typeof(IActionResult));
        _genreServiceMock.Verify(s => s.UpdateAsync(It.IsAny<Genre>()), Times.Once);
    }
    
    [TestMethod]
    public async Task DeleteGenre_ReturnsOk()
    {
        var genreId = 1L;
        var result = await _genreController.Delete(genreId);
        _genreServiceMock.Verify(s => s.DeleteByIdAsync(genreId), Times.Once);
    }
}