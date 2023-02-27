using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Cubus.Cubes;
using Cubus.Filters;
using Cubus.Interfaces;

namespace Cubus.Extensions
{
  public static class CubeExtensions
  {
    #region [ A ]

    public static Cube<T> Average<T>(this Cube<T> cube)
    {
      return new AverageFilter<T>(cube);
    }

    #endregion

    #region [ B ]
    #endregion

    #region [ C ]

    public static Cube<T> Clamp<T>(this Cube<T> cube, T lo, T hi)
      where T : IComparable
    {
      return new ClampFilter<T>(cube, lo, hi);
    }

    public static Cube<T> Freeze<T>(this Cube<T> cube, Layout? layout = null)
    {
      var oldcube = cube as IContiguousCube<T>;

      if ((oldcube != null) && (layout == null || layout == oldcube.Layout))
      {
        return cube;
      }

      var newcube = new ArrayCube<T>(cube.Shape, layout ?? oldcube?.Layout);

      var xyz = newcube.Layout.XYZ();

      foreach (var (x, y, z) in xyz)
      {
        newcube[x, y, z] = cube[x, y, z];
      }

      return newcube;
    }

    #endregion

    #region [ D ]
    #endregion

    #region [ E ]
    #endregion

    #region [ F ]

    public static Cube<T> FreezeParallel<T>(this Cube<T> cube, Layout? layout = null)
    {
      var oldcube = cube as IContiguousCube<T>;

      if ((oldcube != null) && (layout == null || layout == oldcube.Layout))
      {
        return cube;
      }

      var newcube = new ArrayCube<T>(cube.Shape, layout ?? oldcube?.Layout);

      var xyz = newcube.Layout.XYZ();

      Parallel.ForEach(xyz, (_) =>
      {
        var (x, y, z) = _;
        newcube[x, y, z] = cube[x, y, z];
      });

      return newcube;
    }

    #endregion

    #region [ G ]
    #endregion

    #region [ H ]

    public static Cube<T> Hue<T>(this Cube<T> cube, (int r, int g, int b) rgb)
    {
      return new HueFilter<T>(cube, rgb);
    }

    #endregion

    #region [ I ]
    #endregion

    #region [ J ]
    #endregion

    #region [ K ]
    #endregion

    #region [ L ]

    public static Cube<T> Lightness<T>(this Cube<T> cube, (int r, int g, int b) rgb)
    {
      return new LightnessFilter<T>(cube, rgb);
    }

    #endregion

    #region [ M ]

    public static Cube<T> Max<T>(this Cube<T> cube)
    {
      return new MaxFilter<T>(cube);
    }

    public static Cube<T> Min<T>(this Cube<T> cube)
    {
      return new MinFilter<T>(cube);
    }

    #endregion

    #region [ N ]
    #endregion

    #region [ O ]
    #endregion

    #region [ P ]
    #endregion

    #region [ Q ]
    #endregion

    #region [ R ]
    #endregion

    #region [ S ]

    public static Cube<T> Saturation<T>(this Cube<T> cube, (int r, int g, int b) rgb)
    {
      return new SaturationFilter<T>(cube, rgb);
    }

    public static Cube<T> Scale<T>(this Cube<T> cube, double slope)
    {
      return new ScaleFilter<T>(cube, slope);
    }

    #endregion

    #region [ T ]

    public static T[] ToArray<T>(this Cube<T> cube, Layout? layout = null)
    {
      return ((IContiguousCube<T>)cube.Freeze(layout)).Span.ToArray();
    }

    #endregion

    #region [ U ]
    #endregion

    #region [ V ]
    #endregion

    #region [ W ]
    #endregion

    #region [ X ]

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<int> X<T>(this Cube<T> cube, Layout? layout = null)
    {
      return Enumerable.Range(0, cube.Shape.Width);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<(int x, int y)> XY<T>(this Cube<T> cube, Layout? layout = null)
    {
      return (layout ?? (cube as IContiguousCube<T>)?.Layout ?? Layout.Default(cube.Shape)).XY();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<(int x, int y, int z)> XYZ<T>(this Cube<T> cube, Layout? layout = null)
    {
      return (layout ?? (cube as IContiguousCube<T>)?.Layout ?? Layout.Default(cube.Shape)).XYZ();
    }

    #endregion

    #region [ Y ]

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<int> Y<T>(this Cube<T> cube, Layout? layout = null)
    {
      return Enumerable.Range(0, cube.Shape.Height);
    }

    #endregion

    #region [ Z ]

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<int> Z<T>(this Cube<T> cube, Layout? layout = null)
    {
      return Enumerable.Range(0, cube.Shape.Length);
    }

    #endregion
  }
}
