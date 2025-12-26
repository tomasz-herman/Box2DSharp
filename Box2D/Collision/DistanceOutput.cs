using System.Numerics;
using System.Runtime.InteropServices;

namespace Box2D.Collision;

/// <summary>
/// Output for b2ShapeDistance
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct DistanceOutput
{
    public Vector2 PointA;
    public Vector2 PointB;
    public Vector2 Normal;
    public float Distance;
    public int Iterations;
    public int SimplexCount;
}