using System;
using Trilobyte;

namespace ConsoleMazeWoot
{
    class TrophyEntity : Entity
    {
        int Score;

		int Health;
        //constructor; default character for displaying trophy is '+' sign
        //trophies may have different values and so Y will be value of given trophy
        public TrophyEntity(char toDisplay, int score, int health)
        {
			Score = score;
			Health = health;
            Display = toDisplay;

            OnCollidedWith += TrophyEntity_OnCollideWith;
        }
        //when player collides with the trohpy, it should disappear and score should increase
        private void TrophyEntity_OnCollideWith(object sender, CollisionEventArgs e)
        {
            //update player score to be current player score + value of given trophy
            Program.Score += Score;
			Program.Health += Health;

            try
			{
                ParentScene.Terrain.Remove(this);
            }
            catch(Exception ex) { }
        }
    }
}
