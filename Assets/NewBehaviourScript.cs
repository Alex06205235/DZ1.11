using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] PlatformPrefabs;
    //public GameObject FirstPlatformPrefab;
    public int MinPlatforms;
    public int MaxPlatforms;
    public float DistanceBetweenPlatforms;
    public Transform FinishPlatform;
    //public Transform CylindrRoot;
    //public float ExtraCylinderScale = 1f;
    //public Game Game;

    void Awake()
    {
        int platformsCount = Random.Range(MinPlatforms, MaxPlatforms + 1);
        for (int i = 0; i < platformsCount; i++)
        {
            int prefabIndex = Random.Range(0, PlatformPrefabs.Length);
            GameObject platform= Instantiate(PlatformPrefabs[prefabIndex], transform);
            platform.transform.localPosition = new Vector3(0, DistanceBetweenPlatforms * i, 0);
            platform.transform.localRotation = Quaternion.Euler(0, Random.Range(0, 360f), 0);
        }
        FinishPlatform.localPosition = CalculatePlatformPosition(platformsCount);
    }
    private Vector3 CalculatePlatformPosition(int PlatformIndex)
    {
        return new Vector3(0, -DistanceBetweenPlatforms * PlatformIndex, 0);
    }
}
