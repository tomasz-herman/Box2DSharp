using System.Runtime.InteropServices;
namespace Box2D.Collision;

/// <summary>
/// These are performance results returned by dynamic tree queries.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct TreeStats
{
    public int NodeVisits;
    public int LeafVisits;
}