
namespace Game.Module.BusinessObjects
{
    public class BlueMatchPlayer : MatchPlayer, ICanBeRed, ICanBeSpectator
    {
        public virtual string BluePlayerName { get => Player.Name; }

        
    }
}