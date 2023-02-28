using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Cubus.Cubes;
using Cubus.Interfaces;

namespace Cubus.Extensions
{
  public static class CubeExtensions
  {
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

    public static T[] ToArray<T>(this Cube<T> cube, Layout? layout = null)
    {
      return ((IContiguousCube<T>)cube.Freeze(layout)).Span.ToArray();
    }

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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<int> Y<T>(this Cube<T> cube, Layout? layout = null)
    {
      return Enumerable.Range(0, cube.Shape.Height);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<int> Z<T>(this Cube<T> cube, Layout? layout = null)
    {
      return Enumerable.Range(0, cube.Shape.Length);
    }
  }
}
