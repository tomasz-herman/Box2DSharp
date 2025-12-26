namespace Box2D.Collision;

/// <summary>
/// This function receives clipped ray cast input for a proxy. The function
/// returns the new ray fraction.
/// - return a value of 0 to terminate the ray cast
/// - return a value less than input->maxFraction to clip the ray
/// - return a value of input->maxFraction to continue the ray cast without clipping
/// </summary>
public readonly unsafe struct TreeRayCastCallbackFcn(delegate*<RayCastInput*, int, ulong, void*, float> ptr)
{
    private readonly delegate*<RayCastInput*, int, ulong, void*, float> _ptr = ptr;

    public static implicit operator TreeRayCastCallbackFcn(delegate*<RayCastInput*, int, ulong, void*, float> ptr) => new TreeRayCastCallbackFcn(ptr);

    public static implicit operator delegate*<RayCastInput*, int, ulong, void*, float>(TreeRayCastCallbackFcn callback) => callback._ptr;
    
    public float Invoke(RayCastInput* input, int proxyId, ulong userData, void* context) => _ptr(input, proxyId, userData, context);
}