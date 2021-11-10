using System.Collections.Generic;
using _08_rfk.Casting;
using _08_rfk.Services;


namespace _08_rfk.Scripting
{
    // TODO: Add your class here to draw all the actors in the game
    // making use of the OutputService object.
    /// <summary>
    /// The Robot is a base actor with some particular values.
    /// </summary>
    public class DrawActorsAction : Actor 
    {
        private OutputService _outputService;
        public DrawActorsAction(OutputService outputService)
        {
            _outputService = outputService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            _outputService.StartDrawing();

            foreach (List<Actor> group in cast.Values)
            {
                _outputService.DrawActors(group);
            }

            _outputService.EndDrawing();
        }
    }
}