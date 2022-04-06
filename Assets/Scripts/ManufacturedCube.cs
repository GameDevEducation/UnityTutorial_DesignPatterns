using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManufacturedCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CubeRegistry.Register(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLife(float time)
    {
        Destroy(gameObject, time);
    }

    private void OnDestroy()
    {
        CubeRegistry.Deregister(this);
    }
}
