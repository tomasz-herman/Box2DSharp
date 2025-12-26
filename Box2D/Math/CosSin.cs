using System.Runtime.InteropServices;
namespace Box2D.Math;

/// <summary>
/// Cosine and sine pair
/// This uses a custom implementation designed for cross-platform determinism
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct CosSin
{
    public float Cos;
    public float Sin;
}