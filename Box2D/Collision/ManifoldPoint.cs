using System.Numerics;
using System.Runtime.InteropServices;

namespace Box2D.Collision;

/// <summary>
/// A manifold point is a contact point belonging to a contact manifold.
/// It holds details related to the geometry and dynamics of the contact points.
/// Box2D uses speculative collision so some contact points may be separated.
/// You may use the totalNormalImpulse to determine if there was an interaction during
/// the time step.
/// </summary>
public struct ManifoldPoint
{
    public Vector2 Point;
    public Vector2 AnchorA;
    public Vector2 AnchorB;
    public float Separation;
    public float NormalImpulse;
    public float TangentImpulse;
    public float TotalNormalImpulse;
    public float NormalVelocity;
    public ushort Id;
    [MarshalAs(UnmanagedType.U1)]
    public bool Persisted;
}