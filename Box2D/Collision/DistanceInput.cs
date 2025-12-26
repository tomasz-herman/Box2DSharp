using System.Runtime.InteropServices;
using Box2D.Math;

namespace Box2D.Collision;

/// <summary>
/// Input for b2ShapeDistance
/// </summary>
public struct DistanceInput
{
    public ShapeProxy ProxyA;
    public ShapeProxy ProxyB;
    public Transform TransformA;
    public Transform TransformB;
    [MarshalAs(UnmanagedType.U1)]
    public bool UseRadii;
}