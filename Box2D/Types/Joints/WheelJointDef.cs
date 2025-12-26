using System.Numerics;
using System.Runtime.InteropServices;
using Box2D.Id;

namespace Box2D.Types.Joints;

/// <summary>
/// Wheel joint definition
///
/// This requires defining a line of motion using an axis and an anchor point.
/// The definition uses local  anchor points and a local axis so that the initial
/// configuration can violate the constraint slightly. The joint translation is zero
/// when the local anchor points coincide in world space.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct WheelJointDef
{
    public BodyId BodyIdA;
    public BodyId BodyIdB;
    public Vector2 LocalAnchorA;
    public Vector2 LocalAnchorB;
    public Vector2 LocalAxisA;
    [MarshalAs(UnmanagedType.U1)]
    public bool EnableSpring;
    public float Hertz;
    public float DampingRatio;
    [MarshalAs(UnmanagedType.U1)]
    public bool EnableLimit;
    public float LowerTranslation;
    public float UpperTranslation;
    [MarshalAs(UnmanagedType.U1)]
    public bool EnableMotor;
    public float MaxMotorTorque;
    public float MotorSpeed;
    [MarshalAs(UnmanagedType.U1)]
    public bool CollideConnected;
    public void* UserData;
    public int InternalValue;

    [DllImport("box2d", EntryPoint = "b2DefaultWheelJointDef")]
    public static extern WheelJointDef Default();
}