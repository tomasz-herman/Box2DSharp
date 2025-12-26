using System.Numerics;

namespace Box2D.Collision;

/// <summary>
/// A line segment with one-sided collision. Only collides on the right side.
/// Several of these are generated for a chain shape.
/// ghost1 -> point1 -> point2 -> ghost2
/// </summary>
public struct ChainSegment
{
    public Vector2 Ghost1;
    public Segment Segment;
    public Vector2 Ghost2;
    private int _chainId;
}