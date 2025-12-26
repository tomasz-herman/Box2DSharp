using System.Runtime.InteropServices;

namespace Box2D.Types.Shapes;

/// <summary>
/// Surface materials allow chain shapes to have per segment surface properties.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public partial struct SurfaceMaterial
{
    public float Friction;
    public float Restitution;
    public float RollingResistance;
    public float TangentSpeed;
    public int UserMaterialId;
    public uint CustomColor;
    
    [LibraryImport("box2d", EntryPoint = "b2DefaultSurfaceMaterial")]
    public static partial SurfaceMaterial Default();
}