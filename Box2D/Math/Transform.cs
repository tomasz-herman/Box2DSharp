using System.Numerics;
using System.Runtime.InteropServices;

namespace Box2D.Math;

/// <summary>
/// A 2D rigid transform
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Transform
{
    public Vector2 P;
    public Rotation Q;
}