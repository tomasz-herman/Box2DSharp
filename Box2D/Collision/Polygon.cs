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
public struct Polygon
{
    [InlineArray(8)]
    public struct VerticesBuffer
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
    
    [DllImport("box2d", EntryPoint = "b2ComputePolygonMass")]
    public static extern MassData ComputePolygonMass(ref Polygon shape, float density);
    
    [DllImport("box2d", EntryPoint = "b2ComputePolygonAABB")]
    public static extern Aabb ComputePolygonAABB(ref Polygon shape, Transform transform);
    
    [DllImport("box2d", EntryPoint = "b2PointInPolygon")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool PointInPolygon(ref Polygon shape, Vector2 point);
    
    [DllImport("box2d", EntryPoint = "b2RayCastPolygon")]
    public static extern CastOutput RayCastPolygon(ref Polygon shape, ref RayCastInput input);

    [DllImport("box2d", EntryPoint = "b2ShapeCastPolygon")]
    public static extern CastOutput ShapeCastPolygon(ref Polygon shape, ref ShapeCastInput input);

    [DllImport("box2d", EntryPoint = "b2MakePolygon")]
    public static extern Polygon MakePolygon(ref Hull hull, float radius);

    [DllImport("box2d", EntryPoint = "b2MakeOffsetPolygon")]
    public static extern Polygon MakeOffsetPolygon(ref Hull hull, Vector2 position, Rotation rotation);

    [DllImport("box2d", EntryPoint = "b2MakeOffsetRoundedPolygon")]
    public static extern Polygon MakeOffsetRoundedPolygon(ref Hull hull, Vector2 position, Rotation rotation,
        float radius);

    [DllImport("box2d", EntryPoint = "b2MakeSquare")]
    public static extern Polygon MakeSquare(float halfWidth);

    [DllImport("box2d", EntryPoint = "b2MakeBox")]
    public static extern Polygon MakeBox(float halfWidth, float halfHeight);

    [DllImport("box2d", EntryPoint = "b2MakeRoundedBox")]
    public static extern Polygon MakeRoundedBox(float halfWidth, float halfHeight, float radius);

    [DllImport("box2d", EntryPoint = "b2MakeOffsetBox")]
    public static extern Polygon MakeOffsetBox(float halfWidth, float halfHeight, Vector2 center, Rotation rotation);

    [DllImport("box2d", EntryPoint = "b2MakeOffsetRoundedBox")]
    public static extern Polygon MakeOffsetRoundedBox(float halfWidth, float halfHeight, Vector2 center,
        Rotation rotation, float radius);

    [DllImport("box2d", EntryPoint = "b2TransformPolygon")]
    public static extern Polygon TransformPolygon(Transform transform, ref Polygon polygon);
}