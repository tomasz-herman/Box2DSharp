namespace Box2D.Types;

/// <summary>
/// Profiling data. Times are in milliseconds.
/// </summary>
public struct Profile
{
    public float Step;
    public float Pairs;
    public float Collide;
    public float Solve;
    public float MergeIslands;
    public float PrepareStages;
    public float SolveConstraints;
    public float PrepareConstraints;
    public float IntegrateVelocities;
    public float WarmStart;
    public float SolveImpulses;
    public float IntegratePositions;
    public float RelaxImpulses;
    public float ApplyRestitution;
    public float StoreImpulses;
    public float SplitIslands;
    public float Transforms;
    public float HitEvents;
    public float Refit;
    public float Bullets;
    public float SleepIslands;
    public float Sensors;
}