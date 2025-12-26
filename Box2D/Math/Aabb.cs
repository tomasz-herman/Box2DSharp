using System.Numerics;

namespace Box2D.Math;

/// <summary>
/// Axis-aligned bounding box
/// </summary>
public struct Aabb
{
    public Vector2 LowerBound;
    public Vector2 UpperBound;
}