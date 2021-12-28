using REST_API_Task.Controllers;
using Xunit;

namespace REST_API_Task.Tests
{
    public class PingControllerTests
    {
        [Fact]
        public void GetPing_Test_Correct_Response()
        {
            var _controller = new PingController();

            var response = _controller.GetPing();

            Assert.NotNull(response);
            Assert.Equal("Dogs house service. Version 1.0.1", response.Value);
        }
    }
}
