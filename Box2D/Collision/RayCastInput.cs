using System.Numerics;
using System.Runtime.InteropServices;

namespace Box2D.Collision;

/// <summary>
/// Low level ray cast input data
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct RayCastInput
{
    public Vector2 Origin;
    public Vector2 Translation;
    public float MaxFraction;

    public bool IsValid()
    {
        return IsValid(ref this);
    }

    [LibraryImport("box2d", EntryPoint = "b2IsValidRay")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static partial bool IsValid(ref RayCastInput input);
}