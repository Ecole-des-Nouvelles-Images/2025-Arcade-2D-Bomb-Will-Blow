using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> terrainChunks;
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
        _selectedBlock = terrainChunks[Random.Range(0, terrainChunks.Count)];
        _numberofSelectedBlock++;
        if (_lastUsedChunk == null)
        {
            _lastUsedChunk  = startingChunk;
        }
        Instantiate(_selectedBlock, _lastUsedChunk.transform.position + new Vector3(0,23 * _numberofSelectedBlock,0), Quaternion.identity);
        _lastUsedChunk = _selectedBlock;
        _selectedBlock = terrainChunks[Random.Range(0, terrainChunks.Count)];
    }
}
