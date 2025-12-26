using System.Numerics;
using System.Runtime.InteropServices;

namespace Box2D.Types;

/// <summary>
/// The explosion definition is used to configure options for explosions. Explosions
/// consider shape geometry when computing the impulse.
/// </summary>
public struct ExplosionDef
{
    public ulong MaskBits;
    public Vector2 Position;
    public float Radius;
    public float Falloff;
    public float ImpulsePerLength;
    
    [DllImport("box2d", EntryPoint = "b2DefaultExplosionDef")]
    public static extern ExplosionDef Default();
}