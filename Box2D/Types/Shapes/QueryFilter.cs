using System.Runtime.InteropServices;

namespace Box2D.Types.Shapes;

/// <summary>
/// The query filter is used to filter collisions between queries and shapes. For example,
/// you may want a ray-cast representing a projectile to hit players and the static environment
/// but not debris.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public partial struct QueryFilter
{
    public ulong CategoryBits;
    public ulong MaskBits;
    
    [LibraryImport("box2d", EntryPoint = "b2DefaultQueryFilter")]
    public static partial QueryFilter Default();
}