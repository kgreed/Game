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
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Game.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class MatchDetailViewController : ViewController
    {
        SimpleAction actGetChecked;
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public MatchDetailViewController()
        {
            InitializeComponent();
            TargetObjectType = typeof(Game.Module.BusinessObjects.Match);
            TargetViewType = ViewType.DetailView;

            actGetChecked = new SimpleAction(this, "MyAction", "View");
            actGetChecked.Execute += actGetChecked_Execute;
            
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        private void actGetChecked_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var items = ((CompositeView) View).GetItems<PropertyEditor>();
            var bluePlayers = items.FirstOrDefault(i => i.PropertyName == "BluePlayers");
          
            var bluelistViewControl = bluePlayers.Control as DevExpress.ExpressApp.ListView;
            var selectedObjects = bluelistViewControl.SelectedObjects;

            //foreach (PropertyEditor item in items) { 
            
            //    Debug.Print(item.PropertyName);
            //}
            //Debug.Print("Finished");
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
