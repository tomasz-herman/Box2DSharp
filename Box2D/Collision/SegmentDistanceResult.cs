using System.Numerics;
using System.Runtime.InteropServices;

namespace Box2D.Collision;

/// <summary>
/// Result of computing the distance between two line segments
/// </summary>
public struct SegmentDistanceResult
{
    public Vector2 Closest1;
    public Vector2 Closest2;
    public float Fraction1;
    public float Fraction2;
    public float DistanceSquared;

    [DllImport("box2d", EntryPoint = "b2SegmentDistance")]
    public static extern SegmentDistanceResult SegmentDistance(Vector2 p1, Vector2 q1, Vector2 p2, Vector2 q2);
}