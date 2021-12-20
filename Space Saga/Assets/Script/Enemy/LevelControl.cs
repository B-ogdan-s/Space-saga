using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    public GameObject enemy, goal;
    public EnemyAI ai;

    public GameObject[] clon = new GameObject[20];

    public int tyme = 0;

    void Start()
    {
        clon[0] = enemy;

        for(int i = 1; i<20; i++)
        {
            clon[i] = Instantiate(enemy);
            ai = clon[i].GetComponent<EnemyAI>();
            ai.MutantS();
        }
    }

    void Update()
    {
        int n = 0, num = 0;
        float dlin = 0f;

        if(tyme >= 500)
        {
            for (int i = 0; i < 20; i++)
            {
                if (clon[i] != null)
                {
                    if(n==0)
                    {
                        dlin = Vector3.Distance(clon[i].transform.position, goal.transform.position);
                        num = i;
                    }
                    else if(n>0 && dlin > Vector3.Distance(clon[i].transform.position, goal.transform.position))
                    {
                        dlin = Vector3.Distance(clon[i].transform.position, goal.transform.position);
                        num = i;
                    }
                }
            }
            if(clon[num] != null)
            {
                ai = clon[num].GetComponent<EnemyAI>();
                ai.SavingWeights();
            }
            SceneManager.LoadScene("TestEnemy");
        }

        for(int i=0; i<20; i++)
        {
            if(clon[i]!=null)
            {
                n++;
                num = i;
            }
        }
        if(n==1)
        {
            ai = clon[num].GetComponent<EnemyAI>();
            ai.SavingWeights();
            SceneManager.LoadScene("TestEnemy");
        }
        tyme++;
    }
}
