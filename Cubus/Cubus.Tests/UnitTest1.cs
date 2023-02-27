using Cubus.Extensions;
using Cubus.Layouts;

namespace Cubus.Tests;

[TestClass]
public class UnitTest1
{
  [TestMethod]
  public void TestMethod1()
  {
    Assert.AreEqual(LayoutFactory.GetLayoutPoolSize(), 0);

    var a = Cube<byte>.Empty((1000, 1000, 3));
    var b = a.Cast<double>().Clamp(0, 0xFF).Freeze();

    foreach (var (x, y, z) in a.XYZ())
    {
      Assert.AreEqual(a[x, y, z], b[x, y, z]);
    }

    var c = b.ToArray();
    Assert.AreEqual(a.Shape.Volume, c.Length);

    Assert.AreNotEqual(LayoutFactory.GetLayoutPoolSize(), 0);
  }
}
