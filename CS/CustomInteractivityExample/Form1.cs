using DevExpress.DashboardCommon;
using DevExpress.DashboardCommon.ViewerData;
using DevExpress.DashboardWin;
using System;
using System.Collections.Generic;
using System.IO;

namespace CustomInteractivityExample
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        List<AxisPointTuple> selectionCache;
        public Form1()
        {
            InitializeComponent();
            dashboardDesigner1.DashboardItemVisualInteractivity += DashboardDesigner1_DashboardItemVisualInteractivity;
            dashboardDesigner1.DashboardItemSelectionChanged += DashboardDesigner1_DashboardItemSelectionChanged;
            dashboardDesigner1.CustomizeDashboardItemCaption += DashboardDesigner1_CustomizeDashboardItemCaption;
            dashboardDesigner1.ConfigureDataConnection += DashboardDesigner1_ConfigureDataConnection;
            dashboardDesigner1.CreateRibbon();
            dashboardDesigner1.LoadDashboard("topbottom5.xml");
        }

        private void DashboardDesigner1_DashboardItemVisualInteractivity(object sender, DashboardItemVisualInteractivityEventArgs e)
        {
            if (e.DashboardItemName == "gridDashboardItem1")
            {
                e.SelectionMode = DashboardSelectionMode.Single;
                e.EnableHighlighting = true;
                e.SetDefaultSelection(selectionCache);

            };
            if (e.DashboardItemName == "gridDashboardItem2")
            {
                e.SelectionMode = DashboardSelectionMode.Single;
                e.EnableHighlighting = true;
                e.SetDefaultSelection(selectionCache);
            };
        }

        private void DashboardDesigner1_DashboardItemSelectionChanged(object sender, DashboardItemSelectionChangedEventArgs e)
        {
            DashboardDesigner dDesigner = sender as DashboardDesigner;
            if (e.DashboardItemName == "gridDashboardItem1" || e.DashboardItemName == "gridDashboardItem2")
            {
                if (e.CurrentSelection.Count == 0)
                {
                    dDesigner.Parameters[0].SelectedValue = null;
                }
                else
                {
                    selectionCache = e.CurrentSelection;
                    string companyName = e.CurrentSelection[0].GetAxisPoint().DimensionValue.Value.ToString();
                    dDesigner.Parameters[0].SelectedValue = companyName;
                }
            }
        }

        private void DashboardDesigner1_CustomizeDashboardItemCaption(object sender, CustomizeDashboardItemCaptionEventArgs e)
        {
            DashboardDesigner dDesigner = sender as DashboardDesigner;
            if (e.DashboardItemName == "chartDashboardItem1" && dDesigner.Parameters.Count > 0)
            {
                e.FilterText = string.Format(" {0}", dDesigner.Parameters[0].SelectedValue);
            }
        }
        private void DashboardDesigner1_ConfigureDataConnection(object sender, DevExpress.DashboardCommon.DashboardConfigureDataConnectionEventArgs e)
        {
            ExtractDataSourceConnectionParameters parameters = e.ConnectionParameters as ExtractDataSourceConnectionParameters;
            if (parameters != null)
                parameters.FileName = Path.GetFileName(parameters.FileName);
        }
    }
}
