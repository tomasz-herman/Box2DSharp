namespace Box2D.Id;

/// <summary>
/// World id references a world instance. This should be treated as an opaque handle.
/// </summary>
public struct WorldId
{
    private ushort _index;
    private ushort _generation;

    public static implicit operator WorldId(uint id) => new() { _index = (ushort)(id >> 16), _generation = (ushort)id };
    public static implicit operator uint(WorldId id) => ((uint)id._index << 16) | id._generation;
}