using System.Numerics;
using System.Runtime.InteropServices;

namespace Box2D.Collision;

/// <summary>
/// This holds the mass data computed for a shape.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct MassData
{
    public float Mass;
    public Vector2 Center;
    public float RotationalInertia;
}