using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace voodooTest
{
    public class CanvasManager : Singleton<CanvasManager>
    {
        [Header("Menus")]
        [SerializeField] private CanvasGroup menuCanvas;
        [SerializeField] private CanvasGroup levelCanvas;
        [SerializeField] private CanvasGroup winCanvas;
        [SerializeField] private CanvasGroup loseCanvas;

        [Header("Scores")]
        [SerializeField] private TextMeshProUGUI menuScoreText;
        [SerializeField] private TextMeshProUGUI levelScoreText;
        [SerializeField] private TextMeshProUGUI winScoreText;

        private CanvasGroup currentCanvas;


        private void HideCurrentCanvas()
        {
            if (currentCanvas != null)
            {
                currentCanvas.alpha = 0;
                currentCanvas.blocksRaycasts = false;
                currentCanvas.interactable = false;
            }
        }

        private void ShowCanvas(CanvasGroup group)
        {
            group.alpha = 1;
            group.blocksRaycasts = true;
            group.interactable = true;

            currentCanvas = group;
        }

        public void ShowMenuCanvas()
        {
            HideCurrentCanvas();
            menuScoreText.text = GameManager.Instance.TotalScore.ToString();
            ShowCanvas(menuCanvas);
        }

        public void ShowLevelCanvas()
        {
            HideCurrentCanvas();
            ShowCanvas(levelCanvas);
        }

        public void ShowWinCanvas()
        {
            HideCurrentCanvas();
            winScoreText.text = LevelManager.Instance.Score.ToString();
            ShowCanvas(winCanvas);
        }

        public void ShowLoseCanvas()
        {
            HideCurrentCanvas();
            ShowCanvas(loseCanvas);
        }

        public void UpdateLevelScore()
        {
            levelScoreText.text = LevelManager.Instance.Score.ToString();
        }
    }
}
