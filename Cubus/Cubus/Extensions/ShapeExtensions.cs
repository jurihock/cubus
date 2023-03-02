using System;
using System.Linq;
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

    public static Shape Transpose(this Shape shape, (int x, int y, int z) axes)
    {
      var xyz = new[] { axes.x.Mirror(3), axes.y.Mirror(3), axes.z.Mirror(3) };

      if (xyz.Distinct().Count() != 3)
      {
        throw new ArgumentException(
          $"Repeated axis in {axes}!",
          nameof(axes));
      }

      if (xyz.Any(i => (i < 0) || (2 < i)))
      {
        throw new ArgumentException(
          $"Out of bounds axis in {axes}!",
          nameof(axes));
      }

      var whl = new[] { shape.Width, shape.Height, shape.Length };

      return new Shape(whl[xyz[0]], whl[xyz[1]], whl[xyz[2]]);
    }
  }
}

