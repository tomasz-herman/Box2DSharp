using System.Runtime.InteropServices;

namespace Box2D.Collision;

/// <summary>
/// Simplex from the GJK algorithm
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct Simplex
{
    public SimplexVertex V1, V2, V3;
    public int Count;

    [LibraryImport("box2d", EntryPoint = "b2ShapeDistance")]
    public static partial DistanceOutput ShapeDistance(ref DistanceInput input, ref SimplexCache cache,
        Simplex[]? simplexes = null, int simplexCapacity = 0);
}