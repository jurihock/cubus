using System;

namespace Cubus
{
  /// <summary>
  /// Describes the shape of a cube.
  /// </summary>
  public class Shape : IComparable<Shape>, IEquatable<Shape>
  {
    /// <summary>
    /// The length of the x-axis.
    /// </summary>
    public int Width { get; private set; }

    /// <summary>
    /// The length of the y-axis.
    /// </summary>
    public int Height { get; private set; }

    /// <summary>
    /// The length of the z-axis.
    /// </summary>
    public int Length { get; private set; }

    /// <summary>
    /// The product of width, height and length.
    /// </summary>
    public int Volume { get; private set; }

    /// <summary>
    /// Creates a new shape instance.
    /// </summary>
    /// <param name="width">
    /// The length of the x-axis.
    /// </param>
    /// <param name="height">
    /// The length of the y-axis.
    /// </param>
    /// <param name="length">
    /// The length of the z-axis.
    /// </param>
    public Shape(int width, int height, int length = 1)
    {
      Width = width;
      Height = height;
      Length = length;
      Volume = width * height * length;
    }

    public override int GetHashCode() => ToString().GetHashCode();
    public override string ToString() => $"({Width}, ${Height}, ${Length})";

    /// <summary>
    /// Returns the volume difference between two shapes.
    /// </summary>
    /// <returns>
    /// Negative difference if this shape is smaller than the other.
    /// Positive difference if this shape is larger than the other.
    /// Zero difference if both shapes have the same volume,
    /// as the product of width, height and length respectively.
    /// </returns>
    public int CompareTo(Shape other) => this.Volume - other.Volume;

    /// <summary>
    /// Indicates whether both shapes are absolutely identical.
    /// </summary>
    public bool Equals(Shape other) => (this.Width == other.Width) &&
                                       (this.Height == other.Height) &&
                                       (this.Length == other.Length);

    /// <inheritdoc cref="Shape.Equals(Shape)"/>
    public override bool Equals(object shape) => (shape as Shape)?.Equals(this) ?? false;

    /// <inheritdoc cref="Shape.Equals(Shape)"/>
    public static bool operator ==(Shape left, Shape right) => left.Equals(right);

    /// <inheritdoc cref="Shape.Equals(Shape)"/>
    public static bool operator !=(Shape left, Shape right) => !left.Equals(right);

    /// <summary>
    /// Creates a new shape instance by width and height.
    /// </summary>
    public static implicit operator Shape(ValueTuple<int, int> wh) => new Shape(wh.Item1, wh.Item2);

    /// <summary>
    /// Creates a new shape instance by width, height and length.
    /// </summary>
    public static implicit operator Shape(ValueTuple<int, int, int> whl) => new Shape(whl.Item1, whl.Item2, whl.Item3);
  }
}
