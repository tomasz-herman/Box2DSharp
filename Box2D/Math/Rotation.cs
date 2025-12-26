using System.Runtime.InteropServices;
namespace Box2D.Math;

/// <summary>
/// 2D rotation
/// This is similar to using a complex number for rotation
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Rotation
{
    public float Cos;
    public float Sin;
}