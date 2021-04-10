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
            var player = ServicesProvider.Get<IPlayer>();
            player.Side = true;
            players.Add(player);
        }
    }
}