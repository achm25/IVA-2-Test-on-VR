using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnsBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private ExperimentManager _experimentManager;
    
            

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestorySpawn()
    {
        Destroy(gameObject);
    }
}
