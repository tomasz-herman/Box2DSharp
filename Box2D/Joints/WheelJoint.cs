using System.Runtime.InteropServices;
using Box2D.Id;
using Box2D.Types.Joints;

namespace Box2D.Joints;

public unsafe class WheelJoint : Joint
{
    public WheelJoint(WorldId worldId, ref WheelJointDef def) : base(CreateWheelJoint(worldId, ref def))
    {
    }

    /// <summary>
    /// Enable/disable the wheel joint spring
    /// </summary>
    public void EnableSpring(bool enableSpring)
    {
        WheelJoint_EnableSpring(_id, enableSpring);
    }

    /// <summary>
    /// Is the wheel joint spring enabled?
    /// </summary>
    public bool IsSpringEnabled()
    {
        return WheelJoint_IsSpringEnabled(_id);
    }

    /// <summary>
    /// Set the wheel joint stiffness in Hertz
    /// </summary>
    public void SetSpringHertz(float hertz)
    {
        WheelJoint_SetSpringHertz(_id, hertz);
    }

    /// <summary>
    /// Get the wheel joint stiffness in Hertz
    /// </summary>
    public float GetSpringHertz()
    {
        return WheelJoint_GetSpringHertz(_id);
    }

    /// <summary>
    /// Set the wheel joint damping ratio, non-dimensional
    /// </summary>
    public void SetSpringDampingRatio(float dampingRatio)
    {
        WheelJoint_SetSpringDampingRatio(_id, dampingRatio);
    }

    /// <summary>
    /// Get the wheel joint damping ratio, non-dimensional
    /// </summary>
    public float GetSpringDampingRatio()
    {
        return WheelJoint_GetSpringDampingRatio(_id);
    }

    /// <summary>
    /// Enable/disable the wheel joint limit
    /// </summary>
    public void EnableLimit(bool enableLimit)
    {
        WheelJoint_EnableLimit(_id, enableLimit);
    }

    /// <summary>
    /// Is the wheel joint limit enabled?
    /// </summary>
    public bool IsLimitEnabled()
    {
        return WheelJoint_IsLimitEnabled(_id);
    }

    /// <summary>
    /// Get the wheel joint lower limit
    /// </summary>
    public float GetLowerLimit()
    {
        return WheelJoint_GetLowerLimit(_id);
    }

    /// <summary>
    /// Get the wheel joint upper limit
    /// </summary>
    public float GetUpperLimit()
    {
        return WheelJoint_GetUpperLimit(_id);
    }

    /// <summary>
    /// Set the wheel joint limits
    /// </summary>
    public void SetLimits(float lower, float upper)
    {
        WheelJoint_SetLimits(_id, lower, upper);
    }

    /// <summary>
    /// Enable/disable the wheel joint motor
    /// </summary>
    public void EnableMotor(bool enableMotor)
    {
        WheelJoint_EnableMotor(_id, enableMotor);
    }

    /// <summary>
    /// Is the wheel joint motor enabled?
    /// </summary>
    public bool IsMotorEnabled()
    {
        return WheelJoint_IsMotorEnabled(_id);
    }

    /// <summary>
    /// Set the wheel joint motor speed in radians per second
    /// </summary>
    public void SetMotorSpeed(float motorSpeed)
    {
        WheelJoint_SetMotorSpeed(_id, motorSpeed);
    }

    /// <summary>
    /// Get the wheel joint motor speed in radians per second
    /// </summary>
    public float GetMotorSpeed()
    {
        return WheelJoint_GetMotorSpeed(_id);
    }

    /// <summary>
    /// Set the wheel joint maximum motor torque, usually in newton-meters
    /// </summary>
    public void SetMaxMotorTorque(float torque)
    {
        WheelJoint_SetMaxMotorTorque(_id, torque);
    }

    /// <summary>
    /// Get the wheel joint maximum motor torque, usually in newton-meters
    /// </summary>
    public float GetMaxMotorTorque()
    {
        return WheelJoint_GetMaxMotorTorque(_id);
    }

    /// <summary>
    /// Get the wheel joint current motor torque, usually in newton-meters
    /// </summary>
    public float GetMotorTorque()
    {
        return WheelJoint_GetMotorTorque(_id);
    }

    #region NativeFunctions

    [DllImport("box2d", EntryPoint = "b2CreateWheelJoint")]
    private static extern JointId CreateWheelJoint(WorldId worldId, ref WheelJointDef def);

    [DllImport("box2d", EntryPoint = "b2WheelJoint_EnableSpring")]
    private static extern void WheelJoint_EnableSpring(JointId jointId, [MarshalAs(UnmanagedType.U1)] bool enableSpring);

    [DllImport("box2d", EntryPoint = "b2WheelJoint_IsSpringEnabled")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool WheelJoint_IsSpringEnabled(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2WheelJoint_SetSpringHertz")]
    private static extern void WheelJoint_SetSpringHertz(JointId jointId, float hertz);

    [DllImport("box2d", EntryPoint = "b2WheelJoint_GetSpringHertz")]
    private static extern float WheelJoint_GetSpringHertz(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2WheelJoint_SetSpringDampingRatio")]
    private static extern void WheelJoint_SetSpringDampingRatio(JointId jointId, float dampingRatio);

    [DllImport("box2d", EntryPoint = "b2WheelJoint_GetSpringDampingRatio")]
    private static extern float WheelJoint_GetSpringDampingRatio(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2WheelJoint_EnableLimit")]
    private static extern void WheelJoint_EnableLimit(JointId jointId, [MarshalAs(UnmanagedType.U1)] bool enableLimit);

    [DllImport("box2d", EntryPoint = "b2WheelJoint_IsLimitEnabled")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool WheelJoint_IsLimitEnabled(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2WheelJoint_GetLowerLimit")]
    private static extern float WheelJoint_GetLowerLimit(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2WheelJoint_GetUpperLimit")]
    private static extern float WheelJoint_GetUpperLimit(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2WheelJoint_SetLimits")]
    private static extern void WheelJoint_SetLimits(JointId jointId, float lower, float upper);

    [DllImport("box2d", EntryPoint = "b2WheelJoint_EnableMotor")]
    private static extern void WheelJoint_EnableMotor(JointId jointId, [MarshalAs(UnmanagedType.U1)] bool enableMotor);

    [DllImport("box2d", EntryPoint = "b2WheelJoint_IsMotorEnabled")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool WheelJoint_IsMotorEnabled(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2WheelJoint_SetMotorSpeed")]
    private static extern void WheelJoint_SetMotorSpeed(JointId jointId, float motorSpeed);

    [DllImport("box2d", EntryPoint = "b2WheelJoint_GetMotorSpeed")]
    private static extern float WheelJoint_GetMotorSpeed(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2WheelJoint_SetMaxMotorTorque")]
    private static extern void WheelJoint_SetMaxMotorTorque(JointId jointId, float torque);

    [DllImport("box2d", EntryPoint = "b2WheelJoint_GetMaxMotorTorque")]
    private static extern float WheelJoint_GetMaxMotorTorque(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2WheelJoint_GetMotorTorque")]
    private static extern float WheelJoint_GetMotorTorque(JointId jointId);

    #endregion
}
