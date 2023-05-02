using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShardCarrierBehavior : MonoBehaviour
{
    List<GameObject> storedShards = new List<GameObject>();
    [SerializeField] Transform removePosition;
    [SerializeField] Transform rotationIndicator;
    [SerializeField] GameObject absorbDetector;
    bool isGrabbed = false;
    bool isPouring = false;

    [SerializeField] ParticleSystem releaseVF;
    bool isVFPlaying = false;

    private void Start()
    {
        releaseVF.Stop();
    }

    public void SetGrabbed(bool b)
    {
        isGrabbed = b;
    }

    public void addShard(GameObject shard)
    {
        storedShards.Add(shard);
    }

    private void FixedUpdate()
    {
        if(Vector3.Dot(rotationIndicator.up, Vector3.up) < -0.4f && isGrabbed)
        {
            if (!isPouring)
            {
                isPouring = true;
                StartCoroutine("RemoveShard");
            }
        }
        else
        {
            if (isPouring)
            {
                StopCoroutine("RemoveShard");
                releaseVF.Stop();
                absorbDetector.SetActive(true);
                isPouring = false;
                isVFPlaying = false;
            }
        }
    }

    IEnumerator RemoveShard()
    {
        while(storedShards.Count > 0)
        {
            if (!isVFPlaying)
            {
                releaseVF.Play();
                isVFPlaying = true;
            }
            absorbDetector.SetActive(false);
            //GameObject shard = Instantiate(storedShards[0], removePosition.position, Quaternion.identity);
            GameObject shard = storedShards[0];
            shard.transform.position = removePosition.position;
            shard.transform.localScale *= 0.8f;
            shard.transform.rotation = Quaternion.identity;
            shard.SetActive(true);
            storedShards.RemoveAt(0);
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }
}
