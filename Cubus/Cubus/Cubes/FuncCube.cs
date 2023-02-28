using System;
using System.Runtime.CompilerServices;

namespace Cubus
{
  public class FuncCube<T> : Cube<T>
  {
    public Func<int, int, int, T> Getter { get; private set; }
    public Action<int, int, int, T> Setter { get; private set; }

    /// <inheritdoc/>
    public override T this[int x, int y, int z]
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      get => Getter(x, y, z);

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      set => Setter(x, y, z, value);
    }

    public FuncCube(Shape shape, Func<int, int, int, T> getter, Action<int, int, int, T> setter) : base(shape)
    {
      Getter = getter;
      Setter = setter;
    }
  }
}

