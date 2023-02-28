using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Cubus.Filters
{
  public class AverageFilter<T> : Filter<T>, IReadOnlyCube
  {
    private static readonly Func<T, double> ConvertForward = Convert<T>.To<double>();
    private static readonly Func<double, T> ConvertBackward = Convert<double>.To<T>();

    public override T this[int x, int y, int z]
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      get => ConvertBackward(Cube.Z().Average(z => ConvertForward(Cube[x, y, z])));

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      set => throw new ReadOnlyCubeException(GetType());
    }

    public AverageFilter(Cube<T> cube) : base(cube, cube.Shape.Length(1))
    {
    }


  }
}
