using System.Numerics;
using System.Runtime.InteropServices;
using Box2D.Id;

namespace Box2D.Types;

/// <summary>
/// Result from a ray cast
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct RayResult
{
    public ShapeId ShapeId;
    public Vector2 Point;
    public Vector2 Normal;
    public float Fraction;
    public int NodeVisits;
    public int LeafVisits;
    [MarshalAs(UnmanagedType.U1)] 
    public bool Hit;
}