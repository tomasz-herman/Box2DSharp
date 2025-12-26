using System.Numerics;
using System.Runtime.InteropServices;
using Box2D.Collision;
using Box2D.Id;
using Box2D.Types;
using Box2D.Types.Callbacks;
using Box2D.Types.Events;
using Box2D.Types.Shapes;

namespace Box2D;

public unsafe partial class World : IDisposable
{
    private readonly WorldId _id;
    public WorldId Id => _id;

    private bool _disposed;

    public World(ref WorldDef worldDef)
    {
        _id = CreateWorld(ref worldDef);
    }

    /// <summary>
    /// World id validation. Provides validation for up to 64K allocations.
    /// </summary>
    public bool IsValid()
    {
        return World_IsValid(_id);
    }

    /// <summary>
    /// Simulate a world for one time step. This performs collision detection, integration, and constraint solution.
    /// </summary>
    /// <param name="timeStep">The amount of time to simulate, this should be a fixed number. Usually 1/60.</param>
    /// <param name="subStepCount">The number of sub-steps, increasing the sub-step count can increase accuracy. Usually 4.</param>
    public void Step(float timeStep = 1.0f / 60.0f, int subStepCount = 4)
    {
        World_Step(_id, timeStep, subStepCount);
    }

    /// <summary>
    /// Call this to draw shapes and other debug draw data
    /// </summary>
    public void Draw(ref DebugDraw draw)
    {
        World_Draw(_id, ref draw);
    }

    /// <summary>
    /// Get the body events for the current time step. The event data is transient. Do not store a reference to this data.
    /// </summary>
    public BodyEvents GetBodyEvents()
    {
        return World_GetBodyEvents(_id);
    }

    /// <summary>
    /// Get sensor events for the current time step. The event data is transient. Do not store a reference to this data.
    /// </summary>
    public SensorEvents GetSensorEvents()
    {
        return World_GetSensorEvents(_id);
    }

    /// <summary>
    /// Get contact events for this current time step. The event data is transient. Do not store a reference to this data.
    /// </summary>
    public ContactEvents GetContactEvents()
    {
        return World_GetContactEvents(_id);
    }

    /// <summary>
    /// Get joint events for the current time step. The event data is transient. Do not store a reference to this data.
    /// </summary>
    public JointEvents GetJointEvents()
    {
        return World_GetJointEvents(_id);
    }

    /// <summary>
    /// Cast a ray into the world to collect shapes in the path of the ray.
    /// Your callback function controls whether you get the closest point, any point, or n-points.
    /// </summary>
    /// <remarks>
    /// Note: The callback function may receive shapes in any order
    /// </remarks>
    /// <param name="origin">The start point of the ray</param>
    /// <param name="translation">The translation of the ray from the start point to the end point</param>
    /// <param name="filter">Contains bit flags to filter unwanted shapes from the results</param>
    /// <param name="fcn">A user implemented callback function</param>
    /// <param name="context">A user context that is passed along to the callback function</param>
    /// <returns>traversal performance counters</returns>
    public TreeStats CastRay(Vector2 origin, Vector2 translation, QueryFilter filter, CastResultFcn fcn, void* context)
    {
        return World_CastRay(_id, origin, translation, filter, fcn, context);
    }

    /// <summary>
    /// Cast a ray into the world to collect the closest hit. This is a convenience function. Ignores initial overlap.
    /// This is less general than b2World_CastRay() and does not allow for custom filtering.
    /// </summary>
    public RayResult CastRayClosest(Vector2 origin, Vector2 translation, QueryFilter filter)
    {
        return World_CastRayClosest(_id, origin, translation, filter);
    }

    /// <summary>
    /// Cast a shape through the world. Similar to a cast ray except that a shape is cast instead of a point.
    /// </summary>
    /// <seealso cref="CastRay"/>
    public TreeStats CastShape(ref ShapeProxy proxy, Vector2 translation, QueryFilter filter, CastResultFcn fcn,
        void* context)
    {
        return World_CastShape(_id, ref proxy, translation, filter, fcn, context);
    }

    /// <summary>
    /// Cast a capsule mover through the world. This is a special shape cast that handles sliding along other shapes while reducing
    /// clipping.
    /// </summary>
    public float CastMover(ref Capsule mover, Vector2 translation,
        QueryFilter filter)
    {
        return World_CastMover(_id, ref mover, translation, filter);
    }

    /// <summary>
    /// Collide a capsule mover with the world, gathering collision planes that can be fed to b2SolvePlanes. Useful for
    /// kinematic character movement.
    /// </summary>
    public void CollideMover(ref Capsule mover, QueryFilter filter, PlaneResultFcn fcn, void* context)
    {
        World_CollideMover(_id, ref mover, filter, fcn, context);
    }

    /// <summary>
    /// Enable/disable sleep. If your application does not need sleeping, you can gain some performance
    /// by disabling sleep completely at the world level.
    /// </summary>
    /// <seealso cref="WorldDef"/>
    public void EnableSleeping(bool flag)
    {
        World_EnableSleeping(_id, flag);
    }

    /// <summary>
    /// Is body sleeping enabled?
    /// </summary>
    public bool IsSleepingEnabled()
    {
        return World_IsSleepingEnabled(_id);
    }

    /// <summary>
    /// Enable/disable continuous collision between dynamic and static bodies. Generally you should keep continuous
    /// collision enabled to prevent fast moving objects from going through static objects. The performance gain from
    /// disabling continuous collision is minor.
    /// </summary>
    /// <seealso cref="WorldDef"/>
    public void EnableContinuous(bool flag)
    {
        World_EnableContinuous(_id, flag);
    }

    /// <summary>
    /// Is continuous collision enabled?
    /// </summary>
    public bool IsContinuousEnabled()
    {
        return World_IsContinuousEnabled(_id);
    }

    /// <summary>
    /// Adjust the restitution threshold. It is recommended not to make this value very small
    /// because it will prevent bodies from sleeping. Usually in meters per second.
    /// </summary>
    /// <seealso cref="WorldDef"/>
    public void SetRestitutionThreshold(float value)
    {
        World_SetRestitutionThreshold(_id, value);
    }

    /// <summary>
    /// Get the the restitution speed threshold. Usually in meters per second.
    /// </summary>
    public float GetRestitutionThreshold()
    {
        return World_GetRestitutionThreshold(_id);
    }

    /// <summary>
    /// Adjust the hit event threshold. This controls the collision speed needed to generate a b2ContactHitEvent.
    /// Usually in meters per second.
    /// </summary>
    /// <seealso cref="WorldDef.HitEventThreshold"/>
    public void SetHitEventThreshold(float value)
    {
        World_SetHitEventThreshold(_id, value);
    }

    /// <summary>
    /// Get the the hit event speed threshold. Usually in meters per second.
    /// </summary>
    public float GetHitEventThreshold()
    {
        return World_GetHitEventThreshold(_id);
    }

    /// <summary>
    /// Register the custom filter callback. This is optional.
    /// </summary>
    public void SetCustomFilterCallback(CustomFilterFcn fcn, void* context)
    {
        World_SetCustomFilterCallback(_id, fcn, context);
    }

    /// <summary>
    /// Register the pre-solve callback. This is optional.
    /// </summary>
    public void SetPreSolveCallback(PreSolveFcn fcn, void* context)
    {
        World_SetPreSolveCallback(_id, fcn, context);
    }

    /// <summary>
    /// Set the gravity vector for the entire world. Box2D has no concept of an up direction and this
    /// is left as a decision for the application. Usually in m/s^2.
    /// </summary>
    /// <seealso cref="WorldDef"/>
    public void SetGravity(Vector2 gravity)
    {
        World_SetGravity(_id, gravity);
    }

    /// <summary>
    /// Get the gravity vector
    /// </summary>
    public Vector2 GetGravity()
    {
        return World_GetGravity(_id);
    }

    /// <summary>
    /// Apply a radial explosion
    /// </summary>
    /// <param name="explosionDef">The explosion definition</param>
    public void Explode(ref ExplosionDef explosionDef)
    {
        World_Explode(_id, ref explosionDef);
    }

    /// <summary>
    /// Adjust contact tuning parameters
    /// </summary>
    /// <param name="hertz">The contact stiffness (cycles per second)</param>
    /// <param name="dampingRatio">The contact bounciness with 1 being critical damping (non-dimensional)</param>
    /// <param name="maxContactPushSpeed">The maximum contact constraint push out speed (meters per second)</param>
    /// <remarks>
    /// Note: Advanced feature
    /// </remarks>
    public void SetContactTuning(float hertz, float dampingRatio, float maxContactPushSpeed)
    {
        World_SetContactTuning(_id, hertz, dampingRatio, maxContactPushSpeed);
    }

    /// <summary>
    /// Set the maximum linear speed. Usually in m/s.
    /// </summary>
    public void SetMaximumLinearSpeed(float maximumLinearSpeed)
    {
        World_SetMaximumLinearSpeed(_id, maximumLinearSpeed);
    }

    /// <summary>
    /// Get the maximum linear speed. Usually in m/s.
    /// </summary>
    public float GetMaximumLinearSpeed()
    {
        return World_GetMaximumLinearSpeed(_id);
    }

    /// <summary>
    /// Enable/disable constraint warm starting. Advanced feature for testing. Disabling
    /// warm starting greatly reduces stability and provides no performance gain.
    /// </summary>
    public void EnableWarmStarting(bool flag)
    {
        World_EnableWarmStarting(_id, flag);
    }

    /// <summary>
    /// Is constraint warm starting enabled?
    /// </summary>
    public bool IsWarmStartingEnabled()
    {
        return World_IsWarmStartingEnabled(_id);
    }

    /// <summary>
    /// Get the number of awake bodies.
    /// </summary>
    public int GetAwakeBodyCount()
    {
        return World_GetAwakeBodyCount(_id);
    }

    /// <summary>
    /// Get the current world performance profile
    /// </summary>
    public Profile GetProfile()
    {
        return World_GetProfile(_id);
    }

    /// <summary>
    /// Get world counters and sizes
    /// </summary>
    public Counters GetCounters()
    {
        return World_GetCounters(_id);
    }

    /// <summary>
    /// Set the user data pointer.
    /// </summary>
    public void SetUserData(void* userData)
    {
        World_SetUserData(_id, userData);
    }

    /// <summary>
    /// Get the user data pointer.
    /// </summary>
    public void* GetUserData()
    {
        return World_GetUserData(_id);
    }

    /// <summary>
    /// Set the friction callback. Passing NULL resets to default.
    /// </summary>
    public void SetFrictionCallback(FrictionCallback callback)
    {
        World_SetFrictionCallback(_id, callback);
    }

    /// <summary>
    /// Set the restitution callback. Passing NULL resets to default.
    /// </summary>
    public void SetRestitutionCallback(RestitutionCallback callback)
    {
        World_SetRestitutionCallback(_id, callback);
    }

    /// <summary>
    /// Dump memory stats to box2d_memory.txt
    /// </summary>
    public void DumpMemoryStats()
    {
        World_DumpMemoryStats(_id);
    }

    /// <summary>
    /// This is for internal testing
    /// </summary>
    public void RebuildStaticTree()
    {
        World_RebuildStaticTree(_id);
    }

    /// <summary>
    /// This is for internal testing
    /// </summary>
    public void EnableSpeculative(bool flag)
    {
        World_EnableSpeculative(_id, flag);
    }

    #region NativeFunctions

    [LibraryImport("box2d", EntryPoint = "b2CreateWorld")]
    private static partial WorldId CreateWorld(ref WorldDef def);

    [LibraryImport("box2d", EntryPoint = "b2DestroyWorld")]
    private static partial void DestroyWorld(WorldId id);

    [LibraryImport("box2d", EntryPoint = "b2World_IsValid")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static partial bool World_IsValid(WorldId id);

    [LibraryImport("box2d", EntryPoint = "b2World_Step")]
    private static partial void World_Step(WorldId id, float timeStep, int subStepCount);

    [LibraryImport("box2d", EntryPoint = "b2World_Step")]
    private static partial void World_Draw(WorldId id, ref DebugDraw draw);

    [LibraryImport("box2d", EntryPoint = "b2World_GetBodyEvents")]
    private static partial BodyEvents World_GetBodyEvents(WorldId id);

    [LibraryImport("box2d", EntryPoint = "b2World_GetSensorEvents")]
    private static partial SensorEvents World_GetSensorEvents(WorldId id);

    [LibraryImport("box2d", EntryPoint = "b2World_GetContactEvents")]
    private static partial ContactEvents World_GetContactEvents(WorldId id);

    [LibraryImport("box2d", EntryPoint = "b2World_GetJointEvents")]
    private static partial JointEvents World_GetJointEvents(WorldId id);

    [LibraryImport("box2d", EntryPoint = "b2World_CastRay")]
    private static partial TreeStats World_CastRay(WorldId worldId, Vector2 origin, Vector2 translation,
        QueryFilter filter,
        CastResultFcn fcn, void* context);

    [LibraryImport("box2d", EntryPoint = "b2World_CastRayClosest")]
    private static partial RayResult World_CastRayClosest(WorldId worldId, Vector2 origin, Vector2 translation, QueryFilter filter);

    [LibraryImport("box2d", EntryPoint = "b2World_CastShape")]
    private static partial TreeStats World_CastShape(WorldId worldId, ref ShapeProxy proxy, Vector2 translation, QueryFilter filter, CastResultFcn fcn, void* context);

    [LibraryImport("box2d", EntryPoint = "b2World_CastMover")]
    private static partial float World_CastMover(WorldId worldId, ref Capsule mover, Vector2 translation, QueryFilter filter);

    [LibraryImport("box2d", EntryPoint = "b2World_CollideMover")]
    private static partial void World_CollideMover(WorldId worldId, ref Capsule mover, QueryFilter filter, PlaneResultFcn fcn, void* context);

    [LibraryImport("box2d", EntryPoint = "b2World_EnableSleeping")]
    private static partial void World_EnableSleeping(WorldId worldId, [MarshalAs(UnmanagedType.U1)] bool flag);

    [LibraryImport("box2d", EntryPoint = "b2World_IsSleepingEnabled")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static partial bool World_IsSleepingEnabled(WorldId worldId);

    [LibraryImport("box2d", EntryPoint = "b2World_EnableContinuous")]
    private static partial void World_EnableContinuous(WorldId worldId, [MarshalAs(UnmanagedType.U1)] bool flag);

    [LibraryImport("box2d", EntryPoint = "b2World_IsContinuousEnabled")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static partial bool World_IsContinuousEnabled(WorldId worldId);

    [LibraryImport("box2d", EntryPoint = "b2World_SetRestitutionThreshold")]
    private static partial void World_SetRestitutionThreshold(WorldId worldId, float value);

    [LibraryImport("box2d", EntryPoint = "b2World_GetRestitutionThreshold")]
    private static partial float World_GetRestitutionThreshold(WorldId worldId);

    [LibraryImport("box2d", EntryPoint = "b2World_SetHitEventThreshold")]
    private static partial void World_SetHitEventThreshold(WorldId worldId, float value);

    [LibraryImport("box2d", EntryPoint = "b2World_GetHitEventThreshold")]
    private static partial float World_GetHitEventThreshold(WorldId worldId);

    [LibraryImport("box2d", EntryPoint = "b2World_SetCustomFilterCallback")]
    private static partial void World_SetCustomFilterCallback(WorldId worldId, CustomFilterFcn fcn, void* context);

    [LibraryImport("box2d", EntryPoint = "b2World_SetPreSolveCallback")]
    private static partial void World_SetPreSolveCallback(WorldId worldId, PreSolveFcn fcn, void* context);

    [LibraryImport("box2d", EntryPoint = "b2World_SetGravity")]
    private static partial void World_SetGravity(WorldId worldId, Vector2 gravity);

    [LibraryImport("box2d", EntryPoint = "b2World_GetGravity")]
    private static partial Vector2 World_GetGravity(WorldId worldId);

    [LibraryImport("box2d", EntryPoint = "b2World_Explode")]
    private static partial void World_Explode(WorldId worldId, ref ExplosionDef explosionDef);

    [LibraryImport("box2d", EntryPoint = "b2World_SetContactTuning")]
    private static partial void World_SetContactTuning(WorldId worldId, float hertz, float dampingRatio,
        float pushSpeed);

    [LibraryImport("box2d", EntryPoint = "b2World_SetMaximumLinearSpeed")]
    private static partial void World_SetMaximumLinearSpeed(WorldId worldId, float maximumLinearSpeed);

    [LibraryImport("box2d", EntryPoint = "b2World_GetMaximumLinearSpeed")]
    private static partial float World_GetMaximumLinearSpeed(WorldId worldId);

    [LibraryImport("box2d", EntryPoint = "b2World_EnableWarmStarting")]
    private static partial void World_EnableWarmStarting(WorldId worldId, [MarshalAs(UnmanagedType.U1)] bool flag);

    [LibraryImport("box2d", EntryPoint = "b2World_IsWarmStartingEnabled")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static partial bool World_IsWarmStartingEnabled(WorldId worldId);

    [LibraryImport("box2d", EntryPoint = "b2World_GetAwakeBodyCount")]
    private static partial int World_GetAwakeBodyCount(WorldId worldId);

    [LibraryImport("box2d", EntryPoint = "b2World_GetProfile")]
    private static partial Profile World_GetProfile(WorldId worldId);

    [LibraryImport("box2d", EntryPoint = "b2World_GetCounters")]
    private static partial Counters World_GetCounters(WorldId worldId);

    [LibraryImport("box2d", EntryPoint = "b2World_SetUserData")]
    private static partial void World_SetUserData(WorldId worldId, void* userData);

    [LibraryImport("box2d", EntryPoint = "b2World_GetUserData")]
    private static partial void* World_GetUserData(WorldId worldId);

    [LibraryImport("box2d", EntryPoint = "b2World_SetFrictionCallback")]
    private static partial void World_SetFrictionCallback(WorldId worldId, FrictionCallback callback);

    [LibraryImport("box2d", EntryPoint = "b2World_SetRestitutionCallback")]
    private static partial void World_SetRestitutionCallback(WorldId worldId, RestitutionCallback callback);

    [LibraryImport("box2d", EntryPoint = "b2World_DumpMemoryStats")]
    private static partial void World_DumpMemoryStats(WorldId worldId);

    [LibraryImport("box2d", EntryPoint = "b2World_RebuildStaticTree")]
    private static partial void World_RebuildStaticTree(WorldId worldId);

    [LibraryImport("box2d", EntryPoint = "b2World_EnableSpeculative")]
    private static partial void World_EnableSpeculative(WorldId worldId, [MarshalAs(UnmanagedType.U1)] bool flag);

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
            DestroyWorld(_id);
        }

        _disposed = true;
    }

    ~World() => Dispose(false);

    #endregion
}