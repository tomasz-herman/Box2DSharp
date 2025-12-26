using System.Numerics;
using System.Runtime.InteropServices;
using Box2D.Id;
using Box2D.Types.Joints;

namespace Box2D.Joints;

public unsafe partial class MotorJoint : Joint
{
    public MotorJoint(WorldId worldId, ref MotorJointDef def) : base(CreateMotorJoint(worldId, ref def))
    {
    }

    /// <summary>
    /// Set the motor joint linear offset target
    /// </summary>
    public void SetLinearOffset(Vector2 linearOffset)
    {
        MotorJoint_SetLinearOffset(_id, linearOffset);
    }

    /// <summary>
    /// Get the motor joint linear offset target
    /// </summary>
    public Vector2 GetLinearOffset()
    {
        return MotorJoint_GetLinearOffset(_id);
    }

    /// <summary>
    /// Set the motor joint angular offset target in radians. This angle will be unwound
    /// so the motor will drive along the shortest arc.
    /// </summary>
    public void SetAngularOffset(float angularOffset)
    {
        MotorJoint_SetAngularOffset(_id, angularOffset);
    }

    /// <summary>
    /// Get the motor joint angular offset target in radians
    /// </summary>
    public float GetAngularOffset()
    {
        return MotorJoint_GetAngularOffset(_id);
    }

    /// <summary>
    /// Set the motor joint correction factor, usually in [0, 1]
    /// </summary>
    public void SetCorrectionFactor(float correctionFactor)
    {
        MotorJoint_SetCorrectionFactor(_id, correctionFactor);
    }

    /// <summary>
    /// Get the motor joint correction factor, usually in [0, 1]
    /// </summary>
    public float GetCorrectionFactor()
    {
        return MotorJoint_GetCorrectionFactor(_id);
    }

    /// <summary>
    /// Set the motor joint maximum force, usually in newtons
    /// </summary>
    public void SetMaxForce(float maxForce)
    {
        MotorJoint_SetMaxForce(_id, maxForce);
    }

    /// <summary>
    /// Get the motor joint maximum force, usually in newtons
    /// </summary>
    public float GetMaxForce()
    {
        return MotorJoint_GetMaxForce(_id);
    }

    /// <summary>
    /// Set the motor joint maximum torque, usually in newton-meters
    /// </summary>
    public void SetMaxTorque(float maxTorque)
    {
        MotorJoint_SetMaxTorque(_id, maxTorque);
    }

    /// <summary>
    /// Get the motor joint maximum torque, usually in newton-meters
    /// </summary>
    public float GetMaxTorque()
    {
        return MotorJoint_GetMaxTorque(_id);
    }

    #region NativeFunctions

    [LibraryImport("box2d", EntryPoint = "b2CreateMotorJoint")]
    private static partial JointId CreateMotorJoint(WorldId worldId, ref MotorJointDef def);

    [LibraryImport("box2d", EntryPoint = "b2MotorJoint_SetLinearOffset")]
    private static partial void MotorJoint_SetLinearOffset(JointId jointId, Vector2 linearOffset);

    [LibraryImport("box2d", EntryPoint = "b2MotorJoint_GetLinearOffset")]
    private static partial Vector2 MotorJoint_GetLinearOffset(JointId jointId);

    [LibraryImport("box2d", EntryPoint = "b2MotorJoint_SetAngularOffset")]
    private static partial void MotorJoint_SetAngularOffset(JointId jointId, float angularOffset);

    [LibraryImport("box2d", EntryPoint = "b2MotorJoint_GetAngularOffset")]
    private static partial float MotorJoint_GetAngularOffset(JointId jointId);

    [LibraryImport("box2d", EntryPoint = "b2MotorJoint_SetMaxForce")]
    private static partial void MotorJoint_SetMaxForce(JointId jointId, float maxForce);

    [LibraryImport("box2d", EntryPoint = "b2MotorJoint_GetMaxForce")]
    private static partial float MotorJoint_GetMaxForce(JointId jointId);

    [LibraryImport("box2d", EntryPoint = "b2MotorJoint_SetMaxTorque")]
    private static partial void MotorJoint_SetMaxTorque(JointId jointId, float maxTorque);

    [LibraryImport("box2d", EntryPoint = "b2MotorJoint_GetMaxTorque")]
    private static partial float MotorJoint_GetMaxTorque(JointId jointId);

    [LibraryImport("box2d", EntryPoint = "b2MotorJoint_SetCorrectionFactor")]
    private static partial void MotorJoint_SetCorrectionFactor(JointId jointId, float correctionFactor);

    [LibraryImport("box2d", EntryPoint = "b2MotorJoint_GetCorrectionFactor")]
    private static partial float MotorJoint_GetCorrectionFactor(JointId jointId);

    #endregion
}
