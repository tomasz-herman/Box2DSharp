using System.Runtime.InteropServices;

namespace Box2D.Collision;

/// <summary>
/// Input parameters for b2TimeOfImpact
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public partial struct ToiInput
{
    public ShapeProxy ProxyA;
    public ShapeProxy ProxyB;
    public Sweep SweepA;
    public Sweep SweepB;
    public float MaxFriction;

    public ToiOutput Compute()
    {
        return TimeOfImpact(ref this);
    }

    [LibraryImport("box2d", EntryPoint = "b2TimeOfImpact")]
    public static partial ToiOutput TimeOfImpact(ref ToiInput input);
}