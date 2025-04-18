using UnityEngine;

public class GasCanSpawner : MonoBehaviour
{

    public GameObject gas_can_prefab;
    public Transform spawn_point;
    public float spawn_radius = 5f;
    public int spawn_instance = 1;
    public bool has_spawned;

    public PlayerStatusScipt player_status_scipt; 


    void FixedUpdate()
    {
        SpawnGasCans();    
    }

    private void SpawnGasCans(){
        if(player_status_scipt.gas < 10f && !has_spawned){
            Vector3 random_position = Random.insideUnitSphere * spawn_radius;
            random_position.y = 2f;
            Instantiate(gas_can_prefab, random_position, Quaternion.identity);
            has_spawned = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawn_radius);
    }

}
