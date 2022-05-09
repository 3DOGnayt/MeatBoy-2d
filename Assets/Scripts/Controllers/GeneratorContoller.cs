using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace PlatformerMVC
{
    public class GeneratorContoller 
    {
        private Tilemap _tilemap;
        private Tile _groundTile;
        private int _mapWidth;
        private int _mapHeight;
        private bool _borders;
        private int _factorSmooth;
        private int _fillPercent;

        private MarshingSquaresController _marshingSquares;

        private int[,] _map;

        private const int _countWall = 4;

        public GeneratorContoller(GeneratorLevelView levelView)
        {
            _tilemap = levelView.Tilemap;
            _groundTile = levelView.GroundTile;
            _mapWidth = levelView.MapWidth;
            _mapHeight = levelView.MapHeight;
            _factorSmooth = levelView.FactoSmoth;
            _fillPercent = levelView.FillPercent;
            _borders = levelView.Boders;

            _map = new int[_mapWidth, _mapHeight];

            _marshingSquares = new MarshingSquaresController();

        }

        public void Init()
        {
            RandomFillMap();

            for (int i = 0; i < _factorSmooth; i++)
            {
                SmoothMap();
            }
            _marshingSquares.GenerateGrid(_map, 1);
            _marshingSquares.DrawTilesOnMap(_tilemap, _groundTile);


            //DrawTiles();
        }

        private void RandomFillMap()
        {
            //System.Random rand = new System.Random(Time.deltaTime.ToString().GetHashCode());

            //var seed = Time.time.ToString();                                          ne rabotaet
            //var pseudoRandom = new System.Random(seed.GetHashCode());


            float rand = Random.Range(0.00f, 0.04f);

            for (int x = 0; x < _mapWidth; x++)
            {
                for (int y = 0; y < _mapHeight; y++)
                {
                    if (x == 0 || x == _mapWidth - 1 || y == 0 || y == _mapHeight - 1)
                    {
                        if (_borders)
                        {
                            _map[x, y] = 1;
                        }
                        
                    }
                    else
                    {
                        _map[x, y] = (Random.Range(0, 100) < _fillPercent) ? 1 : 0;
                        //_map[x, y] = (pseudoRandom.Next(0, 100) < _fillPercent) ? 1 : 0;       ne rabotaet
                    }
                }
            }

        }

        private void SmoothMap()
        {
            for (int x = 0; x < _mapWidth; x++)
            {
                for (int y = 0; y < _mapHeight; y++)
                {
                    int neighbourwWall = GetWallCount(x, y);

                    if (neighbourwWall > _countWall)
                    {
                        _map[x, y] = 1;
                    }
                    else if(neighbourwWall < _countWall)
                    {
                        _map[x, y] = 0;
                    }
                }
            }

        }

        private int GetWallCount(int x, int y)
        {
            int _wallCount = 0;

            for (int gridX = x - 1; gridX <= x + 1; gridX++)
            {
                for (int gridY = y - 1; gridY <= y + 1; gridY++)
                {
                    if (gridX >= 0 && gridX < _mapWidth && gridY >= 0 && gridY < _mapHeight)
                    {
                        if (gridX != x || gridY != y)
                        {
                            _wallCount += _map[gridX, gridY];
                        }
                    }
                    else
                    {
                        _wallCount++;
                    }
                }
            }
            return _wallCount;

        }

        private void DrawTiles()
        {
            if (_map == null)
                return;

            for (int x = 0; x < _mapWidth; x++)
            {
                for (int y = 0; y < _mapHeight; y++)
                {
                    Vector3Int positionTile = new Vector3Int(-_mapWidth / 2 + x, -_mapHeight / 2 + y, 0);

                    if(_map[x, y]==1)
                    {
                        _tilemap.SetTile(positionTile, _groundTile);
                    }

                }
            }
        }

    }
}
