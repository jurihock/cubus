using Cubus.Extensions;
using Cubus.Layouts;

namespace Cubus.Tests;

[TestClass]
public class LayoutTest
{
  [TestMethod]
  public void TestLayoutFactory()
  {
    LayoutFactory.ClearLayoutPool();
    Assert.AreEqual(LayoutFactory.GetLayoutPoolSize(), 0);

    Cube<byte>.Empty((0, 0));
    Assert.AreNotEqual(LayoutFactory.GetLayoutPoolSize(), 0);
  }
}
