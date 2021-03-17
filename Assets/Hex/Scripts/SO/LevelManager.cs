using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Hex.Scripts.SO
{
    [CreateAssetMenu(fileName = "Level Manager", menuName = "Hex/Level Settings")]
    public class LevelManager : ScriptableObject
    {
        public void Next()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
