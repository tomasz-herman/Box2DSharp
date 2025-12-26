using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Box2D.Math;

namespace Box2D.Collision;

/// <summary>
/// A distance proxy is used by the GJK algorithm. It encapsulates any shape.
/// You can provide between 1 and B2_MAX_POLYGON_VERTICES and a radius.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public partial struct ShapeProxy
{
    [InlineArray(8)]
    [StructLayout(LayoutKind.Sequential)]
    public partial struct VerticesBuffer
    {
        private Vector2 _vertex;
    }

    public VerticesBuffer Points;
    public int Count;
    public float Radius;

    [LibraryImport("box2d", EntryPoint = "b2MakeProxy")]
    public static partial ShapeProxy MakeProxy(Vector2[] points, int count, float radius);

    [LibraryImport("box2d", EntryPoint = "b2MakeOffsetProxy")]
    public static partial ShapeProxy MakeOffsetProxy(Vector2[] points, int count, float radius, Vector2 position,
        Rotation rotation);
}