using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEventForwarder : MonoBehaviour
{
    public Action<Collision> CollisionEnterEvent;
    public Action<Collision> CollisionStayEvent;
    public Action<Collision> CollisionExitEvent;
    
    public Action<Collider> TriggerEnterEvent;
    public Action<Collider> TriggerStayEvent;
    public Action<Collider> TriggerExitEvent;

    void OnCollisionEnter(Collision collision) {
        CollisionEnterEvent?.Invoke(collision);
    }

    void OnCollisionStay(Collision collision) {
        CollisionStayEvent?.Invoke(collision);
    }

    void OnCollisionExit(Collision collision) {
        CollisionExitEvent?.Invoke(collision);
    }

    private void OnTriggerEnter(Collider other) {
        TriggerEnterEvent?.Invoke(other);
    }

    private void OnTriggerStay(Collider other) {
        TriggerStayEvent?.Invoke(other);
    }
    private void OnTriggerExit(Collider other) {
        TriggerExitEvent?.Invoke(other);
    }

}
