using System.Runtime.InteropServices;

namespace Box2D.Collision;

/// <summary>
/// Input parameters for b2TimeOfImpact
/// </summary>
public struct ToiInput
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

    [DllImport("box2d", EntryPoint = "b2TimeOfImpact")]
    public static extern ToiOutput TimeOfImpact(ref ToiInput input);
}