using System;

namespace Cubus
{
  public class InvalidCubeArrayLengthException : ArgumentException
  {
    public InvalidCubeArrayLengthException(string argument, int length, Shape shape)
    {
    }
  }
}
