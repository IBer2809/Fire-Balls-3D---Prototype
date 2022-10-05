using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    public event UnityAction<Block> BulletHit;



    public void SetColor(Renderer rend, Color color)
    {
        rend.material.color = color;
    }
    public void BreakBlock()
    {
        BulletHit?.Invoke(this);
        Destroy(gameObject);
    }
}
