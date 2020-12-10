using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using CubeGameSample;
using UnityEngine;

public class AutoCubeGenerator : MonoBehaviour
{

    [SerializeField]
    private GameObject cubePrefab;

    [SerializeField]
    private int maxCube = 1000;
    
    [SerializeField]
    private int seed = 0;

    private GameObject root;
    
    void Start()
    {
        Random.seed = seed;
        AutoGenerate();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AutoGenerate();
        }
    }

    public void AutoGenerate()
    {
        if (root) Destroy(root);
        root = new GameObject();
        root.transform.position = Vector3.zero;
        CubeBehaviour prevCube = null;
        for (int i = 0;i<maxCube;i++)
        {
            GameObject obj = Instantiate(cubePrefab);
            obj.transform.parent = root.transform;
            CubeBehaviour cube = obj.GetComponent<CubeBehaviour>();
            if (prevCube == null)
            {
                prevCube = cube;
                continue;
            }

            int rand = Random.Range(0,6);

            switch (rand)
            {
                case 0:
                    CubeBehaviour.SetRight(prevCube,cube);
                    break;
                case 1:
                    CubeBehaviour.SetLeft(prevCube,cube);
                    break;
                case 2:
                    CubeBehaviour.SetBack(prevCube,cube);
                    break;
                case 3:
                    CubeBehaviour.SetFront(prevCube,cube);
                    break;
                case 4:
                    CubeBehaviour.SetUpper(prevCube,cube);
                    break;
                case 5:
                    CubeBehaviour.SetLower(prevCube,cube);
                    break;
            }

            prevCube = cube;
        }
    }
}
