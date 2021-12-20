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
         * ������ ������ �� �������� "Money"
         * ������������ �� ������ ���������� hP
         * � ��������� ��� �����������
         */

        save = GameObject.Find("Spaceship").GetComponent<Save>();
        saveUp = GameObject.Find("Spaceship").GetComponent<SaveUp>();

        hP = (int)(transform.localScale.x * 300f);
        price = (int)(transform.localScale.x * 3); 
    }

    /*
     * �������� ���������� hP
     * ���� ��� <= 0 �������� �� ���� 
     * ������ ��������� ����� ������� 
     * � ��������� ���
     */
    public void DestroyAsteroid()
    {
        efect.transform.position = transform.position;
        Instantiate(efect);

        destroy = true;

        Destroy(gameObject);
    }

    /*
     * �������� �� ������� � ������� 
     * �� ������ ����� ��� "Lazer"
     * � ���� ������ �������� ��������� 
     * ���������� hP
     */
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lazer")
        {
            hP -= save.AttackSpac() + (saveUp.OutputAttack());
        }
    }
}
