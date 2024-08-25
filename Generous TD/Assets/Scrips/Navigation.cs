using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject Base;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Base = GameObject.Find("Base");
    }

    // Update is called once per frame
    void Update()
    {
        SetDestination();
    }

    public void SetDestination()
    {
        agent.SetDestination(Base.transform.position);
    }
}
