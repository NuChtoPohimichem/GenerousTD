using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject Prefab;
    [SerializeField] Transform Start_Object;
    [SerializeField] public int[] Enemy_count;
    int Count;
    int Wave = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Count = Enemy_count[Wave];
    }

    public void Spawn()
    {
        Instantiate(Prefab, Start_Object.position, Start_Object.rotation);
    }
    public void Spawning() 
    {
        for (int j = 0; j < Count; j++)
        {
            Invoke("Spawn", 1f);
        }
        Wave++;
        
    }
}


