using System;
using System.Runtime.CompilerServices;

namespace Cubus.Filters
{
  public class ClampFilter<T> : Filter<T>
    where T : IComparable
  {
    public T Lo { get; private set; }
    public T Hi { get; private set; }

    public override T this[int x, int y, int z]
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      get => Clamp(Cube[x, y, z], Lo, Hi);

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      set => Cube[x, y, z] = Clamp(value, Lo, Hi);
    }

    public ClampFilter(Cube<T> cube, T lo, T hi) : base(cube)
    {
      Lo = lo;
      Hi = hi;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static T Clamp(T value, T lo, T hi)
    {
      if (value.CompareTo(lo) < 0)
      {
        return lo;
      }
      else if (value.CompareTo(hi) > 0)
      {
        return hi;
      }
      else
      {
        return value;
      }
    }
  }
}

