using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float HP;
    public static int Money = 50;
    // Start is called before the first frame update
    void Start()
    {
        HP = 100 + Money / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Money += 25;
            Destroy(gameObject);
        }

        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Turret_Base")
        {
            HP -= 25;
        }
        if (other.gameObject.tag == "Turret_Massive")
        {
            HP -= 75;
        }
    }
}
