namespace Box2D.Collision;

/// <summary>
/// This function receives clipped ray cast input for a proxy. The function
/// returns the new ray fraction.
/// - return a value of 0 to terminate the ray cast
/// - return a value less than input->maxFraction to clip the ray
/// - return a value of input->maxFraction to continue the ray cast without clipping
/// </summary>
public readonly unsafe struct TreeShapeCastCallbackFcn(delegate*<ShapeCastInput*, int, ulong, void*, float> ptr)
{
    private readonly delegate*<ShapeCastInput*, int, ulong, void*, float> _ptr = ptr;

    public static implicit operator TreeShapeCastCallbackFcn(delegate*<ShapeCastInput*, int, ulong, void*, float> ptr) => new TreeShapeCastCallbackFcn(ptr);

    public static implicit operator delegate*<ShapeCastInput*, int, ulong, void*, float>(TreeShapeCastCallbackFcn callback) => callback._ptr;
    
    public float Invoke(ShapeCastInput* input, int proxyId, ulong userData, void* context) => _ptr(input, proxyId, userData, context);
}