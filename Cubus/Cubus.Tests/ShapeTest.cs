using Cubus.Extensions;

namespace Cubus.Tests
{
  [TestClass]
  public class ShapeTest
  {
    [TestMethod]
    public void TestShape()
    {
      Shape shape;

      shape = (0, 1);
      Assert.AreEqual(shape.Width, 0);
      Assert.AreEqual(shape.Height, 1);
      Assert.AreEqual(shape.Length, 1);
      Assert.AreEqual(shape.Volume, 0);

      shape = (1, 0);
      Assert.AreEqual(shape.Width, 1);
      Assert.AreEqual(shape.Height, 0);
      Assert.AreEqual(shape.Length, 1);
      Assert.AreEqual(shape.Volume, 0);

      shape = (1, 1, 0);
      Assert.AreEqual(shape.Width, 1);
      Assert.AreEqual(shape.Height, 1);
      Assert.AreEqual(shape.Length, 0);
      Assert.AreEqual(shape.Volume, 0);

      shape = shape.Width(0).Height(0).Length(0);
      Assert.AreEqual(shape.Width, 0);
      Assert.AreEqual(shape.Height, 0);
      Assert.AreEqual(shape.Length, 0);
      Assert.AreEqual(shape.Volume, 0);

      var x = new Shape(1, 1);
      var y = new Shape(1, 1, 1);
      var z = new Shape(1, 2, 3);
      Assert.AreEqual(x, y);
      Assert.AreNotEqual(y, z);

      var a = new Shape(10, 1, 1);
      var b = new Shape(1, 1, 10);
      Assert.AreEqual(a.Equals(b), false);
      Assert.AreEqual(a.CompareTo(b), 0);
      Assert.AreEqual(a.Volume.CompareTo(b.Volume), 0);

      var c = new Shape(1, 1);
      var d = c.Length(100);
      Assert.AreEqual(c.Volume, 1);
      Assert.AreEqual(d.Volume, 100);
      Assert.AreEqual(c.Equals(d), false);
      Assert.AreEqual(c.CompareTo(d), -99);
      Assert.AreEqual(d.CompareTo(c), +99);
      Assert.AreEqual(c.Volume.CompareTo(d.Volume), -1);
      Assert.AreEqual(d.Volume.CompareTo(c.Volume), +1);
    }
  }
}
