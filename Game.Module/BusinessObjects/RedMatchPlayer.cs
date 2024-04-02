namespace Game.Module.BusinessObjects
{
    public class RedMatchPlayer : MatchPlayer, ICanBeBlue, ICanBeSpectator
    {
        public virtual string RedPlayerName { get => this.Player.Name;  }
         
    }
}