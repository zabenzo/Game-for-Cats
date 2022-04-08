using System.Collections;
using UnityEngine;

namespace Infrastructure
{
    public class LoadingCurtain : MonoBehaviour
    {
        public CanvasGroup Curtain;
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Show()
        {
            Curtain.gameObject.SetActive(true);
            Curtain.alpha = 1.0f;
        }

        public void Hide() => 
            StartCoroutine(HideCurtainRoutine());

        private IEnumerator HideCurtainRoutine()
        {
            while (Curtain.alpha > 0.0f)
            {
                Curtain.alpha -= 0.05f;
                yield return new WaitForSeconds(0.05f);
            }

            Curtain.gameObject.SetActive(false);
        }
    }
}