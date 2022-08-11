using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manusia : Enemies
{
 
    public override void gerak(int turun)
    {
        speed = new Vector3(0, -0.5f - (turun / 4));
        rig.velocity = speed;

    }


    public override void Batas()
    {
        mana.mlewat(gameObject);
    }

    public override void onklika(int damage)
    {
      mana.mSalah(gameObject);
    }
}
