using System.Linq;
using System.Runtime.CompilerServices;

namespace Cubus.Filters
{
  public class MaxFilter<T> : Filter<T>, IReadOnlyCube
  {
    public override T this[int x, int y, int z]
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      get => Cube.Z().Max(z => Cube[x, y, z]);

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      set => throw new ReadOnlyCubeException(GetType());
    }

    public MaxFilter(Cube<T> cube) : base(cube, cube.Shape.Length(1))
    {
    }
  }
}

