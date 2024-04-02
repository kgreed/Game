using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Game.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Player : BaseObject
    {
        public Player() { this.Matches = new ObservableCollection<MatchPlayer>(); }
        public virtual string Name { get; set; }
        public virtual IList<MatchPlayer> Matches { get; set; }
    }
}