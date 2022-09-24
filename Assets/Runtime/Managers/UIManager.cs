using UnityEngine;
using TMPro;
using Utilities;

namespace HyperCasual
{
    public class UIManager : Singleton<UIManager>
    {
        [Header("Menus")]
        [SerializeField] private CanvasGroup menuCanvas;
        [SerializeField] private CanvasGroup levelCanvas;
        [SerializeField] private CanvasGroup winCanvas;
        [SerializeField] private CanvasGroup loseCanvas;

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

        public virtual void ShowMenuCanvas()
        {
            HideCurrentCanvas();
            ShowCanvas(menuCanvas);
        }

        public virtual void ShowLevelCanvas()
        {
            HideCurrentCanvas();
            ShowCanvas(levelCanvas);
        }

        public virtual void ShowWinCanvas()
        {
            HideCurrentCanvas();
            ShowCanvas(winCanvas);
        }

        public virtual void ShowLoseCanvas()
        {
            HideCurrentCanvas();
            ShowCanvas(loseCanvas);
        }
    }
}
