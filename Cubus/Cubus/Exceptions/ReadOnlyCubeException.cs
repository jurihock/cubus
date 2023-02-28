using System;

namespace Cubus
{
  public class ReadOnlyCubeException : InvalidOperationException
  {
    public ReadOnlyCubeException(Type type) : base(
      $"The cube of type {type.Name} is a read only cube!")
    {
    }
  }
}

