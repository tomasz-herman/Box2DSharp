using System.Runtime.InteropServices;
using Box2D.Id;
using Box2D.Types.Shapes;

namespace Box2D;

public unsafe class ChainShape : IDisposable
{
    private readonly ChainId _id;
    private bool _disposed;

    public ChainShape(BodyId bodyId, ref ChainDef def)
    {
        _id = CreateChain(bodyId, ref def);
    }

    /// <summary>
    /// Chain identifier validation. Provides validation for up to 64K allocations.
    /// </summary>
    public bool IsValid()
    {
        return Chain_IsValid(_id);
    }

    /// <summary>
    /// Get the world that owns this chain shape
    /// </summary>
    public WorldId GetWorld()
    {
        return Chain_GetWorld(_id);
    }

    /// <summary>
    /// Get the number of segments on this chain
    /// </summary>
    public int GetSegmentCount()
    {
        return Chain_GetSegmentCount(_id);
    }

    /// <summary>
    /// Fill a user array with chain segment shape ids up to the specified capacity. Returns
    /// the actual number of segments returned.
    /// </summary>
    public int GetSegments(ShapeId* segmentArray, int capacity)
    {
        return Chain_GetSegments(_id, segmentArray, capacity);
    }

    /// <summary>
    /// Set the chain friction
    /// </summary>
    /// <seealso cref="Box2D.Types.Shapes.SurfaceMaterial.Friction"/>
    public void SetFriction(float friction)
    {
        Chain_SetFriction(_id, friction);
    }

    /// <summary>
    /// Get the chain friction
    /// </summary>
    public float GetFriction()
    {
        return Chain_GetFriction(_id);
    }

    /// <summary>
    /// Set the chain restitution (bounciness)
    /// </summary>
    /// <seealso cref="Box2D.Types.Shapes.SurfaceMaterial.Restitution"/>
    public void SetRestitution(float restitution)
    {
        Chain_SetRestitution(_id, restitution);
    }

    /// <summary>
    /// Get the chain restitution
    /// </summary>
    public float GetRestitution()
    {
        return Chain_GetRestitution(_id);
    }

    /// <summary>
    /// Set the chain material
    /// </summary>
    /// <seealso cref="Box2D.Types.Shapes.SurfaceMaterial"/>
    public void SetMaterial(int material)
    {
        Chain_SetMaterial(_id, material);
    }

    /// <summary>
    /// Get the chain material
    /// </summary>
    public int GetMaterial()
    {
        return Chain_GetMaterial(_id);
    }

    #region NativeFunctions

    [DllImport("box2d", EntryPoint = "b2CreateChain")]
    private static extern ChainId CreateChain(BodyId bodyId, ref ChainDef def);

    [DllImport("box2d", EntryPoint = "b2DestroyChain")]
    private static extern void DestroyChain(ChainId chainId);

    [DllImport("box2d", EntryPoint = "b2Chain_GetWorld")]
    private static extern WorldId Chain_GetWorld(ChainId chainId);

    [DllImport("box2d", EntryPoint = "b2Chain_GetSegmentCount")]
    private static extern int Chain_GetSegmentCount(ChainId chainId);

    [DllImport("box2d", EntryPoint = "b2Chain_GetSegments")]
    private static extern int Chain_GetSegments(ChainId chainId, ShapeId* segmentArray, int capacity);

    [DllImport("box2d", EntryPoint = "b2Chain_SetFriction")]
    private static extern void Chain_SetFriction(ChainId chainId, float friction);

    [DllImport("box2d", EntryPoint = "b2Chain_GetFriction")]
    private static extern float Chain_GetFriction(ChainId chainId);

    [DllImport("box2d", EntryPoint = "b2Chain_SetRestitution")]
    private static extern void Chain_SetRestitution(ChainId chainId, float restitution);

    [DllImport("box2d", EntryPoint = "b2Chain_GetRestitution")]
    private static extern float Chain_GetRestitution(ChainId chainId);

    [DllImport("box2d", EntryPoint = "b2Chain_SetMaterial")]
    private static extern void Chain_SetMaterial(ChainId chainId, int material);

    [DllImport("box2d", EntryPoint = "b2Chain_GetMaterial")]
    private static extern int Chain_GetMaterial(ChainId chainId);

    [DllImport("box2d", EntryPoint = "b2Chain_SetSurfaceMaterial")]
    private static extern void Chain_SetSurfaceMaterial(ChainId chainId, ref SurfaceMaterial material, int materialIndex);

    [DllImport("box2d", EntryPoint = "b2Chain_GetSurfaceMaterial")]
    private static extern SurfaceMaterial Chain_GetSurfaceMaterial(ChainId chainId, int materialIndex);

    [DllImport("box2d", EntryPoint = "b2Chain_IsValid")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool Chain_IsValid(ChainId id);

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

        if (IsValid())
        {
            DestroyChain(_id);
        }

        _disposed = true;
    }

    ~ChainShape() => Dispose(false);

    #endregion
}
