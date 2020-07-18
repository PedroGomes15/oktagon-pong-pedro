using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script base de controle da bala
/// </summary>
public class Bullet : MonoBehaviour
{
    public string type;

    public Vector2 sizeStart;

    public float size = 1;

    public float speed;

    private float startSpeed;

    public int strength;

    public Vector2 inDirection;

    public float limitTime = 10.0f;

    private float time;

    /// <summary>
    /// Função de destruição da bala sendo chamada por tempo e por condições nos scripts filhos
    /// </summary>
    public void DestroyBullet()
    {

        GameObject explosion = (GameObject)Instantiate(GameManager.instance.LoadPrefab("Explosion"), this.transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
        Destroy(explosion, 1.5f);
        GameManager.instance.NextPlayer();
        Destroy(this.gameObject);
    }

    void Start()
    {
        inDirection = this.transform.up;
        startSpeed = speed;
        sizeStart = this.transform.localScale;
        Resize();
    }

    private void Update()
    {
        time += Time.deltaTime;

        if(time>limitTime)
        {
            DestroyBullet();//Chama a função de destruir quando passa o tempo limite da bala para garantir que a troca de turno aconteça
        }

        transform.Translate(inDirection * speed * Time.deltaTime, Space.World);//Movimento da bala

        if(this.transform.position.x <-10 || this.transform.position.x>10 || this.transform.position.y > 5 || this.transform.position.y<-5)
        {
            DestroyBullet();//Garantia caso a bala saia do cenario
        }
    }

    //Função para balas com tamanho diferente do padrao
    public void Resize()
    {
        this.transform.localScale = sizeStart * size;
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
            //Colisão da bala com o cenario para fazer os recalculos de fisica e de rotação
            var contactPoint = collision.contacts[0].point;
            Vector2 bulletLocation = transform.position;
            var inNormal = (bulletLocation - contactPoint).normalized;
            inDirection = Vector2.Reflect(inDirection, inNormal);

            if(speed < startSpeed + startSpeed * 0.5)
                speed += speed * 0.1f;
        }
    }
}
