using System;

namespace Cubus
{
  public class ReadOnlyCubeException : InvalidOperationException
  {
    public ReadOnlyCubeException(Type type)
    {
    }
  }
}

