using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Box2D.Math;

namespace Box2D.Collision;

/// <summary>
/// A solid convex polygon. It is assumed that the interior of the polygon is to
/// the left of each edge.
/// Polygons have a maximum number of vertices equal to B2_MAX_POLYGON_VERTICES.
/// In most cases you should not need many vertices for a convex polygon.
/// </summary>
/// <remarks>
/// Warning: DO NOT fill this out manually, instead use a helper function like
/// b2MakePolygon or b2MakeBox.
/// </remarks>
[StructLayout(LayoutKind.Sequential)]
public partial struct Polygon
{
    [InlineArray(8)]
    [StructLayout(LayoutKind.Sequential)]
    public partial struct VerticesBuffer
    {
        private Vector2 _vertex;
    }

    public VerticesBuffer Vertices;
    public VerticesBuffer Normals;
    public Vector2 Centroid;
    public float Radius;
    public int Count;
    
    public MassData ComputeMass(float density)
    {
        return ComputePolygonMass(ref this, density);
    }

    public Aabb ComputeAabb(Transform transform)
    {
        return ComputePolygonAABB(ref this, transform);
    }
    
    public bool TestPoint(Vector2 point)
    {
        return PointInPolygon(ref this, point);
    }
    
    public CastOutput CastRay(ref RayCastInput input)
    {
        return RayCastPolygon(ref this, ref input);
    }

    public CastOutput CastShape(ref ShapeCastInput input)
    {
        return ShapeCastPolygon(ref this, ref input);
    }
    
    [LibraryImport("box2d", EntryPoint = "b2ComputePolygonMass")]
    public static partial MassData ComputePolygonMass(ref Polygon shape, float density);
    
    [LibraryImport("box2d", EntryPoint = "b2ComputePolygonAABB")]
    public static partial Aabb ComputePolygonAABB(ref Polygon shape, Transform transform);
    
    [LibraryImport("box2d", EntryPoint = "b2PointInPolygon")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static partial bool PointInPolygon(ref Polygon shape, Vector2 point);
    
    [LibraryImport("box2d", EntryPoint = "b2RayCastPolygon")]
    public static partial CastOutput RayCastPolygon(ref Polygon shape, ref RayCastInput input);

    [LibraryImport("box2d", EntryPoint = "b2ShapeCastPolygon")]
    public static partial CastOutput ShapeCastPolygon(ref Polygon shape, ref ShapeCastInput input);

    [LibraryImport("box2d", EntryPoint = "b2MakePolygon")]
    public static partial Polygon MakePolygon(ref Hull hull, float radius);

    [LibraryImport("box2d", EntryPoint = "b2MakeOffsetPolygon")]
    public static partial Polygon MakeOffsetPolygon(ref Hull hull, Vector2 position, Rotation rotation);

    [LibraryImport("box2d", EntryPoint = "b2MakeOffsetRoundedPolygon")]
    public static partial Polygon MakeOffsetRoundedPolygon(ref Hull hull, Vector2 position, Rotation rotation,
        float radius);

    [LibraryImport("box2d", EntryPoint = "b2MakeSquare")]
    public static partial Polygon MakeSquare(float halfWidth);

    [LibraryImport("box2d", EntryPoint = "b2MakeBox")]
    public static partial Polygon MakeBox(float halfWidth, float halfHeight);

    [LibraryImport("box2d", EntryPoint = "b2MakeRoundedBox")]
    public static partial Polygon MakeRoundedBox(float halfWidth, float halfHeight, float radius);

    [LibraryImport("box2d", EntryPoint = "b2MakeOffsetBox")]
    public static partial Polygon MakeOffsetBox(float halfWidth, float halfHeight, Vector2 center, Rotation rotation);

    [LibraryImport("box2d", EntryPoint = "b2MakeOffsetRoundedBox")]
    public static partial Polygon MakeOffsetRoundedBox(float halfWidth, float halfHeight, Vector2 center,
        Rotation rotation, float radius);

    [LibraryImport("box2d", EntryPoint = "b2TransformPolygon")]
    public static partial Polygon TransformPolygon(Transform transform, ref Polygon polygon);
}