using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using tell.me.a.joke.Controllers;
using tell.me.a.joke.Interfaces;
using Xunit;

namespace UnitTests
{
    public class ControllerUnitTests
    {
        private readonly JokesController _controller;
        private readonly Mock<IJokeService> _jokeService;

        public ControllerUnitTests()
        {
            _jokeService = new Mock<IJokeService>();
            _jokeService
                .Setup(js => js.GetAJoke())
                .ReturnsAsync("joke");
            _controller = new JokesController(_jokeService.Object);
        }

        [Fact(DisplayName = "When called calls GetAJoke method of JokeService")]
        public async Task WhenCalled_CallsGetAJokeMethodOfJokeServiceAsync()
        {
            ActionResult response = await _controller.GetAsync();

            _jokeService.Verify(js => js.GetAJoke(), Times.Once);
        }

        [Fact(DisplayName ="When called returns a joke")]
        public async Task WhenCalled_ReturnsAJokeAsync()
        {
            ActionResult response = await _controller.GetAsync();
            var result = response as OkObjectResult;

            Assert.Equal("joke", result.Value);
        }
    }
}
