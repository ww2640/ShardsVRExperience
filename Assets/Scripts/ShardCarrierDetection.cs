using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShardCarrierDetection : MonoBehaviour
{
    ShardCarrierBehavior shardCarrier;
    [SerializeField] ParticleSystem absorbVF;
    private void Awake()
    {
        shardCarrier = GetComponentInParent<ShardCarrierBehavior>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shard"))
        {
            shardCarrier.addShard(other.gameObject);
            absorbVF.Play();
            other.gameObject.SetActive(false);
        }
    }
}
