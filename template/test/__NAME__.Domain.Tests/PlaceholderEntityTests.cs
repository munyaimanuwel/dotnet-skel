using __NAMESPACE__.Domain.Entities;
using Xunit;

namespace __NAMESPACE__.Domain.Tests;

public class PlaceholderEntityTests
{
    [Fact]
    public void Entity_preserves_assigned_id()
    {
        var id = Guid.Parse("11111111-1111-1111-1111-111111111111");
        var entity = new PlaceholderEntity { Id = id };
        Assert.Equal(id, entity.Id);
    }
}
