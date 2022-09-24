using UnityEngine;
using Utilities;

namespace HyperCasual
{
    public class GameManager : Singleton<GameManager>
    {
        public enum GameState
        {
            Idle,
            Playing
        }

        public GameState State { get; private set; } = GameState.Idle;

        [SerializeField] private int TargetFrameRate = 60;


        protected override void Awake()
        {
            base.Awake();

            Application.targetFrameRate = TargetFrameRate;

            LoadData();
        }

        protected virtual void Start()
        {
            UIManager.Instance.ShowMenuCanvas();
            PrepareLevel();
        }

        public virtual void StartGame()
        {
            if (State != GameState.Idle)
                return;

            State = GameState.Playing;

            LevelManager.Instance.StartLevel();
        }

        public virtual void EndGame(bool win)
        {
            if (State != GameState.Playing)
                return;

            State = GameState.Idle;

            if (win)
            {
                UIManager.Instance.ShowWinCanvas();
            }
            else
            {
                UIManager.Instance.ShowLoseCanvas();
            }

            SaveData();
        }

        protected virtual void PrepareLevel()
        {
            UIManager.Instance.ShowMenuCanvas();
            LevelManager.Instance.SetupLevel();
        }

        protected virtual void SaveData()
        {
        }

        protected virtual void LoadData()
        {
        }
    }
}

