using System;

namespace Cubus.Filters
{
  public static class CubeExtensions
  {
    #region [ A ]

    public static Cube<T> Average<T>(this Cube<T> cube)
    {
      return new AverageFilter<T>(cube);
    }

    #endregion

    #region [ B ]
    #endregion

    #region [ C ]

    /// <summary>
    /// Returns a type converted cube.
    /// </summary>
    public static Cube<Tnew> Cast<Told, Tnew>(this Cube<Told> cube)
    {
      return new CastFilter<Told, Tnew>(cube);
    }

    public static Cube<T> Clamp<T>(this Cube<T> cube, T lo, T hi)
      where T : IComparable
    {
      return new ClampFilter<T>(cube, lo, hi);
    }

    public static Cube<T> Crop<T>(this Cube<T> cube, (int? start, int? stop)? x, (int? start, int? stop)? y, (int? start, int? stop)? z = null)
    {
      return new CropFilter<T>(cube, x, y, z);
    }

    #endregion

    #region [ D ]
    #endregion

    #region [ E ]
    #endregion

    #region [ F ]

    public static Cube<T> Flip<T>(this Cube<T> cube, params int[] axes)
    {
      return new FlipFilter<T>(cube, axes);
    }

    #endregion

    #region [ G ]
    #endregion

    #region [ H ]

    public static Cube<T> Hue<T>(this Cube<T> cube, (int r, int g, int b) rgb)
    {
      return new HueFilter<T>(cube, rgb);
    }

    #endregion

    #region [ I ]
    #endregion

    #region [ J ]
    #endregion

    #region [ K ]
    #endregion

    #region [ L ]

    public static Cube<T> Lightness<T>(this Cube<T> cube, (int r, int g, int b) rgb)
    {
      return new LightnessFilter<T>(cube, rgb);
    }

    #endregion

    #region [ M ]

    public static Cube<T> Max<T>(this Cube<T> cube)
    {
      return new MaxFilter<T>(cube);
    }

    public static Cube<T> Min<T>(this Cube<T> cube)
    {
      return new MinFilter<T>(cube);
    }

    #endregion

    #region [ N ]
    #endregion

    #region [ O ]
    #endregion

    #region [ P ]
    #endregion

    #region [ Q ]
    #endregion

    #region [ R ]
    #endregion

    #region [ S ]

    public static Cube<T> Saturation<T>(this Cube<T> cube, (int r, int g, int b) rgb)
    {
      return new SaturationFilter<T>(cube, rgb);
    }

    public static Cube<T> Scale<T>(this Cube<T> cube, double slope)
    {
      return new ScaleFilter<T>(cube, slope);
    }

    #endregion

    #region [ T ]
    #endregion

    #region [ U ]
    #endregion

    #region [ V ]
    #endregion

    #region [ W ]
    #endregion

    #region [ X ]
    #endregion

    #region [ Y ]
    #endregion

    #region [ Z ]
    #endregion
  }
}
