using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
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
            Shooter();

            time = 0.50f;
        }
        
    }

    void Shooter()
    {

        float percentX =(float) Random.Range(-0.5f, 0.5f);
        float percentY = (float) Random.Range(-0.5f, 0.5f);

        GameObject proy = Instantiate(enemy,  new Vector3(gameObject.transform.position.x + percentX, gameObject.transform.position.y + percentY, 
            gameObject.transform.position.z), Quaternion.identity);
        Destroy(proy, 5);

    }

}
