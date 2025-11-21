using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomBlockSelecter : MonoBehaviour
{
    [SerializeField] private List<GameObject> terrainBlocks;
    [SerializeField] private GameObject startingChunk;

    private GameObject _selectedBlock;
    private GameObject _lastUsedChunk;
    private int _numberofSelectedBlock;
    
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
        _selectedBlock = terrainBlocks[Random.Range(0, terrainBlocks.Count)];
        _numberofSelectedBlock++;
        if (_lastUsedChunk == null)
        {
            _lastUsedChunk  = startingChunk;
        }
        Instantiate(_selectedBlock, _lastUsedChunk.transform.position + new Vector3(-0.921f,23 * _numberofSelectedBlock,0), Quaternion.identity);
        _lastUsedChunk = _selectedBlock;
        _selectedBlock = terrainBlocks[Random.Range(0, terrainBlocks.Count)];
    }
}
