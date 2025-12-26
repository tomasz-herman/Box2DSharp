namespace Box2D.Types.Joints;

/// <summary>
/// Joint type enumeration
///
/// This is useful because all joint types use b2JointId and sometimes you
/// want to get the type of a joint.
/// </summary>
public enum JointType
{
    DistanceJoint,
    FilterJoint,
    MotorJoint,
    PrismaticJoint,
    RevoluteJoint,
    WeldJoint,
    WheelJoint,
    JointTypeCount
}