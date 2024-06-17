using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemigoRojo : MonoBehaviour
{
    private NavMeshAgent _agent;

    public Transform [] esquinas;

    private Vector3 currentDestination;
    private int nextPoint = 0;

    public GameObject gameOverText;

    public float maxPosition = 4;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        
        if(esquinas.Length > 0)
        {
            currentDestination = esquinas[nextPoint].position;
            _agent.SetDestination(currentDestination);
            nextPoint++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, currentDestination) < 0.2f)
        {
            currentDestination = esquinas[nextPoint].position;
            _agent.SetDestination(currentDestination);
            nextPoint++;
            if (nextPoint > 3) nextPoint = 0;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameOverText.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
