﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionButton : InteractiveObject
{
    public PhysicMaterial ice;
    public PhysicMaterial copper;
    public PhysicMaterial wood;
    public PhysicMaterial steel;
    public Animator animator;
    public Incline incline;
    public FrictionBar frictionBar;

    private readonly PhysicMaterial[] physicMaterials = new PhysicMaterial[4];
    private int isOn;

    // Start is called before the first frame update
    void Start()
    {
        physicMaterials[0] = ice;
        physicMaterials[1] = copper;
        physicMaterials[2] = wood;
        physicMaterials[3] = steel;
        isOn = 0;
    }

    public override void OnArrowUp()
    {
        animator.SetTrigger("Pressed");
        AudioManager.instance.PlaySound(SoundType.Pop);

        if (isOn == 3)
        {
            isOn = 0;
        } else
        {
            isOn++;
        }
        incline.GetComponent<BoxCollider>().material = physicMaterials[isOn];

        frictionBar.ChangeBarColorLength(true, false);
    }

    public override void OnArrowDown()
    { 
        animator.SetTrigger("Pressed");
        AudioManager.instance.PlaySound(SoundType.Pop);

        if (isOn == 0)
        {
            isOn = 3;
        }
        else
        {
            isOn--;
        }
        incline.GetComponent<BoxCollider>().material = physicMaterials[isOn];

        frictionBar.ChangeBarColorLength(false, true);
    }

    public override void OnClick()
    {

    }
}
