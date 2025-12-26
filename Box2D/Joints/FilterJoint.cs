using System.Runtime.InteropServices;
using Box2D.Id;
using Box2D.Types.Joints;

namespace Box2D.Joints;

public unsafe partial class FilterJoint : Joint
{
    /// <summary>
    /// Create a filter joint.
    /// </summary>
    /// <seealso cref="FilterJointDef"/>
    public FilterJoint(WorldId worldId, ref FilterJointDef def) : base(CreateFilterJoint(worldId, ref def))
    {
    }

    #region NativeFunctions

    [LibraryImport("box2d", EntryPoint = "b2CreateFilterJoint")]
    private static partial JointId CreateFilterJoint(WorldId worldId, ref FilterJointDef def);

    #endregion
}
