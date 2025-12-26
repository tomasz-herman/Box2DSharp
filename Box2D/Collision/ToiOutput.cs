using System.Numerics;

namespace Box2D.Collision;

/// <summary>
/// Output parameters for b2TimeOfImpact.
/// </summary>
public struct ToiOutput
{
    public ToiState State;
    public Vector2 Point;
    public Vector2 Normal;
    public float Fraction;
}