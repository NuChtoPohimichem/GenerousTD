using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject Base_Turret;
    [SerializeField] private GameObject Massive_Turret;
    [SerializeField] TextMeshProUGUI Money_TXT;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Money_TXT.text = Enemy.Money.ToString(); 
    }

    public void Buy_Base_Turret()
    {
        if (Enemy.Money >= 50)
        {
            GameObject buf = Instantiate(Base_Turret);
            float x = Random.Range(-15, 20);
            float z = Random.Range(-13, 10);
            buf.transform.position = transform.position + new Vector3(x, 6f, z);
            Enemy.Money -= 50;
        }
    }
    public void Buy_Massive_Turret()
    {
        if (Enemy.Money >= 100)
        {
            GameObject buf = Instantiate(Massive_Turret);
            float x = Random.Range(-15, 20);
            float z = Random.Range(-13, 10);
            buf.transform.position = transform.position + new Vector3(x, 6f, z);
            Enemy.Money -= 100;
        }
    }
}
