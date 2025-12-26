using Box2D.Id;

namespace Box2D.Types.Callbacks;

/// <summary>
/// Prototype for a overlap callback.
/// </summary>
/// <remarks>See b2World_OverlapABB</remarks>
/// <returns>false to terminate the query.</returns>
public readonly unsafe struct OverlapResultFcn(delegate*<ShapeId, void*, bool> ptr)
{
    private readonly delegate*<ShapeId, void*, bool> _ptr = ptr;

    public static implicit operator OverlapResultFcn(delegate*<ShapeId, void*, bool> ptr) => new OverlapResultFcn(ptr);

    public static implicit operator delegate*<ShapeId, void*, bool>(OverlapResultFcn callback) => callback._ptr;
    
    public bool Invoke(ShapeId shapeId, void* context) => _ptr(shapeId, context);
}