using Cubus.Filters;

namespace Cubus.Tests;

[TestClass]
public class FilterTest
{
  [TestMethod]
  public void TestCrop()
  {
    var data = new int[,,]
    {
      { { 1 }, { 2 }, { 3 } },
      { { 4 }, { 5 }, { 6 } },
      { { 7 }, { 8 }, { 9 } }
    };

    var x = data.ToCube<int>();
    var y = x.Crop((+1, -1), (+1, -1));

    Assert.AreEqual(y.Shape, (1, 1, 1));
    Assert.AreEqual(y[0, 0, 0], 5);
  }
}
