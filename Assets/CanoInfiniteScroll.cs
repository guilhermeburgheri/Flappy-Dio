using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanoInfiniteScroll : InfiniteScroll
{
    [SerializeField] private Vector2 randomHeight;

    private void Start()
    {
        onScrollPartRecycled += OnPartRecycle;

        foreach (Transform part in parts)
        {
            DoRandomHeight(part);
        }
    }

    void DoRandomHeight(Transform part)
    {
        float randomValue = Random.Range(randomHeight.x, randomHeight.y);
        part.position = new Vector2(part.position.x, randomValue);
    }

    void OnPartRecycle (Transform part)
    {
        DoRandomHeight(part);
    }
}
