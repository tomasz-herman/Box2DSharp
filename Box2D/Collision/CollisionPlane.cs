using System.Numerics;
using System.Runtime.InteropServices;
using Plane = Box2D.Math.Plane;

namespace Box2D.Collision;

/// <summary>
/// These are collision planes that can be fed to b2SolvePlanes. Normally
/// this is assembled by the user from plane results in b2PlaneResult
/// </summary>
public unsafe struct CollisionPlane
{
    public Plane Plane;
    public float PushLimit;
    public float Push;
    [MarshalAs(UnmanagedType.U1)] public bool ClipVelocity;

    public static PlaneSolverResult SolvePlanes(Vector2 targetDelta, params CollisionPlane[] planes)
    {
        fixed (CollisionPlane* planesPtr = planes)
        {
            return SolvePlanes(targetDelta, planesPtr, planes.Length);
        }
    }

    public static Vector2 ClipVector(Vector2 vector, params CollisionPlane[] planes)
    {
        fixed (CollisionPlane* planesPtr = planes)
        {
            return ClipVector(vector, planesPtr, planes.Length);
        }
    }

    [DllImport("box2d", EntryPoint = "b2SolvePlanes")]
    public static extern PlaneSolverResult SolvePlanes(Vector2 targetDelta, CollisionPlane* planes, int count);

    [DllImport("box2d", EntryPoint = "b2ClipVector")]
    public static extern Vector2 ClipVector(Vector2 vector, CollisionPlane* planes, int count);
}