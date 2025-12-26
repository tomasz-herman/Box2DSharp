using System.Numerics;
using System.Runtime.InteropServices;
using Box2D.Math;

namespace Box2D.Collision;

/// <summary>
/// The dynamic tree structure. This should be considered private data.
/// It is placed here for performance reasons.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe class DynamicTree : IDisposable
{
    public void* Nodes;
    public int Root;
    public int NodeCount;
    public int NodeCapacity;
    public int FreeList;
    public int ProxyCount;
    public int* LeafIndices;
    public Aabb* LeafBoxes;
    public Vector2* LeafCenters;
    public int* BinIndices;
    public int RebuildCapacity;
    private bool _disposed;

    public DynamicTree()
    {
        var tree = DynamicTree_Create();
        Nodes = tree.Nodes;
        Root = tree.Root;
        NodeCount = tree.NodeCount;
        NodeCapacity = tree.NodeCapacity;
        FreeList = tree.FreeList;
        ProxyCount = tree.ProxyCount;
        LeafIndices = tree.LeafIndices;
        LeafBoxes = tree.LeafBoxes;
        LeafCenters = tree.LeafCenters;
        BinIndices = tree.BinIndices;
        RebuildCapacity = tree.RebuildCapacity;
    }

    public int CreateProxy(Aabb aabb, ulong categoryBits, ulong userData)
    {
        return DynamicTree_CreateProxy(this, aabb, categoryBits, userData);
    }

    public void DestroyProxy(int proxyId)
    {
        DynamicTree_DestroyProxy(this, proxyId);
    }

    public void MoveProxy(int proxyId, Aabb aabb)
    {
        DynamicTree_MoveProxy(this, proxyId, aabb);
    }

    public void EnlargeProxy(int proxyId, Aabb aabb)
    {
        DynamicTree_EnlargeProxy(this, proxyId, aabb);
    }

    public void SetCategoryBits(int proxyId, ulong categoryBits)
    {
        DynamicTree_SetCategoryBits(this, proxyId, categoryBits);
    }

    public ulong GetCategoryBits(int proxyId)
    {
        return DynamicTree_GetCategoryBits(this, proxyId);
    }

    public TreeStats Query(Aabb aabb, ulong maskBits,
        TreeQueryCallbackFcn callback, void* context)
    {
        return DynamicTree_Query(this, aabb, maskBits, callback, context);
    }

    public TreeStats QueryAll(Aabb aabb, TreeQueryCallbackFcn callback,
        void* context)
    {
        return DynamicTree_QueryAll(this, aabb, callback, context);
    }

    public TreeStats RayCast(ref RayCastInput input, ulong maskBits,
        TreeRayCastCallbackFcn callback, void* context)
    {
        return DynamicTree_RayCast(this, ref input, maskBits, callback, context);
    }

    public TreeStats ShapeCast(ref ShapeCastInput input, ulong maskBits,
        TreeShapeCastCallbackFcn callback, void* context)
    {
        return DynamicTree_ShapeCast(this, ref input, maskBits, callback, context);
    }

    public int GetHeight()
    {
        return DynamicTree_GetHeight(this);
    }

    public float GetAreaRatio()
    {
        return DynamicTree_GetAreaRatio(this);
    }

    public Aabb GetRootBounds()
    {
        return DynamicTree_GetRootBounds(this);
    }

    public int GetProxyCount()
    {
        return DynamicTree_GetProxyCount(this);
    }

    public int Rebuild(bool fullBuild)
    {
        return DynamicTree_Rebuild(this, fullBuild);
    }

    public int GetByteCount()
    {
        return DynamicTree_GetByteCount(this);
    }

    public ulong GetUserData(int proxyId)
    {
        return DynamicTree_GetUserData(this, proxyId);
    }

    public Aabb GetAabb(int proxyId)
    {
        return DynamicTree_GetAabb(this, proxyId);
    }

    public void Validate()
    {
        DynamicTree_Validate(this);
    }

    public void ValidateNoEnlarged()
    {
        DynamicTree_ValidateNoEnlarged(this);
    }

    #region NativeFunctions
    [DllImport("box2d", EntryPoint = "b2DynamicTree_Create")]
    private static extern DynamicTreeStruct DynamicTree_Create();

    [DllImport("box2d", EntryPoint = "b2DynamicTree_Destroy")]
    private static extern void DynamicTree_Destroy(DynamicTree tree);

    [DllImport("box2d", EntryPoint = "b2DynamicTree_CreateProxy")]
    public static extern int DynamicTree_CreateProxy(DynamicTree tree, Aabb aabb, ulong categoryBits, ulong userData);

    [DllImport("box2d", EntryPoint = "b2DynamicTree_DestroyProxy")]
    public static extern void DynamicTree_DestroyProxy(DynamicTree tree, int proxyId);

    [DllImport("box2d", EntryPoint = "b2DynamicTree_MoveProxy")]
    public static extern void DynamicTree_MoveProxy(DynamicTree tree, int proxyId, Aabb aabb);

    [DllImport("box2d", EntryPoint = "b2DynamicTree_EnlargeProxy")]
    public static extern void DynamicTree_EnlargeProxy(DynamicTree tree, int proxyId, Aabb aabb);

    [DllImport("box2d", EntryPoint = "b2DynamicTree_SetCategoryBits")]
    public static extern void DynamicTree_SetCategoryBits(DynamicTree tree, int proxyId, ulong categoryBits);

    [DllImport("box2d", EntryPoint = "b2DynamicTree_GetCategoryBits")]
    public static extern ulong DynamicTree_GetCategoryBits(DynamicTree tree, int proxyId);

    [DllImport("box2d", EntryPoint = "b2DynamicTree_Query")]
    public static extern TreeStats DynamicTree_Query(DynamicTree tree, Aabb aabb, ulong maskBits,
        TreeQueryCallbackFcn callback, void* context);

    [DllImport("box2d", EntryPoint = "b2DynamicTree_QueryAll")]
    public static extern TreeStats DynamicTree_QueryAll(DynamicTree tree, Aabb aabb, TreeQueryCallbackFcn callback,
        void* context);

    [DllImport("box2d", EntryPoint = "b2DynamicTree_RayCast")]
    public static extern TreeStats DynamicTree_RayCast(DynamicTree tree, ref RayCastInput input, ulong maskBits,
        TreeRayCastCallbackFcn callback, void* context);

    [DllImport("box2d", EntryPoint = "b2DynamicTree_ShapeCast")]
    public static extern TreeStats DynamicTree_ShapeCast(DynamicTree tree, ref ShapeCastInput input, ulong maskBits,
        TreeShapeCastCallbackFcn callback, void* context);

    [DllImport("box2d", EntryPoint = "b2DynamicTree_GetHeight")]
    public static extern int DynamicTree_GetHeight(DynamicTree tree);

    [DllImport("box2d", EntryPoint = "b2DynamicTree_GetAreaRatio")]
    public static extern float DynamicTree_GetAreaRatio(DynamicTree tree);

    [DllImport("box2d", EntryPoint = "b2DynamicTree_GetRootBounds")]
    public static extern Aabb DynamicTree_GetRootBounds(DynamicTree tree);

    [DllImport("box2d", EntryPoint = "b2DynamicTree_GetProxyCount")]
    public static extern int DynamicTree_GetProxyCount(DynamicTree tree);

    [DllImport("box2d", EntryPoint = "b2DynamicTree_Rebuild")]
    public static extern int DynamicTree_Rebuild(DynamicTree tree, bool fullBuild);

    [DllImport("box2d", EntryPoint = "b2DynamicTree_GetByteCount")]
    public static extern int DynamicTree_GetByteCount(DynamicTree tree);

    [DllImport("box2d", EntryPoint = "b2DynamicTree_GetUserData")]
    public static extern ulong DynamicTree_GetUserData(DynamicTree tree, int proxyId);

    [DllImport("box2d", EntryPoint = "b2DynamicTree_GetAABB")]
    public static extern Aabb DynamicTree_GetAabb(DynamicTree tree, int proxyId);

    [DllImport("box2d", EntryPoint = "b2DynamicTree_Validate")]
    public static extern void DynamicTree_Validate(DynamicTree tree);

    [DllImport("box2d", EntryPoint = "b2DynamicTree_ValidateNoEnlarged")]
    public static extern void DynamicTree_ValidateNoEnlarged(DynamicTree tree);
    #endregion
    
    #region DisposePattern
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool _)
    {
        if (_disposed)
        {
            return;
        }

        DynamicTree_Destroy(this);
        _disposed = true;
    }

    ~DynamicTree() => Dispose(false);
    #endregion
    
    private struct DynamicTreeStruct
    {
        public void* Nodes;
        public int Root;
        public int NodeCount;
        public int NodeCapacity;
        public int FreeList;
        public int ProxyCount;
        public int* LeafIndices;
        public Aabb* LeafBoxes;
        public Vector2* LeafCenters;
        public int* BinIndices;
        public int RebuildCapacity;
    }
}