using UnityEngine;

namespace Desolation
{
    public class Tile
    {
        public Vector3 Center;
        public Vector2Int LocalIndex;
        public Vector2Int GlobalIndex;

        public Tile(Vector3 center, Vector2Int localIndex, Vector2Int globalIndex)
        {
            Center = center;
            LocalIndex = localIndex;
            GlobalIndex = globalIndex;
        }
    }
}