using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Cubus
{
  public static class Convert<Tin>
  {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Func<Tin, Tout> To<Tout>()
    {
      Debug.Assert(typeof(IConvertible).IsAssignableFrom(typeof(Tin)));
      Debug.Assert(typeof(IConvertible).IsAssignableFrom(typeof(Tout)));

      var parameter = Expression.Parameter(typeof(Tin));
      var convert = Expression.Convert(parameter, typeof(Tout));
      var lambda = Expression.Lambda<Func<Tin, Tout>>(convert, parameter);

      return lambda.Compile();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Tout To<Tout>(Tin value)
    {
      Debug.Assert(typeof(IConvertible).IsAssignableFrom(typeof(Tin)));
      Debug.Assert(typeof(IConvertible).IsAssignableFrom(typeof(Tout)));

      return (Tout)Convert.ChangeType(value, typeof(Tout));
    }
  }
}
