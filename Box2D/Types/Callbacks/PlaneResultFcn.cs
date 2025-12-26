using System.Numerics;
using Box2D.Collision;
using Box2D.Id;

namespace Box2D.Types.Callbacks;

/// <summary>
/// Used to collect collision planes for character movers.
/// Return true to continue gathering planes.
/// </summary>
public readonly unsafe struct PlaneResultFcn(delegate*<ShapeId, PlaneResult*, void*, bool> ptr)
{
    private readonly delegate*<ShapeId, PlaneResult*, void*, bool> _ptr = ptr;

    public static implicit operator PlaneResultFcn(delegate*<ShapeId, PlaneResult*, void*, bool> ptr) => new PlaneResultFcn(ptr);

    public static implicit operator delegate*<ShapeId, PlaneResult*, void*, bool>(PlaneResultFcn callback) => callback._ptr;
    
    public bool Invoke(ShapeId shapeId, PlaneResult* plane, void* context) => _ptr(shapeId, plane, context);
}