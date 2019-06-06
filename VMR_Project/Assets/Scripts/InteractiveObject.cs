﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour
{
    protected bool focused;

    public void OnFocusEnter()
    {
        Debug.Log(gameObject.name + "focused!");
        focused = true;
    }

    public void OnFocusExit()
    {
        Debug.Log(gameObject.name + "stop focused!");
        focused = false;
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
            OnClick();

        if (Input.GetKeyDown(KeyCode.UpArrow))
            OnArrowUp();

        if (Input.GetKeyDown(KeyCode.DownArrow))
            OnArrowDown();*/
    }

    public abstract void OnClick();
    public abstract void OnArrowUp();
    public abstract void OnArrowDown();
}
