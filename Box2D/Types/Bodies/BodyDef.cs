using System.Numerics;
using System.Runtime.InteropServices;
using Box2D.Math;

namespace Box2D.Types.Bodies;

/// <summary>
/// A body definition holds all the data needed to construct a rigid body.
/// You can safely re-use body definitions. Shapes are added to a body after construction.
/// Body definitions are temporary objects used to bundle creation parameters.
/// Must be initialized using b2DefaultBodyDef().
/// </summary>
public unsafe struct BodyDef
{
    public BodyType Type;
    public Vector2 Position;
    public Rotation Rotation;
    public Vector2 LinearVelocity;
    public float AngularVelocity;
    public float LinearDamping;
    public float AngularDamping;
    public float GravityScale;
    public float SleepThreshold;
    public byte* Name;
    public void* UserData;
    [MarshalAs(UnmanagedType.U1)] 
    public bool EnableSleep;
    [MarshalAs(UnmanagedType.U1)] 
    public bool IsAwake;
    [MarshalAs(UnmanagedType.U1)] 
    public bool FixedRotation;
    [MarshalAs(UnmanagedType.U1)] 
    public bool IsBullet;
    [MarshalAs(UnmanagedType.U1)] 
    public bool IsEnabled;
    [MarshalAs(UnmanagedType.U1)] 
    public bool AllowFastRotation;
    private int _internalValue;
    
    [DllImport("box2d", EntryPoint = "b2DefaultBodyDef")]
    public static extern BodyDef Default();
}