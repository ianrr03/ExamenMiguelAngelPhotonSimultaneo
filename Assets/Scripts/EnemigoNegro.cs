using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemigoNegro : MonoBehaviour
{
    private NavMeshAgent _agent;

    public int limitX = 4;
    public int limitZ = 4;

    public GameObject gameOverText;

    private Vector3 destination;
    
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        destination = RandomDestination();
        _agent.SetDestination(destination);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, destination) < 0.2f)
        {
            destination = RandomDestination();
            _agent.SetDestination(destination);
        }
    }

    

    private Vector3 RandomDestination()
    {
        return new Vector3(Random.Range(-limitX, limitX), transform.position.y, Random.Range(-limitZ, limitZ));
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
