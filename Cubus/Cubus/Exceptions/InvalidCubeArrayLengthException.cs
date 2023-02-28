using System;

namespace Cubus
{
  public class InvalidCubeArrayLengthException : ArgumentException
  {
    public InvalidCubeArrayLengthException(string name, int length, Shape shape) : base(
      $"Invalid {name} array length: {shape.Volume} expected, got {length}!", name)
    {
    }
  }
}
