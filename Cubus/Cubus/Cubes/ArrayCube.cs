using System;
using System.Runtime.CompilerServices;
using Cubus.Exceptions;
using Cubus.Interfaces;

namespace Cubus.Cubes
{
  public class ArrayCube<T> : Cube<T>, IContiguousCube<T>
  {
    #if NETSTANDARD2_1_OR_GREATER

    public T[] Data { get; private set; }
    public Layout Layout { get; private set; }
    public ReadOnlySpan<T> Span => Data.AsSpan<T>();

    #else

    public T[] Data { get; private set; }
    public Layout Layout { get; private set; }
    public T[] Span => Data;

    #endif

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
      #if NETSTANDARD2_1_OR_GREATER

      Array.Fill(Data, value);

      #else

      for (var i = 0; i < Data.Length; i++)
      {
        Data[i] = value;
      }

      #endif
    }

    public ArrayCube(T[] data, Shape shape, Layout? layout = null) : this(shape, layout)
    {
      if (data.Length != Shape.Volume)
      {
        throw new InvalidCubeArrayLengthException(nameof(data), data.Length, Shape);
      }

      data.CopyTo(Data, 0);
    }

    #if NETSTANDARD2_1_OR_GREATER

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

    #endif
  }
}
