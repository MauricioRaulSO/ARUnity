using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float time;
    public float timePast;
    public float timePased;
    public float difficulty;
    public bool started;

    // Start is called before the first frame update
    void Start()
    {
        started = false;
       
    }

    // Update is called once per frame
    void Update()
    {

        if (started) {
            timePast -= Time.deltaTime;
            timePased += Time.deltaTime;
            if (timePast <= 0.0f)
            {
                timePast = 5;
            }
            time -= Time.deltaTime;
            if (time <= 0.0f)
            {
                Shooter();

                time = 0.50f;
            }

        }
    }

    public void Starter()
    {
        Debug.Log("Start Portal");
        started = true;
    }

    void Shooter()
    {

        float percentX =(float) Random.Range(-0.5f, 0.5f);
        float percentY = (float) Random.Range(-0.5f, 0.5f);

        GameObject proy = Instantiate(enemy,  new Vector3(gameObject.transform.position.x + percentX, gameObject.transform.position.y + percentY, 
            gameObject.transform.position.z), Quaternion.identity);
        proy.GetComponent<EnemyMovement>().Velocity += timePased * difficulty;
        Destroy(proy, 5);

    }

}
