using System;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Moq;
using CinemaApp.BLL.Contracts;
using CinemaApp.BLL.Implementation;
using CinemaApp.DAL.Contracts;
using CinemaApp.Domain;
using CinemaApp.Domain.Models;
using NUnit.Framework;

namespace CinemaApp.BLL.Tests.Unit
{
    [TestFixture]
    public class NoteServiceTest
    {
        [Test]
        public async Task CreateAsync_NoteValidationSucceed_CreatesNote()
        {
            // Arrange
            var note = new NoteUpdateModel();
            var expected = new Note();
            
            var visitorService = new Mock<IVisitorService>();
            visitorService.Setup(x => x.ValidateAsync(note));
            var sessionService = new Mock<ISessionService>();
            sessionService.Setup(x => x.ValidateAsync(note));
            var filmService = new Mock<IFilmService>();
            filmService.Setup(x => x.ValidateAsync(note));
            
            var noteDAL = new Mock<INoteDAL>();
            noteDAL.Setup(x => x.InsertAsync(note)).ReturnsAsync(expected);

            var noteService = new NoteService(noteDAL.Object, visitorService.Object, sessionService.Object,filmService.Object);
            
            // Act
            var result = await noteService.CreateAsync(note);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Test]
        public async Task CreateAsync_NoteValidationVisitorFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var note = new NoteUpdateModel();
            var expected = fixture.Create<string>();
            
            var visitorService = new Mock<IVisitorService>();
            visitorService.Setup(x => x.ValidateAsync(note))
                .Throws(new InvalidOperationException(expected));
            var sessionService = new Mock<ISessionService>();
            sessionService.Setup(x => x.ValidateAsync(note));
            var filmService = new Mock<IFilmService>();
            filmService.Setup(x => x.ValidateAsync(note));

            
            var noteDAL = new Mock<INoteDAL>();
            
            var noteService = new NoteService(noteDAL.Object, visitorService.Object, sessionService.Object,filmService.Object);
            
            var action = new Func<Task>(() => noteService.CreateAsync(note));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            noteDAL.Verify(x => x.InsertAsync(note), Times.Never);
        }
        
        [Test]
        public async Task CreateAsync_NoteValidationSessionFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var note = new NoteUpdateModel();
            var expected = fixture.Create<string>();
            
            var visitorService = new Mock<IVisitorService>();
            visitorService.Setup(x => x.ValidateAsync(note));
            var sessionService = new Mock<ISessionService>();
            sessionService.Setup(x => x.ValidateAsync(note)) 
                .Throws(new InvalidOperationException(expected));
            var filmService = new Mock<IFilmService>();
            filmService.Setup(x => x.ValidateAsync(note));

            
            var noteDAL = new Mock<INoteDAL>();
            
            var noteService = new NoteService(noteDAL.Object, visitorService.Object, sessionService.Object,filmService.Object);
            
            var action = new Func<Task>(() => noteService.CreateAsync(note));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            noteDAL.Verify(x => x.InsertAsync(note), Times.Never);
        }
        
        [Test]
        public async Task CreateAsync_NoteValidationFilmFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var note = new NoteUpdateModel();
            var expected = fixture.Create<string>();
            
            var visitorService = new Mock<IVisitorService>();
            visitorService.Setup(x => x.ValidateAsync(note));
            var sessionService = new Mock<ISessionService>();
            sessionService.Setup(x => x.ValidateAsync(note));
            var filmService = new Mock<IFilmService>();
            filmService.Setup(x => x.ValidateAsync(note))
                .Throws(new InvalidOperationException(expected));

            
            var noteDAL = new Mock<INoteDAL>();
            
            var noteService = new NoteService(noteDAL.Object, visitorService.Object, sessionService.Object,filmService.Object);
            
            var action = new Func<Task>(() => noteService.CreateAsync(note));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            noteDAL.Verify(x => x.InsertAsync(note), Times.Never);
        }
    }
}