using System;
using System.Collections.Generic;

namespace _05_hide_and_seek
{
    /// <summary>
    /// The Hider is responsible to watch the seeker and give hints.
    /// 
    /// Stereotype:
    ///     Information Holder
    /// </summary>
    public class Hider
    {
        // TODO: Add any member variables here

        public int _location; 
        public List<int> _distances; 

        /// <summary>
        /// Initializes the location of the hider to a random location 1-1000.
        /// Also initializes the list of distances to be a new, empty list.
        /// </summary>
        public Hider()
        {
            // Start at a new random position from 1-1000
            Random randomGenerator = new Random();
            _location = randomGenerator.Next(1, 1001);

            // Set up the list to track the distances we have traveled.            
            _distances = new List<int>();
        }

        /// <summary>
        /// Computes the distance from the hider's location to the provided location of the seeker
        /// and stores it in a list of distances to use later.
        /// </summary>
        /// <param name="seekerLocation">The current location of the seeker.</param>
        public void Watch(int seekerLocation)
        {
            // Compute the distance from the seeker
            int distanceMoved = Math.Abs(_location - seekerLocation);
            
            // Add this distance to the end of our list
            _distances.Add(distanceMoved);
        }

        /// <summary>
        /// Gets a hint.
        /// 
        /// If there is not enough information yet (fewer than 2 distances), a generic hint is given.
        /// If the seeker has found the hider, the hint notes they have been found.
        /// If the seeker is moving closer, the hint notes they are getting warmer.
        /// If the seeker is moving futher away, the hint notes they are getting colder.
        /// </summary>
        /// <returns>The hint message</returns>
        public string GetHint()
        {
            string hint = "";
            
            if (_distances.Count < 2)
            {
                // we don't have enough information to know if they are getting
                // warmer or colder, so just give a generic message
                hint = "(-.-) Maybe I'll take a nap";
            }
            else
            {
                if (IsFound())
                {
                    hint = "(;.;) You found me!";
                }
                
                else if (_distances[_distances.Count - 1] > _distances[_distances.Count - 2])
                {
                    // the latest distance is further away than before
                    hint = "(^.^) Getting colder!";
                }
                else
                {
                    // The latest distance is the same or closer
                    hint = "(>.<) Getting warmer!";
                }
            }

            return hint;
        }

        /// <summary>
        /// Returns whether the hider has been found. (Hint: the last distance is 0 in that case.)
        /// </summary>
        /// <returns>True if the hider has been found.</returns>
        public bool IsFound()
        {
            return _distances[_distances.Count - 1] == 0;
        }
    }
}
