using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    [SerializeField] float _RotationRate = 15f;

    public static float RotationRate => Instance._RotationRate;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // does the instance already exist
        if (Instance != null)
        {
            Debug.LogError($"Found duplicate GameManager on {gameObject.name}. Destroying this version");
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
        if (Input.GetKeyDown(KeyCode.S))
            CubeFactory.BuildCube(transform, transform.position, 10f);

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            foreach(var cube in CubeRegistry.RegisteredCubes)
                Destroy(cube.gameObject);
        }
    }

    public static void SetRandomRotation(Transform target)
    {
        Instance.SetRandomRotationInternal(target);
    }

    private void SetRandomRotationInternal(Transform target)
    {
        target.eulerAngles = new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
    }
}
