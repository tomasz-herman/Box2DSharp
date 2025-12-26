using System.Numerics;
using System.Runtime.InteropServices;

namespace Box2D.Math;

/// <summary>
/// separation = dot(normal, point) - offset
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Plane
{
    public Vector2 Normal;
    public float Offset;
}