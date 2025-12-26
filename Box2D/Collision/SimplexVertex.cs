using System.Numerics;
using System.Runtime.InteropServices;

namespace Box2D.Collision;

/// <summary>
/// Simplex vertex for debugging the GJK algorithm
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct SimplexVertex
{
    public Vector2 WA;
    public Vector2 WB;
    public Vector2 W;
    public float A;
    public int IndexA;
    public int IndexB;
}