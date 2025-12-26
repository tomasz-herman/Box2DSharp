using System.Numerics;
using System.Runtime.InteropServices;
using Box2D.Math;

namespace Box2D.Collision;

/// <summary>
/// Input parameters for b2ShapeCast
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public partial struct ShapeCastPairInput
{
    public ShapeProxy ProxyA;
    public ShapeProxy ProxyB;
    public Transform TransformA;
    public Transform TransformB;
    public Vector2 TranslationB;
    public float MaxFraction;
    public bool CanEncroach;

    public CastOutput ShapeCast()
    {
        return ShapeCast(ref this);
    }
    
    [LibraryImport("box2d", EntryPoint = "b2ShapeCast")]
    public static partial CastOutput ShapeCast(ref ShapeCastPairInput input);
}