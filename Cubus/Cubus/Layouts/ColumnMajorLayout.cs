using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Cubus
{
  public sealed class ColumnMajorLayout : Layout
  {
    private readonly int[] OffsetX, OffsetY;

    public override int this[int x, int y, int z]
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      get => OffsetX[x] + OffsetY[y] + z;
    }

    public ColumnMajorLayout(Shape shape) : base(shape)
    {
      OffsetX = Enumerable.Range(0, shape.Width).Select(x => x * Shape.Height).ToArray();
      OffsetY = Enumerable.Range(0, shape.Height).Select(y => y * Shape.Length).ToArray();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override IEnumerable<(int x, int y)> XY()
    {
      var width = Shape.Width;
      var height = Shape.Height;

      for (var x = 0; x < width; x++)
      {
        for (var y = 0; y < height; y++)
        {
          yield return (x, y);
        }
      }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override IEnumerable<(int x, int y, int z)> XYZ()
    {
      var width = Shape.Width;
      var height = Shape.Height;
      var length = Shape.Length;

      for (var x = 0; x < width; x++)
      {
        for (var y = 0; y < height; y++)
        {
          for (var z = 0; z < length; z++)
          {
            yield return (x, y, z);
          }
        }
      }
    }
  }
}
