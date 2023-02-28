using System;

namespace Cubus
{
  public class InvalidCubeLayoutShapeException : ArgumentException
  {
    public InvalidCubeLayoutShapeException(Layout layout, Shape shape)
    {
    }
  }
}
