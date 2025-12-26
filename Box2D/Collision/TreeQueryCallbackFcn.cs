namespace Box2D.Collision;

/// <summary>
/// This function receives proxies found in the AABB query.
/// </summary>
/// <returns>true if the query should continue</returns>
public readonly unsafe struct TreeQueryCallbackFcn(delegate*<int, ulong, void*, bool> ptr)
{
    private readonly delegate*<int, ulong, void*, bool> _ptr = ptr;

    public static implicit operator TreeQueryCallbackFcn(delegate*<int, ulong, void*, bool> ptr) => new TreeQueryCallbackFcn(ptr);

    public static implicit operator delegate*<int, ulong, void*, bool>(TreeQueryCallbackFcn callback) => callback._ptr;
    
    public bool Invoke(int proxyId, ulong userData, void* context) => _ptr(proxyId, userData, context);
}