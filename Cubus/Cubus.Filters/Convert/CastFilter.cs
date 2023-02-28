using System;
using System.Runtime.CompilerServices;

namespace Cubus.Filters
{
  public class CastFilter<Tin, Tout> : Filter<Tin, Tout>
  {
    private static readonly Func<Tin, Tout> ConvertForward = Convert<Tin>.To<Tout>();
    private static readonly Func<Tout, Tin> ConvertBackward = Convert<Tout>.To<Tin>();

    public override Tout this[int x, int y, int z]
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      get => ConvertForward(Cube[x, y, z]);

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      set => Cube[x, y, z] = ConvertBackward(value);
    }

    public CastFilter(Cube<Tin> cube) : base(cube)
    {
    }
  }
}

