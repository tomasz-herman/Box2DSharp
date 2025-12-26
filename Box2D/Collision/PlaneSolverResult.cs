using System.Numerics;

namespace Box2D.Collision;

/// <summary>
/// Result returned by b2SolvePlanes
/// </summary>
public struct PlaneSolverResult
{
    public Vector2 Translation;
    public int IterationCount;
}