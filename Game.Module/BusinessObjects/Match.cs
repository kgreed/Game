using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Game.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Match : BaseObject, IObjectSpaceLink
    {
        public Match() { this.MatchPlayers = new ObservableCollection<MatchPlayer>(); }
        public virtual string Name { get; set; }

        public override void OnLoaded()
        {
            base.OnLoaded();
            Spectators = MatchPlayers.Where(mp => mp.TeamId == (int)TeamEnum.Spectator)
                .Select(mp => mp.DuplicateSpectator())
                .ToList();
            RedPlayers = MatchPlayers.Where(mp => mp.TeamId == (int)TeamEnum.Red)
                .Select(mp => mp.DuplicateRed())
                .ToList();
            BluePlayers = MatchPlayers.Where(mp => mp.TeamId == (int)TeamEnum.Blue)
                .Select(mp => mp.DuplicateBlue())
                .ToList();
        }

        public virtual IList<MatchPlayer> MatchPlayers { get; set; }
        [NotMapped]
        public virtual IList<SpectatorMatchPlayer> Spectators { get; set; }
        [NotMapped]
        public virtual IList<RedMatchPlayer> RedPlayers { get; set; }
        [NotMapped]
        public virtual IList<BlueMatchPlayer> BluePlayers { get; set; }
        [Action(Caption = "Add Missing", ImageName = "Attention", AutoCommit = true)]
        public void ActionMethod()
        {
            var allPlayers = ObjectSpace.GetObjects<Player>();
            var playersNotInMatch = allPlayers.Where(p => !MatchPlayers.Select(mp => mp.Player).Contains(p)).ToList();
            // add the players to the match
            foreach(var player in playersNotInMatch)
            {
                var matchPlayer = ObjectSpace.CreateObject<MatchPlayer>();
                matchPlayer.Match = this;
                matchPlayer.Player = player;
                matchPlayer.TeamId = (int) TeamEnum.Spectator;
                MatchPlayers.Add(matchPlayer);
            }
            ObjectSpace.CommitChanges();
            // refresh detail view
            ObjectSpace.Refresh();
        }
    }
} 