using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperimentManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Transform spawnsPosition;
    [SerializeField] public PlayerController playerController;

    [SerializeField] public List<GameObject> spawnsList;
    [SerializeField] public List<int> playerInputs;
    [SerializeField] public int numberOfSpawns;
    [SerializeField] public int timeToDecide;
    [SerializeField] public float startTime = 5f;
    public GameObject currentSpawn;
    public bool isSpawnInProgress;
    [SerializeField] private Animator doorAnimator;
    private int currentSpawnNumber = 0;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // if (currentSpawnNumber < numberOfSpawns && !isSpawnInProgress)
        // {
        //     StartCoroutine(HandleSpawn(timeToDecide));
        // }

    }



}
   

    