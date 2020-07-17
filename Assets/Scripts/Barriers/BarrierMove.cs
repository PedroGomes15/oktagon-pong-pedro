using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierMove : Barrier
{
    public float speed;

    public float startPoint, endPoint;

    private bool gotoEndPoint = true;

    [Tooltip("Use X/Y")]
    public string axis;

    public override void Movement()
    {
        Vector2 newPos = new Vector2();
        if (axis.ToLower() == "x")
        {
            if (gotoEndPoint)
                newPos = this.transform.localPosition + (Vector3.right * speed * Time.deltaTime);
            else
                newPos = this.transform.localPosition - (Vector3.right * speed * Time.deltaTime);

            if (newPos.x < endPoint && newPos.x > startPoint)
            {
                this.transform.localPosition = newPos;
            }
            else
            {
                gotoEndPoint = !gotoEndPoint;
            }
        }
        if (axis.ToLower() == "y")
        {
            if (gotoEndPoint)
                newPos = this.transform.localPosition - (Vector3.up * speed * Time.deltaTime);
            else
                newPos = this.transform.localPosition + (Vector3.up * speed * Time.deltaTime);

            if (newPos.y < endPoint && newPos.y > startPoint)
            {
                this.transform.localPosition = newPos;
            }
            else
            {
                gotoEndPoint = !gotoEndPoint;
            }
        }
       

    }
}
