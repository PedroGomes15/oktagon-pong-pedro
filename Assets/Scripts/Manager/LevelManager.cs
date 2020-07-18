using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controlador simples dentro do level
/// </summary>
public class LevelManager : MonoBehaviour
{
    void Start()
    {
        GameManager.instance.StartGame();   
    }
}
