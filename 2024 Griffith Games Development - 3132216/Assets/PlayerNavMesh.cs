using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNavMesh : MonoBehaviour
{
    private Camera mainCamera;
    public Animator animator;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    public float currentVelocity;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        animator = GetComponentInChildren<Animator>();
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //get the velocity of the player
        currentVelocity = navMeshAgent.velocity.magnitude;
        //set the speed of the animator to the velocity of the player
        animator.SetFloat("velocity", currentVelocity);
        // Move towards the mouse click using navmesh
        if (Input.GetMouseButtonDown(0) && mainCamera != null && navMeshAgent != null)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                navMeshAgent.destination = hit.point;
            }
        }
    }
}