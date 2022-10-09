using UnityEngine;
using TMPro;

namespace Labyrinth
{
    public sealed class PlayerGameOver // здесь помчему-то убрали монобехейвиор, интересно почему?
    {
        private TextMeshProUGUI _gameOverText;

        public PlayerGameOver(TextMeshProUGUI endGameText) // конструктор класса
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

