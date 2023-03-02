using System.Linq;
using System.Runtime.CompilerServices;

namespace Cubus.Filters
{
  public class CropFilter<T> : Filter<T>
  {
    public readonly int[] IndexX, IndexY, IndexZ;

    public override T this[int x, int y, int z]
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      get => Cube[IndexX[x], IndexY[y], IndexZ[z]];

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      set => Cube[IndexX[x], IndexY[y], IndexZ[z]] = value;
    }

    public CropFilter(Cube<T> cube, (int? start, int? stop)? x, (int? start, int? stop)? y, (int? start, int? stop)? z) :
      base(cube, cube.Shape.Crop(x, y, z))
    {
      IndexX = x.Limit(cube.Shape.Width).Mirror(cube.Shape.Width).Enumerate().ToArray();
      IndexY = y.Limit(cube.Shape.Height).Mirror(cube.Shape.Height).Enumerate().ToArray();
      IndexZ = z.Limit(cube.Shape.Length).Mirror(cube.Shape.Length).Enumerate().ToArray();
    }
  }
}
