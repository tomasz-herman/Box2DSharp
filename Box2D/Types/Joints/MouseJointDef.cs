using System.Numerics;
using System.Runtime.InteropServices;
using Box2D.Id;

namespace Box2D.Types.Joints;

/// <summary>
/// A mouse joint is used to make a point on a body track a specified world point.
///
/// This a soft constraint and allows the constraint to stretch without
/// applying huge forces. This also applies rotation constraint heuristic to improve control.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct MouseJointDef
{
    public BodyId BodyIdA;
    public BodyId BodyIdB;
    public Vector2 Target;
    public float Hertz;
    public float DampingRatio;
    public float MaxForce;
    [MarshalAs(UnmanagedType.U1)]
    public bool CollideConnected;
    public void* UserData;
    public int InternalValue;

    [LibraryImport("box2d", EntryPoint = "b2DefaultMouseJointDef")]
    public static partial MouseJointDef Default();
}