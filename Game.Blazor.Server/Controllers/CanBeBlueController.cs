using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using Game.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Game.Blazor.Server.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class CanBeBlueController : ViewController
    {
        SimpleAction actBlue;
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public CanBeBlueController()
        {
            InitializeComponent();
            TargetObjectType = typeof(ICanBeBlue);
            
            actBlue = new SimpleAction(this, "Blue", "View");
            actBlue.Execute += actBlue_Execute;
            
        }
        private void actBlue_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            // get the selected
            var selected = View.SelectedObjects.Cast<MatchPlayer>().ToList();    
            //change them to blue
            foreach (var matchPlayer in selected)
            {
                var persistentMatchPlayer = ObjectSpace.GetObjectByKey<MatchPlayer>(matchPlayer.ID);

                persistentMatchPlayer.TeamId = (int)TeamEnum.Blue;

                // mark the object as modified
                View.ObjectSpace.SetModified(matchPlayer);
            }
            View.ObjectSpace.CommitChanges();
            ObjectSpace.Refresh();
        }
         
    }
}
