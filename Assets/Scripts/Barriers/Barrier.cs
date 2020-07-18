using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Script base de controle da barreira
/// </summary>
public class Barrier : MonoBehaviour
{

    public Sprite normalSprite, onlyBorder;

    public virtual void Start()
    {
        if(normalSprite != null && onlyBorder != null)
            StartCoroutine(EnableCollision());
    }

    public void FixedUpdate()
    {
        Movement();
    }

    /// <summary>
    /// Reponsavel por chamar o movimentos dos scripts filhos
    /// </summary>
    public virtual void Movement() { }

    /// <summary>
    /// Habilita colisão para mais dinamismo no jogo
    /// </summary>
    /// <returns></returns>
    public IEnumerator EnableCollision()
    {
        this.GetComponent<SpriteRenderer>().sprite = normalSprite;
        this.GetComponent<Collider2D>().enabled = true;
        yield return new WaitForSeconds(Random.Range(30, 80));
        StartCoroutine(DisableCollision());
    }

    /// <summary>
    /// Desabilita colisão para mais dinamismo no jogo
    /// </summary>
    /// <returns></returns>
    public IEnumerator DisableCollision()
    {
        this.GetComponent<SpriteRenderer>().sprite = onlyBorder;
        this.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(Random.Range(10, 15));
        StartCoroutine(EnableCollision());
    }
}
