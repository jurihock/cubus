using System;

namespace Cubus.Interfaces
{
  public interface IContiguousCube<T>
  {
    Layout Layout { get; }
    ReadOnlySpan<T> Span { get; }
  }
}

