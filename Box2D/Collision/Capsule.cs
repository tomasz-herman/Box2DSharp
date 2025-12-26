using System.Numerics;
using System.Runtime.InteropServices;
using Box2D.Math;

namespace Box2D.Collision;

/// <summary>
/// A solid capsule can be viewed as two semicircles connected
/// by a rectangle.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public partial struct Capsule
{
    public Vector2 Center1;
    public Vector2 Center2;
    public float Radius;
    
    public MassData ComputeMass(float density)
    {
        return ComputeCapsuleMass(ref this, density);
    }

    public Aabb ComputeAabb(Transform transform)
    {
        return ComputeCapsuleAABB(ref this, transform);
    }
    
    public bool TestPoint(Vector2 point)
    {
        return PointInCapsule(ref this, point);
    }
    
    public CastOutput CastRay(ref RayCastInput input)
    {
        return RayCastCapsule(ref this, ref input);
    }

    public CastOutput CastShape(ref ShapeCastInput input)
    {
        return ShapeCastCapsule(ref this, ref input);
    }
    
    [LibraryImport("box2d", EntryPoint = "b2ComputeCapsuleMass")]
    public static partial MassData ComputeCapsuleMass(ref Capsule shape, float density);
    
    [LibraryImport("box2d", EntryPoint = "b2ComputeCapsuleAABB")]
    public static partial Aabb ComputeCapsuleAABB(ref Capsule shape, Transform transform);
    
    [LibraryImport("box2d", EntryPoint = "b2PointInCapsule")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static partial bool PointInCapsule(ref Capsule shape, Vector2 point);
    
    [LibraryImport("box2d", EntryPoint = "b2RayCastCapsule")]
    public static partial CastOutput RayCastCapsule(ref Capsule shape, ref RayCastInput input);

    [LibraryImport("box2d", EntryPoint = "b2ShapeCastCapsule")]
    public static partial CastOutput ShapeCastCapsule(ref Capsule shape, ref ShapeCastInput input);
}