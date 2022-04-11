using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "Default Mouse", menuName = "Static Data/Mouse", order = 0)]
    public class MouseType : ScriptableObject
    {
        public GameObject MousePrefab;
        public AudioClip MouseSound;
        public float Speed;
        public float SoundDelay;
    }
}