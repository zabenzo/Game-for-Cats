using UnityEngine;

namespace Utility
{
    public class ScreenUtility : IScreenUtility
    {
        private const float WidthToMaintain = 5.0f;

        public ScreenUtility() => 
            SetupScreen();

        public float LeftLimit() => 
            Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f)).x;

        public float RightLimit() => 
            Camera.main.ViewportToWorldPoint(new Vector3(1.0f, 0.0f, 0.0f)).x;

        public float TopLimit() =>
            Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 1.0f, 0.0f)).y;

        public float BottomLimit() => 
            Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f)).y;

        private void SetupScreen()
        {
            float height = Camera.main.orthographicSize * 2.0f;
            float width = height * Camera.main.aspect;

            if (width != WidthToMaintain)
            {
                Camera.main.orthographicSize = WidthToMaintain / Camera.main.aspect;
            }
        }
    }
}