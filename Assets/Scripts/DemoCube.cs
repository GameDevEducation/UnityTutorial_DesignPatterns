using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoCube : MonoBehaviour
{
    private void Awake()
    {
        // Don't try to talk to the singleton in Awake (or generally other objects in awake either)
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.SetRandomRotation(transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, GameManager.RotationRate * Time.deltaTime, 0f);
    }

    private void OnDestroy()
    {
        // if we're being destroyed null check before talking to the singleton
        if (GameManager.Instance != null)
        {

        }
    }
}
