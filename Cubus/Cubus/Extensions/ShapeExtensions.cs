using System.Runtime.CompilerServices;

namespace Cubus
{
  public static class ShapeExtensions
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Shape Width(this Shape shape, int width) =>
      new Shape(width, shape.Height, shape.Length);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Shape Height(this Shape shape, int height) =>
      new Shape(shape.Width, height, shape.Length);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Shape Length(this Shape shape, int length) =>
      new Shape(shape.Width, shape.Height, length);
  }
}

