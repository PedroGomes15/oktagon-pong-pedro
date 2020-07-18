using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bala rapida derivada da original com limite de quicadas
/// </summary>
public class QuickBullet : Bullet
{
    public int bounceCount = 3;

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        if (collision.transform.tag == "Block")
        {
            bounceCount--;
            if (bounceCount <= 0)
            {
                DestroyBullet();
            }
        }
    }

}
