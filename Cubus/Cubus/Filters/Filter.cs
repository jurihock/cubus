using System;

namespace Cubus.Filters
{
  public abstract class Filter<T> : Cube<T>
  {
    public Cube<T> Cube { get; private set; }

    public Filter(Cube<T> cube, Shape? shape = null) : base(shape ?? cube.Shape)
    {
      Cube = cube;
    }
  }

  public abstract class Filter<Tin, Tout> : Cube<Tout>
  {
    public Cube<Tin> Cube { get; private set; }

    public Filter(Cube<Tin> cube, Shape? shape = null) : base(shape ?? cube.Shape)
    {
      Cube = cube;
    }
  }
}
