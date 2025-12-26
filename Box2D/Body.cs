using System.Numerics;
using System.Runtime.InteropServices;
using Box2D.Collision;
using Box2D.Id;
using Box2D.Math;
using Box2D.Types;
using Box2D.Types.Bodies;

namespace Box2D;

public unsafe class Body
{
    private readonly BodyId _id;
    public BodyId Id => _id;

    private bool _disposed;

    public Body(WorldId worldId, ref BodyDef def)
    {
        _id = CreateBody(worldId, ref def);
    }

    private void DestroyBody()
    {
        DestroyBody(_id);
    }

    /// <summary>
    /// Body identifier validation. Can be used to detect orphaned ids. Provides validation for up to 64K allocations.
    /// </summary>
    public bool IsValid()
    {
        return Body_IsValid(_id);
    }

    /// <summary>
    /// Get the body type: static, kinematic, or dynamic
    /// </summary>
    public new BodyType GetType()
    {
        return Body_GetType(_id);
    }

    /// <summary>
    /// Change the body type. This is an expensive operation. This automatically updates the mass
    /// properties regardless of the automatic mass setting.
    /// </summary>
    public void SetType(BodyType type)
    {
        Body_SetType(_id, type);
    }

    /// <summary>
    /// Set the body name. Up to 31 characters excluding 0 termination.
    /// </summary>
    public void SetName(string name)
    {
        var ptr = Marshal.StringToHGlobalAnsi(name);
        try
        {
            Body_SetName(_id, (byte*)ptr);
        }
        finally
        {
            Marshal.FreeHGlobal(ptr);
        }
    }

    /// <summary>
    /// Get the body name. May be null.
    /// </summary>
    public string? GetName()
    {
        return Marshal.PtrToStringAnsi((IntPtr)Body_GetName(_id));
    }

    /// <summary>
    /// Set the user data for a body
    /// </summary>
    public void SetUserData(void* userData)
    {
        Body_SetUserData(_id, userData);
    }

    /// <summary>
    /// Get the user data stored in a body
    /// </summary>
    public void* GetUserData()
    {
        return Body_GetUserData(_id);
    }

    /// <summary>
    /// Get the world position of a body. This is the location of the body origin.
    /// </summary>
    public Vector2 GetPosition()
    {
        return Body_GetPosition(_id);
    }

    /// <summary>
    /// Get the world rotation of a body as a cosine/sine pair (complex number)
    /// </summary>
    public Rotation GetRotation()
    {
        return Body_GetRotation(_id);
    }

    /// <summary>
    /// Get the world transform of a body.
    /// </summary>
    public Transform GetTransform()
    {
        return Body_GetTransform(_id);
    }

    /// <summary>
    /// Set the world transform of a body. This acts as a teleport and is fairly expensive.
    /// </summary>
    /// <remarks>
    /// Generally you should create a body with then intended transform.
    /// </remarks>
    /// <seealso cref="BodyDef.Position"/>
    /// <seealso cref="BodyDef.Rotation"/>
    public void SetTransform(Vector2 position, Rotation rotation)
    {
        Body_SetTransform(_id, position, rotation);
    }

    /// <summary>
    /// Get a local point on a body given a world point
    /// </summary>
    public Vector2 GetLocalPoint(Vector2 worldPoint)
    {
        return Body_GetLocalPoint(_id, worldPoint);
    }

    /// <summary>
    /// Get a world point on a body given a local point
    /// </summary>
    public Vector2 GetWorldPoint(Vector2 localPoint)
    {
        return Body_GetWorldPoint(_id, localPoint);
    }

    /// <summary>
    /// Get a local vector on a body given a world vector
    /// </summary>
    public Vector2 GetLocalVector(Vector2 worldVector)
    {
        return Body_GetLocalVector(_id, worldVector);
    }

    /// <summary>
    /// Get a world vector on a body given a local vector
    /// </summary>
    public Vector2 GetWorldVector(Vector2 localVector)
    {
        return Body_GetWorldVector(_id, localVector);
    }

    /// <summary>
    /// Get the linear velocity of a body's center of mass. Usually in meters per second.
    /// </summary>
    public Vector2 GetLinearVelocity()
    {
        return Body_GetLinearVelocity(_id);
    }

    /// <summary>
    /// Get the angular velocity of a body in radians per second
    /// </summary>
    public float GetAngularVelocity()
    {
        return Body_GetAngularVelocity(_id);
    }

    /// <summary>
    /// Set the linear velocity of a body. Usually in meters per second.
    /// </summary>
    public void SetLinearVelocity(Vector2 linearVelocity)
    {
        Body_SetLinearVelocity(_id, linearVelocity);
    }

    /// <summary>
    /// Set the angular velocity of a body in radians per second
    /// </summary>
    public void SetAngularVelocity(float angularVelocity)
    {
        Body_SetAngularVelocity(_id, angularVelocity);
    }

    /// <summary>
    /// Set the velocity to reach the given transform after a given time step.
    /// The result will be close but maybe not exact. This is meant for kinematic bodies.
    /// The target is not applied if the velocity would be below the sleep threshold.
    /// This will automatically wake the body if asleep.
    /// </summary>
    public void SetTargetTransform(Transform target, float timeStep, bool wake)
    {
        Body_SetTargetTransform(_id, target, timeStep, wake);
    }

    /// <summary>
    /// Get the linear velocity of a local point attached to a body. Usually in meters per second.
    /// </summary>
    public Vector2 GetLocalPointVelocity(Vector2 localPoint)
    {
        return Body_GetLocalPointVelocity(_id, localPoint);
    }

    /// <summary>
    /// Get the linear velocity of a world point attached to a body. Usually in meters per second.
    /// </summary>
    public Vector2 GetWorldPointVelocity(Vector2 worldPoint)
    {
        return Body_GetWorldPointVelocity(_id, worldPoint);
    }

    /// <summary>
    /// Apply a force at a world point. If the force is not applied at the center of mass,
    /// it will generate a torque and affect the angular velocity. This optionally wakes up the body.
    /// The force is ignored if the body is not awake.
    /// </summary>
    /// <param name="force">The world force vector, usually in newtons (N)</param>
    /// <param name="point">The world position of the point of application</param>
    /// <param name="wake">Option to wake up the body</param>
    public void ApplyForce(Vector2 force, Vector2 point, bool wake)
    {
        Body_ApplyForce(_id, force, point, wake);
    }

    /// <summary>
    /// Apply a force to the center of mass. This optionally wakes up the body.
    /// The force is ignored if the body is not awake.
    /// </summary>
    /// <param name="force">the world force vector, usually in newtons (N).</param>
    /// <param name="wake">also wake up the body</param>
    public void ApplyForceToCenter(Vector2 force, bool wake)
    {
        Body_ApplyForceToCenter(_id, force, wake);
    }

    /// <summary>
    /// Apply a torque. This affects the angular velocity without affecting the linear velocity.
    /// This optionally wakes the body. The torque is ignored if the body is not awake.
    /// </summary>
    /// <param name="torque">about the z-axis (out of the screen), usually in N*m.</param>
    /// <param name="wake">also wake up the body</param>
    public void ApplyTorque(float torque, bool wake)
    {
        Body_ApplyTorque(_id, torque, wake);
    }

    /// <summary>
    /// Clear forces
    /// </summary>
    public void ClearForces()
    {
        Body_ClearForces(_id);
    }

    /// <summary>
    /// Apply an impulse at a point. This immediately modifies the velocity.
    /// It also modifies the angular velocity if the point of application
    /// is not at the center of mass. This optionally wakes the body.
    /// The impulse is ignored if the body is not awake.
    /// </summary>
    /// <param name="impulse">the world impulse vector, usually in N*s or kg*m/s.</param>
    /// <param name="point">the world position of the point of application.</param>
    /// <param name="wake">also wake up the body</param>
    /// <warning>This should be used for one-shot impulses. If you need a steady force,
    /// use a force instead, which will work better with the sub-stepping solver.</warning>
    public void ApplyLinearImpulse(Vector2 impulse, Vector2 point, bool wake)
    {
        Body_ApplyLinearImpulse(_id, impulse, point, wake);
    }

    /// <summary>
    /// Apply an impulse to the center of mass. This immediately modifies the velocity.
    /// The impulse is ignored if the body is not awake. This optionally wakes the body.
    /// </summary>
    /// <param name="impulse">the world impulse vector, usually in N*s or kg*m/s.</param>
    /// <param name="wake">also wake up the body</param>
    /// <warning>This should be used for one-shot impulses. If you need a steady force,
    /// use a force instead, which will work better with the sub-stepping solver.</warning>
    public void ApplyLinearImpulseToCenter(Vector2 impulse, bool wake)
    {
        Body_ApplyLinearImpulseToCenter(_id, impulse, wake);
    }

    /// <summary>
    /// Apply an angular impulse. The impulse is ignored if the body is not awake.
    /// This optionally wakes the body.
    /// </summary>
    /// <param name="impulse">the angular impulse, usually in units of kg*m*m/s</param>
    /// <param name="wake">also wake up the body</param>
    /// <warning>This should be used for one-shot impulses. If you need a steady force,
    /// use a force instead, which will work better with the sub-stepping solver.</warning>
    public void ApplyAngularImpulse(float impulse, bool wake)
    {
        Body_ApplyAngularImpulse(_id, impulse, wake);
    }

    /// <summary>
    /// Get the mass of the body, usually in kilograms
    /// </summary>
    public float GetMass()
    {
        return Body_GetMass(_id);
    }

    /// <summary>
    /// Get the rotational inertia of the body, usually in kg*m^2
    /// </summary>
    public float GetRotationalInertia()
    {
        return Body_GetRotationalInertia(_id);
    }

    /// <summary>
    /// Get the center of mass position of the body in local space
    /// </summary>
    public Vector2 GetLocalCenterOfMass()
    {
        return Body_GetLocalCenterOfMass(_id);
    }

    /// <summary>
    /// Get the center of mass position of the body in world space
    /// </summary>
    public Vector2 GetWorldCenterOfMass()
    {
        return Body_GetWorldCenterOfMass(_id);
    }

    /// <summary>
    /// Override the body's mass properties. Normally this is computed automatically using the
    /// shape geometry and density. This information is lost if a shape is added or removed or if the
    /// body type changes.
    /// </summary>
    public void SetMassData(MassData massData)
    {
        Body_SetMassData(_id, massData);
    }

    /// <summary>
    /// Get the mass data for a body
    /// </summary>
    public MassData GetMassData()
    {
        return Body_GetMassData(_id);
    }

    /// <summary>
    /// This update the mass properties to the sum of the mass properties of the shapes.
    /// This normally does not need to be called unless you called SetMassData to override
    /// the mass and you later want to reset the mass.
    /// You may also use this when automatic mass computation has been disabled.
    /// You should call this regardless of body type.
    /// Note that sensor shapes may have mass.
    /// </summary>
    public void ApplyMassFromShapes()
    {
        Body_ApplyMassFromShapes(_id);
    }

    /// <summary>
    /// Adjust the linear damping. Normally this is set in b2BodyDef before creation.
    /// </summary>
    public void SetLinearDamping(float linearDamping)
    {
        Body_SetLinearDamping(_id, linearDamping);
    }

    /// <summary>
    /// Get the current linear damping.
    /// </summary>
    public float GetLinearDamping()
    {
        return Body_GetLinearDamping(_id);
    }

    /// <summary>
    /// Adjust the angular damping. Normally this is set in b2BodyDef before creation.
    /// </summary>
    public void SetAngularDamping(float angularDamping)
    {
        Body_SetAngularDamping(_id, angularDamping);
    }

    /// <summary>
    /// Get the current angular damping.
    /// </summary>
    public float GetAngularDamping()
    {
        return Body_GetAngularDamping(_id);
    }

    /// <summary>
    /// Adjust the gravity scale. Normally this is set in b2BodyDef before creation.
    /// </summary>
    /// <seealso cref="BodyDef.GravityScale"/>
    public void SetGravityScale(float gravityScale)
    {
        Body_SetGravityScale(_id, gravityScale);
    }

    /// <summary>
    /// Get the current gravity scale
    /// </summary>
    public float GetGravityScale()
    {
        return Body_GetGravityScale(_id);
    }

    /// <summary>
    /// Returns true if this body is awake
    /// </summary>
    /// <returns></returns>
    public bool IsAwake()
    {
        return Body_IsAwake(_id);
    }

    /// <summary>
    /// Wake a body from sleep. This wakes the entire island the body is touching.
    /// </summary>
    /// <remarks>
    /// Warning: Putting a body to sleep will put the entire island of bodies touching this body to sleep,
    /// which can be expensive and possibly unintuitive.
    /// </remarks>
    public void SetAwake(bool awake)
    {
        Body_SetAwake(_id, awake);
    }

    /// <summary>
    /// Wake a body from sleep. This wakes the entire island the body is touching.
    /// </summary>
    public void WakeTouching()
    {
        Body_WakeTouching(_id);
    }

    /// <summary>
    /// Enable or disable sleeping for this body. If sleeping is disabled the body will wake.
    /// </summary>
    public void EnableSleep(bool enableSleep)
    {
        Body_EnableSleep(_id, enableSleep);
    }

    /// <summary>
    /// Returns true if sleeping is enabled for this body
    /// </summary>
    public bool IsSleepEnabled()
    {
        return Body_IsSleepEnabled(_id);
    }

    /// <summary>
    /// Set the sleep threshold, usually in meters per second
    /// </summary>
    public void SetSleepThreshold(float sleepThreshold)
    {
        Body_SetSleepThreshold(_id, sleepThreshold);
    }

    /// <summary>
    /// Get the sleep threshold, usually in meters per second.
    /// </summary>
    public float GetSleepThreshold()
    {
        return Body_GetSleepThreshold(_id);
    }

    /// <summary>
    /// Returns true if this body is enabled
    /// </summary>
    public bool IsEnabled()
    {
        return Body_IsEnabled(_id);
    }

    /// <summary>
    /// Disable a body by removing it completely from the simulation. This is expensive.
    /// </summary>
    public void Disable()
    {
        Body_Disable(_id);
    }

    /// <summary>
    /// Enable a body by adding it to the simulation. This is expensive.
    /// </summary>
    public void Enable()
    {
        Body_Enable(_id);
    }

    /// <summary>
    /// Set this body to have fixed rotation. This causes the mass to be reset in all cases.
    /// </summary>
    public void SetFixedRotation(bool flag)
    {
        Body_SetFixedRotation(_id, flag);
    }

    /// <summary>
    /// Does this body have fixed rotation?
    /// </summary>
    public bool IsFixedRotation()
    {
        return Body_IsFixedRotation(_id);
    }

    /// <summary>
    /// Set this body to be a bullet. A bullet does continuous collision detection
    /// against dynamic bodies (but not other bullets).
    /// </summary>
    public void SetBullet(bool flag)
    {
        Body_SetBullet(_id, flag);
    }

    /// <summary>
    /// Is this body a bullet?
    /// </summary>
    public bool IsBullet()
    {
        return Body_IsBullet(_id);
    }

    /// <summary>
    /// Enable/disable contact events on all shapes.
    /// </summary>
    /// <seealso cref="ShapeDef.EnableContactEvents"/>
    /// <remarks>
    /// Warning: changing this at runtime may cause mismatched begin/end touch events
    /// </remarks>
    public void EnableContactEvents(bool flag)
    {
        Body_EnableContactEvents(_id, flag);
    }

    /// <summary>
    /// Enable/disable hit events on all shapes
    /// </summary>
    /// <seealso cref="ShapeDef.EnableHitEvents"/>
    public void EnableHitEvents(bool flag)
    {
        Body_EnableHitEvents(_id, flag);
    }

    /// <summary>
    /// Get the world that owns this body
    /// </summary>
    public WorldId GetWorld()
    {
        return Body_GetWorld(_id);
    }

    /// <summary>
    /// Get the number of shapes on this body
    /// </summary>
    public int GetShapeCount()
    {
        return Body_GetShapeCount(_id);
    }

    /// <summary>
    /// Get the shape ids for all shapes on this body, up to the provided capacity.
    /// </summary>
    /// <returns>the number of shape ids stored in the user array</returns>
    public int GetShapes(ShapeId* shapeArray, int capacity)
    {
        return Body_GetShapes(_id, shapeArray, capacity);
    }

    /// <summary>
    /// Get the number of joints on this body
    /// </summary>
    public int GetJointCount()
    {
        return Body_GetJointCount(_id);
    }

    /// <summary>
    /// Get the joint ids for all joints on this body, up to the provided capacity
    /// </summary>
    /// <returns>the number of joint ids stored in the user array</returns>
    public int GetJoints(JointId* jointArray, int capacity)
    {
        return Body_GetJoints(_id, jointArray, capacity);
    }

    /// <summary>
    /// Get the maximum capacity required for retrieving all the touching contacts on a body
    /// </summary>
    public int GetContactCapacity()
    {
        return Body_GetContactCapacity(_id);
    }

    /// <summary>
    /// Get the touching contact data for a body.
    /// </summary>
    /// <remarks>
    /// Note: Box2D uses speculative collision so some contact points may be separated.
    /// Warning: do not ignore the return value, it specifies the valid number of elements
    /// </remarks>
    /// <returns>the number of elements filled in the provided array</returns>
    public int GetContactData(ContactData* contactData, int capacity)
    {
        return Body_GetContactData(_id, contactData, capacity);
    }

    /// <summary>
    /// Get the current world AABB that contains all the attached shapes. Note that this may not encompass the body origin.
    /// If there are no shapes attached then the returned AABB is empty and centered on the body origin.
    /// </summary>
    public Aabb ComputeAABB()
    {
        return Body_ComputeAABB(_id);
    }

    #region NativeFunctions

    [DllImport("box2d", EntryPoint = "b2CreateBody")]
    private static extern BodyId CreateBody(WorldId worldId, ref BodyDef def);

    [DllImport("box2d", EntryPoint = "b2DestroyBody")]
    private static extern void DestroyBody(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_IsValid")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool Body_IsValid(BodyId id);

    [DllImport("box2d", EntryPoint = "b2Body_GetType")]
    private static extern BodyType Body_GetType(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_SetType")]
    private static extern void Body_SetType(BodyId bodyId, BodyType type);

    [DllImport("box2d", EntryPoint = "b2Body_SetName")]
    private static extern void Body_SetName(BodyId bodyId, byte* name);

    [DllImport("box2d", EntryPoint = "b2Body_GetName")]
    private static extern byte* Body_GetName(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_SetUserData")]
    private static extern void Body_SetUserData(BodyId bodyId, void* userData);

    [DllImport("box2d", EntryPoint = "b2Body_GetUserData")]
    private static extern void* Body_GetUserData(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_GetPosition")]
    private static extern Vector2 Body_GetPosition(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_GetRotation")]
    private static extern Rotation Body_GetRotation(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_GetTransform")]
    private static extern Transform Body_GetTransform(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_SetTransform")]
    private static extern void Body_SetTransform(BodyId bodyId, Vector2 position, Rotation rotation);

    [DllImport("box2d", EntryPoint = "b2Body_GetLocalPoint")]
    private static extern Vector2 Body_GetLocalPoint(BodyId bodyId, Vector2 worldPoint);

    [DllImport("box2d", EntryPoint = "b2Body_GetWorldPoint")]
    private static extern Vector2 Body_GetWorldPoint(BodyId bodyId, Vector2 localPoint);

    [DllImport("box2d", EntryPoint = "b2Body_GetLocalVector")]
    private static extern Vector2 Body_GetLocalVector(BodyId bodyId, Vector2 worldVector);

    [DllImport("box2d", EntryPoint = "b2Body_GetWorldVector")]
    private static extern Vector2 Body_GetWorldVector(BodyId bodyId, Vector2 localVector);

    [DllImport("box2d", EntryPoint = "b2Body_GetLinearVelocity")]
    private static extern Vector2 Body_GetLinearVelocity(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_GetAngularVelocity")]
    private static extern float Body_GetAngularVelocity(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_SetLinearVelocity")]
    private static extern void Body_SetLinearVelocity(BodyId bodyId, Vector2 linearVelocity);

    [DllImport("box2d", EntryPoint = "b2Body_SetAngularVelocity")]
    private static extern void Body_SetAngularVelocity(BodyId bodyId, float angularVelocity);

    [DllImport("box2d", EntryPoint = "b2Body_SetTargetTransform")]
    private static extern void Body_SetTargetTransform(BodyId bodyId, Transform target, float timeStep,
        [MarshalAs(UnmanagedType.U1)] bool wake);

    [DllImport("box2d", EntryPoint = "b2Body_GetLocalPointVelocity")]
    private static extern Vector2 Body_GetLocalPointVelocity(BodyId bodyId, Vector2 localPoint);

    [DllImport("box2d", EntryPoint = "b2Body_GetWorldPointVelocity")]
    private static extern Vector2 Body_GetWorldPointVelocity(BodyId bodyId, Vector2 worldPoint);

    [DllImport("box2d", EntryPoint = "b2Body_ApplyForce")]
    private static extern void Body_ApplyForce(BodyId bodyId, Vector2 force, Vector2 point,
        [MarshalAs(UnmanagedType.U1)] bool wake);

    [DllImport("box2d", EntryPoint = "b2Body_ApplyForceToCenter")]
    private static extern void Body_ApplyForceToCenter(BodyId bodyId, Vector2 force,
        [MarshalAs(UnmanagedType.U1)] bool wake);

    [DllImport("box2d", EntryPoint = "b2Body_ApplyTorque")]
    private static extern void Body_ApplyTorque(BodyId bodyId, float torque, [MarshalAs(UnmanagedType.U1)] bool wake);

    [DllImport("box2d", EntryPoint = "b2Body_ClearForces")]
    private static extern void Body_ClearForces(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_ApplyLinearImpulse")]
    private static extern void Body_ApplyLinearImpulse(BodyId bodyId, Vector2 impulse, Vector2 point,
        [MarshalAs(UnmanagedType.U1)] bool wake);

    [DllImport("box2d", EntryPoint = "b2Body_ApplyLinearImpulseToCenter")]
    private static extern void Body_ApplyLinearImpulseToCenter(BodyId bodyId, Vector2 impulse,
        [MarshalAs(UnmanagedType.U1)] bool wake);

    [DllImport("box2d", EntryPoint = "b2Body_ApplyAngularImpulse")]
    private static extern void Body_ApplyAngularImpulse(BodyId bodyId, float impulse,
        [MarshalAs(UnmanagedType.U1)] bool wake);

    [DllImport("box2d", EntryPoint = "b2Body_GetMass")]
    private static extern float Body_GetMass(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_GetRotationalInertia")]
    private static extern float Body_GetRotationalInertia(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_GetLocalCenterOfMass")]
    private static extern Vector2 Body_GetLocalCenterOfMass(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_GetWorldCenterOfMass")]
    private static extern Vector2 Body_GetWorldCenterOfMass(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_SetMassData")]
    private static extern void Body_SetMassData(BodyId bodyId, MassData massData);

    [DllImport("box2d", EntryPoint = "b2Body_GetMassData")]
    private static extern MassData Body_GetMassData(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_ApplyMassFromShapes")]
    private static extern void Body_ApplyMassFromShapes(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_SetLinearDamping")]
    private static extern void Body_SetLinearDamping(BodyId bodyId, float linearDamping);

    [DllImport("box2d", EntryPoint = "b2Body_GetLinearDamping")]
    private static extern float Body_GetLinearDamping(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_SetAngularDamping")]
    private static extern void Body_SetAngularDamping(BodyId bodyId, float angularDamping);

    [DllImport("box2d", EntryPoint = "b2Body_GetAngularDamping")]
    private static extern float Body_GetAngularDamping(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_SetGravityScale")]
    private static extern void Body_SetGravityScale(BodyId bodyId, float gravityScale);

    [DllImport("box2d", EntryPoint = "b2Body_GetGravityScale")]
    private static extern float Body_GetGravityScale(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_IsAwake")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool Body_IsAwake(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_SetAwake")]
    private static extern void Body_SetAwake(BodyId bodyId, [MarshalAs(UnmanagedType.U1)] bool awake);

    [DllImport("box2d", EntryPoint = "b2Body_WakeTouching")]
    private static extern void Body_WakeTouching(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_EnableSleep")]
    private static extern void Body_EnableSleep(BodyId bodyId, [MarshalAs(UnmanagedType.U1)] bool enableSleep);

    [DllImport("box2d", EntryPoint = "b2Body_IsSleepEnabled")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool Body_IsSleepEnabled(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_SetSleepThreshold")]
    private static extern void Body_SetSleepThreshold(BodyId bodyId, float sleepThreshold);

    [DllImport("box2d", EntryPoint = "b2Body_GetSleepThreshold")]
    private static extern float Body_GetSleepThreshold(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_IsEnabled")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool Body_IsEnabled(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_Disable")]
    private static extern void Body_Disable(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_Enable")]
    private static extern void Body_Enable(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_SetFixedRotation")]
    private static extern void Body_SetFixedRotation(BodyId bodyId, [MarshalAs(UnmanagedType.U1)] bool flag);

    [DllImport("box2d", EntryPoint = "b2Body_IsFixedRotation")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool Body_IsFixedRotation(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_SetBullet")]
    private static extern void Body_SetBullet(BodyId bodyId, [MarshalAs(UnmanagedType.U1)] bool flag);

    [DllImport("box2d", EntryPoint = "b2Body_IsBullet")]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool Body_IsBullet(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_EnableContactEvents")]
    private static extern void Body_EnableContactEvents(BodyId bodyId, [MarshalAs(UnmanagedType.U1)] bool flag);

    [DllImport("box2d", EntryPoint = "b2Body_EnableHitEvents")]
    private static extern void Body_EnableHitEvents(BodyId bodyId, [MarshalAs(UnmanagedType.U1)] bool flag);

    [DllImport("box2d", EntryPoint = "b2Body_GetWorld")]
    private static extern WorldId Body_GetWorld(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_GetShapeCount")]
    private static extern int Body_GetShapeCount(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_GetShapes")]
    private static extern int Body_GetShapes(BodyId bodyId, ShapeId* shapeArray, int capacity);

    [DllImport("box2d", EntryPoint = "b2Body_GetJointCount")]
    private static extern int Body_GetJointCount(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_GetJoints")]
    private static extern int Body_GetJoints(BodyId bodyId, JointId* jointArray, int capacity);

    [DllImport("box2d", EntryPoint = "b2Body_GetContactCapacity")]
    private static extern int Body_GetContactCapacity(BodyId bodyId);

    [DllImport("box2d", EntryPoint = "b2Body_GetContactData")]
    private static extern int Body_GetContactData(BodyId bodyId, ContactData* contactData, int capacity);

    [DllImport("box2d", EntryPoint = "b2Body_ComputeAABB")]
    private static extern Aabb Body_ComputeAABB(BodyId bodyId);

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
            DestroyBody(_id);
        }

        _disposed = true;
    }

    ~Body() => Dispose(false);

    #endregion
}