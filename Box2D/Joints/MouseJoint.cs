using System.Numerics;
using System.Runtime.InteropServices;
using Box2D.Id;
using Box2D.Types.Joints;

namespace Box2D.Joints;

public unsafe partial class MouseJoint : Joint
{
    public MouseJoint(WorldId worldId, ref MouseJointDef def) : base(CreateMouseJoint(worldId, ref def))
    {
    }

    /// <summary>
    /// Set the mouse joint target
    /// </summary>
    public void SetTarget(Vector2 target)
    {
        MouseJoint_SetTarget(_id, target);
    }

    /// <summary>
    /// Get the mouse joint target
    /// </summary>
    public Vector2 GetTarget()
    {
        return MouseJoint_GetTarget(_id);
    }

    /// <summary>
    /// Set the mouse joint spring stiffness in Hertz
    /// </summary>
    public void SetSpringHertz(float hertz)
    {
        MouseJoint_SetSpringHertz(_id, hertz);
    }

    /// <summary>
    /// Get the mouse joint spring stiffness in Hertz
    /// </summary>
    public float GetSpringHertz()
    {
        return MouseJoint_GetSpringHertz(_id);
    }

    /// <summary>
    /// Set the mouse joint spring damping ratio, non-dimensional
    /// </summary>
    public void SetSpringDampingRatio(float dampingRatio)
    {
        MouseJoint_SetSpringDampingRatio(_id, dampingRatio);
    }

    /// <summary>
    /// Get the mouse joint damping ratio, non-dimensional
    /// </summary>
    public float GetSpringDampingRatio()
    {
        return MouseJoint_GetSpringDampingRatio(_id);
    }

    /// <summary>
    /// Set the mouse joint maximum force, usually in newtons
    /// </summary>
    public void SetMaxForce(float maxForce)
    {
        MouseJoint_SetMaxForce(_id, maxForce);
    }

    /// <summary>
    /// Get the mouse joint maximum force, usually in newtons
    /// </summary>
    public float GetMaxForce()
    {
        return MouseJoint_GetMaxForce(_id);
    }

    #region NativeFunctions

    [LibraryImport("box2d", EntryPoint = "b2CreateMouseJoint")]
    private static partial JointId CreateMouseJoint(WorldId worldId, ref MouseJointDef def);

    [LibraryImport("box2d", EntryPoint = "b2MouseJoint_SetTarget")]
    private static partial void MouseJoint_SetTarget(JointId jointId, Vector2 target);

    [LibraryImport("box2d", EntryPoint = "b2MouseJoint_GetTarget")]
    private static partial Vector2 MouseJoint_GetTarget(JointId jointId);

    [LibraryImport("box2d", EntryPoint = "b2MouseJoint_SetSpringHertz")]
    private static partial void MouseJoint_SetSpringHertz(JointId jointId, float hertz);

    [LibraryImport("box2d", EntryPoint = "b2MouseJoint_GetSpringHertz")]
    private static partial float MouseJoint_GetSpringHertz(JointId jointId);

    [LibraryImport("box2d", EntryPoint = "b2MouseJoint_SetSpringDampingRatio")]
    private static partial void MouseJoint_SetSpringDampingRatio(JointId jointId, float dampingRatio);

    [LibraryImport("box2d", EntryPoint = "b2MouseJoint_GetSpringDampingRatio")]
    private static partial float MouseJoint_GetSpringDampingRatio(JointId jointId);

    [LibraryImport("box2d", EntryPoint = "b2MouseJoint_SetMaxForce")]
    private static partial void MouseJoint_SetMaxForce(JointId jointId, float maxForce);

    [LibraryImport("box2d", EntryPoint = "b2MouseJoint_GetMaxForce")]
    private static partial float MouseJoint_GetMaxForce(JointId jointId);

    #endregion
}
