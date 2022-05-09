using UnityEngine.Tilemaps;
using UnityEngine;

namespace PlatformerMVC
{
    public class GeneratorLevelView : MonoBehaviour
    {
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private Tile _groundTile;
        [SerializeField] private int _mapWidth;
        [SerializeField] private int _mapHeight;
        [SerializeField] private bool _borders;
        [SerializeField] [Range(0, 100)] private int _factorSmooth;
        [SerializeField] [Range(0, 100)] private int _fillPercent;

        public Tilemap Tilemap { get => _tilemap; set => _tilemap = value; }
        public Tile GroundTile { get => _groundTile; set => _groundTile = value; }
        public int MapWidth { get => _mapWidth; set => _mapWidth = value; }
        public int MapHeight { get => _mapHeight; set => _mapHeight = value; }
        public bool Boders { get => _borders; set => _borders = value; }
        public int FactoSmoth { get => _factorSmooth; set => _factorSmooth = value; }
        public int FillPercent { get => _fillPercent; set => _fillPercent = value; }

    }
}
