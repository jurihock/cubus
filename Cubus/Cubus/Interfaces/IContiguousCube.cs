#if NETSTANDARD2_1_OR_GREATER

using System;

namespace Cubus
{
  public interface IContiguousCube<T>
  {
    Layout Layout { get; }
    ReadOnlySpan<T> Span { get; }
  }
}

#endif
