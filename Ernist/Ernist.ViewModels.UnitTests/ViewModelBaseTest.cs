using FluentAssertions;
using Xunit;

namespace Ernist.ViewModels.UnitTests
{
    public class ViewModelBaseTest
    {
        // Testee.
        private ClassViewModel _classViewModel;

        public ViewModelBaseTest()
        {
            _classViewModel = new ClassViewModel();
        }

        [Fact]
        public void CheckGetSetViewModelProperties()
        {
            // Arrange.
            // Act.
            _classViewModel.Property1 = "Text 1";
            _classViewModel.Property2 = "Text 2";

            // Assert.
            _classViewModel.Property1.Should().Be("Text 1");
            _classViewModel.Property2.Should().Be("Text 2");
        }
    }
}
