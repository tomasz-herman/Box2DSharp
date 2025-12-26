using System.Runtime.InteropServices;
using Box2D.Id;
using Box2D.Types.Joints;

namespace Box2D.Joints;

public unsafe partial class WeldJoint : Joint
{
    public WeldJoint(WorldId worldId, ref WeldJointDef def) : base(CreateWeldJoint(worldId, ref def))
    {
    }

    /// <summary>
    /// Set the weld joint linear stiffness in Hertz. 0 is rigid.
    /// </summary>
    public void SetLinearHertz(float hertz)
    {
        WeldJoint_SetLinearHertz(_id, hertz);
    }

    /// <summary>
    /// Get the weld joint linear stiffness in Hertz
    /// </summary>
    public float GetLinearHertz()
    {
        return WeldJoint_GetLinearHertz(_id);
    }

    /// <summary>
    /// Set the weld joint linear damping ratio (non-dimensional)
    /// </summary>
    public void SetLinearDampingRatio(float dampingRatio)
    {
        WeldJoint_SetLinearDampingRatio(_id, dampingRatio);
    }

    /// <summary>
    /// Get the weld joint linear damping ratio (non-dimensional)
    /// </summary>
    public float GetLinearDampingRatio()
    {
        return WeldJoint_GetLinearDampingRatio(_id);
    }

    /// <summary>
    /// Set the weld joint angular stiffness in Hertz. 0 is rigid.
    /// </summary>
    public void SetAngularHertz(float hertz)
    {
        WeldJoint_SetAngularHertz(_id, hertz);
    }

    /// <summary>
    /// Get the weld joint angular stiffness in Hertz
    /// </summary>
    public float GetAngularHertz()
    {
        return WeldJoint_GetAngularHertz(_id);
    }

    /// <summary>
    /// Set weld joint angular damping ratio, non-dimensional
    /// </summary>
    public void SetAngularDampingRatio(float dampingRatio)
    {
        WeldJoint_SetAngularDampingRatio(_id, dampingRatio);
    }

    /// <summary>
    /// Get the weld joint angular damping ratio, non-dimensional
    /// </summary>
    public float GetAngularDampingRatio()
    {
        return WeldJoint_GetAngularDampingRatio(_id);
    }

    #region NativeFunctions

    [LibraryImport("box2d", EntryPoint = "b2CreateWeldJoint")]
    private static partial JointId CreateWeldJoint(WorldId worldId, ref WeldJointDef def);

    [LibraryImport("box2d", EntryPoint = "b2WeldJoint_SetLinearHertz")]
    private static partial void WeldJoint_SetLinearHertz(JointId jointId, float hertz);

    [LibraryImport("box2d", EntryPoint = "b2WeldJoint_GetLinearHertz")]
    private static partial float WeldJoint_GetLinearHertz(JointId jointId);

    [LibraryImport("box2d", EntryPoint = "b2WeldJoint_SetLinearDampingRatio")]
    private static partial void WeldJoint_SetLinearDampingRatio(JointId jointId, float dampingRatio);

    [LibraryImport("box2d", EntryPoint = "b2WeldJoint_GetLinearDampingRatio")]
    private static partial float WeldJoint_GetLinearDampingRatio(JointId jointId);

    [LibraryImport("box2d", EntryPoint = "b2WeldJoint_SetAngularHertz")]
    private static partial void WeldJoint_SetAngularHertz(JointId jointId, float hertz);

    [LibraryImport("box2d", EntryPoint = "b2WeldJoint_GetAngularHertz")]
    private static partial float WeldJoint_GetAngularHertz(JointId jointId);

    [LibraryImport("box2d", EntryPoint = "b2WeldJoint_SetAngularDampingRatio")]
    private static partial void WeldJoint_SetAngularDampingRatio(JointId jointId, float dampingRatio);

    [LibraryImport("box2d", EntryPoint = "b2WeldJoint_GetAngularDampingRatio")]
    private static partial float WeldJoint_GetAngularDampingRatio(JointId jointId);

    #endregion
}
