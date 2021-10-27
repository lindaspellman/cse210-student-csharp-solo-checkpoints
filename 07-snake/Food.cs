using System;

namespace _07_snake
{
    /// <summary>
    /// Repesents the food that the snake is chasing for points. 
    // When a food is hit, this class will return points and reset the food in a new location.
    /// </summary>
    public class Food : Actor 
    {
        int _points;
        public Food()
        {

            Reset();
            
        }

        public int GetPoints()
        {
            return _points;
        }

        public void Reset()
        {
            Random randomGenerator = new Random();
            _points = randomGenerator.Next(1, 11);
            _text = _points.ToString();

            int x = randomGenerator.Next(0, Constants.MAX_X);
            int y = randomGenerator.Next(0, Constants.MAX_Y);

            _position = new Point(x, y);
        }
    }
 
}