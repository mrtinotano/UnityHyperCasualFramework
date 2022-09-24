using Utilities;

namespace HyperCasual
{
    public class LevelManager : Singleton<LevelManager>
    {
        public virtual void SetupLevel()
        {
        }

        public virtual void StartLevel()
        {
            UIManager.Instance.ShowLevelCanvas();
        }

        public virtual void EndLevel()
        {
        }
    }
}

