using System;
using Cubus.Cubes;
using Cubus.Filters;

namespace Cubus
{
  public abstract class Cube<T>
  {
    public Shape Shape { get; private set; }

    /// <summary>
    /// Gets or sets the cube value at coordinate triple x, y and z.
    /// </summary>
    /// <param name="x">The horizontal coordinate.</param>
    /// <param name="y">The vertical coordinate.</param>
    /// <param name="z">The z-axis coordinate.</param>
    public abstract T this[int x, int y, int z] { get; set; }

    protected Cube(Shape shape)
    {
      Shape = shape;
    }

    public static Cube<T> Empty(Shape shape, Layout? layout = null)
    {
      return new ArrayCube<T>(shape, layout);
    }

    public static Cube<T> Full(T value, Shape shape, Layout? layout = null)
    {
      return new ArrayCube<T>(value, shape, layout);
    }

    public Cube<Tnew> Cast<Tnew>()
    {
      return new CastFilter<T, Tnew>(this);
    }
  }
}
