using Box2D.Id;

namespace Box2D.Types.Callbacks;

/// <summary>
/// Prototype for a custom body filter callback.
/// </summary>
/// <seealso cref="Box2D.Types.Shapes.ShapeDef"/>
/// <remarks>
/// Warning: Do not attempt to modify the world inside this callback
/// </remarks>
public readonly unsafe struct CustomFilterFcn(delegate*<ShapeId, ShapeId, void*, bool> ptr)
{
    private readonly delegate*<ShapeId, ShapeId, void*, bool> _ptr = ptr;

    public static implicit operator CustomFilterFcn(delegate*<ShapeId, ShapeId, void*, bool> ptr) => new CustomFilterFcn(ptr);

    public static implicit operator delegate*<ShapeId, ShapeId, void*, bool>(CustomFilterFcn callback) => callback._ptr;
    
    public bool Invoke(ShapeId shapeA, ShapeId shapeB, void* context) => _ptr(shapeA, shapeB, context);
}