using UnityEngine;
using Random = System.Random;

public class LevelGeneration : MonoBehaviour
{
    public GameObject[] PlatformPrefabs;
    public GameObject FirstPlatformPrefab;
    public int MinPlatforms;
    public int MaxPlatforms;
    public float DistanceBetweenPlatforms;
    public Transform FinishPlatform;
    public Transform CylindrRoot;
    public float ExtraCylinderScale = 1f;
    public Game Game;

    void Awake()
    {
        int levelIndex = Game.LevelIndex;
        Random random = new Random(levelIndex);
        int platformsCount = randomRange(random, MinPlatforms, MaxPlatforms + 1);

        for(int i = 0; i < platformsCount; i++)
        {
            int prefabIndex = randomRange(random, 0, PlatformPrefabs.Length);
            GameObject platformPrefab = i == 0 ? FirstPlatformPrefab : PlatformPrefabs[prefabIndex];
            GameObject platform = Instantiate(platformPrefab, transform);
            platform.transform.localPosition = CalculatePlatformPosition(i);
            if(i > 0)
                platform.transform.localPosition = Quaternion.Euler(0, RandomRange(random, 0, 360f), 0).eulerAngles;

        }

        FinishPlatform.localPosition = CalculatePlatformPosition(platformsCount);
        CylindrRoot.localScale = new Vector3(1, platformsCount * DistanceBetweenPlatforms + ExtraCylinderScale, 1);
    }
    private float RandomRange(Random random, float min, float max)
    {
        float t = (float) random.NextDouble();
        return Mathf.Lerp(min, max, t);
    }
    private int randomRange(Random random, int min, int maxExclusive)
    {
        int number = random.Next();
        int lenght = maxExclusive - min;
        number %= lenght;
        return min + number;
    }
    private Vector3 CalculatePlatformPosition(int PlatformIndex)
    {
        return new Vector3(0, -DistanceBetweenPlatforms * PlatformIndex, 0);
    }
}
