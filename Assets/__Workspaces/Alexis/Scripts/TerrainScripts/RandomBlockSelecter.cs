using System.Collections.Generic;
using UnityEngine;

public class RandomBlockSelecter : MonoBehaviour
{
    [SerializeField] public List<GameObject> TerrainBlocks;

    private GameObject _selectedBlock;
    
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            SpawnNextBlock();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnNextBlock()
    {
        Debug.Log(TerrainBlocks.Count);
        _selectedBlock = TerrainBlocks[Random.Range(0, TerrainBlocks.Count)];
        GameObject previousSelectedBlock = _selectedBlock;
        Instantiate(_selectedBlock, transform.position = new Vector3(0,20,0), Quaternion.identity);
        _selectedBlock = TerrainBlocks[Random.Range(0, TerrainBlocks.Count)];
        //while (_selectedBlock == previousSelectedBlock)
        //{
            //_selectedBlock = TerrainBlocks[Random.Range(0, TerrainBlocks.Count)];
        //}
    }
}
