using System.Runtime.CompilerServices;

namespace Cubus
{
  public static class Extensions
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Mirror(this int number, int range)
    {
      return number < 0 ? range - number : number;
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
  }
}

