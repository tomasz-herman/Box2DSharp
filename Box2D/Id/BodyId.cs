namespace Box2D.Id;

/// <summary>
/// Body id references a body instance. This should be treated as an opaque handle.
/// </summary>
public struct BodyId
{
    private int _index;
    private ushort _world;
    private ushort _generation;

    public static implicit operator BodyId(ulong id) => new()
        { _index = (int)(id >> 32), _world = (ushort)(id >> 16), _generation = (ushort)id };

    public static implicit operator ulong(BodyId id) =>
        ((ulong)id._index << 32) | (ulong)id._world << 16 | id._generation;
}