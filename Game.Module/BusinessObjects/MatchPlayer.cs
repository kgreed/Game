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
    }

    public enum TeamEnum
    {
        Blue = 1,
        Red = 2,
        Spectator = 3
    }
}