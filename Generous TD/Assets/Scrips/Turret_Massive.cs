using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Massive : MonoBehaviour
{
    new Transform transform;
    [SerializeField] GameObject Head;
    [SerializeField] GameObject Point;
    [SerializeField] GameObject Prefab_bullet;
    [SerializeField] Transform Cannon;
    public int bulletForce = 30;
    private float cooldown = 3f;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        Point = GameObject.Find("Point");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Head.transform.LookAt(other.transform);
            if (timer > cooldown)
            {
                Shoot();
                timer = 0f;
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        transform.position = Point.transform.position;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(Prefab_bullet, Cannon.position, Cannon.rotation);
        bullet.tag = "Turret_Massive";
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(Cannon.forward * bulletForce, ForceMode.Impulse);
    }
}
