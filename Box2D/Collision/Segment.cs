using System.Numerics;
using System.Runtime.InteropServices;
using Box2D.Math;

namespace Box2D.Collision;

/// <summary>
/// A line segment with two-sided collision.
/// </summary>
public struct Segment
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
    
    [DllImport("box2d", EntryPoint = "b2ComputeSegmentAABB")]
    public static extern Aabb ComputeSegmentAABB(ref Segment shape, Transform transform);
    
    [DllImport("box2d", EntryPoint = "b2RayCastSegment")]
    public static extern CastOutput RayCastSegment(ref Segment shape, ref RayCastInput input);

    [DllImport("box2d", EntryPoint = "b2ShapeCastSegment")]
    public static extern CastOutput ShapeCastSegment(ref Segment shape, ref ShapeCastInput input);
}