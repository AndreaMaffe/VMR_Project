﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumSupport : MonoBehaviour
{
    // These values store the pendulum's initial state.
    private Quaternion initialRopeRotation;
    private Quaternion initialPendulumBodyRotation;
    private Vector3 initialPendulumBodyPosition;
    public float pendulumBodyColliderRadius;
    private float initialWeightScale;

    // Height at which the pendulum body starts swinging.
    private float startingPendulumHeight;

    // GameObjects whose parameters are needed.
    public GameObject pendulumSupport;
    public GameObject pendulumBody;
    public GameObject rope;
    public GameObject height;
    public Vector weight;

    // This value indicates whether the pendulum is in its initial position or not.
    public bool isPendulumReset = true;

    // This value modifies the value of the torque applied to the rope when the pendulum movement is started.
    private float appliedForceAmount = 4f;

    // Start is called before the first frame update
    void Start()
    {
        initialRopeRotation = rope.transform.rotation;

        initialPendulumBodyRotation = pendulumBody.transform.rotation;
        initialPendulumBodyPosition = pendulumBody.transform.position;

        initialWeightScale = 2;
        weight.SetScale(initialWeightScale);

        startingPendulumHeight = pendulumBody.transform.position.y;

        // Adjust the SphereCollider radius, so that it remains constant with the pendulumBody scaling.
        pendulumBodyColliderRadius = pendulumBody.GetComponent<SphereCollider>().radius * pendulumBody.transform.localScale.x;
    }

    /**
     * This function brings back the pendulum to its initial state.
     */
    public void Reset()
    {
        pendulumBody.GetComponent<Rigidbody>().isKinematic = true;
        rope.GetComponent<Rigidbody>().isKinematic = true;
        isPendulumReset = true;

        pendulumBody.transform.position = new Vector3(initialPendulumBodyPosition.x, startingPendulumHeight, initialPendulumBodyPosition.z);
        pendulumBody.transform.rotation = initialPendulumBodyRotation;

        rope.transform.rotation = initialRopeRotation;
    }

    /**
     * This function is used to start the movement of the pendulum.
     */
    public void MovePendulum()
    {
        isPendulumReset = false;
        startingPendulumHeight = pendulumBody.transform.position.y;

        pendulumBody.GetComponent<Rigidbody>().isKinematic = false;
        rope.GetComponent<Rigidbody>().isKinematic = false;

        pendulumBody.GetComponent<Rigidbody>().AddForce(Vector3.right * appliedForceAmount, ForceMode.VelocityChange);
    }

    public void OnDisable()
    {
        Reset();
    }
}
