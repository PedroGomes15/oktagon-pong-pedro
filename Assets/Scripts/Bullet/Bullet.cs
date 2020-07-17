using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string type;

    public int size = 1;

    public int speed;

    public int strength;

    public void DestroyBullet()
    {
        Destroy(this.gameObject);
    }

    private void Update()
    {
        this.transform.localPosition += transform.up * speed * Time.deltaTime;
        this.transform.localScale *= size;
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<Player>().TakeDamage(strength);
            DestroyBullet();
        }
        else if (collision.transform.tag == "Block")
        {
            Vector3 v = Vector3.Reflect(this.transform.position, collision.contacts[0].normal).normalized;
            float rot = 0;
            if (v.x >= 0)
            {
                rot = 90 + Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
            }
            else
            {
                rot = 90 - Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
            }
            transform.localEulerAngles = new Vector3(0, 0, rot);
        }
    }

    public void OnDestroy()
    {
        GameManager.instance.NextPlayer();
    }
}
