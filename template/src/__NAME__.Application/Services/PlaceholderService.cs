using __NAMESPACE__.Application.DTOs;
using __NAMESPACE__.Application.Interfaces;
using __NAMESPACE__.Domain.Entities;

namespace __NAMESPACE__.Application.Services;

public sealed class PlaceholderService : IPlaceholderService
{
    public PlaceholderDto GetPlaceholder()
    {
        var entity = new PlaceholderEntity();
        return new PlaceholderDto(entity.Id, "Hello from __NAME__");
    }
}
