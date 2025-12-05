using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawnerPlayer2 : MonoBehaviour
{
    [SerializeField] private List<GameObject> terrainChunks;
    [SerializeField] private GameObject _StartingChunk;
    [SerializeField] private GameObject _EndingChunk;

    private GameObject _selectedBlock;
    private GameObject _lastUsedChunk;
    private int _numberofSelectedBlock;
    
    void Start()
    {
        _StartingChunk.GetComponent<Transform>().localScale = new Vector3(-1,1,1);
        SpawnStartingChunk();
        for (int i = 0; i < 5; i++)
        {
            SpawnNextBlock();
        }
        SpawnEndingChunk();
    }

    private void SpawnStartingChunk()
    {
        Instantiate(_StartingChunk, _StartingChunk.transform.position + new Vector3(0,-300,0), Quaternion.identity);
    }
    
    private void SpawnNextBlock()
    {
        _selectedBlock = terrainChunks[Random.Range(0, terrainChunks.Count)];
        _numberofSelectedBlock++;
        if (_lastUsedChunk == null)
        {
            _lastUsedChunk  = _StartingChunk;
        }
        Instantiate(_selectedBlock, _lastUsedChunk.transform.position + new Vector3(0,-300 + 23 * _numberofSelectedBlock,0), Quaternion.identity);
        _lastUsedChunk = _selectedBlock;
        _selectedBlock = terrainChunks[Random.Range(0, terrainChunks.Count)];
    }

    private void SpawnEndingChunk()
    {
        Instantiate(_EndingChunk, _EndingChunk.transform.position + new Vector3(0,-300,0), Quaternion.identity);
    }
}
