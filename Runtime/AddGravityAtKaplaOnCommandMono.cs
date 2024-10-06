using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGravityAtKaplaOnCommandMono : MonoBehaviour
{

    public Transform m_parentContainingKapla;
    public Rigidbody m_rigidBodyToCopy;


    private void Reset()
    {
        m_parentContainingKapla = transform;
    }

    [ContextMenu("Apply Rigidboy")]
    public void AddRigidbodyToKapla() {

        KaplaTagMono[] kapla= m_parentContainingKapla.GetComponentsInChildren<KaplaTagMono>();
        foreach (KaplaTagMono k in kapla) {

            Rigidbody r = k.GetComponent<Rigidbody>();
            if(r == null) 
                r =k.gameObject.AddComponent<Rigidbody>();


            if (m_rigidBodyToCopy != null) {

                // Basic Rigidbody Properties
                r.mass = m_rigidBodyToCopy.mass;
                r.drag = m_rigidBodyToCopy.drag;
                r.angularDrag = m_rigidBodyToCopy.angularDrag;
                r.useGravity = m_rigidBodyToCopy.useGravity;
                r.isKinematic = m_rigidBodyToCopy.isKinematic;
                r.interpolation = m_rigidBodyToCopy.interpolation;
                r.collisionDetectionMode = m_rigidBodyToCopy.collisionDetectionMode;
                r.constraints = m_rigidBodyToCopy.constraints;

                // Movement Properties
                r.velocity = m_rigidBodyToCopy.velocity;
                r.angularVelocity = m_rigidBodyToCopy.angularVelocity;
                r.maxDepenetrationVelocity = m_rigidBodyToCopy.maxDepenetrationVelocity;

                // Rigidbody Sleeping Settings
                r.sleepThreshold = m_rigidBodyToCopy.sleepThreshold;
                r.maxAngularVelocity = m_rigidBodyToCopy.maxAngularVelocity;

                // Rigidbody Center of Mass and Inertia
                r.centerOfMass = m_rigidBodyToCopy.centerOfMass;
                r.inertiaTensor = m_rigidBodyToCopy.inertiaTensor;
                r.inertiaTensorRotation = m_rigidBodyToCopy.inertiaTensorRotation;

                // Rigidbody Properties Introduced in Newer Versions
                r.detectCollisions = m_rigidBodyToCopy.detectCollisions;
                r.solverIterations = m_rigidBodyToCopy.solverIterations;
                r.solverVelocityIterations = m_rigidBodyToCopy.solverVelocityIterations;

                // Rigidbody Constraints and Flags
                r.constraints = m_rigidBodyToCopy.constraints;
                r.detectCollisions = m_rigidBodyToCopy.detectCollisions;
                r.sleepThreshold = m_rigidBodyToCopy.sleepThreshold;



            }
        }

    }


    [ContextMenu("Remove Rigidbody")]
    public void RemoveRigidbodyToKapla() { 
    
        KaplaTagMono[] kapla = m_parentContainingKapla.GetComponentsInChildren<KaplaTagMono>();
        foreach (KaplaTagMono k in kapla) {
            Rigidbody r = k.GetComponentInChildren<Rigidbody>();
            if (r != null) {
                if(Application.isPlaying)
                    Destroy(r);
                else
                    DestroyImmediate(r);
            }
        }
    }
}
