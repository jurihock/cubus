using System;

namespace Cubus.Interfaces
{
  public interface IContiguousCube<T>
  {
    Layout Layout { get; }

    #if NETSTANDARD2_1_OR_GREATER

    ReadOnlySpan<T> Span { get; }

    #else

    T[] Span { get; }

    #endif
  }
}

