using Box2D.Collision;
using System.Runtime.InteropServices;
using Box2D.Id;

namespace Box2D.Types.Events;

/// <summary>
/// A begin touch event is generated when two shapes begin touching.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct ContactBeginTouchEvent
{
    public ShapeId ShapeIdA;
    public ShapeId ShapeIdB;
    public Manifold Manifold;
}