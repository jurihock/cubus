using System;

namespace Cubus.Exceptions
{
  public class ReadOnlyCubeException : InvalidOperationException
  {
    public ReadOnlyCubeException(Type type)
    {
    }
  }
}

