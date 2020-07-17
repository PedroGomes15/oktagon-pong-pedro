using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerIndex = 0;

    public float limitY = 4;

    public float moveSpeed = 5.0f;

    public float rotationSpeed = 5.0f;

    public float angleLimit = 60;

    public float startAngle = 0;

    public string myBullet;

    public float life = 100;

    private bool myTurn = false;

    void Awake()
    {
        GameManager.instance.AssignPlayer(this, playerIndex);
        startAngle = this.transform.rotation.eulerAngles.z;
    }

    public void StartMyTurn()
    {
        this.transform.Find("MarkPoint").GetComponent<SpriteRenderer>().enabled = true;
        myTurn = true;
    }

    public void EndMyTurn()
    {
        this.transform.Find("MarkPoint").GetComponent<SpriteRenderer>().enabled = false;
        myTurn = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && myTurn)
        {
            Shot();
        }
    }

    private void FixedUpdate()
    {
        if (!myTurn) return;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 newPos = this.transform.position;
        newPos.y += vertical * moveSpeed * Time.deltaTime ;

        Vector3 newRotation = this.transform.localRotation.eulerAngles;
        newRotation.z -= horizontal * rotationSpeed * Time.deltaTime;
        
        if (newPos.y <= limitY && newPos.y >= -limitY)
        {
            this.transform.position = newPos;
        }

        if(newRotation.z <= (startAngle + angleLimit) && newRotation.z >= (startAngle - angleLimit))
        {
            this.transform.localRotation = Quaternion.Euler(newRotation);
        }
    }

    public void Shot()
    {
        GameObject bullet = (GameObject)Instantiate(GameManager.instance.LoadPrefab(myBullet), this.transform.Find("Gun").position, this.transform.localRotation);
    }

    public void TakeDamage(float dmg)
    {
        life -= dmg;
        if(life<=0)
        {
            life = 0;
            Dead();
        }
    }

    public void Dead()
    {

    }
}
