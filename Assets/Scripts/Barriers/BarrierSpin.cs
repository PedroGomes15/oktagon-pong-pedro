using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Barreira derivada da original com função de rotação
/// </summary>
public class BarrierSpin : Barrier
{
    public float speed = 10;

    public override void Start()
    {
        base.Start();
        speed = Random.Range(0, 2) == 0 ? speed : -speed;//direção da rotação aleatoria
    }

    public override void Movement()
    {
        this.transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
