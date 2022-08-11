using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Enemies2 : Enemies
{
    private int life =2;
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (this.transform.position.x <= -8 || this.transform.position.x >= 8)
        {
            mantul();
        }
    }

    public override void gerak(int turun)
    {
        speed = new Vector3(10, -0.5f+(turun/4));
        rig.velocity = speed;
    }



    void mantul()
    {
        speed = new Vector2(speed.x * -1, speed.y);
        rig.velocity = speed;
    }

    public override void onklika(int damage)
    {
        life -= 1;
        if (life == 0)
            mana.hancur(gameObject);
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red; 
        }
    }

}
