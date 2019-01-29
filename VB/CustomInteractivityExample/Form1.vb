Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardCommon.ViewerData
Imports DevExpress.DashboardWin
Imports System
Imports System.Collections.Generic
Imports System.IO

Namespace CustomInteractivityExample
	Partial Public Class Form1
		Inherits DevExpress.XtraEditors.XtraForm

		Private selectionCache As List(Of AxisPointTuple)
		Public Sub New()
			InitializeComponent()
			AddHandler dashboardDesigner1.DashboardItemVisualInteractivity, AddressOf DashboardDesigner1_DashboardItemVisualInteractivity
			AddHandler dashboardDesigner1.DashboardItemSelectionChanged, AddressOf DashboardDesigner1_DashboardItemSelectionChanged
			AddHandler dashboardDesigner1.CustomizeDashboardItemCaption, AddressOf DashboardDesigner1_CustomizeDashboardItemCaption
			AddHandler dashboardDesigner1.ConfigureDataConnection, AddressOf DashboardDesigner1_ConfigureDataConnection
			dashboardDesigner1.CreateRibbon()
			dashboardDesigner1.LoadDashboard("topbottom5.xml")
		End Sub

		Private Sub DashboardDesigner1_DashboardItemVisualInteractivity(ByVal sender As Object, ByVal e As DashboardItemVisualInteractivityEventArgs)
			If e.DashboardItemName = "gridDashboardItem1" Then
				e.SelectionMode = DashboardSelectionMode.Single
				e.EnableHighlighting = True
				e.SetDefaultSelection(selectionCache)

			End If
			If e.DashboardItemName = "gridDashboardItem2" Then
				e.SelectionMode = DashboardSelectionMode.Single
				e.EnableHighlighting = True
				e.SetDefaultSelection(selectionCache)
			End If
		End Sub

		Private Sub DashboardDesigner1_DashboardItemSelectionChanged(ByVal sender As Object, ByVal e As DashboardItemSelectionChangedEventArgs)
			Dim dDesigner As DashboardDesigner = TryCast(sender, DashboardDesigner)
			If e.DashboardItemName = "gridDashboardItem1" OrElse e.DashboardItemName = "gridDashboardItem2" Then
				If e.CurrentSelection.Count = 0 Then
					dDesigner.Parameters(0).SelectedValue = Nothing
				Else
					selectionCache = e.CurrentSelection
'INSTANT VB NOTE: The variable companyName was renamed since Visual Basic does not handle local variables named the same as class members well:
					Dim companyName_Renamed As String = e.CurrentSelection(0).GetAxisPoint().DimensionValue.Value.ToString()
					dDesigner.Parameters(0).SelectedValue = companyName_Renamed
				End If
			End If
		End Sub

		Private Sub DashboardDesigner1_CustomizeDashboardItemCaption(ByVal sender As Object, ByVal e As CustomizeDashboardItemCaptionEventArgs)
			Dim dDesigner As DashboardDesigner = TryCast(sender, DashboardDesigner)
			If e.DashboardItemName = "chartDashboardItem1" AndAlso dDesigner.Parameters.Count > 0 Then
				e.FilterText = String.Format(" {0}", dDesigner.Parameters(0).SelectedValue)
			End If
		End Sub
		Private Sub DashboardDesigner1_ConfigureDataConnection(ByVal sender As Object, ByVal e As DevExpress.DashboardCommon.DashboardConfigureDataConnectionEventArgs)
			Dim parameters As ExtractDataSourceConnectionParameters = TryCast(e.ConnectionParameters, ExtractDataSourceConnectionParameters)
			If parameters IsNot Nothing Then
				parameters.FileName = Path.GetFileName(parameters.FileName)
			End If
		End Sub
	End Class
End Namespace
