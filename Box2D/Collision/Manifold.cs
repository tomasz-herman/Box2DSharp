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
public struct Manifold
{
    public Vector2 Normal;
    public float RollingImpulse;

    [InlineArray(2)]
    public struct ManifoldPointBuffer
    {
        private ManifoldPoint _point;
    }

    public ManifoldPointBuffer Points;
    public int PointCount;

    [DllImport("box2d", EntryPoint = "b2CollideCircles")]
    public static extern Manifold CollideCircles(ref Circle circleA, Transform xfA, ref Circle circleB, Transform xfB);

    [DllImport("box2d", EntryPoint = "b2CollideCapsuleAndCircle")]
    public static extern Manifold CollideCapsuleAndCircle(ref Capsule capsuleA, Transform xfA, ref Circle circleB,
        Transform xfB);

    [DllImport("box2d", EntryPoint = "b2CollideSegmentAndCircle")]
    public static extern Manifold CollideSegmentAndCircle(ref Segment segmentA, Transform xfA, ref Circle circleB,
        Transform xfB);

    [DllImport("box2d", EntryPoint = "b2CollidePolygonAndCircle")]
    public static extern Manifold CollidePolygonAndCircle(ref Polygon polygonA, Transform xfA, ref Circle circleB,
        Transform xfB);

    [DllImport("box2d", EntryPoint = "b2CollideCapsules")]
    public static extern Manifold CollideCapsules(ref Capsule capsuleA, Transform xfA, ref Capsule capsuleB,
        Transform xfB);

    [DllImport("box2d", EntryPoint = "b2CollideSegmentAndCapsule")]
    public static extern Manifold CollideSegmentAndCapsule(ref Segment segmentA, Transform xfA, ref Capsule capsuleB,
        Transform xfB);

    [DllImport("box2d", EntryPoint = "b2CollidePolygonAndCapsule")]
    public static extern Manifold CollidePolygonAndCapsule(ref Polygon polygonA, Transform xfA, ref Capsule capsuleB,
        Transform xfB);

    [DllImport("box2d", EntryPoint = "b2CollidePolygons")]
    public static extern Manifold CollidePolygons(ref Polygon polygonA, Transform xfA, ref Polygon polygonB,
        Transform xfB);

    [DllImport("box2d", EntryPoint = "b2CollideSegmentAndPolygon")]
    public static extern Manifold CollideSegmentAndPolygon(ref Segment segmentA, Transform xfA, ref Polygon polygonB,
        Transform xfB);

    [DllImport("box2d", EntryPoint = "b2CollideChainSegmentAndCircle")]
    public static extern Manifold CollideChainSegmentAndCircle(ref ChainSegment segmentA, Transform xfA,
        ref Circle circleB,
        Transform xfB);

    [DllImport("box2d", EntryPoint = "b2CollideChainSegmentAndCapsule")]
    public static extern Manifold CollideChainSegmentAndCapsule(ref ChainSegment segmentA, Transform xfA,
        ref Capsule capsuleB,
        Transform xfB, ref SimplexCache cache);

    [DllImport("box2d", EntryPoint = "b2CollideChainSegmentAndPolygon")]
    public static extern Manifold CollideChainSegmentAndPolygon(ref ChainSegment segmentA, Transform xfA,
        ref Polygon polygonB,
        Transform xfB, ref SimplexCache cache);
}