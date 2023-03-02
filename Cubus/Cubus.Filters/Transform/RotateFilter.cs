using System;

namespace Cubus.Filters.Transform
{
  public class RotateFilter<T> : Filter<T>
  {
    public override T this[int x, int y, int z]
    {
      get => throw new NotImplementedException();
      set => throw new NotImplementedException();
    }

    public RotateFilter(Cube<T> cube, int angle) : base(cube)
    {
      throw new NotImplementedException();
    }
  }
}

