using System;

namespace Cubus
{
  public class InvalidCubeLayoutShapeException : ArgumentException
  {
    public InvalidCubeLayoutShapeException(Layout layout, Shape shape) : base(
      $"Invalid cube memory layout shape: {shape} expected, got {layout.Shape}!")
    {
    }
  }
}
