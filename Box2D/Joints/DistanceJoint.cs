using System.Runtime.InteropServices;
using Box2D.Id;
using Box2D.Types.Joints;

namespace Box2D.Joints;

public unsafe partial class DistanceJoint : Joint
{
    public DistanceJoint(WorldId worldId, ref DistanceJointDef def) : base(CreateDistanceJoint(worldId, ref def))
    {
    }

    /// <summary>
    /// Set the rest length of a distance joint
    /// </summary>
    /// <param name="length">The new distance joint length</param>
    public void SetLength(float length)
    {
        DistanceJoint_SetLength(_id, length);
    }

    /// <summary>
    /// Get the rest length of a distance joint
    /// </summary>
    public float GetLength()
    {
        return DistanceJoint_GetLength(_id);
    }

    /// <summary>
    /// Enable/disable the distance joint spring. When disabled the distance joint is rigid.
    /// </summary>
    public void EnableSpring(bool enableSpring)
    {
        DistanceJoint_EnableSpring(_id, enableSpring);
    }

    /// <summary>
    /// Is the distance joint spring enabled?
    /// </summary>
    public bool IsSpringEnabled()
    {
        return DistanceJoint_IsSpringEnabled(_id);
    }

    /// <summary>
    /// Set the spring stiffness in Hertz
    /// </summary>
    public void SetSpringHertz(float hertz)
    {
        DistanceJoint_SetSpringHertz(_id, hertz);
    }

    /// <summary>
    /// Set the spring damping ratio, non-dimensional
    /// </summary>
    public void SetSpringDampingRatio(float dampingRatio)
    {
        DistanceJoint_SetSpringDampingRatio(_id, dampingRatio);
    }

    /// <summary>
    /// Get the spring Hertz
    /// </summary>
    public float GetSpringHertz()
    {
        return DistanceJoint_GetSpringHertz(_id);
    }

    /// <summary>
    /// Get the spring damping ratio
    /// </summary>
    public float GetSpringDampingRatio()
    {
        return DistanceJoint_GetSpringDampingRatio(_id);
    }

    /// <summary>
    /// Enable joint limit. The limit only works if the joint spring is enabled. Otherwise the joint is rigid
    /// and the limit has no effect.
    /// </summary>
    public void EnableLimit(bool enableLimit)
    {
        DistanceJoint_EnableLimit(_id, enableLimit);
    }

    /// <summary>
    /// Is the distance joint limit enabled?
    /// </summary>
    public bool IsLimitEnabled()
    {
        return DistanceJoint_IsLimitEnabled(_id);
    }

    /// <summary>
    /// Set the minimum and maximum length parameters of a distance joint
    /// </summary>
    public void SetLengthRange(float minLength, float maxLength)
    {
        DistanceJoint_SetLengthRange(_id, minLength, maxLength);
    }

    /// <summary>
    /// Get the distance joint minimum length
    /// </summary>
    public float GetMinLength()
    {
        return DistanceJoint_GetMinLength(_id);
    }

    /// <summary>
    /// Get the distance joint maximum length
    /// </summary>
    public float GetMaxLength()
    {
        return DistanceJoint_GetMaxLength(_id);
    }

    /// <summary>
    /// Get the current length of a distance joint
    /// </summary>
    public float GetCurrentLength()
    {
        return DistanceJoint_GetCurrentLength(_id);
    }

    /// <summary>
    /// Enable/disable the distance joint motor
    /// </summary>
    public void EnableMotor(bool enableMotor)
    {
        DistanceJoint_EnableMotor(_id, enableMotor);
    }

    /// <summary>
    /// Is the distance joint motor enabled?
    /// </summary>
    public bool IsMotorEnabled()
    {
        return DistanceJoint_IsMotorEnabled(_id);
    }

    /// <summary>
    /// Set the distance joint motor speed, usually in meters per second
    /// </summary>
    public void SetMotorSpeed(float motorSpeed)
    {
        DistanceJoint_SetMotorSpeed(_id, motorSpeed);
    }

    /// <summary>
    /// Get the distance joint motor speed, usually in meters per second
    /// </summary>
    public float GetMotorSpeed()
    {
        return DistanceJoint_GetMotorSpeed(_id);
    }

    /// <summary>
    /// Set the distance joint maximum motor force, usually in newtons
    /// </summary>
    public void SetMaxMotorForce(float force)
    {
        DistanceJoint_SetMaxMotorForce(_id, force);
    }

    /// <summary>
    /// Get the distance joint maximum motor force, usually in newtons
    /// </summary>
    public float GetMaxMotorForce()
    {
        return DistanceJoint_GetMaxMotorForce(_id);
    }

    /// <summary>
    /// Get the distance joint current motor force, usually in newtons
    /// </summary>
    public float GetMotorForce()
    {
        return DistanceJoint_GetMotorForce(_id);
    }

    #region NativeFunctions

    [LibraryImport("box2d", EntryPoint = "b2CreateDistanceJoint")]
    private static partial JointId CreateDistanceJoint(WorldId worldId, ref DistanceJointDef def);

    [LibraryImport("box2d", EntryPoint = "b2DistanceJoint_SetLength")]
    private static partial void DistanceJoint_SetLength(JointId jointId, float length);

    [LibraryImport("box2d", EntryPoint = "b2DistanceJoint_GetLength")]
    private static partial float DistanceJoint_GetLength(JointId jointId);

    [LibraryImport("box2d", EntryPoint = "b2DistanceJoint_EnableSpring")]
    private static partial void DistanceJoint_EnableSpring(JointId jointId, [MarshalAs(UnmanagedType.U1)] bool enableSpring);

    [LibraryImport("box2d", EntryPoint = "b2DistanceJoint_IsSpringEnabled")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static partial bool DistanceJoint_IsSpringEnabled(JointId jointId);

    [LibraryImport("box2d", EntryPoint = "b2DistanceJoint_SetSpringHertz")]
    private static partial void DistanceJoint_SetSpringHertz(JointId jointId, float hertz);

    [LibraryImport("box2d", EntryPoint = "b2DistanceJoint_SetSpringDampingRatio")]
    private static partial void DistanceJoint_SetSpringDampingRatio(JointId jointId, float dampingRatio);

    [LibraryImport("box2d", EntryPoint = "b2DistanceJoint_GetSpringHertz")]
    private static partial float DistanceJoint_GetSpringHertz(JointId jointId);

    [LibraryImport("box2d", EntryPoint = "b2DistanceJoint_GetSpringDampingRatio")]
    private static partial float DistanceJoint_GetSpringDampingRatio(JointId jointId);

    [LibraryImport("box2d", EntryPoint = "b2DistanceJoint_EnableLimit")]
    private static partial void DistanceJoint_EnableLimit(JointId jointId, [MarshalAs(UnmanagedType.U1)] bool enableLimit);

    [LibraryImport("box2d", EntryPoint = "b2DistanceJoint_IsLimitEnabled")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static partial bool DistanceJoint_IsLimitEnabled(JointId jointId);

    [LibraryImport("box2d", EntryPoint = "b2DistanceJoint_SetLengthRange")]
    private static partial void DistanceJoint_SetLengthRange(JointId jointId, float minLength, float maxLength);

    [LibraryImport("box2d", EntryPoint = "b2DistanceJoint_GetMinLength")]
    private static partial float DistanceJoint_GetMinLength(JointId jointId);

    [LibraryImport("box2d", EntryPoint = "b2DistanceJoint_GetMaxLength")]
    private static partial float DistanceJoint_GetMaxLength(JointId jointId);

    [LibraryImport("box2d", EntryPoint = "b2DistanceJoint_GetCurrentLength")]
    private static partial float DistanceJoint_GetCurrentLength(JointId jointId);

    [LibraryImport("box2d", EntryPoint = "b2DistanceJoint_EnableMotor")]
    private static partial void DistanceJoint_EnableMotor(JointId jointId, [MarshalAs(UnmanagedType.U1)] bool enableMotor);

    [LibraryImport("box2d", EntryPoint = "b2DistanceJoint_IsMotorEnabled")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static partial bool DistanceJoint_IsMotorEnabled(JointId jointId);

    [LibraryImport("box2d", EntryPoint = "b2DistanceJoint_SetMotorSpeed")]
    private static partial void DistanceJoint_SetMotorSpeed(JointId jointId, float motorSpeed);

    [LibraryImport("box2d", EntryPoint = "b2DistanceJoint_GetMotorSpeed")]
    private static partial float DistanceJoint_GetMotorSpeed(JointId jointId);

    [LibraryImport("box2d", EntryPoint = "b2DistanceJoint_SetMaxMotorForce")]
    private static partial void DistanceJoint_SetMaxMotorForce(JointId jointId, float force);

    [LibraryImport("box2d", EntryPoint = "b2DistanceJoint_GetMaxMotorForce")]
    private static partial float DistanceJoint_GetMaxMotorForce(JointId jointId);

    [LibraryImport("box2d", EntryPoint = "b2DistanceJoint_GetMotorForce")]
    private static partial float DistanceJoint_GetMotorForce(JointId jointId);

    #endregion
}
