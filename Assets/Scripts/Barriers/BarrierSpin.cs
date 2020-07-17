using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierSpin : Barrier
{
    public float speed = 10;

    public override void Movement()
    {
        this.transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
