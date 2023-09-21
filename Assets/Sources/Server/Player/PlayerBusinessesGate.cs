using Server.BusinessLogic;

namespace Server.PlayerLogic
{
    public class PlayerBusinessesGate
    {
        private readonly Player _player;

        public PlayerBusinessesGate(Player player)
        {
            _player = player;
        }

        public void AddBusiness(Business business)
        {
            _player.BusinessesList.AddBusiness(business);
        }
    }
}