using System;
using System.Collections.Generic;
using System.Text;

namespace GameModel
{
    public class Game
    {
        int turnCount;
        Field playField;
        int size;
        public void NewGame()
        {
            turnCount = 0;
            size = 3;
            playField = new Field(size);
        }

        public void Step(int x, int y)
        {
            playField.Step(x,y);
            turnCount++;
            if (turnCount == 6)
            {
                playField.Expand();
                size = playField.Size;
                turnCount = 0;
            }
        }
    }
}
