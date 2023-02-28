#if NETSTANDARD2_1_OR_GREATER

using System;
using System.Runtime.CompilerServices;

namespace Cubus
{
  public class ReadOnlyMemoryCube<T> : Cube<T>, IContiguousCube<T>, IReadOnlyCube
  {
    public ReadOnlyMemory<T> Data { get; private set; }
    public Layout Layout { get; private set; }
    public ReadOnlySpan<T> Span => Data.Span;

    /// <inheritdoc/>
    public override T this[int x, int y, int z]
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      get => Data.Span[Layout[x, y, z]];

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      set => throw new ReadOnlyCubeException(GetType());
    }

    public ReadOnlyMemoryCube(ReadOnlyMemory<T> data, Shape shape, Layout? layout = null) : base(shape)
    {
      if (data.Length != Shape.Volume)
      {
        throw new InvalidCubeArrayLengthException(nameof(data), data.Length, Shape);
      }

      Data = data;
      Layout = layout ?? Layout.Default(shape);

      if (Layout.Shape != Shape)
      {
        throw new InvalidCubeLayoutShapeException(Layout, Shape);
      }
    }

    public ReadOnlyMemoryCube(T[] data, Shape shape, Layout? layout = null) : this(data.AsMemory(), shape, layout)
    {
    }
  }
}

#endif
