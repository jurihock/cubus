using Cubus.Filters;

namespace Cubus.Tests;

[TestClass]
public class FilterTest
{
  [TestMethod]
  public void TestCrop()
  {
    var array = new int[,,]
    {
      { { 1 }, { 2 }, { 3 } },
      { { 4 }, { 5 }, { 6 } },
      { { 7 }, { 8 }, { 9 } }
    };

    var x = array.ToCube<int>();
    var y = x.Crop((+1, -1), (+1, -1));

    Assert.AreEqual(y.Shape, (1, 1, 1));
    Assert.AreEqual(y[0, 0, 0], 5);
  }

  [TestMethod]
  public void TestFlip()
  {
    var a = new int[,,]
    {
      { { 1 }, { 2 }, { 3 } },
      { { 4 }, { 5 }, { 6 } },
      { { 7 }, { 8 }, { 9 } }
    };

    var b = new int[,,]
    {
      { { 3 }, { 2 }, { 1 } },
      { { 6 }, { 5 }, { 4 } },
      { { 9 }, { 8 }, { 7 } }
    };

    var c = new int[,,]
    {
      { { 9 }, { 8 }, { 7 } },
      { { 6 }, { 5 }, { 4 } },
      { { 3 }, { 2 }, { 1 } }
    };

    Assert.IsTrue(Enumerable.SequenceEqual(
      a.ToCube<int>().ToArray(),
      a.ToCube<int>().Flip().ToArray()));

    Assert.IsTrue(Enumerable.SequenceEqual(
      b.ToCube<int>().ToArray(),
      a.ToCube<int>().Flip(0).ToArray()));

    Assert.IsFalse(Enumerable.SequenceEqual(
      b.ToCube<int>().ToArray(),
      a.ToCube<int>().Flip(1).ToArray()));

    Assert.IsTrue(Enumerable.SequenceEqual(
      c.ToCube<int>().ToArray(),
      a.ToCube<int>().Flip(0, 1).ToArray()));

    Assert.IsTrue(Enumerable.SequenceEqual(
      a.ToCube<int>().ToArray(),
      a.ToCube<int>().Flip(2).ToArray()));
  }
}
