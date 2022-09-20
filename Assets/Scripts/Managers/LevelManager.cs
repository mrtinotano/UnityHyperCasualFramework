using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace voodooTest
{
    public abstract class LevelManager : Singleton<LevelManager>
    {
        public int Score { get; private set; }


        public abstract void SetupLevel();

        public virtual void StartLevel()
        {
            CanvasManager.Instance.ShowLevelCanvas();
        }

        public virtual void EndLevel()
        {
            Score = 0;
            CanvasManager.Instance.UpdateLevelScore();
        }

        public void AddScore(int score)
        {
            Score += score;

            CanvasManager.Instance.UpdateLevelScore();
        }
    }
}

