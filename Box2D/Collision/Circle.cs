using System.Numerics;
using System.Runtime.InteropServices;
using Box2D.Math;

namespace Box2D.Collision;

/// <summary>
/// A solid circle
/// </summary>
public struct Circle
{
    public Vector2 Center;
    public float Radius;

    public MassData ComputeMass(float density)
    {
        return ComputeCircleMass(ref this, density);
    }

    public Aabb ComputeAabb(Transform transform)
    {
        return ComputeCircleAABB(ref this, transform);
    }
    
    public bool TestPoint(Vector2 point)
    {
        return PointInCircle(ref this, point);
    }
    
    public CastOutput CastRay(ref RayCastInput input)
    {
        return RayCastCircle(ref this, ref input);
    }
    
    public CastOutput CastShape(ref ShapeCastInput input)
    {
        return ShapeCastCircle(ref this, ref input);
    }
    
    [DllImport("box2d", EntryPoint = "b2ComputeCircleMass")]
    public static extern MassData ComputeCircleMass(ref Circle shape, float density);
    
    [DllImport("box2d", EntryPoint = "b2ComputeCircleAABB")]
    public static extern Aabb ComputeCircleAABB(ref Circle shape, Transform transform);
    
    [DllImport("box2d", EntryPoint = "b2PointInCircle")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool PointInCircle(ref Circle shape, Vector2 point);
    
    [DllImport("box2d", EntryPoint = "b2RayCastCircle")]
    public static extern CastOutput RayCastCircle(ref Circle shape, ref RayCastInput input);
    
    [DllImport("box2d", EntryPoint = "b2ShapeCastCircle")]
    public static extern CastOutput ShapeCastCircle(ref Circle shape, ref ShapeCastInput input);
}