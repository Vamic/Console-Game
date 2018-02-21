using System;
using System.Collections.Generic;
using System.Threading;
using Utilities;

namespace Console_Game
{
    internal class Game
    {
        private List<GameObject> gameObjects;
        private Dictionary<Point, List<int>> graphicDic;

        public void Init()
        {
            gameObjects = new List<GameObject>
            {
                new Player()
            };
        }

        internal void Update(int delta)
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Update(delta);
            }
        }
        internal void Draw()
        {
            //Move cursor to top again
            Console.SetCursorPosition(0,0);
            //Get display information from all the objects
            graphicDic = new Dictionary<Point, List<int>>();
            for (int i = 0; i < gameObjects.Count; i++)
            {
                //Get where
                Point point = gameObjects[i].GetGraphicPos();
                //If the object doesnt have a locatoin, ignore it
                if (point.IsEmpty) continue;
                //Check if location already has stuff
                if(graphicDic.ContainsKey(point))
                {
                    graphicDic[point].Add(i);
                }
                else
                {
                    graphicDic.Add(point, new List<int>{i});
                }
            }
            
            //How many tiles the map has
            byte mapSize = 20;
            //Build the display line by line
            for (int y = 0; y <= mapSize; y++)
            {
                string line = "\t";
                //Line left with border
                if (y > 0 && y < mapSize)
                    line += "|";
                else
                    line += " ";
                for (int x = 1; x <= mapSize; x++)
                {
                    //Space the tiles out because non monospace fonts kill me
                    line += " ";
                    //line the top & bottom with borders
                    if(y == 0 || y == mapSize)
                    {
                        line += "-";
                    }
                    else
                    {
                        //Get the character to display at the coordinate
                        line += GetGraphic(x, y);
                    }
                    //line right with border
                    if (x == mapSize && y > 0 && y < mapSize)
                    {
                        line += "|";
                    }
                }
                //Display the line
                Console.WriteLine(line);
            }
        }

        private string GetGraphic(int x, int y)
        {
            Point point = new Point(x, y);
            //Get the graphic for the coordinate
            if (graphicDic.ContainsKey(point))
            {
                List<int> indices = graphicDic[point];
                switch (indices.Count)
                {
                    case 1: //Only one item here, show the graphic
                        return gameObjects[indices[0]].GetGraphic();
                    default: //Multiple items, show the count
                        return indices.Count.ToString();
                }
            }
            //Nothing here, empty space
            return " ";
        }
    }
}