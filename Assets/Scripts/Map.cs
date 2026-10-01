using System.Collections.Generic;
using UnityEngine;

namespace Desolation
{
    public class Map
    {
        private const int CHUNK_SIZE = 16;
        private const float MAP_X = -10f;
        private const float MAP_Y = -1f;
        
        private Chunk _currentChunk;
        
        public void Run()
        {
            
        }
        
        private void CreateChunk(Vector2Int chunkIndex)
        {
            if (_currentChunk != null && _currentChunk.Index == chunkIndex) return;
            
            var chunk = new Chunk(chunkIndex, new Dictionary<Vector2Int, Tile>());
            var chunkGlobalX = chunkIndex.x * CHUNK_SIZE;
            var chunkGlobalY = chunkIndex.y * CHUNK_SIZE;

            for (var y = 0; y < CHUNK_SIZE; y++)
            {
                for (var x = 0; x < CHUNK_SIZE; x++)
                {
                    var tileIndexLocal = new Vector2Int(x, y);
                    var tileIndexGlobal = new Vector2Int(x + chunkGlobalX, y + chunkGlobalY);
                    var worldPosition = Grid.GridToWorldCenter(tileIndexGlobal);
                    
                    var tile = new Tile(worldPosition, tileIndexLocal, tileIndexGlobal);
                    chunk.TilesMap[tileIndexLocal] = tile;
                }
            }
            
            _currentChunk = chunk;
        }
    }
}
