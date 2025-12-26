using System.Numerics;
using System.Runtime.InteropServices;
using Box2D.Id;

namespace Box2D.Types.Events;

/// <summary>
/// A hit touch event is generated when two shapes collide with a speed faster than the hit speed threshold.
/// This may be reported for speculative contacts that have a confirmed impulse.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct ContactHitEvent
{
    public ShapeId ShapeIdA;
    public ShapeId ShapeIdB;
    public Vector2 Point;
    public Vector2 Normal;
    public float ApproachSpeed;
}