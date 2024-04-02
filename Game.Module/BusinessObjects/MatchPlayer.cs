using DevExpress.Persistent.BaseImpl.EF;
using System;
using System.Linq;

namespace Game.Module.BusinessObjects
{
    public class MatchPlayer : BaseObject
    {
        public MatchPlayer()
        {
        }
        public virtual Match Match { get; set; }
        public virtual Player Player { get; set; }
        public virtual int TeamId { get; set; }

        internal virtual BlueMatchPlayer DuplicateBlue()
        {
            var mp = new BlueMatchPlayer();
            ((MatchPlayer)mp).CopyFrom(this,mp);
            return mp;
        }
        internal virtual RedMatchPlayer DuplicateRed()
        {
            var mp = new RedMatchPlayer();
            ((MatchPlayer)mp).CopyFrom(this, mp);
            return mp;
        }
        internal virtual SpectatorMatchPlayer DuplicateSpectator()
        {
            var mp = new SpectatorMatchPlayer();
            ((MatchPlayer)mp).CopyFrom(this, mp);
            return mp;
        }
        private void CopyFrom(MatchPlayer oFrom, MatchPlayer oTo)
        {
            oTo.Player = oFrom.Player;
            oTo.TeamId = oFrom.TeamId;
            oTo.Match = oFrom.Match;
            oTo.ID = oFrom.ID;
             
        }
    }


 

    public enum TeamEnum
    {
        Blue = 1,
        Red = 2,
        Spectator = 3
    }
}