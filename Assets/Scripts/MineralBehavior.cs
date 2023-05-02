using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralBehavior : MonoBehaviour
{
    bool isMineable = true;
    [SerializeField] GameObject shardPF;
    [SerializeField] Transform shardSpawnTransform;
    [SerializeField] int mineralDurability;
    [SerializeField] float shardSpeed;
    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("detect collision");
        if (collision.gameObject.CompareTag("Pickaxe") && isMineable)
        {
            Debug.Log("Mining");
            if (!gameManager.TestControllerVelocity()) { return; }
            mineralDurability--;
            GameObject shard = Instantiate(shardPF, shardSpawnTransform.position, Quaternion.identity);
            float randomSpeed = Random.Range(0, shardSpeed);
            shard.GetComponent<Rigidbody>().velocity = new Vector3(randomSpeed, Mathf.Abs(randomSpeed), randomSpeed);
            if(mineralDurability <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                isMineable = false;
                Invoke("SetMineable", 1f);
            }
        }
    }

    void SetMineable()
    {
        isMineable = true;
    }
}
