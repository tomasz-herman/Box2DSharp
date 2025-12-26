using System.Numerics;
using System.Runtime.InteropServices;

namespace Box2D.Math;

/// <summary>
/// Axis-aligned bounding box
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Aabb
{
    public Vector2 LowerBound;
    public Vector2 UpperBound;
}