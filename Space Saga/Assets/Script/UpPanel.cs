using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpPanel : MonoBehaviour
{
    public SaveUp savaUp;
    public Text[] levelText, priceText; 

    void Update()
    {
        levelText[0].text = "Óð.: " + (savaUp.OutputAttack() + 1);
        levelText[1].text = "Óð.: " + (savaUp.OutputAccelerationSpeed() + 1);
        levelText[2].text = "Óð.: " + (savaUp.OutputAccelerationRotat() + 1);
        levelText[3].text = "Óð.: " + (savaUp.OutputHp() + 1);

        priceText[0].text = "" + (savaUp.OutputAttack() * 50 + 100);
        priceText[1].text = "" + (savaUp.OutputAccelerationSpeed() * 50 + 100);
        priceText[2].text = "" + (savaUp.OutputAccelerationRotat() * 50 + 100);
        priceText[3].text = "" + (savaUp.OutputHp() * 50 + 100);
    }
}
