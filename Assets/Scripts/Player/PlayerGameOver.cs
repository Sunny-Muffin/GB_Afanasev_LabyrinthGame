using UnityEngine;
using TMPro;

namespace Labyrinth
{
    public sealed class PlayerGameOver // ����� �������-�� ������ �������������, ��������� ������?
    {
        private TextMeshProUGUI _gameOverText;

        public PlayerGameOver(TextMeshProUGUI endGameText) // ����������� ������
        {
            _gameOverText = endGameText;
            _gameOverText.text = string.Empty;
        }
        
        public void GameOver()
        {
            //Debug.Log("BOOM");
            _gameOverText.text = "WASTED";
        }
    }
}

