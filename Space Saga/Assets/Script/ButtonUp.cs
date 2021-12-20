using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUp : MonoBehaviour
{
    public SaveUp saveUp;
    public Save save;

    public void ButtonUpAttack()
    {
        if (save.OutputMoney() >= saveUp.OutputAttack() * 50 + 100)
        {
            //save.InputMoney(-(0));
            //saveUp.InputAttack(0);

            save.InputMoney(-(saveUp.OutputAttack() * 50 + 100));
            saveUp.InputAttack(saveUp.OutputAttack() + 1);
        }
    }

    public void ButtonUpHp()
    {
        if (save.OutputMoney() >= saveUp.OutputHp() * 50 + 100)
        {
            //save.InputMoney(-(0));
            //saveUp.InputHp(0);

            save.InputMoney(-(saveUp.OutputHp() * 50 + 100));
            saveUp.InputHp(saveUp.OutputHp() + 1);
        }
    }

    public void ButtonUpAccelerationSpeed()
    {
        if (save.OutputMoney() >= saveUp.OutputAccelerationSpeed() * 50 + 100)
        {
            //save.InputMoney(-(0));
            //saveUp.InputAccelerationSpeed(0);

            save.InputMoney(-(saveUp.OutputAccelerationSpeed() * 50 + 100));
            saveUp.InputAccelerationSpeed(saveUp.OutputAccelerationSpeed() + 1);
        }
    }

    public void ButtonUpAccelerationRotat()
    {
        if (save.OutputMoney() >= saveUp.OutputAccelerationRotat() * 50 + 100)
        {
            //save.InputMoney(-(0));
            //saveUp.InputAccelerationRotat(0);

            save.InputMoney(-(saveUp.OutputAccelerationRotat() * 50 + 100));
            saveUp.InputAccelerationRotat(saveUp.OutputAccelerationRotat() + 1);
        }
    }
}
