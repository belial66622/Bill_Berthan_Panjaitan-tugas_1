using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies2 : MonoBehaviour
{
    Vector2  speed;
    Rigidbody2D rig;
    public ManagerMusuh mana;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;
        gerak(mana.level*-1);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {

        // this object was clicked - do something
        Debug.Log(mana.level);
        mana.hancur(gameObject);
    }

    void gerak(int turun)
    {
        speed = new Vector2(10, -0.5f+(turun/4));
        rig.velocity = speed;

    }



    void mantul()
    {
        speed = new Vector2(speed.x *-1, Random.RandomRange(speed.y,speed.y *2) );
        rig.velocity = speed;
        Debug.Log("cobb");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="dinding")
        mantul();
        if (collision.tag =="batas")
            mana.lewat(gameObject);

    }
}
