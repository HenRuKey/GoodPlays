using System;
using System.Collections.Generic;
using System.Text;

namespace GoodPlaysLib.controllers
{
    public class IGDBManager
    {

        /// <summary>
        /// Gathers game data based on a list of game ids.
        /// </summary>
        /// <param name="ids">The ids to look up.</param>
        /// <returns>An array of games found by the api call.</returns>
        public Game[] GamesFromIds(List<string> ids)
        {
            throw new NotImplementedException();
        }

    }
}
