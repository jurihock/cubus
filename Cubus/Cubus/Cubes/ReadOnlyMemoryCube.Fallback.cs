#if NETSTANDARD2_0

using System;
using System.Runtime.CompilerServices;

namespace Cubus
{
  public class ReadOnlyMemoryCube<T> : Cube<T>, IContiguousCube<T>, IReadOnlyCube
  {
    public T[] Data { get; private set; }
    public Layout Layout { get; private set; }
    public T[] Span => Data;

    /// <inheritdoc/>
    public override T this[int x, int y, int z]
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      get => Data[Layout[x, y, z]];

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      set => throw new ReadOnlyCubeException(GetType());
    }

    public ReadOnlyMemoryCube(T[] data, Shape shape, Layout? layout = null) : base(shape)
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
  }
}

#endif
