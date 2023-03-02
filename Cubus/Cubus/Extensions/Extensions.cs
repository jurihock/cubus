using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Cubus
{
  public static class Extensions
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Mirror(this int number, int range)
    {
      return number + (number < 0 ? range : 0);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (int, int) Mirror(this (int, int) numbers, int range)
    {
      return (numbers.Item1.Mirror(range),
              numbers.Item2.Mirror(range));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (int, int, int) Mirror(this (int, int, int) numbers, int range)
    {
      return (numbers.Item1.Mirror(range),
              numbers.Item2.Mirror(range),
              numbers.Item3.Mirror(range));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (int start, int stop) Limit(this (int? start, int? stop)? roi, int range)
    {
      return (roi?.start ?? 0, roi?.stop ?? range);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Start(this (int start, int stop) range)
    {
      return range.start;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Stop(this (int start, int stop) range)
    {
      return range.stop;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Count(this (int start, int stop) range)
    {
      return range.stop - range.start;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<int> Enumerate(this (int start, int stop) range)
    {
      return Enumerable.Range(range.Start(), range.Count());
    }

    public static Cube<T> ToCube<T>(this T[] array, Shape shape, Layout? layout = null)
    {
      var data = array.ToArray();

      return new MemoryCube<T>(data, shape, layout);
    }

    public static Cube<T> ToCube<T>(this T[,,] array, Layout? layout = null)
    {
      var data = array.Cast<T>().ToArray();
      var shape = new Shape(array.GetLength(0), array.GetLength(1), array.GetLength(2));

      return new MemoryCube<T>(data, shape, layout);
    }
  }
}

