using System.Numerics;
using System.Runtime.InteropServices;

namespace Box2D.Collision;

/// <summary>
/// Low level ray cast or shape-cast output data. Returns a zero fraction and normal in the case of initial overlap.
/// </summary>
public struct CastOutput
{
    public Vector2 Normal;
    public Vector2 Point;
    public float Fraction;
    public int Iterations;
    [MarshalAs(UnmanagedType.U1)]
    public bool Hit;
}