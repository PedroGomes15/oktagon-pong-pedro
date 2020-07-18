using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Script para seleção da bala no menu
/// </summary>
public class SelectBulletPlayer : MonoBehaviour
{
    public MenuManager menuManager;

    private int bullet;

    public Vector2 startSize;

    public int player;

    private void Start()
    {
        startSize = this.transform.Find("IconBullet").GetComponent<RectTransform>().sizeDelta;
        LoadBullet();
    }

    public void btn_NextBullet()
    {
        if((bullet+1)>= menuManager.bullets.Length)
        {
            bullet = 0;
        }
        else
        {
            bullet += 1;
        }
        LoadBullet();
    }

    public void btn_PrevBullet()
    {

        if ((bullet - 1) < 0)
        {
            bullet = menuManager.bullets.Length-1;
        }
        else
        {
            bullet -= 1;
        }
        LoadBullet();
    }

    public void LoadBullet()
    {
        this.transform.Find("bulletName").GetComponent<TextMeshProUGUI>().text = menuManager.bullets[bullet].bulletName;
        this.transform.Find("IconBullet").GetComponent<Image>().color = menuManager.bullets[bullet].bulletColor;
        this.transform.Find("IconBullet").GetComponent<RectTransform>().sizeDelta = startSize * menuManager.bullets[bullet].size;

        menuManager.addToSelectedBullets(player, menuManager.bullets[bullet]);
    }
}
