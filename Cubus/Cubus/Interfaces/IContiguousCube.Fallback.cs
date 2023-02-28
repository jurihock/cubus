#if NETSTANDARD2_0

using System;

namespace Cubus
{
  public interface IContiguousCube<T>
  {
    Layout Layout { get; }
    T[] Span { get; }
  }
}

#endif
