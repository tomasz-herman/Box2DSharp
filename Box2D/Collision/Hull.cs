using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Box2D.Collision;

/// <summary>
/// A convex hull. Used to create convex polygons.
/// </summary>
/// <remarks>
/// Warning: Do not modify these values directly, instead use b2ComputeHull()
/// </remarks>
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct Hull
{
    [InlineArray(8)]
    [StructLayout(LayoutKind.Sequential)]
    public partial struct VerticesBuffer
    {
        private Vector2 _vertex;
    }
    
    public VerticesBuffer Points;

    public int Count;

    public static Hull Compute(Vector2[] points)
    {
        fixed (Vector2* p = points)
        {
            return ComputeHull(p, points.Length);
        }
    }

    public bool Validate()
    {
        return ValidateHull(ref this);
    }

    [LibraryImport("box2d", EntryPoint = "b2ComputeHull")]
    public static partial Hull ComputeHull(Vector2* points, int count);

    [LibraryImport("box2d", EntryPoint = "b2ValidateHull")]
    [return: MarshalAs(UnmanagedType.U1)]
    public static partial bool ValidateHull(ref Hull hull);
}