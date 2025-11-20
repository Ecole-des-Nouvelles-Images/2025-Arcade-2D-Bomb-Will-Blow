using System.Collections.Generic;
using UnityEngine;

public class RandomBlockSelecter : MonoBehaviour
{
    [SerializeField] private List<GameObject> TerrainBlocks;

    private GameObject _selectedBlock;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            SpawnNextBlock();
        }
    }

    private void SpawnNextBlock()
    {
        _selectedBlock = TerrainBlocks[Random.Range(0, TerrainBlocks.Count - 1)];
        GameObject previousSelectedBlock = _selectedBlock;
        Instantiate(_selectedBlock, transform.position = new Vector3(0,20,0), Quaternion.identity);
        _selectedBlock = TerrainBlocks[Random.Range(0, TerrainBlocks.Count - 1)];
        //while (_selectedBlock == previousSelectedBlock)
        //{
            //_selectedBlock = TerrainBlocks[Random.Range(0, TerrainBlocks.Count)];
        //}
    }
}
