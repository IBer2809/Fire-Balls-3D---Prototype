using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuild : MonoBehaviour
{
    [SerializeField] private float _towerSize;
    [SerializeField] private Transform _buildPoint;
    [SerializeField] private Block _blockToBuild;
    private List<Block> _blocks;
    [SerializeField] private Color[] _blocksColor;


    public List<Block> Build()
    {
        _blocks = new List<Block>();

        Transform currentPoint = _buildPoint;
        for (int i = 0; i < _towerSize; i++)
        {
            Block newBlock = BuildTower(currentPoint);
            Debug.Log(currentPoint.position.y);
            if (i % 2 == 0)
            {
                newBlock.SetColor(newBlock.GetComponent<Renderer>(), _blocksColor[0]);
            }
            else
            {
                newBlock.SetColor(newBlock.GetComponent<Renderer>(), _blocksColor[1]);
            }
            
            _blocks.Add(newBlock);
            currentPoint = newBlock.transform;
        }
        return _blocks;
    }

    private Block BuildTower(Transform currentBuildPoint)
    {
        return Instantiate(_blockToBuild, GetBuildPoint(currentBuildPoint), Quaternion.identity, _buildPoint);
    }

    private Vector3 GetBuildPoint(Transform currentBuildSegment)
    {
        return new Vector3(
            _buildPoint.position.x, 
            currentBuildSegment.position.y + 1, 
            _buildPoint.position.z
            );
    }






}
