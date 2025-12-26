using System.Numerics;
using System.Runtime.InteropServices;
using Box2D.Math;

namespace Box2D.Collision;

/// <summary>
/// The dynamic tree structure. This should be considered private data.
/// It is placed here for performance reasons.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe partial class DynamicTree : IDisposable
{
    private DynamicTreeStruct Tree;
    private bool _disposed;

    public DynamicTree()
    {
        Tree = DynamicTree_Create();
    }

    public int CreateProxy(Aabb aabb, ulong categoryBits, ulong userData)
    {
        return DynamicTree_CreateProxy(ref Tree, aabb, categoryBits, userData);
    }

    public void DestroyProxy(int proxyId)
    {
        DynamicTree_DestroyProxy(ref Tree, proxyId);
    }

    public void MoveProxy(int proxyId, Aabb aabb)
    {
        DynamicTree_MoveProxy(ref Tree, proxyId, aabb);
    }

    public void EnlargeProxy(int proxyId, Aabb aabb)
    {
        DynamicTree_EnlargeProxy(ref Tree, proxyId, aabb);
    }

    public void SetCategoryBits(int proxyId, ulong categoryBits)
    {
        DynamicTree_SetCategoryBits(ref Tree, proxyId, categoryBits);
    }

    public ulong GetCategoryBits(int proxyId)
    {
        return DynamicTree_GetCategoryBits(ref Tree, proxyId);
    }

    public TreeStats Query(Aabb aabb, ulong maskBits,
        TreeQueryCallbackFcn callback, void* context)
    {
        return DynamicTree_Query(ref Tree, aabb, maskBits, callback, context);
    }

    public TreeStats QueryAll(Aabb aabb, TreeQueryCallbackFcn callback,
        void* context)
    {
        return DynamicTree_QueryAll(ref Tree, aabb, callback, context);
    }

    public TreeStats RayCast(ref RayCastInput input, ulong maskBits,
        TreeRayCastCallbackFcn callback, void* context)
    {
        return DynamicTree_RayCast(ref Tree, ref input, maskBits, callback, context);
    }

    public TreeStats ShapeCast(ref ShapeCastInput input, ulong maskBits,
        TreeShapeCastCallbackFcn callback, void* context)
    {
        return DynamicTree_ShapeCast(ref Tree, ref input, maskBits, callback, context);
    }

    public int GetHeight()
    {
        return DynamicTree_GetHeight(ref Tree);
    }

    public float GetAreaRatio()
    {
        return DynamicTree_GetAreaRatio(ref Tree);
    }

    public Aabb GetRootBounds()
    {
        return DynamicTree_GetRootBounds(ref Tree);
    }

    public int GetProxyCount()
    {
        return DynamicTree_GetProxyCount(ref Tree);
    }

    public int Rebuild(bool fullBuild)
    {
        return DynamicTree_Rebuild(ref Tree, fullBuild);
    }

    public int GetByteCount()
    {
        return DynamicTree_GetByteCount(ref Tree);
    }

    public ulong GetUserData(int proxyId)
    {
        return DynamicTree_GetUserData(ref Tree, proxyId);
    }

    public Aabb GetAabb(int proxyId)
    {
        return DynamicTree_GetAabb(ref Tree, proxyId);
    }

    public void Validate()
    {
        DynamicTree_Validate(ref Tree);
    }

    public void ValidateNoEnlarged()
    {
        DynamicTree_ValidateNoEnlarged(ref Tree);
    }

    #region NativeFunctions
    [LibraryImport("box2d", EntryPoint = "b2DynamicTree_Create")]
    private static partial DynamicTreeStruct DynamicTree_Create();

    [LibraryImport("box2d", EntryPoint = "b2DynamicTree_Destroy")]
    private static partial void DynamicTree_Destroy(ref DynamicTreeStruct tree);

    [LibraryImport("box2d", EntryPoint = "b2DynamicTree_CreateProxy")]
    private static partial int DynamicTree_CreateProxy(ref DynamicTreeStruct tree, Aabb aabb, ulong categoryBits, ulong userData);

    [LibraryImport("box2d", EntryPoint = "b2DynamicTree_DestroyProxy")]
    private static partial void DynamicTree_DestroyProxy(ref DynamicTreeStruct tree, int proxyId);

    [LibraryImport("box2d", EntryPoint = "b2DynamicTree_MoveProxy")]
    private static partial void DynamicTree_MoveProxy(ref DynamicTreeStruct tree, int proxyId, Aabb aabb);

    [LibraryImport("box2d", EntryPoint = "b2DynamicTree_EnlargeProxy")]
    private static partial void DynamicTree_EnlargeProxy(ref DynamicTreeStruct tree, int proxyId, Aabb aabb);

    [LibraryImport("box2d", EntryPoint = "b2DynamicTree_SetCategoryBits")]
    private static partial void DynamicTree_SetCategoryBits(ref DynamicTreeStruct tree, int proxyId, ulong categoryBits);

    [LibraryImport("box2d", EntryPoint = "b2DynamicTree_GetCategoryBits")]
    private static partial ulong DynamicTree_GetCategoryBits(ref DynamicTreeStruct tree, int proxyId);

    [LibraryImport("box2d", EntryPoint = "b2DynamicTree_Query")]
    private static partial TreeStats DynamicTree_Query(ref DynamicTreeStruct tree, Aabb aabb, ulong maskBits,
        TreeQueryCallbackFcn callback, void* context);

    [LibraryImport("box2d", EntryPoint = "b2DynamicTree_QueryAll")]
    private static partial TreeStats DynamicTree_QueryAll(ref DynamicTreeStruct tree, Aabb aabb, TreeQueryCallbackFcn callback,
        void* context);

    [LibraryImport("box2d", EntryPoint = "b2DynamicTree_RayCast")]
    private static partial TreeStats DynamicTree_RayCast(ref DynamicTreeStruct tree, ref RayCastInput input, ulong maskBits,
        TreeRayCastCallbackFcn callback, void* context);

    [LibraryImport("box2d", EntryPoint = "b2DynamicTree_ShapeCast")]
    private static partial TreeStats DynamicTree_ShapeCast(ref DynamicTreeStruct tree, ref ShapeCastInput input, ulong maskBits,
        TreeShapeCastCallbackFcn callback, void* context);

    [LibraryImport("box2d", EntryPoint = "b2DynamicTree_GetHeight")]
    private static partial int DynamicTree_GetHeight(ref DynamicTreeStruct tree);

    [LibraryImport("box2d", EntryPoint = "b2DynamicTree_GetAreaRatio")]
    private static partial float DynamicTree_GetAreaRatio(ref DynamicTreeStruct tree);

    [LibraryImport("box2d", EntryPoint = "b2DynamicTree_GetRootBounds")]
    private static partial Aabb DynamicTree_GetRootBounds(ref DynamicTreeStruct tree);

    [LibraryImport("box2d", EntryPoint = "b2DynamicTree_GetProxyCount")]
    private static partial int DynamicTree_GetProxyCount(ref DynamicTreeStruct tree);

    [LibraryImport("box2d", EntryPoint = "b2DynamicTree_Rebuild")]
    private static partial int DynamicTree_Rebuild(ref DynamicTreeStruct tree, [MarshalAs(UnmanagedType.U1)] bool fullBuild);

    [LibraryImport("box2d", EntryPoint = "b2DynamicTree_GetByteCount")]
    private static partial int DynamicTree_GetByteCount(ref DynamicTreeStruct tree);

    [LibraryImport("box2d", EntryPoint = "b2DynamicTree_GetUserData")]
    private static partial ulong DynamicTree_GetUserData(ref DynamicTreeStruct tree, int proxyId);

    [LibraryImport("box2d", EntryPoint = "b2DynamicTree_GetAABB")]
    private static partial Aabb DynamicTree_GetAabb(ref DynamicTreeStruct tree, int proxyId);

    [LibraryImport("box2d", EntryPoint = "b2DynamicTree_Validate")]
    private static partial void DynamicTree_Validate(ref DynamicTreeStruct tree);

    [LibraryImport("box2d", EntryPoint = "b2DynamicTree_ValidateNoEnlarged")]
    private static partial void DynamicTree_ValidateNoEnlarged(ref DynamicTreeStruct tree);
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

        DynamicTree_Destroy(ref Tree);
        _disposed = true;
    }

    ~DynamicTree() => Dispose(false);
    #endregion
    
    [StructLayout(LayoutKind.Sequential)]
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