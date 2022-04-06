using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CubeRegistry : MonoBehaviour
{
    public static CubeRegistry Instance { get; private set; }

    public List<ManufacturedCube> _RegisteredCubes = new List<ManufacturedCube>();

    public static List<ManufacturedCube> RegisteredCubes => Instance._RegisteredCubes;

    private void Awake()
    {
        // does the instance already exist
        if (Instance != null)
        {
            Debug.LogError($"Found duplicate CubeRegistry on {gameObject.name}. Destroying this version");
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

    public static void Register(ManufacturedCube cube)
    {
        Instance.RegisterInternal(cube);
    }

    public static void Deregister(ManufacturedCube cube)
    {
        if (Instance != null)
            Instance.DeregisterInternal(cube);
    }

    void RegisterInternal(ManufacturedCube cube)
    {
        if (_RegisteredCubes.Contains(cube))
        {
            Debug.LogError($"Attempting to add {cube.gameObject.name} multiple times to the registry");
            return;
        }

        _RegisteredCubes.Add(cube);
    }

    void DeregisterInternal(ManufacturedCube cube)
    {
        if (!_RegisteredCubes.Remove(cube))
            Debug.LogError($"Attempting to remove unknown cube {cube.gameObject.name} from the registry");
    }
}
