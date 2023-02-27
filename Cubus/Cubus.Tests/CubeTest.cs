using Cubus.Cubes;
using Cubus.Extensions;

namespace Cubus.Tests
{
  [TestClass]
  public class CubeTest
  {
    [TestMethod]
    public void TestCube()
    {
      var a = Cube<int>.Empty((1, 1));
      Assert.AreEqual(a[0, 0, 0], 0);

      var b = Cube<float>.Full(+42, (1, 2));
      Assert.AreEqual(b[0, 1, 0], +42);

      var c = Cube<double>.Full(-42, (1, 3));
      Assert.AreEqual(c[0, 0, 2], -42);
    }

    [TestMethod]
    public void TestContiguous()
    {
      var a = new ArrayCube<int>((1, 2, 3));
      var b = new MemoryCube<int>(a.Data, a.Shape);
      var c = new ReadOnlyMemoryCube<int>(b.Data, b.Shape);
      var d = new ArrayCube<int>(c.Data, c.Shape);

      b[0, 1, 2] = 42;

      Assert.AreEqual(a[0, 1, 2], b[0, 1, 2]);
      Assert.AreEqual(a[0, 1, 2], b[0, 1, 2]);
      Assert.AreNotEqual(c[0, 1, 2], d[0, 1, 2]);
    }
  }
}

