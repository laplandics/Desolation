using System.Collections.Generic;
using UnityEngine;

namespace Desolation
{
    public class Chunk
    {
        public Vector2Int Index;
        public readonly Dictionary<Vector2Int, Tile> TilesMap;
        
        public Chunk(Vector2Int index, Dictionary<Vector2Int, Tile> tilesMap)
        { Index = index; TilesMap = tilesMap; }
    }
}
