using System.Numerics;
using Box2D.Id;

namespace Box2D.Types.Callbacks;

/// <summary>
/// Low level ray cast / shape cast callback callback.
/// </summary>
/// <param name="shapeId">the shape hit by the ray</param>
/// <param name="point">the point of initial intersection</param>
/// <param name="normal">the normal vector at the point of intersection, zero for a shape cast with initial overlap</param>
/// <param name="fraction">the fraction along the ray at the point of intersection, zero for a shape cast with initial overlap</param>
/// <param name="context">the user context</param>
/// <returns>-1 to filter, 0 to terminate, fraction to clip the ray for closest hit, 1 to continue</returns>
/// <seealso cref="Box2D.World.CastRay"/>
public readonly unsafe struct CastResultFcn(delegate*<ShapeId, Vector2, Vector2, float, void*, float> ptr)
{
    private readonly delegate*<ShapeId, Vector2, Vector2, float, void*, float> _ptr = ptr;

    public static implicit operator CastResultFcn(delegate*<ShapeId, Vector2, Vector2, float, void*, float> ptr) => new CastResultFcn(ptr);

    public static implicit operator delegate*<ShapeId, Vector2, Vector2, float, void*, float>(CastResultFcn callback) => callback._ptr;
    
    public float Invoke(ShapeId shapeId, Vector2 point, Vector2 normal, float fraction, void* context) => _ptr(shapeId, point, normal, fraction, context);
}