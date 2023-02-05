using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class DoorBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private ExperimentManager _experimentManager;
    private Animator _doorAnimator;
    private int experimentCounter;
    private float timer = 0;
    public GameObject detector;
    private Animator detectorAnimator;
    private DetectorBehavior detectorBehavior;


    void Start()
    {
        _experimentManager = GetComponentInParent<ExperimentManager>();
        _doorAnimator = GetComponent<Animator>();
        detectorAnimator = detector.GetComponent<Animator>();
        detectorBehavior = detector.GetComponent<DetectorBehavior>();

        startExperiment();
    }

    // Update is called once per frame
    void Update()
    {
        if (_experimentManager.isSpawnInProgress)
        {
            timer += Time.deltaTime;
        }

        if (timer > _experimentManager.timeToDecide)
        {
            _doorAnimator.SetBool("OpenBool", false);
            timer = 0;
        }
    }

    void startExperiment()
    {
        _doorAnimator.SetBool("OpenBool", true);
    }

    void SpawnCommand()
    {
        _experimentManager.currentSpawn = Instantiate(
            _experimentManager.spawnsList[Random.Range(0, _experimentManager.spawnsList.Count)],
            _experimentManager.spawnsPosition.transform.position,
            Quaternion.identity);
        _experimentManager.isSpawnInProgress = true;
        _experimentManager.playerController.inputReading = true;

        int detectorDecision = Random.Range(1, 3);
        if (detectorDecision == 1)
        {
            detectorBehavior.sign = 1;
            detectorAnimator.SetBool("Reset", false);
            detectorAnimator.SetBool("Blue", true);
        }

        if (detectorDecision == 2)
        {
            detectorBehavior.sign = 2;
            detectorAnimator.SetBool("Reset", false);
            detectorAnimator.SetBool("Red", true);
        }
    }

    void EndSpawnCommand()
    {
        _experimentManager.isSpawnInProgress = false;
        _experimentManager.playerController.inputReading = false;
        _experimentManager.currentSpawn.GetComponent<Animator>().SetTrigger("SpawnEnd");
        detectorAnimator.SetBool("Reset", true);
        detectorAnimator.SetBool("Red", false);
        detectorAnimator.SetBool("Blue", false);

        experimentCounter++;
        if (experimentCounter < _experimentManager.numberOfSpawns)
        {
            startExperiment();
        }
        else
        {
            Debug.Log(_experimentManager.playerInputs.Count);
        }
    }
}