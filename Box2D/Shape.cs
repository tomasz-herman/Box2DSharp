using System.Numerics;
using System.Runtime.InteropServices;
using Box2D.Collision;
using Box2D.Id;
using Box2D.Types;
using Box2D.Types.Shapes;
using Box2D.Math;

namespace Box2D;

public unsafe partial class Shape : IDisposable
{
    private readonly ShapeId _id;
    private bool _disposed;

    // Constructors for creating different shape types
    public Shape(BodyId bodyId, ref ShapeDef def, ref Circle circle)
    {
        _id = CreateCircleShape(bodyId, ref def, ref circle);
    }

    public Shape(BodyId bodyId, ref ShapeDef def, ref Segment segment)
    {
        _id = CreateSegmentShape(bodyId, ref def, ref segment);
    }

    public Shape(BodyId bodyId, ref ShapeDef def, ref Capsule capsule)
    {
        _id = CreateCapsuleShape(bodyId, ref def, ref capsule);
    }

    public Shape(BodyId bodyId, ref ShapeDef def, ref Polygon polygon)
    {
        _id = CreatePolygonShape(bodyId, ref def, ref polygon);
    }

    // Constructor for existing shape (e.g. from events)
    public Shape(ShapeId id)
    {
        _id = id;
    }

    /// <summary>
    /// Shape identifier validation. Provides validation for up to 64K allocations.
    /// </summary>
    public bool IsValid()
    {
        return Shape_IsValid(_id);
    }

    /// <summary>
    /// Get the type of a shape
    /// </summary>
    public new ShapeType GetType()
    {
        return Shape_GetType(_id);
    }

    /// <summary>
    /// Get the id of the body that a shape is attached to
    /// </summary>
    public BodyId GetBody()
    {
        return Shape_GetBody(_id);
    }

    /// <summary>
    /// Get the world that owns this shape
    /// </summary>
    public WorldId GetWorld()
    {
        return Shape_GetWorld(_id);
    }

    /// <summary>
    /// Returns true if the shape is a sensor. It is not possible to change a shape
    /// from sensor to solid dynamically because this breaks the contract for
    /// sensor events.
    /// </summary>
    public bool IsSensor()
    {
        return Shape_IsSensor(_id);
    }

    /// <summary>
    /// Set the user data for a shape
    /// </summary>
    public void SetUserData(void* userData)
    {
        Shape_SetUserData(_id, userData);
    }

    /// <summary>
    /// Get the user data for a shape. This is useful when you get a shape id
    /// from an event or query.
    /// </summary>
    public void* GetUserData()
    {
        return Shape_GetUserData(_id);
    }

    /// <summary>
    /// Set the mass density of a shape, usually in kg/m^2.
    /// This will optionally update the mass properties on the parent body.
    /// </summary>
    /// <seealso cref="Box2D.Types.Shapes.ShapeDef.Density"/>
    /// <seealso cref="Box2D.Body.ApplyMassFromShapes"/>
    public void SetDensity(float density, bool updateBodyMass)
    {
        Shape_SetDensity(_id, density, updateBodyMass);
    }

    /// <summary>
    /// Get the density of a shape, usually in kg/m^2
    /// </summary>
    public float GetDensity()
    {
        return Shape_GetDensity(_id);
    }

    /// <summary>
    /// Set the friction on a shape
    /// </summary>
    /// <seealso cref="Box2D.Types.Shapes.SurfaceMaterial.Friction"/>
    public void SetFriction(float friction)
    {
        Shape_SetFriction(_id, friction);
    }

    /// <summary>
    /// Get the friction of a shape
    /// </summary>
    public float GetFriction()
    {
        return Shape_GetFriction(_id);
    }

    /// <summary>
    /// Set the shape restitution (bounciness)
    /// </summary>
    /// <seealso cref="Box2D.Types.Shapes.SurfaceMaterial.Restitution"/>
    public void SetRestitution(float restitution)
    {
        Shape_SetRestitution(_id, restitution);
    }

    /// <summary>
    /// Get the shape restitution
    /// </summary>
    public float GetRestitution()
    {
        return Shape_GetRestitution(_id);
    }

    /// <summary>
    /// Set the shape material identifier
    /// </summary>
    /// <seealso cref="Box2D.Types.Shapes.ShapeDef.Material"/>
    public void SetUserMaterial(ulong material)
    {
        Shape_SetUserMaterial(_id, material);
    }

    /// <summary>
    /// Get the shape material identifier
    /// </summary>
    public ulong GetUserMaterial()
    {
        return Shape_GetUserMaterial(_id);
    }

    /// <summary>
    /// Set the shape surface material
    /// </summary>
    public void SetSurfaceMaterial(ref SurfaceMaterial surfaceMaterial)
    {
        Shape_SetSurfaceMaterial(_id, ref surfaceMaterial);
    }

    /// <summary>
    /// Get the shape surface material
    /// </summary>
    public SurfaceMaterial GetSurfaceMaterial()
    {
        return Shape_GetSurfaceMaterial(_id);
    }

    /// <summary>
    /// Get the shape filter
    /// </summary>
    public Filter GetFilter()
    {
        return Shape_GetFilter(_id);
    }

    /// <summary>
    /// Set the current filter. This is almost as expensive as recreating the shape. This may cause
    /// contacts to be immediately destroyed. However contacts are not created until the next world step.
    /// Sensor overlap state is also not updated until the next world step.
    /// </summary>
    /// <seealso cref="Box2D.Types.Shapes.ShapeDef.Filter"/>
    public void SetFilter(Filter filter)
    {
        Shape_SetFilter(_id, filter);
    }

    /// <summary>
    /// Enable sensor events for this shape.
    /// </summary>
    /// <seealso cref="Box2D.Types.Shapes.ShapeDef.EnableSensorEvents"/>
    public void EnableSensorEvents(bool flag)
    {
        Shape_EnableSensorEvents(_id, flag);
    }

    /// <summary>
    /// Returns true if sensor events are enabled.
    /// </summary>
    public bool AreSensorEventsEnabled()
    {
        return Shape_AreSensorEventsEnabled(_id);
    }

    /// <summary>
    /// Enable contact events for this shape. Only applies to kinematic and dynamic bodies. Ignored for sensors.
    /// </summary>
    /// <seealso cref="Box2D.Types.Shapes.ShapeDef.EnableContactEvents"/>
    /// <remarks>
    /// Warning: changing this at run-time may lead to lost begin/end events
    /// </remarks>
    public void EnableContactEvents(bool flag)
    {
        Shape_EnableContactEvents(_id, flag);
    }

    /// <summary>
    /// Returns true if contact events are enabled
    /// </summary>
    public bool AreContactEventsEnabled()
    {
        return Shape_AreContactEventsEnabled(_id);
    }

    /// <summary>
    /// Enable pre-solve contact events for this shape. Only applies to dynamic bodies. These are expensive
    /// and must be carefully handled due to multithreading. Ignored for sensors.
    /// </summary>
    /// <seealso cref="Box2D.Types.Callbacks.PreSolveFcn"/>
    public void EnablePreSolveEvents(bool flag)
    {
        Shape_EnablePreSolveEvents(_id, flag);
    }

    /// <summary>
    /// Returns true if pre-solve events are enabled
    /// </summary>
    public bool ArePreSolveEventsEnabled()
    {
        return Shape_ArePreSolveEventsEnabled(_id);
    }

    /// <summary>
    /// Enable contact hit events for this shape. Ignored for sensors.
    /// </summary>
    /// <seealso cref="Box2D.Types.WorldDef.HitEventThreshold"/>
    public void EnableHitEvents(bool flag)
    {
        Shape_EnableHitEvents(_id, flag);
    }

    /// <summary>
    /// Returns true if hit events are enabled
    /// </summary>
    public bool AreHitEventsEnabled()
    {
        return Shape_AreHitEventsEnabled(_id);
    }

    /// <summary>
    /// Test a point for overlap with a shape
    /// </summary>
    public bool TestPoint(Vector2 point)
    {
        return Shape_TestPoint(_id, point);
    }

    /// <summary>
    /// Ray cast a shape directly
    /// </summary>
    public CastOutput RayCast(ref RayCastInput input)
    {
        return Shape_RayCast(_id, ref input);
    }

    /// <summary>
    /// Get a copy of the shape's circle. Asserts the type is correct.
    /// </summary>
    public Circle GetCircle()
    {
        return Shape_GetCircle(_id);
    }

    /// <summary>
    /// Get a copy of the shape's line segment. Asserts the type is correct.
    /// </summary>
    public Segment GetSegment()
    {
        return Shape_GetSegment(_id);
    }

    /// <summary>
    /// Get a copy of the shape's chain segment. These come from chain shapes.
    /// Asserts the type is correct.
    /// </summary>
    public ChainSegment GetChainSegment()
    {
        return Shape_GetChainSegment(_id);
    }

    /// <summary>
    /// Get a copy of the shape's capsule. Asserts the type is correct.
    /// </summary>
    public Capsule GetCapsule()
    {
        return Shape_GetCapsule(_id);
    }

    /// <summary>
    /// Get a copy of the shape's convex polygon. Asserts the type is correct.
    /// </summary>
    public Polygon GetPolygon()
    {
        return Shape_GetPolygon(_id);
    }

    /// <summary>
    /// Allows you to change a shape to be a circle or update the current circle.
    /// This does not modify the mass properties.
    /// </summary>
    /// <seealso cref="Box2D.Body.ApplyMassFromShapes"/>
    public void SetCircle(ref Circle circle)
    {
        Shape_SetCircle(_id, ref circle);
    }

    /// <summary>
    /// Allows you to change a shape to be a capsule or update the current capsule.
    /// This does not modify the mass properties.
    /// </summary>
    /// <seealso cref="Box2D.Body.ApplyMassFromShapes"/>
    public void SetCapsule(ref Capsule capsule)
    {
        Shape_SetCapsule(_id, ref capsule);
    }

    /// <summary>
    /// Allows you to change a shape to be a segment or update the current segment.
    /// </summary>
    public void SetSegment(ref Segment segment)
    {
        Shape_SetSegment(_id, ref segment);
    }

    /// <summary>
    /// Allows you to change a shape to be a polygon or update the current polygon.
    /// This does not modify the mass properties.
    /// </summary>
    /// <seealso cref="Box2D.Body.ApplyMassFromShapes"/>
    public void SetPolygon(ref Polygon polygon)
    {
        Shape_SetPolygon(_id, ref polygon);
    }

    /// <summary>
    /// Get the parent chain id if the shape type is a chain segment, otherwise
    /// returns b2_nullChainId.
    /// </summary>
    public ChainId GetParentChain()
    {
        return Shape_GetParentChain(_id);
    }

    /// <summary>
    /// Get the maximum capacity required for retrieving all the touching contacts on a shape
    /// </summary>
    public int GetContactCapacity()
    {
        return Shape_GetContactCapacity(_id);
    }

    /// <summary>
    /// Get the touching contact data for a shape. The provided shapeId will be either shapeIdA or shapeIdB on the contact data.
    /// </summary>
    /// <remarks>
    /// Note: Box2D uses speculative collision so some contact points may be separated.
    /// Warning: do not ignore the return value, it specifies the valid number of elements
    /// </remarks>
    /// <returns>the number of elements filled in the provided array</returns>
    public int GetContactData(ContactData* contactData, int capacity)
    {
        return Shape_GetContactData(_id, contactData, capacity);
    }

    /// <summary>
    /// Get the maximum capacity required for retrieving all the overlapped shapes on a sensor shape.
    /// This returns 0 if the provided shape is not a sensor.
    /// </summary>
    /// <returns>the required capacity to get all the overlaps in b2Shape_GetSensorOverlaps</returns>
    /// <summary>
    /// Set the shape material identifier
    /// </summary>
    /// <seealso cref="Box2D.Types.Shapes.ShapeDef.Material"/>
    public void SetMaterial(int material)
    {
        Shape_SetMaterial(_id, material);
    }

    /// <summary>
    /// Get the shape material identifier
    /// </summary>
    public int GetMaterial()
    {
        return Shape_GetMaterial(_id);
    }

    public int GetSensorCapacity()
    {
        return Shape_GetSensorCapacity(_id);
    }

    /// <summary>
    /// Get the overlapped shapes for a sensor shape.
    /// </summary>
    /// <param name="visitorIds">a user allocated array that is filled with the overlapping shapes</param>
    /// <param name="capacity">the capacity of overlappedShapes</param>
    /// <returns>the number of elements filled in the provided array</returns>
    /// <remarks>
    /// Warning: do not ignore the return value, it specifies the valid number of elements
    /// Warning: overlaps may contain destroyed shapes so use b2Shape_IsValid to confirm each overlap
    /// </remarks>
    public int GetSensorOverlaps(ShapeId* visitorIds, int capacity)
    {
        return Shape_GetSensorOverlaps(_id, visitorIds, capacity);
    }

    /// <summary>
    /// Get the current world AABB
    /// </summary>
    public Aabb GetAabb()
    {
        return Shape_GetAabb(_id);
    }

    /// <summary>
    /// Get the mass data for a shape
    /// </summary>
    public MassData GetMassData()
    {
        return Shape_GetMassData(_id);
    }

    /// <summary>
    /// Get the closest point on a shape to a target point. Target and result are in world space.
    /// </summary>
    public Vector2 GetClosestPoint(Vector2 target)
    {
        return Shape_GetClosestPoint(_id, target);
    }

    public void ApplyWind(Vector2 wind, float drag, float lift, bool wake)
    {
        Shape_ApplyWind(_id, wind, drag, lift, wake);
    }

    #region NativeFunctions

    [LibraryImport("box2d", EntryPoint = "b2CreateCircleShape")]
    private static partial ShapeId CreateCircleShape(BodyId bodyId, ref ShapeDef def, ref Circle circle);

    [LibraryImport("box2d", EntryPoint = "b2CreateSegmentShape")]
    private static partial ShapeId CreateSegmentShape(BodyId bodyId, ref ShapeDef def, ref Segment segment);

    [LibraryImport("box2d", EntryPoint = "b2CreateCapsuleShape")]
    private static partial ShapeId CreateCapsuleShape(BodyId bodyId, ref ShapeDef def, ref Capsule capsule);

    [LibraryImport("box2d", EntryPoint = "b2CreatePolygonShape")]
    private static partial ShapeId CreatePolygonShape(BodyId bodyId, ref ShapeDef def, ref Polygon polygon);

    [LibraryImport("box2d", EntryPoint = "b2DestroyShape")]
    private static partial void DestroyShape(ShapeId shapeId, [MarshalAs(UnmanagedType.U1)] bool updateBodyMass);

    [LibraryImport("box2d", EntryPoint = "b2Shape_IsValid")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static partial bool Shape_IsValid(ShapeId id);

    [LibraryImport("box2d", EntryPoint = "b2Shape_GetType")]
    private static partial ShapeType Shape_GetType(ShapeId shapeId);

    [LibraryImport("box2d", EntryPoint = "b2Shape_GetBody")]
    private static partial BodyId Shape_GetBody(ShapeId shapeId);

    [LibraryImport("box2d", EntryPoint = "b2Shape_GetWorld")]
    private static partial WorldId Shape_GetWorld(ShapeId shapeId);

    [LibraryImport("box2d", EntryPoint = "b2Shape_IsSensor")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static partial bool Shape_IsSensor(ShapeId shapeId);

    [LibraryImport("box2d", EntryPoint = "b2Shape_SetUserData")]
    private static partial void Shape_SetUserData(ShapeId shapeId, void* userData);

    [LibraryImport("box2d", EntryPoint = "b2Shape_GetUserData")]
    private static partial void* Shape_GetUserData(ShapeId shapeId);

    [LibraryImport("box2d", EntryPoint = "b2Shape_SetDensity")]
    private static partial void Shape_SetDensity(ShapeId shapeId, float density, [MarshalAs(UnmanagedType.U1)] bool updateBodyMass);

    [LibraryImport("box2d", EntryPoint = "b2Shape_GetDensity")]
    private static partial float Shape_GetDensity(ShapeId shapeId);

    [LibraryImport("box2d", EntryPoint = "b2Shape_SetFriction")]
    private static partial void Shape_SetFriction(ShapeId shapeId, float friction);

    [LibraryImport("box2d", EntryPoint = "b2Shape_GetFriction")]
    private static partial float Shape_GetFriction(ShapeId shapeId);

    [LibraryImport("box2d", EntryPoint = "b2Shape_SetRestitution")]
    private static partial void Shape_SetRestitution(ShapeId shapeId, float restitution);

    [LibraryImport("box2d", EntryPoint = "b2Shape_GetRestitution")]
    private static partial float Shape_GetRestitution(ShapeId shapeId);

    [LibraryImport("box2d", EntryPoint = "b2Shape_SetMaterial")]
    private static partial void Shape_SetMaterial(ShapeId shapeId, int material);

    [LibraryImport("box2d", EntryPoint = "b2Shape_GetMaterial")]
    private static partial int Shape_GetMaterial(ShapeId shapeId);

    [LibraryImport("box2d", EntryPoint = "b2Shape_SetUserMaterial")]
    private static partial void Shape_SetUserMaterial(ShapeId shapeId, ulong material);

    [LibraryImport("box2d", EntryPoint = "b2Shape_GetUserMaterial")]
    private static partial ulong Shape_GetUserMaterial(ShapeId shapeId);

    [LibraryImport("box2d", EntryPoint = "b2Shape_SetSurfaceMaterial")]
    private static partial void Shape_SetSurfaceMaterial(ShapeId shapeId, ref SurfaceMaterial surfaceMaterial);

    [LibraryImport("box2d", EntryPoint = "b2Shape_GetSurfaceMaterial")]
    private static partial SurfaceMaterial Shape_GetSurfaceMaterial(ShapeId shapeId);

    [LibraryImport("box2d", EntryPoint = "b2Shape_GetFilter")]
    private static partial Filter Shape_GetFilter(ShapeId shapeId);

    [LibraryImport("box2d", EntryPoint = "b2Shape_SetFilter")]
    private static partial void Shape_SetFilter(ShapeId shapeId, Filter filter);

    [LibraryImport("box2d", EntryPoint = "b2Shape_EnableSensorEvents")]
    private static partial void Shape_EnableSensorEvents(ShapeId shapeId, [MarshalAs(UnmanagedType.U1)] bool flag);

    [LibraryImport("box2d", EntryPoint = "b2Shape_AreSensorEventsEnabled")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static partial bool Shape_AreSensorEventsEnabled(ShapeId shapeId);

    [LibraryImport("box2d", EntryPoint = "b2Shape_EnableContactEvents")]
    private static partial void Shape_EnableContactEvents(ShapeId shapeId, [MarshalAs(UnmanagedType.U1)] bool flag);

    [LibraryImport("box2d", EntryPoint = "b2Shape_AreContactEventsEnabled")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static partial bool Shape_AreContactEventsEnabled(ShapeId shapeId);

    [LibraryImport("box2d", EntryPoint = "b2Shape_EnablePreSolveEvents")]
    private static partial void Shape_EnablePreSolveEvents(ShapeId shapeId, [MarshalAs(UnmanagedType.U1)] bool flag);

    [LibraryImport("box2d", EntryPoint = "b2Shape_ArePreSolveEventsEnabled")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static partial bool Shape_ArePreSolveEventsEnabled(ShapeId shapeId);

    [LibraryImport("box2d", EntryPoint = "b2Shape_EnableHitEvents")]
    private static partial void Shape_EnableHitEvents(ShapeId shapeId, [MarshalAs(UnmanagedType.U1)] bool flag);

    [LibraryImport("box2d", EntryPoint = "b2Shape_AreHitEventsEnabled")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static partial bool Shape_AreHitEventsEnabled(ShapeId shapeId);

    [LibraryImport("box2d", EntryPoint = "b2Shape_TestPoint")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static partial bool Shape_TestPoint(ShapeId shapeId, Vector2 point);

    [LibraryImport("box2d", EntryPoint = "b2Shape_RayCast")]
    private static partial CastOutput Shape_RayCast(ShapeId shapeId, ref RayCastInput input);

    [LibraryImport("box2d", EntryPoint = "b2Shape_GetCircle")]
    private static partial Circle Shape_GetCircle(ShapeId shapeId);

    [LibraryImport("box2d", EntryPoint = "b2Shape_GetSegment")]
    private static partial Segment Shape_GetSegment(ShapeId shapeId);

    [LibraryImport("box2d", EntryPoint = "b2Shape_GetChainSegment")]
    private static partial ChainSegment Shape_GetChainSegment(ShapeId shapeId);

    [LibraryImport("box2d", EntryPoint = "b2Shape_GetCapsule")]
    private static partial Capsule Shape_GetCapsule(ShapeId shapeId);

    [LibraryImport("box2d", EntryPoint = "b2Shape_GetPolygon")]
    private static partial Polygon Shape_GetPolygon(ShapeId shapeId);

    [LibraryImport("box2d", EntryPoint = "b2Shape_SetCircle")]
    private static partial void Shape_SetCircle(ShapeId shapeId, ref Circle circle);

    [LibraryImport("box2d", EntryPoint = "b2Shape_SetCapsule")]
    private static partial void Shape_SetCapsule(ShapeId shapeId, ref Capsule capsule);

    [LibraryImport("box2d", EntryPoint = "b2Shape_SetSegment")]
    private static partial void Shape_SetSegment(ShapeId shapeId, ref Segment segment);

    [LibraryImport("box2d", EntryPoint = "b2Shape_SetPolygon")]
    private static partial void Shape_SetPolygon(ShapeId shapeId, ref Polygon polygon);

    [LibraryImport("box2d", EntryPoint = "b2Shape_GetParentChain")]
    private static partial ChainId Shape_GetParentChain(ShapeId shapeId);

    [LibraryImport("box2d", EntryPoint = "b2Shape_GetContactCapacity")]
    private static partial int Shape_GetContactCapacity(ShapeId shapeId);

    [LibraryImport("box2d", EntryPoint = "b2Shape_GetContactData")]
    private static partial int Shape_GetContactData(ShapeId shapeId, ContactData* contactData, int capacity);

    [LibraryImport("box2d", EntryPoint = "b2Shape_GetSensorCapacity")]
    private static partial int Shape_GetSensorCapacity(ShapeId shapeId);

    [LibraryImport("box2d", EntryPoint = "b2Shape_GetSensorOverlaps")]
    private static partial int Shape_GetSensorOverlaps(ShapeId shapeId, ShapeId* visitorIds, int capacity);

    [LibraryImport("box2d", EntryPoint = "b2Shape_GetAABB")]
    private static partial Aabb Shape_GetAabb(ShapeId shapeId);

    [LibraryImport("box2d", EntryPoint = "b2Shape_GetMassData")]
    private static partial MassData Shape_GetMassData(ShapeId shapeId);

    [LibraryImport("box2d", EntryPoint = "b2Shape_GetClosestPoint")]
    private static partial Vector2 Shape_GetClosestPoint(ShapeId shapeId, Vector2 target);

    [LibraryImport("box2d", EntryPoint = "b2Shape_ApplyWind")]
    private static partial void Shape_ApplyWind(ShapeId shapeId, Vector2 wind, float drag, float lift, [MarshalAs(UnmanagedType.U1)] bool wake);

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
            DestroyShape(_id, false);
        }

        _disposed = true;
    }

    ~Shape() => Dispose(false);

    public void Destroy(bool updateBodyMass = true)
    {
        if (_disposed) return;
        if (IsValid())
        {
            DestroyShape(_id, updateBodyMass);
        }
        _disposed = true;
        GC.SuppressFinalize(this);
    }

    #endregion
}
