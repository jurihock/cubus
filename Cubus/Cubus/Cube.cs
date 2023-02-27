using System;
using Cubus.Cubes;
using Cubus.Filters;

namespace Cubus
{
  public abstract class Cube<T>
  {
    public Shape Shape { get; private set; }

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
