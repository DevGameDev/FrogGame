using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridManager
{

    class Grid2D
    {
        public int x;
        public int y;
        public float xScale;
        public float yScale;

        public List<List<Tile2D>> theGrid;

        public Grid2D(int x_size, int y_size, float x_scale, float y_scale)
        {
            x = x_size;
            y = y_size;
            xScale = x_scale;
            yScale = y_scale;

            theGrid = new List<List<Tile2D>>();

            //Loop through x size and y size in order to create a rectangular matrix of size x by y.
            for(int i = 0; i < x; i++)
            {
                List<Tile2D> current_row = new List<Tile2D>();

                for(int j = 0; j < y; j++)
                {
                    Tile2D newPosition = new Tile2D(i, j, new List<GameObject>());
                    current_row.Add(newPosition);
                }

                theGrid.Add(current_row);
            }
        }

        public Tile2D GetPosition(int getX, int getY)
        {
            return theGrid[getX][getY];
        }

        public void SetPosition(int setX, int setY, List<GameObject> contents)
        {
            if(0 <= setX && setX <= x && 0 <= setY && setY <= y)
            {
                theGrid[x][y] = new Tile2D(setX, setY, contents);
            }
            else
            {
                Debug.Log("Position out of index range");
            }
        }

        public void ShiftPositionAbsolute(int oldX, int oldY, int newX, int newY)
        {
            if (0 <= oldX && oldX <= x && 0 <= oldY && oldY <= y && 0 <= newX && newX <= x && 0 <= newY && newY <= y)
            {
                Tile2D currentTile = theGrid[oldX][oldY];
                theGrid[oldX][oldY] = new Tile2D(oldX, oldY, new List<GameObject>());
                theGrid[newX][newY] = currentTile;
                currentTile.SetPosition(newX, newY);
            }

            else
            {
                Debug.Log("Position out of index range");
            }
        }

        public void ShiftPositionRelative(int oldX, int oldY, int xDelta, int yDelta)
        {
            if (0 <= oldX  && oldX <= x && 0 <= oldY && oldY <= y && 0 <= oldX + xDelta  && oldX + xDelta <= x && 0 <= oldY + yDelta && oldY + yDelta <= y)
            {
                Tile2D currentTile = theGrid[oldX][oldY];
                theGrid[oldX][oldY] = new Tile2D(oldX, oldY, new List<GameObject>());
                theGrid[xDelta][xDelta] = currentTile;
                currentTile.SetPositionRelative(xDelta, xDelta);
            }

            else
            {
                Debug.Log("Relative position out of index range");
            }
        }

        public List<Tile2D> FindTilesWithObject(GameObject objectName)
        {
            List<Tile2D> returnList = new List<Tile2D>();

            foreach (List<Tile2D> row in theGrid)
            {
                foreach (Tile2D tile in row)
                {
                    if(tile.contents.Contains(objectName))
                    {
                        returnList.Add(tile);
                    }
                }
            }

            return returnList;
        }

        public List<Tile2D> FindTilesInCardinalRangeWithDiagonals(int xPosition, int yPosition, int effectRange)
        {
            List<Tile2D> returnList = new List<Tile2D>();
            returnList.Add(theGrid[xPosition][yPosition]);
            for(int i = 1; i <= effectRange; i++)
            {
                if(xPosition + i <= x)
                {
                    returnList.Add(GetPosition(xPosition + i, yPosition));

                    if(yPosition + i <= y)
                    {
                        returnList.Add(GetPosition(xPosition + i, yPosition + i));
                    }

                    if(yPosition - i >= 0)
                    {
                        returnList.Add(GetPosition(xPosition + i, yPosition - i));
                    }
                }

                if (xPosition - i >= 0)
                {
                    returnList.Add(GetPosition(xPosition - i, yPosition));

                    if(yPosition + i <= y)
                    {
                        returnList.Add(GetPosition(xPosition - i, yPosition + i));
                    }

                    if(yPosition - i <= y)
                    {
                        returnList.Add(GetPosition(xPosition - i, yPosition - i));
                    }
                }

                if (yPosition + i <= y)
                {
                    returnList.Add(GetPosition(xPosition, yPosition + i));
                }

                if (yPosition - i >= 0)
                {
                    returnList.Add(GetPosition(xPosition, yPosition - i));
                }


            }

            return returnList;
        }

        public List<Tile2D> FindTilesInDiagonalRange(int xPosition, int yPosition, int effectRange)
        {
            List<Tile2D> returnList = new List<Tile2D>();
            returnList.Add(theGrid[xPosition][yPosition]);
            for (int i = 1; i <= effectRange; i++)
            {
                if(xPosition + i <= x && yPosition + i <= y)
                {
                    returnList.Add(GetPosition(xPosition + i, yPosition + i));
                }

                if(xPosition + i <= x && yPosition - i >= 0)
                {
                    returnList.Add(GetPosition(xPosition + i, yPosition - i));
                }

                if(xPosition - i >= 0 && yPosition + i <= y)
                {
                    returnList.Add(GetPosition(xPosition - i, yPosition + i));
                }

                if (xPosition - i >= 0 && yPosition - i >= 0)
                {
                    returnList.Add(GetPosition(xPosition - i, yPosition - i));
                }

            }

            return returnList;
        }

        public List<Tile2D> FindTilesInCardinalRange(int xPosition, int yPosition, int effectRange)
        {
            List<Tile2D> returnList = new List<Tile2D>();
            returnList.Add(theGrid[xPosition][yPosition]);

            for (int i = 1; i <= effectRange; i++)
            {
                if (xPosition + i <= x)
                {
                    returnList.Add(GetPosition(xPosition + i, yPosition));
                }

                if (xPosition - i >= 0)
                {
                    returnList.Add(GetPosition(xPosition - i, yPosition));
                }

                if (yPosition + i <= y)
                {
                    returnList.Add(GetPosition(xPosition, yPosition + i));
                }

                if (yPosition - i >= 0)
                {
                    returnList.Add(GetPosition(xPosition, yPosition - i));
                }
            }

            return returnList;
        }

        public List<Tile2D> FindTilesInSquareRange(int xPosition, int yPosition, int effectRange)
        {
            List<Tile2D> returnList = new List<Tile2D>();
            for (int i = -effectRange; i <= effectRange; i++)
            {
                for (int j = -effectRange; j <= effectRange; j++)
                {
                    if(0 <= xPosition + i && xPosition + i <= x && 0 <= yPosition && yPosition + i <= y)
                    {
                        returnList.Add(GetPosition(xPosition + i, yPosition + j));
                    }
                }
            }
            return returnList;
        }

        public List<Tile2D> FindTilesInLine(int xPosition, int yPosition, int effectRange, string direction)
        {
            List<Tile2D> returnList = new List<Tile2D>();
            if (direction == "Right")
            {
                for (int i = 0; i <= effectRange; i++)
                {
                    if (xPosition + i <= x)
                    {
                        returnList.Add(GetPosition(xPosition + i, yPosition));
                    }
                }
                return returnList;
            }

            else if (direction == "Left")
            {
                for (int i = 0; i <= effectRange; i++)
                {
                    if (xPosition - i >= 0)
                    {
                        returnList.Add(GetPosition(xPosition - i, yPosition));
                    }
                }
                return returnList;
            }

            else if (direction == "Up")
            {
                for (int i = 0; i <= effectRange; i++)
                {
                    if (yPosition + i <= y)
                    {
                        returnList.Add(GetPosition(xPosition, yPosition + i));
                    }
                }
                return returnList;
            }

            else if (direction == "Down")
            {
                for (int i = 0; i <= effectRange; i++)
                {
                    if (yPosition - i >= 0)
                    {
                        returnList.Add(GetPosition(xPosition, yPosition - i));
                    }
                }
                return returnList;
            }

            else
            {
                return returnList;
            }
        }
    }

    class Tile2D
    {
        public int x;
        public int y;
        public int z_height;
        public List<GameObject> contents;

        public Tile2D(int x_position, int y_position, List<GameObject> spawnContents)
        {
            x = x_position;
            y = y_position;
            z_height = 0;
            contents = spawnContents;
        }

        public int[] ReturnPosition()
        {
            int[] position = { x, y };
            return position;
        }

        public void SetPosition(int x_position, int y_position)
        {
            x = x_position;
            y = y_position;
        }

        public void SetPositionRelative(int x_delta, int y_delta)
        {
            x += x_delta;
            y += y_delta;
        }

        public List<GameObject> ReturnContents()
        {
            return contents;
        }

        public bool IsInContents(GameObject objectInQuestion)
        {
            return contents.Contains(objectInQuestion);
        }

        public List<GameObject> AddToContents(GameObject newObject)
        {
            contents.Add(newObject);
            return contents;
        }

        public List<GameObject> SubtractFromContents(GameObject oldObject)
        {
            if (contents.Contains(oldObject))
            {
                contents.Remove(oldObject);
            }

            return contents;
        }

        public void SetHeight(int z_position)
        {
            z_height = z_position;
        }

    }

}
