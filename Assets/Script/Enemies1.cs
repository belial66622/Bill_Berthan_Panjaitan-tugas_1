using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies1 : Enemies
{
    public override void gerak(int turun)
    {
        speed = new Vector3(0, -0.5f - (turun / 4));
        rig.velocity = speed;

    }

}
