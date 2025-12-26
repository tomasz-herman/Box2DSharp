using System.Numerics;

namespace Box2D.Collision;

/// <summary>
/// This holds the mass data computed for a shape.
/// </summary>
public struct MassData
{
    public float Mass;
    public Vector2 Center;
    public float RotationalInertia;
}