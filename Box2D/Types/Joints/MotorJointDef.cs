using System.Numerics;
using System.Runtime.InteropServices;
using Box2D.Id;

namespace Box2D.Types.Joints;

/// <summary>
/// A motor joint is used to control the relative motion between two bodies
///
/// A typical usage is to control the movement of a dynamic body with respect to the ground.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct MotorJointDef
{
    public BodyId BodyIdA;
    public BodyId BodyIdB;
    public Vector2 LinearOffset;
    public float AngularOffset;
    public float MaxForce;
    public float MaxTorque;
    public float CorrectionFactor;
    [MarshalAs(UnmanagedType.U1)]
    public bool CollideConnected;
    public void* UserData;
    public int InternalValue;

    [LibraryImport("box2d", EntryPoint = "b2DefaultMotorJointDef")]
    public static partial MotorJointDef Default();
}