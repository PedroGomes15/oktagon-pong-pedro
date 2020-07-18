using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bala com aumento de tamanho e o dano quando quica em alguma parede
/// </summary>
public class GiantBullet : Bullet
{
    public int bounceLimitTimes = 10;

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        if (collision.transform.tag == "Block")
        {
            if (bounceLimitTimes > 0)
            {
                Invoke("Bounce",0.1f);
            }
        }
    }

    public void Bounce()
    {
        this.size += 0.1f;
        this.strength += 2;
        bounceLimitTimes--;
        Resize();
    }
}
