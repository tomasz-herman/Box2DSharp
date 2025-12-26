using System.Runtime.InteropServices;
namespace Box2D.Id;

/// <summary>
/// Chain id references a chain instances. This should be treated as an opaque handle.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct ChainId
{
    private int _index;
    private ushort _world;
    private ushort _generation;

    public static implicit operator ChainId(ulong id) => new()
        { _index = (int)(id >> 32), _world = (ushort)(id >> 16), _generation = (ushort)id };

    public static implicit operator ulong(ChainId id) =>
        ((ulong)id._index << 32) | (ulong)id._world << 16 | id._generation;
}