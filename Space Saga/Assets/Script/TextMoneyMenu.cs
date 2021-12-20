using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMoneyMenu : MonoBehaviour
{
    public Text money;
    public Save save;

    void Update()
    {
        money.text = "" + (save.OutputMoney());
    }
}
