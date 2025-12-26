using System.Numerics;
using System.Runtime.InteropServices;
using Plane = Box2D.Math.Plane;

namespace Box2D.Collision;

/// <summary>
/// These are the collision planes returned from b2World_CollideMover
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct PlaneResult
{
    public Plane Plane;
    public Vector2 Point;
    [MarshalAs(UnmanagedType.U1)]
    public bool Hit;
}