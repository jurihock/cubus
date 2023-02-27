using System;
using System.Runtime.CompilerServices;
using Cubus.Exceptions;
using Cubus.Interfaces;

namespace Cubus.Cubes
{
  public class ReadOnlyFuncCube<T> : Cube<T>, IReadOnlyCube
  {
    public Func<int, int, int, T> Getter { get; private set; }

    public override T this[int x, int y, int z]
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      get => Getter(x, y, z);

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      set => throw new ReadOnlyCubeException(GetType());
    }

    public ReadOnlyFuncCube(Shape shape, Func<int, int, int, T> getter) : base(shape)
    {
      Getter = getter;
    }
  }
}

