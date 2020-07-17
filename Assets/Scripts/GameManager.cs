using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        players[currentPlayer].StartMyTurn();
    }

    public Object LoadPrefab(string name)
    {
        return Resources.Load("Prefabs/" + name);
    }

    public void AssignPlayer(Player player, int pos)
    {
        players[pos] = player;
    }

    public void NextPlayer()
    {
        players[currentPlayer].EndMyTurn();

        if ((currentPlayer+1)<players.Length)
        {
            currentPlayer++;
        }
        else
        {
            currentPlayer = 0;
        }
        players[currentPlayer].StartMyTurn();
    }
}
