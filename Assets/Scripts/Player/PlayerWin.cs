using Labyrinth;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Labyrinth
{
public class PlayerWin : MonoBehaviour
{
    [SerializeField] private GameObject _victoryScreen;
    [SerializeField] private TextMeshProUGUI _winText;
    private Player[] _playersList;

    private void Awake()
    {
        _victoryScreen.SetActive(false);
        _winText.text = string.Empty;
        _playersList = Object.FindObjectsOfType<Player>();
        Player1.PlayerVictory += MakeWinScreen;
        Player2.PlayerVictory += MakeWinScreen;
    }

    public void MakeWinScreen(GameObject player)
    {
        _victoryScreen.SetActive(true);
        _winText.text = $"{player.name} WINS!";
        // it will be good to stop time here, or unbind players
    }

}
}
