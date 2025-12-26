using System.Runtime.InteropServices;

namespace Box2D.Types.Shapes;

/// <summary>
/// This is used to filter collision on shapes. It affects shape-vs-shape collision
/// and shape-versus-query collision (such as b2World_CastRay).
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public partial struct Filter
{
    public ulong CategoryBits;
    public ulong MaskBits;
    public int GroupIndex;
    
    [LibraryImport("box2d", EntryPoint = "b2DefaultFilter")]
    public static partial Filter Default();
}