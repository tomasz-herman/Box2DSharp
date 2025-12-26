using System.Numerics;
using System.Runtime.InteropServices;

namespace Box2D.Collision;

/// <summary>
/// Output parameters for b2TimeOfImpact.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct ToiOutput
{
    public ToiState State;
    public Vector2 Point;
    public Vector2 Normal;
    public float Fraction;
}