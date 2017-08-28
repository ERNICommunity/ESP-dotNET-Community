using FluentAssertions;
using Xunit;

namespace WarColors.ViewModels.UnitTests
{
    public class HelloViewModelTest
    {
        [Fact(DisplayName = "HelloViewModel check properties")]
        public void HelloViewModelCheckProperties()
        {
            // Arrange.
            var helloViewModel = new HelloViewModel { Name = "Name" };

            // Act.
            helloViewModel.Name = "NameExpected";

            // Assert.
            helloViewModel.Greeting.Should().Be("Hello, NameExpected!");
            helloViewModel.Name.Should().Be("NameExpected");
        }
    }
}
