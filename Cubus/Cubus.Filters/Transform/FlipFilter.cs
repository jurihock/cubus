using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Cubus.Filters
{
  public class FlipFilter<T> : Filter<T>
  {
    public readonly int[] IndexX, IndexY, IndexZ;

    public override T this[int x, int y, int z]
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      get => Cube[IndexX[x], IndexY[y], IndexZ[z]];

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      set => Cube[IndexX[x], IndexY[y], IndexZ[z]] = value;
    }

    public FlipFilter(Cube<T> cube, params int[] axes) : base(cube)
    {
      IndexX = Enumerable.Range(0, Shape.Width).ToArray();
      IndexY = Enumerable.Range(0, Shape.Height).ToArray();
      IndexZ = Enumerable.Range(0, Shape.Length).ToArray();

      foreach (var axis in axes.Distinct())
      {
        if (axis == 0)
        {
          IndexX = IndexX.Reverse().ToArray();
        }
        else if (axis == 1)
        {
          IndexY = IndexY.Reverse().ToArray();
        }
        else if (axis == 2)
        {
          IndexZ = IndexZ.Reverse().ToArray();
        }
        else
        {
          throw new ArgumentOutOfRangeException(nameof(axes),
            $"Invalid axis index: 0, 1 or 2 expected, got {axis}!");
        }
      }
    }
  }
}
