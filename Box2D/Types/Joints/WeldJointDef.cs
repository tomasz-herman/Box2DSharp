using System.Numerics;
using System.Runtime.InteropServices;
using Box2D.Id;

namespace Box2D.Types.Joints;

/// <summary>
/// A weld joint connects to bodies with fixed relative transform.
/// </summary>
/// <remarks>
/// Note: The approximate solver in Box2D cannot hold many bodies together rigidly
/// </remarks>
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct WeldJointDef
{
    public BodyId BodyIdA;
    public BodyId BodyIdB;
    public Vector2 LocalAnchorA;
    public Vector2 LocalAnchorB;
    public float ReferenceAngle;
    public float LinearHertz;
    public float AngularHertz;
    public float LinearDampingRatio;
    public float AngularDampingRatio;
    [MarshalAs(UnmanagedType.U1)]
    public bool CollideConnected;
    public void* UserData;
    public int InternalValue;

    [LibraryImport("box2d", EntryPoint = "b2DefaultWeldJointDef")]
    public static partial WeldJointDef Default();
}