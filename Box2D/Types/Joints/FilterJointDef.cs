using System.Runtime.InteropServices;
using Box2D.Id;

namespace Box2D.Types.Joints;

/// <summary>
/// A filter joint is used to disable collision between two specific bodies.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct FilterJointDef
{
    public BodyId BodyIdA;
    public BodyId BodyIdB;
    public void* UserData;
    public int InternalValue;

    [DllImport("box2d", EntryPoint = "b2DefaultFilterJointDef")]
    public static extern FilterJointDef Default();
}