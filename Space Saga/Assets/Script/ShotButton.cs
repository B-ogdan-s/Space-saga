using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotButton : MonoBehaviour
{
    public bool shot = false;

    public void Shot()
    {
        shot = true;
    }

    public void Shot2()
    {
        shot = false;
    }
}
