using System.Numerics;
using System.Runtime.InteropServices;

namespace Box2D.Types.Shapes;

/// <summary>
/// Used to create a chain of line segments. This is designed to eliminate ghost collisions with some limitations.
/// - chains are one-sided
/// - chains have no mass and should be used on static bodies
/// - chains have a counter-clockwise winding order (normal points right of segment direction)
/// - chains are either a loop or open
/// - a chain must have at least 4 points
/// - the distance between any two points must be greater than B2_LINEAR_SLOP
/// - a chain shape should not self intersect (this is not validated)
/// - an open chain shape has NO COLLISION on the first and final edge
/// - you may overlap two open chains on their first three and/or last three points to get smooth collision
/// - a chain shape creates multiple line segment shapes on the body
/// https://en.wikipedia.org/wiki/Polygonal_chain
/// Must be initialized using b2DefaultChainDef().
/// <remarks>
/// Warning: Do not use chain shapes unless you understand the limitations. This is an advanced feature.
/// </remarks>
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct ChainDef
{
    public void* UserData;
    public Vector2* Points;
    public int Count;
    public SurfaceMaterial* Materials;
    public int MaterialsCount;
    public Filter Filter;
    [MarshalAs(UnmanagedType.U1)] 
    public bool IsLoop;
    [MarshalAs(UnmanagedType.U1)] 
    public bool EnableSensorEvents;
    private int _internalValue;
    
    [LibraryImport("box2d", EntryPoint = "b2DefaultChainDef")]
    public static partial ChainDef Default();
}