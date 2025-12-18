using System;
using System.Collections.Generic;
using UnityEngine;

namespace __Workspaces.Alexis.Scripts.FinalGame.Level
{
    public class ChunkSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> terrainChunks;

        [SerializeField] private int numberOfChunks = 5;
        [SerializeField] private float chunkHeight = 23f;
        [SerializeField] private float heightOffset = 23f;

        private Vector3 _spawnPosition;

        // Seed partagée entre tous les spawners
        private static int _sharedSeed;
        private static bool _seedInitialized = false;

        private System.Random _rng;

        private void Awake()
        {
            // Génération de la seed partagée
            if (!_seedInitialized)
            {
                _sharedSeed = new System.Random().Next(int.MinValue, int.MaxValue);
                _seedInitialized = true;
                Debug.Log("Shared ChunkSpawner seed: " + _sharedSeed);
            }

            // Initialisation du Random local basé sur la seed partagée
            _rng = new System.Random(_sharedSeed);
        }

        private void Start()
        {
            _spawnPosition = transform.position + Vector3.up * heightOffset;

            for (int i = 0; i < numberOfChunks; i++)
            {
                SpawnChunk(terrainChunks[_rng.Next(terrainChunks.Count)]);
            }
        }

        private void SpawnChunk(GameObject prefab)
        {
            Instantiate(prefab, _spawnPosition, Quaternion.identity);
            _spawnPosition += Vector3.up * chunkHeight;
        }
    }
}