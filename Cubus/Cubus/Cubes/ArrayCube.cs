#if NETSTANDARD2_1_OR_GREATER

using System;
using System.Runtime.CompilerServices;
using Cubus.Exceptions;
using Cubus.Interfaces;

namespace Cubus.Cubes
{
  public class ArrayCube<T> : Cube<T>, IContiguousCube<T>
  {
    public T[] Data { get; private set; }
    public Layout Layout { get; private set; }
    public ReadOnlySpan<T> Span => Data.AsSpan<T>();

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
      Array.Fill(Data, value);
    }

    public ArrayCube(T[] data, Shape shape, Layout? layout = null) : this(shape, layout)
    {
      if (data.Length != Shape.Volume)
      {
        throw new InvalidCubeArrayLengthException(nameof(data), data.Length, Shape);
      }

      data.CopyTo(Data, 0);
    }

    public ArrayCube(Memory<T> data, Shape shape, Layout? layout = null) : this(shape, layout)
    {
      if (data.Length != Shape.Volume)
      {
        throw new InvalidCubeArrayLengthException(nameof(data), data.Length, Shape);
      }

      data.CopyTo(Data);
    }

    public ArrayCube(ReadOnlyMemory<T> data, Shape shape, Layout? layout = null) : this(shape, layout)
    {
      if (data.Length != Shape.Volume)
      {
        throw new InvalidCubeArrayLengthException(nameof(data), data.Length, Shape);
      }

      data.CopyTo(Data);
    }

    public ArrayCube(Span<T> data, Shape shape, Layout? layout = null) : this(shape, layout)
    {
      if (data.Length != Shape.Volume)
      {
        throw new InvalidCubeArrayLengthException(nameof(data), data.Length, Shape);
      }

      data.CopyTo(Data);
    }

    public ArrayCube(ReadOnlySpan<T> data, Shape shape, Layout? layout = null) : this(shape, layout)
    {
      if (data.Length != Shape.Volume)
      {
        throw new InvalidCubeArrayLengthException(nameof(data), data.Length, Shape);
      }

      data.CopyTo(Data);
    }
  }
}

#endif