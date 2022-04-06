using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CubeFactory : MonoBehaviour
{
    [SerializeField] GameObject CubePrefab;

    public static CubeFactory Instance { get; private set; }

    int NextCubeNumber = 1;

    private void Awake()
    {
        // does the instance already exist
        if (Instance != null)
        {
            Debug.LogError($"Found duplicate CubeFactory on {gameObject.name}. Destroying this version");
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static ManufacturedCube BuildCube(Transform parentTransform, Vector3 location, float range)
    {
        return Instance.BuildCubeInternal(parentTransform, location, range);
    }

    private ManufacturedCube BuildCubeInternal(Transform parentTransform, Vector3 location, float range)
    {
        Vector3 spawnLocation = location + new Vector3(Random.Range(-range, range),
                                                       Random.Range(-range, range),
                                                       Random.Range(-range, range));

        GameObject cubeGO = Instantiate(CubePrefab, spawnLocation, Quaternion.identity, parentTransform);
        cubeGO.name = $"ManufacturedCube_{NextCubeNumber}";

        ManufacturedCube cubeScript = cubeGO.GetComponent<ManufacturedCube>();
        cubeScript.SetLife(Random.Range(0.1f, 2f));

        ++NextCubeNumber;

        return cubeScript;
    }
}
