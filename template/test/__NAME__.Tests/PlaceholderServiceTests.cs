using __NAMESPACE__.Application.Services;
using Xunit;

namespace __NAMESPACE__.Tests;

public class PlaceholderServiceTests
{
    [Fact]
    public void GetPlaceholder_returns_expected_message()
    {
        var service = new PlaceholderService();
        var dto = service.GetPlaceholder();
        Assert.Equal("Hello from __NAME__", dto.Message);
    }
}
