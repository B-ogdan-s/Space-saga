using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMoney : MonoBehaviour
{
    public Money money;

    void Update()
    {
        GetComponent<Text>().text = (money.money).ToString();
    }
}
