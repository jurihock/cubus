using System;
using System.Collections.Generic;
using System.Linq;

namespace Cubus.Layouts
{
  public class LayoutFactory
  {
    private static readonly Dictionary<Type, Dictionary<Shape, Layout>> InstancePool;
    private static readonly object SyncRoot;

    static LayoutFactory()
    {
      InstancePool = new Dictionary<Type, Dictionary<Shape, Layout>>();
      SyncRoot = new object();
    }

    public static void ClearLayoutPool()
    {
      lock (SyncRoot)
      {
        InstancePool.Clear();
      }
    }

    public static int GetLayoutPoolSize()
    {
      lock (SyncRoot)
      {
        return InstancePool.Select(type => type.Value.Count).Sum();
      }
    }

    public static Layout GetLayout(Shape shape) => GetLayout<RowMajorLayout>(shape);

    public static Layout GetLayout<T>(Shape shape) where T : Layout
    {
      lock (SyncRoot)
      {
        var type = typeof(T);

        if (!InstancePool.ContainsKey(type))
        {
          InstancePool.Add(type, new Dictionary<Shape, Layout>());
        }

        if (!InstancePool[type].ContainsKey(shape))
        {
          var instance = Activator.CreateInstance(type, shape) as T;

          if (instance == null)
          {
            throw new Exception(
              $"Unable to create an instance of " +
              $"cube memory layout type {nameof(T)}!");
          }

          InstancePool[type].Add(shape, instance);

          return instance;
        }

        return InstancePool[type][shape];
      }
    }
  }
}
