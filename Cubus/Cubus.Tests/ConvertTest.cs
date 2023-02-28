using System.Diagnostics;

namespace Cubus.Tests;

[TestClass]
public class ConvertTest
{
  [TestMethod]
  public void TestTypeConverter()
  {
    var a = Convert<byte>.To<double>()(42);
    var b = Convert<byte>.To<double>(42);
    Assert.AreEqual(a, b);
  }

  [TestMethod]
  public void TestTypeConverterSpeed()
  {
    var n = 1000;
    var foo = new byte[n];
    var bar = new double[n];

    var stopwatch = new Stopwatch();
    var convert = Convert<byte>.To<double>();

    var dofast = () =>
    {
      stopwatch.Restart();
      for (var i = 0; i < n; i++)
      {
        bar[i] = convert(foo[i]);
      }
      stopwatch.Stop();

      return stopwatch.ElapsedTicks;
    };

    var doslow = () =>
    {
      stopwatch.Restart();
      for (var i = 0; i < n; i++)
      {
        bar[i] = Convert<byte>.To<double>(foo[i]);
      }
      stopwatch.Stop();

      return stopwatch.ElapsedTicks;
    };

    dofast();

    var fast = dofast();

    doslow();

    var slow = doslow();

    Trace.WriteLine($"fast {fast} vs. slow {slow}");

    Assert.IsTrue(fast < slow);
  }
}
