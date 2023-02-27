using System;

namespace Cubus
{
  public class Shape : IEquatable<Shape>
  {
    public int Width { get; private set; }
    public int Height { get; private set; }
    public int Length { get; private set; }
    public int Volume { get; private set; }

    public Shape(int width, int height, int length)
    {
      Width = width;
      Height = height;
      Length = length;
      Volume = width * height * length;
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

    public Shape WithWidth(int width) => new Shape(width, Height, Length);
    public Shape WithHeight(int height) => new Shape(Width, height, Length);
    public Shape WithLength(int length) => new Shape(Width, Height, length);

    public static bool operator ==(Shape left, Shape right) => left.Equals(right);
    public static bool operator !=(Shape left, Shape right) => !left.Equals(right);

    public static implicit operator Shape(ValueTuple ___) => new Shape(0, 0, 0);
    public static implicit operator Shape(ValueTuple<int> w__) => new Shape(w__.Item1, 1, 1);
    public static implicit operator Shape(ValueTuple<int, int> wh_) => new Shape(wh_.Item1, wh_.Item2, 1);
    public static implicit operator Shape(ValueTuple<int, int, int> whl) => new Shape(whl.Item1, whl.Item2, whl.Item3);
  }
}
