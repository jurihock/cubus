using System;
using System.Runtime.CompilerServices;

namespace Cubus.Filters
{
  public class ScaleFilter<T> : Filter<T>
  {
    private static readonly Func<T, double> ConvertForward = Convert<T>.To<double>();
    private static readonly Func<double, T> ConvertBackward = Convert<double>.To<T>();

    public double Slope { get; private set; }
    public double InverseSlope { get; private set; }

    public override T this[int x, int y, int z]
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      get => ConvertBackward(ConvertForward(Cube[x, y, z]) * Slope);

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      set => Cube[x, y, z] = ConvertBackward((ConvertForward(value) * InverseSlope));
    }

    public ScaleFilter(Cube<T> cube, double slope) : base(cube)
    {
      Slope = slope;
      InverseSlope = 1 / slope;
    }
  }
}
