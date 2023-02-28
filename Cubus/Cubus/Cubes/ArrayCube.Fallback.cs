#if NETSTANDARD2_0

using System;
using System.Runtime.CompilerServices;

namespace Cubus
{
  public class ArrayCube<T> : Cube<T>, IContiguousCube<T>
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
      set => Data[Layout[x, y, z]] = value;
    }

    public ArrayCube(Shape shape, Layout? layout = null) : base(shape)
    {
      Data = new T[shape.Volume];
      Layout = layout ?? Layout.Default(shape);

      if (Layout.Shape != Shape)
      {
        throw new InvalidCubeLayoutShapeException(Layout, Shape);
      }
    }

    public ArrayCube(T value, Shape shape, Layout? layout = null) : this(shape, layout)
    {
      for (var i = 0; i < Data.Length; i++)
      {
        Data[i] = value;
      }
    }

    public ArrayCube(T[] data, Shape shape, Layout? layout = null) : this(shape, layout)
    {
      if (data.Length != Shape.Volume)
      {
        throw new InvalidCubeArrayLengthException(nameof(data), data.Length, Shape);
      }

      data.CopyTo(Data, 0);
    }
  }
}

#endif