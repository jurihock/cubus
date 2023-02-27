using System;

namespace Cubus.Exceptions
{
  public class InvalidCubeArrayLengthException : ArgumentException
  {
    public InvalidCubeArrayLengthException(string argument, int length, Shape shape)
    {
    }
  }
}
