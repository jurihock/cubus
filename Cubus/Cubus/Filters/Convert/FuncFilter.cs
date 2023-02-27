using System;
using System.Runtime.CompilerServices;

namespace Cubus.Filters
{
  public class FuncFilter<Tin, Tout> : Filter<Tin, Tout>
  {
    public Func<Tin, Tout> Getter { get; private set; }
    public Func<Tout, Tin> Setter { get; private set; }

    public override Tout this[int x, int y, int z]
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      get => Getter(Cube[x, y, z]);

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      set => Cube[x, y, z] = Setter(value);
    }

    public FuncFilter(Cube<Tin> cube, Func<Tin, Tout> getter, Func<Tout, Tin> setter) : base(cube)
    {
      Getter = getter;
      Setter = setter;
    }
  }
}
