using System.Linq;
using System.Runtime.CompilerServices;

namespace Cubus.Filters
{
  public class MinFilter<T> : Filter<T>, IReadOnlyCube
  {
    public override T this[int x, int y, int z]
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      get => Cube.Z().Min(z => Cube[x, y, z]);

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      set => throw new ReadOnlyCubeException(GetType());
    }

    public MinFilter(Cube<T> cube) : base(cube, cube.Shape.Length(1))
    {
    }
  }
}

