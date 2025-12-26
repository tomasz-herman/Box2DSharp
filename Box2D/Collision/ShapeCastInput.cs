using System.Numerics;
using System.Runtime.InteropServices;

namespace Box2D.Collision;

/// <summary>
/// Low level shape cast input in generic form. This allows casting an arbitrary point
/// cloud wrap with a radius. For example, a circle is a single point with a non-zero radius.
/// A capsule is two points with a non-zero radius. A box is four points with a zero radius.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct ShapeCastInput
{
    public ShapeProxy Proxy;
    public Vector2 Translation;
    public float MaxFraction;
    [MarshalAs(UnmanagedType.U1)]
    public bool CanEncroach;
}