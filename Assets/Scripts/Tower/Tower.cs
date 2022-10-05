using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerBuild))]
public class Tower : MonoBehaviour
{
    private TowerBuild _towerBuild;
    private List<Block> _blocks;
    public event UnityAction<int> SizeUpdated;

    private void Start()
    {
        _towerBuild = GetComponent<TowerBuild>();
        _blocks = _towerBuild.Build();
        
        foreach (var block in _blocks)
        {
            block.BulletHit += OnBulletHit;
        }
        SizeUpdated?.Invoke(_blocks.Count);
    }


    private void OnBulletHit(Block hittedBlock)
    {
        hittedBlock.BulletHit -= OnBulletHit;

        _blocks.Remove(hittedBlock);

        foreach (var block in _blocks)
        {
            block.transform.position = new Vector3(
                block.transform.position.x,
                block.transform.position.y - 1,
                block.transform.position.z
                );
        }
        SizeUpdated?.Invoke(_blocks.Count);
        if(_blocks.Count == 0)
        {
            FindObjectOfType<GameManager>().ShowPannels(1);
        }

    }

    
}
