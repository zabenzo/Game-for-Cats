using UnityEngine;
using Utility;

public class Test : MonoBehaviour
{
    private ScreenUtility _screenUtility;
    
    private void Awake()
    {
        _screenUtility = new ScreenUtility();

        Debug.Log(_screenUtility.LeftLimit());
        Debug.Log(_screenUtility.RightLimit());
        Debug.Log(_screenUtility.TopLimit());
        Debug.Log(_screenUtility.BottomLimit());
    }
}