using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemies : MonoBehaviour, Ionklik
{
    protected Vector3  speed;
    protected Rigidbody rig;
    protected ManagerMusuh mana;
    // Start is called before the first frame update
    void Start()
    {
        mana = GameObject.Find("Spawn").GetComponent<ManagerMusuh>();
        rig = GetComponent<Rigidbody>();
        rig.velocity = speed;
        gerak(mana.level);
    }

    // Update is called once per frame
    public virtual void FixedUpdate()
    {
        if (this.transform.position.y <= -5)
        {
            Batas();
        }
    }

    /*
    void OnMouseDown()
    {

        // this object was clicked - do something
        Debug.Log("coab");
        mana.hancur(gameObject);
    }
    */

    public abstract void gerak(int turun);


    public virtual void Batas()
    {
            mana.lewat(gameObject);
    }

    public virtual void onklika(int damage)
    {
        mana.hancur(gameObject);
    }
}
