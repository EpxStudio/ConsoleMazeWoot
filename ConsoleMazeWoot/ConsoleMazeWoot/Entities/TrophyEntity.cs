using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trilobyte;

namespace ConsoleMazeWoot
{
    class TrophyEntity : Entity
    {
        int value;
        //constructor; default character for displaying trophy is '+' sign
        //trophies may have different values and so Y will be value of given trophy
        public TrophyEntity(int val, char toDisplay = '+')
        {

            value = val;
            Display = toDisplay;

            OnCollidedWith += TrophyEntity_OnCollideWith;
        }
        //when player collides with the trohpy, it should disappear and score should increase
        private void TrophyEntity_OnCollideWith(object sender, CollisionEventArgs e)
        {
            //update player score to be current player score + value of given trophy
            Program.Score += value;

			ParentScene.Terrain.Remove(this);
        }
    }
}
