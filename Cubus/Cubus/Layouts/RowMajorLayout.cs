using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Cubus
{
  public sealed class RowMajorLayout : Layout
  {
    private readonly int[] OffsetX;
    private readonly int[] OffsetY;

    public override int this[int x, int y, int z]
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      get => OffsetX[x] + OffsetY[y] + z;
    }

    public RowMajorLayout(Shape shape) : base(shape)
    {
      OffsetX = Enumerable.Range(0, shape.Width).Select(x => x * Shape.Length).ToArray();
      OffsetY = Enumerable.Range(0, shape.Height).Select(y => y * Shape.Width).ToArray();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override IEnumerable<(int x, int y)> XY()
    {
      var width = Shape.Width;
      var height = Shape.Height;

      for (var y = 0; y < height; y++)
      {
        for (var x = 0; x < width; x++)
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

      for (var y = 0; y < height; y++)
      {
        for (var x = 0; x < width; x++)
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
