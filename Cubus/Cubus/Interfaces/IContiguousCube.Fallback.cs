#if NETSTANDARD2_0

using System;

namespace Cubus.Interfaces
{
  public interface IContiguousCube<T>
  {
    Layout Layout { get; }
    T[] Span { get; }
  }
}

#endif
