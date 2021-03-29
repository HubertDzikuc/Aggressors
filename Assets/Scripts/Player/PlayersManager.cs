using System.Collections.Generic;

namespace Aggressors
{
    public interface IPlayersManager
    {
        void Start();
    }

    public class PlayersManager : IPlayersManager
    {
        private List<IPlayer> players = new List<IPlayer>();

        public void Start()
        {
            players.Add(Configuration.Instance.Provider.Get<IPlayer>());
        }
    }
}