using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Box2D.Math;

namespace Box2D.Collision;

/// <summary>
/// A contact manifold describes the contact points between colliding shapes.
/// </summary>
/// <remarks>
/// Note: Box2D uses speculative collision so some contact points may be separated.
/// </remarks>
[StructLayout(LayoutKind.Sequential)]
public partial struct Manifold
{
    public Vector2 Normal;
    public float RollingImpulse;

    [InlineArray(2)]
    [StructLayout(LayoutKind.Sequential)]
    public partial struct ManifoldPointBuffer
    {
        private ManifoldPoint _point;
    }

    public ManifoldPointBuffer Points;
    public int PointCount;

    [LibraryImport("box2d", EntryPoint = "b2CollideCircles")]
    public static partial Manifold CollideCircles(ref Circle circleA, Transform xfA, ref Circle circleB, Transform xfB);

    [LibraryImport("box2d", EntryPoint = "b2CollideCapsuleAndCircle")]
    public static partial Manifold CollideCapsuleAndCircle(ref Capsule capsuleA, Transform xfA, ref Circle circleB,
        Transform xfB);

    [LibraryImport("box2d", EntryPoint = "b2CollideSegmentAndCircle")]
    public static partial Manifold CollideSegmentAndCircle(ref Segment segmentA, Transform xfA, ref Circle circleB,
        Transform xfB);

    [LibraryImport("box2d", EntryPoint = "b2CollidePolygonAndCircle")]
    public static partial Manifold CollidePolygonAndCircle(ref Polygon polygonA, Transform xfA, ref Circle circleB,
        Transform xfB);

    [LibraryImport("box2d", EntryPoint = "b2CollideCapsules")]
    public static partial Manifold CollideCapsules(ref Capsule capsuleA, Transform xfA, ref Capsule capsuleB,
        Transform xfB);

    [LibraryImport("box2d", EntryPoint = "b2CollideSegmentAndCapsule")]
    public static partial Manifold CollideSegmentAndCapsule(ref Segment segmentA, Transform xfA, ref Capsule capsuleB,
        Transform xfB);

    [LibraryImport("box2d", EntryPoint = "b2CollidePolygonAndCapsule")]
    public static partial Manifold CollidePolygonAndCapsule(ref Polygon polygonA, Transform xfA, ref Capsule capsuleB,
        Transform xfB);

    [LibraryImport("box2d", EntryPoint = "b2CollidePolygons")]
    public static partial Manifold CollidePolygons(ref Polygon polygonA, Transform xfA, ref Polygon polygonB,
        Transform xfB);

    [LibraryImport("box2d", EntryPoint = "b2CollideSegmentAndPolygon")]
    public static partial Manifold CollideSegmentAndPolygon(ref Segment segmentA, Transform xfA, ref Polygon polygonB,
        Transform xfB);

    [LibraryImport("box2d", EntryPoint = "b2CollideChainSegmentAndCircle")]
    public static partial Manifold CollideChainSegmentAndCircle(ref ChainSegment segmentA, Transform xfA,
        ref Circle circleB,
        Transform xfB);

    [LibraryImport("box2d", EntryPoint = "b2CollideChainSegmentAndCapsule")]
    public static partial Manifold CollideChainSegmentAndCapsule(ref ChainSegment segmentA, Transform xfA,
        ref Capsule capsuleB,
        Transform xfB, ref SimplexCache cache);

    [LibraryImport("box2d", EntryPoint = "b2CollideChainSegmentAndPolygon")]
    public static partial Manifold CollideChainSegmentAndPolygon(ref ChainSegment segmentA, Transform xfA,
        ref Polygon polygonB,
        Transform xfB, ref SimplexCache cache);
}