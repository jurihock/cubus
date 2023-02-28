using System;
using Cubus.Cubes;
using Cubus.Filters;

namespace Cubus
{
  /// <summary>
  /// Describes a 3D data cube.
  /// </summary>
  /// <typeparam name="T">
  /// The data type.
  /// </typeparam>
  public abstract class Cube<T>
  {
    /// <summary>
    /// The width, height and length of this cube.
    /// </summary>
    public Shape Shape { get; private set; }

    /// <summary>
    /// Gets or sets the cube value at coordinate triple x, y and z.
    /// </summary>
    /// <param name="x">The horizontal coordinate.</param>
    /// <param name="y">The vertical coordinate.</param>
    /// <param name="z">The z-axis coordinate.</param>
    public abstract T this[int x, int y, int z] { get; set; }

    /// <summary>
    /// Creates a new cube instance of the specified shape.
    /// </summary>
    protected Cube(Shape shape)
    {
      Shape = shape;
    }

    /// <summary>
    /// Returns a new cube instance filled with zeros.
    /// </summary>
    public static Cube<T> Empty(Shape shape, Layout? layout = null)
    {
      return new ArrayCube<T>(shape, layout);
    }

    /// <summary>
    /// Returns a new cube instance filled with specified value.
    /// </summary>
    public static Cube<T> Full(T value, Shape shape, Layout? layout = null)
    {
      return new ArrayCube<T>(value, shape, layout);
    }

    /// <summary>
    /// Returns a type converted cube.
    /// </summary>
    public Cube<Tnew> Cast<Tnew>()
    {
      return new CastFilter<T, Tnew>(this);
    }
  }
}
