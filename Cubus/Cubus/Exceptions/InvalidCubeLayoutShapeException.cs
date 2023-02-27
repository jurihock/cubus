using System;

namespace Cubus.Exceptions
{
  public class InvalidCubeLayoutShapeException : ArgumentException
  {
    public InvalidCubeLayoutShapeException(Layout layout, Shape shape)
    {
    }
  }
}
