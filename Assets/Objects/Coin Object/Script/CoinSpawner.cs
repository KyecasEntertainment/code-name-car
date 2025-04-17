using UnityEngine;

public class CoinSpawner : MonoBehaviour
{

    public GameObject coin_prefab; 
    public GameObject spawn_radius_prefab;
    public Transform spawn_point;
    public int coins_in_scene;
    public float spawn_radius = 5f; 
    public int spawn_instance = 5;

    void Start()
    {
        SpawnCoins();

    }

    private void Update()
    {
        CountCoinsOnScene();
    }

    private void CountCoinsOnScene()
    {
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        coins_in_scene = coins.Length; 
    }

    private void SpawnCoins()
    {
        for (int i = 0; i < spawn_instance; i++)
        {
            Vector3 random_position = spawn_point.position + Random.insideUnitSphere * spawn_radius;
            random_position.y = 2f; 
            Instantiate(coin_prefab, random_position, Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(spawn_point.position, spawn_radius);
    }
}
