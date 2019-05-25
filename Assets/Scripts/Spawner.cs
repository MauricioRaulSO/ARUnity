using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject[] lanes= new GameObject[9];
    public float time;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0.0f)
        {
            Shoot();

            time = 0.50f;
        }
        
    }

    void Shoot()
    {
        int rndm = (int)Random.Range(0, 9);
        if (rndm == 0)
        {
           GameObject proy=  Instantiate(enemy, lanes[0].transform.position, Quaternion.identity);
            Destroy(proy, 5);
        }
        if (rndm == 1)
        {
            GameObject proy = Instantiate(enemy, lanes[1].transform.position, Quaternion.identity);
            Destroy(proy, 5);
        }
        if (rndm == 2)
        {
            GameObject proy = Instantiate(enemy, lanes[2].transform.position, Quaternion.identity);
            Destroy(proy, 5);
        }

        if (rndm == 3)
        {
            GameObject proy = Instantiate(enemy, lanes[3].transform.position, Quaternion.identity);
            Destroy(proy, 5);
        }
        if (rndm == 4)
        {
            GameObject proy = Instantiate(enemy, lanes[4].transform.position, Quaternion.identity);
            Destroy(proy, 5);
        }
        if (rndm == 5)
        {
            GameObject proy = Instantiate(enemy, lanes[5].transform.position, Quaternion.identity);
            Destroy(proy, 5);
        }

        if (rndm == 6)
        {
            GameObject proy = Instantiate(enemy, lanes[6].transform.position, Quaternion.identity);
            Destroy(proy, 5);
        }
        if (rndm == 7)
        {
            GameObject proy = Instantiate(enemy, lanes[7].transform.position, Quaternion.identity);
            Destroy(proy, 5);
        }
        if (rndm == 8)
        {
            GameObject proy = Instantiate(enemy, lanes[8].transform.position, Quaternion.identity);
            Destroy(proy, 5);
        }

    }


}
