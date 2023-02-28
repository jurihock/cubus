using System;
using System.Runtime.CompilerServices;

namespace Cubus.Filters
{
  public class SaturationFilter<T> : Filter<T>, IReadOnlyCube
  {
    private static readonly Func<T, int> ConvertForward = Convert<T>.To<int>();
    private static readonly Func<float, T> ConvertBackward = Convert<float>.To<T>();

    public (int r, int g, int b) RGB { get; private set; }

    public override T this[int x, int y, int z]
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      get => GetSaturation(Cube[x, y, RGB.r], Cube[x, y, RGB.g], Cube[x, y, RGB.b]);

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      set => throw new ReadOnlyCubeException(GetType());
    }

    public SaturationFilter(Cube<T> cube, (int r, int g, int b) rgb) :
      base(cube, cube.Shape.Length(1))
    {
      RGB = rgb;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static T GetSaturation(T r, T g, T b)
    {
      var color = System.Drawing.Color.FromArgb(
        ConvertForward(r), ConvertForward(g), ConvertForward(b));

      return ConvertBackward(color.GetSaturation());
    }
  }
}

