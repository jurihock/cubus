using System;
using System.Runtime.CompilerServices;

namespace Cubus.Filters.Transform
{
  public class TransposeFilter<T> : Filter<T>
  {
    public readonly Func<int, int, int, (int x, int y, int z)> Transpose;

    public override T this[int x, int y, int z]
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      get
      {
        (x, y, z) = Transpose(x, y, z);
        return Cube[x, y, z];
      }

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      set
      {
        (x, y, z) = Transpose(x, y, z);
        Cube[x, y, z] = value;
      }
    }

    public TransposeFilter(Cube<T> cube, (int x, int y, int z) axes) :
      base(cube, cube.Shape.Transpose(axes))
    {
      Transpose = GetTransposeFunc(axes.Mirror(3));
    }

    private static Func<int, int, int, (int x, int y, int z)> GetTransposeFunc((int x, int y, int z) axes)
    {
      if (axes == (0, 1, 2))
      {
        return (x, y, z) => (x, y, z);
      }
      else if (axes == (0, 2, 1))
      {
        return (x, y, z) => (x, z, y);
      }
      else if (axes == (1, 0, 2))
      {
        return (x, y, z) => (y, x, z);
      }
      else if (axes == (1, 2, 0))
      {
        return (x, y, z) => (y, z, x);
      }
      else if (axes == (2, 0, 1))
      {
        return (x, y, z) => (z, x, y);
      }
      else if (axes == (2, 1, 0))
      {
        return (x, y, z) => (z, y, x);
      }
      else
      {
        throw new ArgumentOutOfRangeException(nameof(axes),
          $"Invalid axis index: 0, 1 or 2 expected, got {axes}!");
      }
    }
  }
}
