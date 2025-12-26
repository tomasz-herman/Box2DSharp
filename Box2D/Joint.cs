using System.Numerics;
using System.Runtime.InteropServices;
using Box2D.Id;
using Box2D.Math;
using Box2D.Types.Joints;

namespace Box2D;

public unsafe class Joint : IDisposable
{
    protected readonly JointId _id;
    private bool _disposed;

    protected Joint(JointId id)
    {
        _id = id;
    }

    /// <summary>
    /// Joint identifier validation. Provides validation for up to 64K allocations.
    /// </summary>
    public bool IsValid()
    {
        return Joint_IsValid(_id);
    }

    /// <summary>
    /// Get the joint type
    /// </summary>
    public new JointType GetType()
    {
        return Joint_GetType(_id);
    }

    /// <summary>
    /// Get body A id on a joint
    /// </summary>
    public BodyId GetBodyA()
    {
        return Joint_GetBodyA(_id);
    }

    /// <summary>
    /// Get body B id on a joint
    /// </summary>
    public BodyId GetBodyB()
    {
        return Joint_GetBodyB(_id);
    }

    /// <summary>
    /// Get the world that owns this joint
    /// </summary>
    public WorldId GetWorld()
    {
        return Joint_GetWorld(_id);
    }

    /// <summary>
    /// Set the local anchor on bodyA
    /// </summary>
    public void SetLocalAnchorA(Vector2 localAnchor)
    {
        Joint_SetLocalAnchorA(_id, localAnchor);
    }

    /// <summary>
    /// Get the local anchor on bodyA
    /// </summary>
    public Vector2 GetLocalAnchorA()
    {
        return Joint_GetLocalAnchorA(_id);
    }

    /// <summary>
    /// Set the local anchor on bodyB
    /// </summary>
    public void SetLocalAnchorB(Vector2 localAnchor)
    {
        Joint_SetLocalAnchorB(_id, localAnchor);
    }

    /// <summary>
    /// Get the local anchor on bodyB
    /// </summary>
    public Vector2 GetLocalAnchorB()
    {
        return Joint_GetLocalAnchorB(_id);
    }

    /// <summary>
    /// Get the joint reference angle in radians (revolute, prismatic, and weld)
    /// </summary>
    public float GetReferenceAngle()
    {
        return Joint_GetReferenceAngle(_id);
    }

    /// <summary>
    /// Set the joint reference angle in radians, must be in [-pi,pi]. (revolute, prismatic, and weld)
    /// </summary>
    public void SetReferenceAngle(float angleInRadians)
    {
        Joint_SetReferenceAngle(_id, angleInRadians);
    }

    /// <summary>
    /// Set the local axis on bodyA (prismatic and wheel)
    /// </summary>
    public void SetLocalAxisA(Vector2 localAxis)
    {
        Joint_SetLocalAxisA(_id, localAxis);
    }

    /// <summary>
    /// Get the local axis on bodyA (prismatic and wheel)
    /// </summary>
    public Vector2 GetLocalAxisA()
    {
        return Joint_GetLocalAxisA(_id);
    }

    /// <summary>
    /// Toggle collision between connected bodies
    /// </summary>
    public void SetCollideConnected(bool shouldCollide)
    {
        Joint_SetCollideConnected(_id, shouldCollide);
    }

    /// <summary>
    /// Is collision allowed between connected bodies?
    /// </summary>
    public bool GetCollideConnected()
    {
        return Joint_GetCollideConnected(_id);
    }

    /// <summary>
    /// Set the user data on a joint
    /// </summary>
    public void SetUserData(void* userData)
    {
        Joint_SetUserData(_id, userData);
    }

    /// <summary>
    /// Get the user data on a joint
    /// </summary>
    public void* GetUserData()
    {
        return Joint_GetUserData(_id);
    }

    /// <summary>
    /// Wake the bodies connect to this joint
    /// </summary>
    public void WakeBodies()
    {
        Joint_WakeBodies(_id);
    }

    /// <summary>
    /// Get the current constraint force for this joint. Usually in Newtons.
    /// </summary>
    public Vector2 GetConstraintForce()
    {
        return Joint_GetConstraintForce(_id);
    }

    /// <summary>
    /// Get the current constraint torque for this joint. Usually in Newton * meters.
    /// </summary>
    public float GetConstraintTorque()
    {
        return Joint_GetConstraintTorque(_id);
    }

    /// <summary>
    /// Get the current linear separation error for this joint. Does not consider admissible movement. Usually in meters.
    /// </summary>
    public float GetLinearSeparation()
    {
        return Joint_GetLinearSeparation(_id);
    }

    /// <summary>
    /// Get the current angular separation error for this joint. Does not consider admissible movement. Usually in meters.
    /// </summary>
    public float GetAngularSeparation()
    {
        return Joint_GetAngularSeparation(_id);
    }

    /// <summary>
    /// Set the joint constraint tuning. Advanced feature.
    /// </summary>
    /// <param name="hertz">the stiffness in Hertz (cycles per second)</param>
    /// <param name="dampingRatio">the non-dimensional damping ratio (one for critical damping)</param>
    public void SetConstraintTuning(float hertz, float dampingRatio)
    {
        Joint_SetConstraintTuning(_id, hertz, dampingRatio);
    }

    /// <summary>
    /// Get the joint constraint tuning. Advanced feature.
    /// </summary>
    public void GetConstraintTuning(out float hertz, out float dampingRatio)
    {
        fixed (float* h = &hertz)
        fixed (float* d = &dampingRatio)
        {
            Joint_GetConstraintTuning(_id, h, d);
        }
    }

    #region NativeFunctions

    [DllImport("box2d", EntryPoint = "b2DestroyJoint")]
    private static extern void DestroyJoint(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2Joint_IsValid")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool Joint_IsValid(JointId id);

    [DllImport("box2d", EntryPoint = "b2Joint_GetType")]
    private static extern JointType Joint_GetType(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2Joint_GetBodyA")]
    private static extern BodyId Joint_GetBodyA(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2Joint_GetBodyB")]
    private static extern BodyId Joint_GetBodyB(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2Joint_GetWorld")]
    private static extern WorldId Joint_GetWorld(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2Joint_SetLocalAnchorA")]
    private static extern void Joint_SetLocalAnchorA(JointId jointId, Vector2 localAnchor);

    [DllImport("box2d", EntryPoint = "b2Joint_GetLocalAnchorA")]
    private static extern Vector2 Joint_GetLocalAnchorA(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2Joint_SetLocalAnchorB")]
    private static extern void Joint_SetLocalAnchorB(JointId jointId, Vector2 localAnchor);

    [DllImport("box2d", EntryPoint = "b2Joint_GetLocalAnchorB")]
    private static extern Vector2 Joint_GetLocalAnchorB(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2Joint_GetReferenceAngle")]
    private static extern float Joint_GetReferenceAngle(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2Joint_SetReferenceAngle")]
    private static extern void Joint_SetReferenceAngle(JointId jointId, float angleInRadians);

    [DllImport("box2d", EntryPoint = "b2Joint_SetLocalAxisA")]
    private static extern void Joint_SetLocalAxisA(JointId jointId, Vector2 localAxis);

    [DllImport("box2d", EntryPoint = "b2Joint_GetLocalAxisA")]
    private static extern Vector2 Joint_GetLocalAxisA(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2Joint_SetCollideConnected")]
    private static extern void Joint_SetCollideConnected(JointId jointId, [MarshalAs(UnmanagedType.U1)] bool shouldCollide);

    [DllImport("box2d", EntryPoint = "b2Joint_GetCollideConnected")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool Joint_GetCollideConnected(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2Joint_SetUserData")]
    private static extern void Joint_SetUserData(JointId jointId, void* userData);

    [DllImport("box2d", EntryPoint = "b2Joint_GetUserData")]
    private static extern void* Joint_GetUserData(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2Joint_WakeBodies")]
    private static extern void Joint_WakeBodies(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2Joint_GetConstraintForce")]
    private static extern Vector2 Joint_GetConstraintForce(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2Joint_GetConstraintTorque")]
    private static extern float Joint_GetConstraintTorque(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2Joint_GetLinearSeparation")]
    private static extern float Joint_GetLinearSeparation(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2Joint_GetAngularSeparation")]
    private static extern float Joint_GetAngularSeparation(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2Joint_SetConstraintTuning")]
    private static extern void Joint_SetConstraintTuning(JointId jointId, float hertz, float dampingRatio);

    [DllImport("box2d", EntryPoint = "b2Joint_GetConstraintTuning")]
    private static extern void Joint_GetConstraintTuning(JointId jointId, float* hertz, float* dampingRatio);

    #endregion

    #region DisposePattern

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool _)
    {
        if (_disposed)
        {
            return;
        }

        if (IsValid())
        {
            DestroyJoint(_id);
        }

        _disposed = true;
    }

    ~Joint() => Dispose(false);

    public void Destroy()
    {
        if (_disposed) return;
        if (IsValid())
        {
            DestroyJoint(_id);
        }
        _disposed = true;
        GC.SuppressFinalize(this);
    }

    #endregion
}
