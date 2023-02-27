using System;

namespace Cubus
{
  public class Shape : IComparable<Shape>, IEquatable<Shape>
  {
    public int Width { get; private set; }
    public int Height { get; private set; }
    public int Length { get; private set; }
    public int Volume { get; private set; }

    public Shape(int width, int height, int length = 1)
    {
      Width = width;
      Height = height;
      Length = length;
      Volume = width * height * length;
    }

    public int CompareTo(Shape other)
    {
      return this.Volume - other.Volume;
    }

    public bool Equals(Shape other)
    {
      if (this.Width != other.Width)
      {
        return false;
      }

      if (this.Height != other.Height)
      {
        return false;
      }

      if (this.Length != other.Length)
      {
        return false;
      }

      return true;
    }

    public override bool Equals(object shape)
    {
      if (shape is Shape other)
      {
        return other.Equals(this);
      }

      return false;
    }

    public override int GetHashCode()
    {
      return ToString().GetHashCode();
    }

    public override string ToString()
    {
      return $"({Width}, ${Height}, ${Length})";
    }

    public static bool operator ==(Shape left, Shape right) => left.Equals(right);
    public static bool operator !=(Shape left, Shape right) => !left.Equals(right);

    public static implicit operator Shape(ValueTuple<int, int> wh_) => new Shape(wh_.Item1, wh_.Item2);
    public static implicit operator Shape(ValueTuple<int, int, int> whl) => new Shape(whl.Item1, whl.Item2, whl.Item3);
  }
}
