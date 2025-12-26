using System.Numerics;
using System.Runtime.InteropServices;
using Box2D.Math;

namespace Box2D.Collision;

/// <summary>
/// A line segment with two-sided collision.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public partial struct Segment
{
    public Vector2 Point1;
    public Vector2 Point2;
    
    public Aabb ComputeAabb(Transform transform)
    {
        return ComputeSegmentAABB(ref this, transform);
    }
    
    public CastOutput CastRay(ref RayCastInput input)
    {
        return RayCastSegment(ref this, ref input);
    }

    public CastOutput CastShape(ref ShapeCastInput input)
    {
        return ShapeCastSegment(ref this, ref input);
    }
    
    [LibraryImport("box2d", EntryPoint = "b2ComputeSegmentAABB")]
    public static partial Aabb ComputeSegmentAABB(ref Segment shape, Transform transform);
    
    [LibraryImport("box2d", EntryPoint = "b2RayCastSegment")]
    public static partial CastOutput RayCastSegment(ref Segment shape, ref RayCastInput input);

    [LibraryImport("box2d", EntryPoint = "b2ShapeCastSegment")]
    public static partial CastOutput ShapeCastSegment(ref Segment shape, ref ShapeCastInput input);
}