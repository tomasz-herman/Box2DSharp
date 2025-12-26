using System.Runtime.InteropServices;
using Box2D.Id;
using Box2D.Types.Joints;

namespace Box2D.Joints;

public unsafe class PrismaticJoint : Joint
{
    public PrismaticJoint(WorldId worldId, ref PrismaticJointDef def) : base(CreatePrismaticJoint(worldId, ref def))
    {
    }

    /// <summary>
    /// Enable/disable the joint spring.
    /// </summary>
    public void EnableSpring(bool enableSpring)
    {
        PrismaticJoint_EnableSpring(_id, enableSpring);
    }

    /// <summary>
    /// Is the prismatic joint spring enabled or not?
    /// </summary>
    public bool IsSpringEnabled()
    {
        return PrismaticJoint_IsSpringEnabled(_id);
    }

    /// <summary>
    /// Set the prismatic joint stiffness in Hertz.
    /// This should usually be less than a quarter of the simulation rate. For example, if the simulation
    /// runs at 60Hz then the joint stiffness should be 15Hz or less.
    /// </summary>
    public void SetSpringHertz(float hertz)
    {
        PrismaticJoint_SetSpringHertz(_id, hertz);
    }

    /// <summary>
    /// Get the prismatic joint stiffness in Hertz
    /// </summary>
    public float GetSpringHertz()
    {
        return PrismaticJoint_GetSpringHertz(_id);
    }

    /// <summary>
    /// Set the prismatic joint damping ratio (non-dimensional)
    /// </summary>
    public void SetSpringDampingRatio(float dampingRatio)
    {
        PrismaticJoint_SetSpringDampingRatio(_id, dampingRatio);
    }

    /// <summary>
    /// Get the prismatic spring damping ratio (non-dimensional)
    /// </summary>
    public float GetSpringDampingRatio()
    {
        return PrismaticJoint_GetSpringDampingRatio(_id);
    }

    /// <summary>
    /// Set the prismatic joint spring target angle, usually in meters
    /// </summary>
    public void SetTargetTranslation(float translation)
    {
        PrismaticJoint_SetTargetTranslation(_id, translation);
    }

    /// <summary>
    /// Get the prismatic joint spring target translation, usually in meters
    /// </summary>
    public float GetTargetTranslation()
    {
        return PrismaticJoint_GetTargetTranslation(_id);
    }

    /// <summary>
    /// Enable/disable a prismatic joint limit
    /// </summary>
    public void EnableLimit(bool enableLimit)
    {
        PrismaticJoint_EnableLimit(_id, enableLimit);
    }

    /// <summary>
    /// Is the prismatic joint limit enabled?
    /// </summary>
    public bool IsLimitEnabled()
    {
        return PrismaticJoint_IsLimitEnabled(_id);
    }

    /// <summary>
    /// Get the prismatic joint lower limit
    /// </summary>
    public float GetLowerLimit()
    {
        return PrismaticJoint_GetLowerLimit(_id);
    }

    /// <summary>
    /// Get the prismatic joint upper limit
    /// </summary>
    public float GetUpperLimit()
    {
        return PrismaticJoint_GetUpperLimit(_id);
    }

    /// <summary>
    /// Set the prismatic joint limits
    /// </summary>
    public void SetLimits(float lower, float upper)
    {
        PrismaticJoint_SetLimits(_id, lower, upper);
    }

    /// <summary>
    /// Enable/disable a prismatic joint motor
    /// </summary>
    public void EnableMotor(bool enableMotor)
    {
        PrismaticJoint_EnableMotor(_id, enableMotor);
    }

    /// <summary>
    /// Is the prismatic joint motor enabled?
    /// </summary>
    public bool IsMotorEnabled()
    {
        return PrismaticJoint_IsMotorEnabled(_id);
    }

    /// <summary>
    /// Set the prismatic joint motor speed, usually in meters per second
    /// </summary>
    public void SetMotorSpeed(float motorSpeed)
    {
        PrismaticJoint_SetMotorSpeed(_id, motorSpeed);
    }

    /// <summary>
    /// Get the prismatic joint motor speed, usually in meters per second
    /// </summary>
    public float GetMotorSpeed()
    {
        return PrismaticJoint_GetMotorSpeed(_id);
    }

    /// <summary>
    /// Set the prismatic joint maximum motor force, usually in newtons
    /// </summary>
    public void SetMaxMotorForce(float force)
    {
        PrismaticJoint_SetMaxMotorForce(_id, force);
    }

    /// <summary>
    /// Get the prismatic joint maximum motor force, usually in newtons
    /// </summary>
    public float GetMaxMotorForce()
    {
        return PrismaticJoint_GetMaxMotorForce(_id);
    }

    /// <summary>
    /// Get the prismatic joint current motor force, usually in newtons
    /// </summary>
    public float GetMotorForce()
    {
        return PrismaticJoint_GetMotorForce(_id);
    }

    /// <summary>
    /// Get the current joint translation, usually in meters.
    /// </summary>
    public float GetTranslation()
    {
        return PrismaticJoint_GetTranslation(_id);
    }

    /// <summary>
    /// Get the current joint translation speed, usually in meters per second.
    /// </summary>
    public float GetSpeed()
    {
        return PrismaticJoint_GetSpeed(_id);
    }

    #region NativeFunctions

    [DllImport("box2d", EntryPoint = "b2CreatePrismaticJoint")]
    private static extern JointId CreatePrismaticJoint(WorldId worldId, ref PrismaticJointDef def);

    [DllImport("box2d", EntryPoint = "b2PrismaticJoint_EnableSpring")]
    private static extern void PrismaticJoint_EnableSpring(JointId jointId, [MarshalAs(UnmanagedType.U1)] bool enableSpring);

    [DllImport("box2d", EntryPoint = "b2PrismaticJoint_IsSpringEnabled")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool PrismaticJoint_IsSpringEnabled(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2PrismaticJoint_SetSpringHertz")]
    private static extern void PrismaticJoint_SetSpringHertz(JointId jointId, float hertz);

    [DllImport("box2d", EntryPoint = "b2PrismaticJoint_GetSpringHertz")]
    private static extern float PrismaticJoint_GetSpringHertz(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2PrismaticJoint_SetSpringDampingRatio")]
    private static extern void PrismaticJoint_SetSpringDampingRatio(JointId jointId, float dampingRatio);

    [DllImport("box2d", EntryPoint = "b2PrismaticJoint_GetSpringDampingRatio")]
    private static extern float PrismaticJoint_GetSpringDampingRatio(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2PrismaticJoint_SetTargetTranslation")]
    private static extern void PrismaticJoint_SetTargetTranslation(JointId jointId, float translation);

    [DllImport("box2d", EntryPoint = "b2PrismaticJoint_GetTargetTranslation")]
    private static extern float PrismaticJoint_GetTargetTranslation(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2PrismaticJoint_EnableLimit")]
    private static extern void PrismaticJoint_EnableLimit(JointId jointId, [MarshalAs(UnmanagedType.U1)] bool enableLimit);

    [DllImport("box2d", EntryPoint = "b2PrismaticJoint_IsLimitEnabled")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool PrismaticJoint_IsLimitEnabled(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2PrismaticJoint_GetLowerLimit")]
    private static extern float PrismaticJoint_GetLowerLimit(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2PrismaticJoint_GetUpperLimit")]
    private static extern float PrismaticJoint_GetUpperLimit(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2PrismaticJoint_SetLimits")]
    private static extern void PrismaticJoint_SetLimits(JointId jointId, float lower, float upper);

    [DllImport("box2d", EntryPoint = "b2PrismaticJoint_EnableMotor")]
    private static extern void PrismaticJoint_EnableMotor(JointId jointId, [MarshalAs(UnmanagedType.U1)] bool enableMotor);

    [DllImport("box2d", EntryPoint = "b2PrismaticJoint_IsMotorEnabled")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool PrismaticJoint_IsMotorEnabled(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2PrismaticJoint_SetMotorSpeed")]
    private static extern void PrismaticJoint_SetMotorSpeed(JointId jointId, float motorSpeed);

    [DllImport("box2d", EntryPoint = "b2PrismaticJoint_GetMotorSpeed")]
    private static extern float PrismaticJoint_GetMotorSpeed(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2PrismaticJoint_SetMaxMotorForce")]
    private static extern void PrismaticJoint_SetMaxMotorForce(JointId jointId, float force);

    [DllImport("box2d", EntryPoint = "b2PrismaticJoint_GetMaxMotorForce")]
    private static extern float PrismaticJoint_GetMaxMotorForce(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2PrismaticJoint_GetMotorForce")]
    private static extern float PrismaticJoint_GetMotorForce(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2PrismaticJoint_GetTranslation")]
    private static extern float PrismaticJoint_GetTranslation(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2PrismaticJoint_GetSpeed")]
    private static extern float PrismaticJoint_GetSpeed(JointId jointId);

    #endregion
}
