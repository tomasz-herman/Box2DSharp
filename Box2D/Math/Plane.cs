using System.Numerics;

namespace Box2D.Math;

/// <summary>
/// separation = dot(normal, point) - offset
/// </summary>
public struct Plane
{
    public Vector2 Normal;
    public float Offset;
}