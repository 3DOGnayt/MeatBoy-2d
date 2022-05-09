using UnityEngine;
using UnityEngine.Tilemaps;

namespace PlatformerMVC
{
    public class MarshingSquaresController
    {
        private Tile _tileGround;
        private Tilemap _tileMapGround;
        private SquareGrid _squareGrid;

        public class Node
        {
            public Vector3 _position;
            public Node(Vector3 pos)
            {
                _position = pos;
            }
        }

        public class ControlNode : Node
        {
            public bool _active;
            public ControlNode(Vector3 pos, bool active) : base(pos)
            {
                _active = active;
            }
        }

        public class Square
        {
            public ControlNode TopLeft, TopRight, BottomLeft, BottomRight;

            public Square(ControlNode topLeft, ControlNode topRight, ControlNode bottomLeft, ControlNode bottomRight)
            {
                TopLeft = topLeft;
                TopRight = topRight;
                BottomLeft = bottomLeft;
                BottomRight = bottomRight;
            }
        }

        public class SquareGrid
        {
            public Square[,] Squares;

            public SquareGrid(int[,] map, float squareSize)
            {
                int nodeCountX = map.GetLength(0);
                int nodeCountY = map.GetLength(1);

                float mapWidth = nodeCountX * squareSize;
                float mapHeight = nodeCountY * squareSize;

                ControlNode[,] controlNodes = new ControlNode[nodeCountX, nodeCountY];

                for (int x = 0; x < nodeCountX; x++)
                {
                    for (int y = 0; y < nodeCountY; y++)
                    {
                        Vector3 position = new Vector3(-mapWidth / 2 + x * squareSize + squareSize / 2,
                            -mapHeight / 2 + y * squareSize + squareSize / 2);
                        controlNodes[x, y] = new ControlNode(position, map[x, y] == 1);
                    }
                }

                Squares = new Square[nodeCountX - 1, nodeCountY - 1];

                for (int x = 0; x < nodeCountX - 1; x++)
                {
                    for (int y = 0; y < nodeCountY - 1; y++)
                    {
                        Squares[x, y] = new Square(controlNodes[x, y + 1], controlNodes[x + 1, y + 1], controlNodes[x + 1, y], controlNodes[x, y]);
                    }
                }

            }           

        }

        public void GenerateGrid(int[,] map, float squareSize)
        {
            _squareGrid = new SquareGrid(map, squareSize);
        }

        public void DrawTilesOnMap(Tilemap tileMapGround, Tile tileGround)
        {
            if (_squareGrid == null)
                return;

            _tileMapGround = tileMapGround;
            _tileGround = tileGround;

            for (int x = 0; x < _squareGrid.Squares.GetLength(0); x++)
            {
                for (int y = 0; y < _squareGrid.Squares.GetLength(1); y++)
                {
                    DrawTileInControlNode(_squareGrid.Squares[x, y].TopLeft._active, _squareGrid.Squares[x, y].TopLeft._position);
                    DrawTileInControlNode(_squareGrid.Squares[x, y].TopRight._active, _squareGrid.Squares[x, y].TopRight._position);
                    DrawTileInControlNode(_squareGrid.Squares[x, y].BottomLeft._active, _squareGrid.Squares[x, y].BottomLeft._position);
                    DrawTileInControlNode(_squareGrid.Squares[x, y].BottomRight._active, _squareGrid.Squares[x, y].BottomRight._position);
                }
            }


        }

        private void DrawTileInControlNode(bool active, Vector3 pos)
        {
            if (active)
            {
                Vector3Int positionTile = new Vector3Int((int)pos.x, (int)pos.y, 0);

                _tileMapGround.SetTile(positionTile, _tileGround);
            }
        }


    }
}
