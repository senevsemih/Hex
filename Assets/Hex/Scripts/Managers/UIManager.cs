using System.Collections;
using Assets.Hex.Scripts.Managers.Singleton;
using UnityEngine;

namespace Assets.Hex.Scripts.Managers
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private GameObject _nextLevelText;

        public void ActivateGoalText()
        {
            StartCoroutine(WaitForActivate());
        }
        
        private IEnumerator WaitForActivate()
        {
            yield return new WaitForSeconds(3f);
            _nextLevelText.SetActive(true);
        }
    }
}
