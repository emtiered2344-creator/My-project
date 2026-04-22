using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public static CoinSpawn Instance { get; private set; }
    public GameObject coinPrefab;
    public float spawnInterval = 10f;
    public float moneyPerCoin = 1.5f;

    [Header("x-Axis spawn range")]//if there are more sections in map, add more x-axis spawn ranges
    public float minX = 4f;
    public float maxX = 13f;
    public float minX2 = -14f;
    public float maxX2 = -5f;

    [Header("z-Axis spawn range")]//if there are more sections in map, add more z-axis spawn ranges
    public float minZ = -6f;
    public float maxZ = 7f;
    [Header("Number of Sections")]
    public int numberOfSections = 2;
    float timer;

    void Awake()
    {
         if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnCoin();
            timer = 0f;
        }
    }

    void SpawnCoin()
    {
        float x1 = Random.Range(minX, maxX);
        float x2 = Random.Range(minX2, maxX2);
        float z = Random.Range(minZ, maxZ);
        //point random, add more sections if needed

        int r = Random.Range(0, numberOfSections);//randomly decide to spawn in one of the two sections of the map
        Debug.Log(r);
        if(r == 0)
            Instantiate(coinPrefab, new Vector3(x1, 0.5f, z), Quaternion.identity);
        else
             Instantiate(coinPrefab, new Vector3(x2, 0.5f, z), Quaternion.identity);
    }
}
