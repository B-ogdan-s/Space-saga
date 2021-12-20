using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidInfo : MonoBehaviour
{
    public Save save;
    public SaveUp saveUp;
    public GameObject efect;
    public int hP, price;
    public bool destroy = false;

    void Start()
    {
        /*
         * нахожу объект со скриптом "Money"
         * устанавливою на объект количество hP
         * и стоимость при уничтожении
         */

        save = GameObject.Find("Spaceship").GetComponent<Save>();
        saveUp = GameObject.Find("Spaceship").GetComponent<SaveUp>();

        hP = (int)(transform.localScale.x * 300f);
        price = (int)(transform.localScale.x * 3); 
    }

    /*
     * провер€ю количество hP
     * если оно <= 0 начисл€ю на счЄт 
     * игрока стоимость этого объекта 
     * и уничтожаю эго
     */
    public void DestroyAsteroid()
    {
        efect.transform.position = transform.position;
        Instantiate(efect);

        destroy = true;

        Destroy(gameObject);
    }

    /*
     * проверка на триггер с объктом 
     * на которм весит тег "Lazer"
     * и если тригер сработал уменьшаем 
     * количество hP
     */
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lazer")
        {
            hP -= save.AttackSpac() + (saveUp.OutputAttack());
        }
    }
}
