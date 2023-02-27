using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cubus.Layouts;

namespace Cubus
{
  public abstract class Layout
  {
    public Shape Shape { get; private set; }

    public abstract int this[int x, int y, int z] { get; }

    protected Layout(Shape shape)
    {
      Shape = shape;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public IEnumerable<int> X() => Enumerable.Range(0, Shape.Width);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public IEnumerable<int> Y() => Enumerable.Range(0, Shape.Height);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public IEnumerable<int> Z() => Enumerable.Range(0, Shape.Length);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public abstract IEnumerable<(int x, int y)> XY();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public abstract IEnumerable<(int x, int y, int z)> XYZ();

    public static Layout Default(Shape shape) => LayoutFactory.GetLayout(shape);
    public static Layout Custom<T>(Shape shape) where T : Layout => LayoutFactory.GetLayout<T>(shape);
  }
}
