using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton do controlador geral do jogo
/// </summary>
public class GameManager : MonoBehaviour
{
    #region singleton
    public static GameManager instance = null;

    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    private Player[] players = new Player[2];

    private int currentPlayer = 0;

    private string[] playerBullets = new string[2];

    [HideInInspector]
    public HUDManager hudManager;

    public void StartGame()
    {
        players[currentPlayer].StartMyTurn();
    }

    /// <summary>
    /// Função para carregar um prefab
    /// </summary>
    /// <param name="name">nome do prefab</param>
    /// <returns>Referencia do objeto</returns>
    public Object LoadPrefab(string name)
    {
        return Resources.Load("Prefabs/" + name);
    }

    /// <summary>
    /// Carrega o player no gameManager
    /// </summary>
    /// <param name="player">o script do player</param>
    /// <param name="index">index do jogador</param>
    public void AssignPlayer(Player player, int index)
    {
        players[index] = player;
        players[index].myBullet = playerBullets[index]; 
    }

    /// <summary>
    /// Carrega a bala no player
    /// </summary>
    /// <param name="bullet">o nome do prefab da bala</param>
    /// <param name="index">index do jogador</param>
    public void AssignBullets(string bullet, int index)
    {
        playerBullets[index] = bullet;
    }

    public void NextPlayer()
    {
        if ((currentPlayer + 1) < players.Length)
        {
            currentPlayer++;
        }
        else
        {
            currentPlayer = 0;
        }

        if(players[currentPlayer] != null)
            players[currentPlayer].StartMyTurn();
    }

    public void EndGame(int index)
    {
        foreach(var aux in players)
        {
            if(aux.playerIndex != index)
            {
                hudManager.EndGame(aux.gameObject, aux);
            }
        }
    }
}
