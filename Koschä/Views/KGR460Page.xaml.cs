﻿using Koschä.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Koschä.Views;

// TODO: Change the grid as appropriate for your app. Adjust the column definitions on DataGridPage.xaml.
// For more details, see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid.
public sealed partial class KGR460Page : Page
{
    public KGR460ViewModel ViewModel
    {
        get;
    }

    public KGR460Page()
    {
        ViewModel = App.GetService<KGR460ViewModel>();
        InitializeComponent();
    }
}
