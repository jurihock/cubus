using System;
using System.Runtime.CompilerServices;
using Cubus.Exceptions;
using Cubus.Interfaces;

namespace Cubus.Filters
{
  public class ReadOnlyFuncFilter<Tin, Tout> : Filter<Tin, Tout>, IReadOnlyCube
  {
    public Func<Tin, Tout> Getter { get; private set; }

    public override Tout this[int x, int y, int z]
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      get => Getter(Cube[x, y, z]);

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      set => throw new ReadOnlyCubeException(GetType());
    }

    public ReadOnlyFuncFilter(Cube<Tin> cube, Func<Tin, Tout> getter) : base(cube)
    {
      Getter = getter;
    }
  }
}
