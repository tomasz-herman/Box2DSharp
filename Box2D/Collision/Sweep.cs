using System.Numerics;
using System.Runtime.InteropServices;
using Box2D.Math;

namespace Box2D.Collision;

/// <summary>
/// This describes the motion of a body/shape for TOI computation. Shapes are defined with respect to the body origin,
/// which may not coincide with the center of mass. However, to support dynamics we must interpolate the center of mass
/// position.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public partial struct Sweep
{
    public Vector2 LocalCenter;
    public Vector2 C1;
    public Vector2 C2;
    public Rotation Q1;
    public Rotation Q2;
    
    [LibraryImport("box2d", EntryPoint = "b2GetSweepTransform")]
    public static partial Transform GetSweepTransform(ref Sweep sweep, float time);
}