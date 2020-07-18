using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controlador da cena de menu
/// </summary>
public class MenuManager : MonoBehaviour
{
    public BulletUi[] bullets;

    private BulletUi[] selectedBullets = new BulletUi[2];

    public void btn_Start()
    {
        SceneLoadManager.instance.LoadScene("LevelGame");
        GameManager.instance.AssignBullets(selectedBullets[0].prefabName, 0);
        GameManager.instance.AssignBullets(selectedBullets[1].prefabName, 1);
    }

    public void addToSelectedBullets(int pos, BulletUi bullet)
    {
        selectedBullets[pos] = bullet;
    }
}
