using System;

namespace Cruises.Application.Common.Exceptions
{
  public class NotFoundException
    : Exception
  {
    public NotFoundException(string message)
      : base(message) { }

    public NotFoundException(
      string message,
      Exception exception
    ) : base(
      message,
      exception
    )
    { }

    public NotFoundException(
        string entityName, object objectKey
    ) : base($"Entity \"{entityName}\" ({objectKey}) was not found.") { }
  }
}
