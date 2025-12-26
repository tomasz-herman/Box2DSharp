using System.Numerics;
using System.Runtime.InteropServices;

namespace Box2D.Collision;

/// <summary>
/// Result returned by b2SolvePlanes
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct PlaneSolverResult
{
    public Vector2 Translation;
    public int IterationCount;
}