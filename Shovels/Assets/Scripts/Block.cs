using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config params
    [SerializeField] Sprite[] hitSprites;
    [SerializeField] int timesHit; // only for debugging
    [SerializeField] Coin coinPrefab;

    //cashed references
    Score score;

    void Start()
    {
        CountBlocks();
    }
    private void CountBlocks()
    {
        score = FindObjectOfType<Score>();
        if (tag == "Block")
        {
            score.CountBlocks();
        }
    }

    private void OnMouseDown()
    {
        if (timesHit < 3)
        {
            HandleHit();
            Spawn(transform.position, transform.rotation);
        }
    }

    private void HandleHit()
    {
        timesHit++;
        score.SubShovels();
        int MaxHits = hitSprites.Length;
        if (timesHit == MaxHits)
        {
            score.SubCountBlocks();
            ShowNextHitSprite();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit-1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Missing block sprite " + gameObject.name);
        }
    }

    private void Spawn(Vector3 trans, Quaternion rot)
    {
        Debug.Log("Шанс спавна монеты "+score.GetRandom());
        if (Random.Range(1.0f/10.0f, 1.0f) <= score.GetRandom()+0.05)
        {
            Coin newCoin = Instantiate(coinPrefab, trans, rot) as Coin;
            newCoin.transform.parent = transform;
        }
    }
}
