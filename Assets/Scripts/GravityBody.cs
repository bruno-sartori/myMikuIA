using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class GravityBody : MonoBehaviour {
    GravityAttractor planet;
    Rigidbody rgbd;

    void Awake() {
        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityAttractor>();
        rgbd = GetComponent<Rigidbody>();

        rgbd.useGravity = false;
        rgbd.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate() {
        planet.Attract(transform);
    }
}
