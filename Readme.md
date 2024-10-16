<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/168115326/18.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T830471)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# Dashboard for WinForms - How to Use Dashboard Items in Tab Pages as Independent Master Filters

This example demonstrates how to implement a custom visual interactivity that enables the [Grid](https://docs.devexpress.com/Dashboard/15150) dashboard items placed in different tab pages to act as independent master filters.

The example uses the following API:

* The [DashboardDesigner.DashboardItemSelectionChanged](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardDesigner.DashboardItemSelectionChanged) event is handled to assign selected values to a [dashboard's parameter](https://docs.devexpress.com/Dashboard/16135) and save them in a variable.

* The [DashboardDesigner.DashboardItemVisualInteractivity](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardDesigner.DashboardItemVisualInteractivity) event is handled to restore the selected values and highlight a grid row.

* The [DashboardDesigner.CustomizeDashboardItemCaption](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardDesigner.CustomizeDashboardItemCaption) event displays the filter value in the [Chart](https://docs.devexpress.com/Dashboard/14719) item's [caption](https://docs.devexpress.com/Dashboard/15620).

* The [DashboardDesigner.ConfigureDataConnection](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWin.DashboardDesigner.ConfigureDataConnection) event specifies the [Extract Data Source](https://docs.devexpress.com/Dashboard/115900) file location at runtime.

![screenshot](./images/screenshot.png)

## Files to Review

* [Form1.cs](./CS/CustomInteractivityExample/Form1.cs) / [Form1.vb](./VB/CustomInteractivityExample/Form1.vb)

## Documentation

- [Drill-Down](https://docs.devexpress.com/Dashboard/116913)
- [Master Filtering](https://docs.devexpress.com/Dashboard/116912)
- [Interactivity](https://docs.devexpress.com/Dashboard/116692)
- [Tab Container](https://docs.devexpress.com/Dashboard/400237)

## More Examples 

- [Dashboard for WinForms - How to Initialize Master Filters in Dashboard Viewer](https://github.com/DevExpress-Examples/how-to-apply-default-filtering-to-master-filters-in-dashboardviewer-t329583)
- [Dashboard for WinForms - How to Set Master Filter in Dashboard Viewer](https://github.com/DevExpress-Examples/how-to-apply-master-filtering-in-dashboardviewer-e5097)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-dashboard-designer-custom-interactivity-in-tab-pages&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-dashboard-designer-custom-interactivity-in-tab-pages&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
