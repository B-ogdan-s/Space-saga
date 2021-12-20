using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestFPS : MonoBehaviour
{
    public static float fps;

    void Update()
    {
        fps = 1f / Time.deltaTime;
        
        GetComponent<Text>().text = ((int)fps).ToString();
    }
}
