namespace Box2D.Collision;

/// <summary>
/// Used to warm start the GJK simplex. If you call this function multiple times with nearby
/// transforms this might improve performance. Otherwise you can zero initialize this.
/// The distance cache must be initialized to zero on the first call.
/// Users should generally just zero initialize this structure for each call.
/// </summary>
public unsafe struct SimplexCache
{
    public ushort Count;
    public fixed byte IndexA[3];
    public fixed byte IndexB[3];
}