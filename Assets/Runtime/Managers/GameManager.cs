using UnityEngine;
using Utilities;

namespace HyperCasual
{
    public class GameManager : Singleton<GameManager>
    {
        private enum GameState
        {
            Idle,
            Playing
        }

        private GameState gameState = GameState.Idle;

        public int TotalScore { get; private set; }
        public int CurrentLevel { get; private set; }


        private const string TotalScoreKey = "TotalScore"; 
        private const string CurrentLevelKey = "CurrentLevel"; 


        protected override void Awake()
        {
            base.Awake();

            Application.targetFrameRate = 60;

            LoadData();
        }

        private void Start()
        {
            CanvasManager.Instance.ShowMenuCanvas();
            PrepareLevel();
        }

        public void StartGame()
        {
            if (gameState != GameState.Idle)
                return;

            LevelManager.Instance.StartLevel();
        }

        public void EndGame(bool win)
        {
            if (win)
            {
                TotalScore += LevelManager.Instance.Score;
                CanvasManager.Instance.ShowWinCanvas();
            }
            else
            {
                CanvasManager.Instance.ShowLoseCanvas();
            }

            SaveData();
        }

        private void PrepareLevel()
        {
            CanvasManager.Instance.ShowMenuCanvas();
            LevelManager.Instance.SetupLevel();
        }

        protected virtual void SaveData()
        {
            PlayerPrefs.SetInt(TotalScoreKey, TotalScore);
            PlayerPrefs.SetInt(CurrentLevelKey, CurrentLevel);
            PlayerPrefs.Save();
        }

        protected virtual void LoadData()
        {
            //Check if file exist
            if (!PlayerPrefs.HasKey(TotalScoreKey))
                return;

            TotalScore = PlayerPrefs.GetInt(TotalScoreKey);
            CurrentLevel = PlayerPrefs.GetInt(CurrentLevelKey);
        }
    }
}

