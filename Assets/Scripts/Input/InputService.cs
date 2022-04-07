using UnityEngine;

namespace Input
{
    public class InputService : IInputService
    {
        public bool TouchInMouse(Collider2D mouse)
        {
            if (UnityEngine.Input.touchCount > 0)
            {
                if (UnityEngine.Input.GetTouch(0).phase == TouchPhase.Stationary || UnityEngine.Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(UnityEngine.Input.GetTouch(0).position);
                    Vector3 touch = new Vector3(touchPosition.x, touchPosition.y, 0.0f);
                    
                    if (mouse.bounds.Contains(touch))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}