using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickBullet : Bullet
{
    public int quickCount = 3;

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        if (collision.transform.tag == "Block")
        {
            quickCount--;
            if (quickCount <= 0)
            {
                DestroyBullet();
            }
        }
    }
}
