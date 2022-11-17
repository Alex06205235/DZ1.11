using UnityEngine;
using Random = System.Random;

public class LevelGeneration : MonoBehaviour
{
    public GameObject[]   platformPrefabs;
    public GameObject firstPlatformPrefab;
    public int minPlatforms;
    public int maxPlatforms;
    public float distanceBetweenPlatforms;
    public Transform finishPlatform;
    public Transform cylindrRoot;
    public float extraCylinderScale = 1f;
    public Game game;

    void Awake()
    {
        int levelIndex = game.LevelIndex;
        Random random = new Random(levelIndex);
        int platformsCount = randomRange(random, minPlatforms, maxPlatforms + 1);

        for(int i = 0; i < platformsCount; i++)
        {
            int prefabIndex = randomRange(random, 0, platformPrefabs.Length);
            GameObject platformPrefab = i == 0 ? firstPlatformPrefab : platformPrefabs[prefabIndex];
            GameObject platform = Instantiate(platformPrefab, transform);
            platform.transform.localPosition = MoveDown(distanceBetweenPlatforms * i);
            if(i > 0)
                platform.transform.localRotation = Quaternion.Euler(0, RandomRange(random, 0, 360f), 0);
        }

        finishPlatform.localPosition = MoveDown(distanceBetweenPlatforms * platformsCount);
        cylindrRoot.localScale = new Vector3(1, platformsCount * distanceBetweenPlatforms + extraCylinderScale, 1);
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
    private static Vector3 MoveDown(float distance)
    {
        return new Vector3(0, -distance, 0);
    }
}
