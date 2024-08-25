using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower_spawn : MonoBehaviour
{
    [SerializeField] GameObject Prefab;
    [SerializeField] int count;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        GameObject buf = Instantiate(Prefab);
        float x = Random.Range(0, 60);
        float z = Random.Range(-25, 25);
        buf.transform.position = transform.position + new Vector3(x, -0.4f, z);
        
    }
}


