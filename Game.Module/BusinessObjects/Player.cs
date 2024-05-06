using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using Microsoft.Identity.Client;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DevExpress.ExpressApp.Editors;

namespace Game.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Player : BaseObject
    {
        public Player() { this.Matches = []; }
        public virtual string Name { get; set; }
        public virtual IList<MatchPlayer> Matches { get; set; }

        //[NotMapped]
        //[EditorAlias(EditorAliases.IntegerPropertyEditor)]
        //public virtual int  counter { get; set;}

        public virtual Guid? PreferredPlayer1Guid { get; set; }
        [ForeignKey("PreferredPlayer1Guid")]
        public virtual Player PreferredPlayer1 { get; set; }
 
    }
}