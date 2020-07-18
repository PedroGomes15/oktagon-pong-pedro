using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Controlador do HUD na cena de game
/// </summary>
public class HUDManager : MonoBehaviour
{
    public void Awake()
    {
        GameManager.instance.hudManager = this;
    }

    public GameObject endGameObject;

    /// <summary>
    /// Função para dfinir o limite de vida da barra
    /// </summary>
    /// <param name="lifeBar">objeto da barra de vida</param>
    /// <param name="lifeMax">valor maximo da vida</param>
    public void SetupLifeBar(GameObject lifeBar, float lifeMax)
    {
        lifeBar.GetComponent<Slider>().maxValue = lifeMax;
    }

    /// <summary>
    /// Função para dfinir o valor atual na barra
    /// </summary>
    /// <param name="lifeBar">objeto da barra de vida</param>
    /// <param name="life">valor atual vida</param>
    public void SetLifeBar(GameObject lifeBar, float life)
    {
        lifeBar.GetComponent<Slider>().value = life;
    }

    /// <summary>
    /// exibe o fim de jogo
    /// </summary>
    /// <param name="playerWins">Objeto do jogador que ganhou</param>
    /// <param name="player">Classe do jogador</param>
    public void EndGame(GameObject playerWins, Player player)
    {
        endGameObject.SetActive(true);
        Transform panel = endGameObject.transform.Find("Panel");

        string color = ColorUtility.ToHtmlStringRGB(playerWins.GetComponent<SpriteRenderer>().color);

        panel.transform.Find("txtPlayer").GetComponent<TextMeshProUGUI>().text = "PLAYER\n" +
            "<size=100><b><#"+ color+ "> " + (player.playerIndex + 1)+ " </color></b></u></size>\n" +
            "WIN!!";

        Transform playerImage = panel.transform.Find("player");
        playerImage.GetComponent<Image>().color = playerWins.GetComponent<SpriteRenderer>().color;
        playerImage.rotation = playerWins.transform.rotation;
    }

    public void btn_Retry()
    {
        SceneLoadManager.instance.ReloadScene();
    }

    public void btn_Menu()
    {
        SceneLoadManager.instance.LoadScene("Menu");
    }
}
