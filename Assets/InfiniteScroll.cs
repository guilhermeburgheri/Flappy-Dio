using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScroll : MonoBehaviour
{
    [SerializeField] protected Transform[] parts;
    [SerializeField] private Vector2 speed;
    [SerializeField] private float width;
    private int _partsLenght;
    protected Action<Transform> onScrollPartRecycled;

    void Awake()
    {
        _partsLenght = parts.Length;
    }

    void Update()
    {
        foreach (Transform p in parts)
        {
            p.Translate(speed * Time.deltaTime);
            if (p.position.x < width * _partsLenght/2 * -1)
            {
                p.Translate(new Vector2(_partsLenght * width, 0));
                onScrollPartRecycled?.Invoke(p);
            }
        }
    }
}
