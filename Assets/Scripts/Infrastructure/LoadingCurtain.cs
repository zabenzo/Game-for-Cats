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
            Curtain.enabled = true;
            Curtain.alpha = 1;
        }

        public void Hide() => 
            StartCoroutine(HideCurtainRoutine());

        private IEnumerator HideCurtainRoutine()
        {
            while (Curtain.alpha > 0.0f)
            {
                Curtain.alpha -= 0.01f;
                yield return new WaitForSeconds(0.05f);
            }

            Curtain.enabled = false;
        }
    }
}