﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockSphere : InteractiveObject
{
    private Rigidbody rb;
    private float scale;
    private GameObject sphere;
    public Transform otherSphere;

    private Vector3 originalPosition;
    public Vector vector;

    private bool isMoving;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalPosition = transform.position;
        scale = 1f;
        Vector3 direction = otherSphere.position - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);
        sphere = transform.Find("Sphere").gameObject;
        isMoving = false;
    }

    private void FixedUpdate()
    {
        Vector3 newRotation = Quaternion.LookRotation(rb.velocity).eulerAngles + Quaternion.Euler(90f, 0f, 0f).eulerAngles;
        vector.gameObject.transform.rotation = Quaternion.Euler(newRotation);
        vector.SetScale(rb.velocity.magnitude * 0.2f);
    }

    public override void OnArrowDown()
    {
        if (!isMoving)
        {
            scale -= 0.1f;

            if (scale < 0.3f)
                scale = 0.3f;

            this.transform.localScale = new Vector3(scale, scale, scale);

            rb.mass -= 2f;

            if (rb.mass < 6f)
                rb.mass = 6f;
        }
    }

    public override void OnArrowUp()
    {
        if (!isMoving)
        {
            scale += 0.1f;

            if (scale > 1.7f)
                scale = 1.7f;

            sphere.transform.localScale = new Vector3(scale, scale, scale);

            rb.mass += 1f;

            if (rb.mass > 34f)
                rb.mass = 34f;
        }

    }

    public void ResetPosition()
    {
        isMoving = false;
        rb.angularVelocity = Vector3.zero;
        rb.velocity = Vector3.zero;
        transform.position = originalPosition;
    }

    public void StartAddForce()
    {
        isMoving = true;
        rb.AddForce(transform.forward * 100, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        AudioManager.instance.PlaySound(SoundType.Toc);
        vector.gameObject.SetActive(!vector.enabled);
    }

    public override void OnClick()
    {
    }

    void OnDisable()
    {
        ResetPosition();
    }
}
