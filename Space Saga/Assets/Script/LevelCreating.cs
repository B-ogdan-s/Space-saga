using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreating : MonoBehaviour
{
    public GameObject asteroyd;
    public AsteroidInfo[] asterod;
    public int numberOfAsteroids;

    /*
     * создаёт препяствея на уровне
     */
    void Start()
    {
        for(int i = 0; i < numberOfAsteroids; i++)
        {
            asteroyd.transform.position = new Vector3(Random.Range(-2500f, 2500f), Random.Range(-2500f, 2500f), Random.Range(-2500f, 2500f));
            float scale = Random.Range(7f, 15f);
            asteroyd.transform.localScale = new Vector3(scale, scale, scale);
            Instantiate(asteroyd);
        }

        asterod = FindObjectsOfType(typeof(AsteroidInfo)) as AsteroidInfo[];
    }
}
