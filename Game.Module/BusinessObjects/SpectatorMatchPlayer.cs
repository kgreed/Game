namespace Game.Module.BusinessObjects
{
    public class SpectatorMatchPlayer : MatchPlayer, ICanBeRed, ICanBeBlue
    {
        public virtual string SpectatorName { get => Player.Name; }
        
    }
}