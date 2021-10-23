using UnityEngine;

public class FastCarSpawner : MonoBehaviour
{

    [SerializeField] private float[] roadX;

    [SerializeField] private Transform player;

    [SerializeField] private Movement movement;

    [SerializeField] private int minTime;
    [SerializeField] private int maxTime;
    [SerializeField] private float spawnTime;
    [SerializeField] private string fastCarTag;
    [SerializeField] private float maxDist;
    [SerializeField] private float minDist;

    public int lastPick;
    void Update()
    {
        if (Time.time > spawnTime)
        {
            SpawnCar();
            spawnTime = GetSpawnTime();
        }

    }

    private float GetSpawnTime()
    {
        return Time.time + Random.Range(minTime, maxTime);
    }

    private void SpawnCar()
    {
        GameObject go = ObjectPool.Instance.GetObject(fastCarTag);
        var distanceFromPlayer = Random.Range(minDist, maxDist);
        var zPos = player.transform.position.z - distanceFromPlayer;
        lastPick = Random.Range(0, roadX.Length);
        var xPos = roadX[lastPick];
        go.transform.position = new Vector3(xPos, 0f, zPos);
    }
}
