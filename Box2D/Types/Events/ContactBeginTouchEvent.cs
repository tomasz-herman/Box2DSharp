using Box2D.Collision;
using Box2D.Id;

namespace Box2D.Types.Events;

/// <summary>
/// A begin touch event is generated when two shapes begin touching.
/// </summary>
public struct ContactBeginTouchEvent
{
    public ShapeId ShapeIdA;
    public ShapeId ShapeIdB;
    public Manifold Manifold;
}