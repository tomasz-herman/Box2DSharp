using System.Numerics;
using System.Runtime.InteropServices;
using Box2D.Id;
using Box2D.Types.Joints;

namespace Box2D.Joints;

public unsafe class MouseJoint : Joint
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

    [DllImport("box2d", EntryPoint = "b2CreateMouseJoint")]
    private static extern JointId CreateMouseJoint(WorldId worldId, ref MouseJointDef def);

    [DllImport("box2d", EntryPoint = "b2MouseJoint_SetTarget")]
    private static extern void MouseJoint_SetTarget(JointId jointId, Vector2 target);

    [DllImport("box2d", EntryPoint = "b2MouseJoint_GetTarget")]
    private static extern Vector2 MouseJoint_GetTarget(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2MouseJoint_SetSpringHertz")]
    private static extern void MouseJoint_SetSpringHertz(JointId jointId, float hertz);

    [DllImport("box2d", EntryPoint = "b2MouseJoint_GetSpringHertz")]
    private static extern float MouseJoint_GetSpringHertz(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2MouseJoint_SetSpringDampingRatio")]
    private static extern void MouseJoint_SetSpringDampingRatio(JointId jointId, float dampingRatio);

    [DllImport("box2d", EntryPoint = "b2MouseJoint_GetSpringDampingRatio")]
    private static extern float MouseJoint_GetSpringDampingRatio(JointId jointId);

    [DllImport("box2d", EntryPoint = "b2MouseJoint_SetMaxForce")]
    private static extern void MouseJoint_SetMaxForce(JointId jointId, float maxForce);

    [DllImport("box2d", EntryPoint = "b2MouseJoint_GetMaxForce")]
    private static extern float MouseJoint_GetMaxForce(JointId jointId);

    #endregion
}
