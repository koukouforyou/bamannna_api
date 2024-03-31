﻿using Bamanna.DouDian.Models.Tenants;
using Bamanna.DouDian.ViewModels;
using Xamarin.Forms;

namespace Bamanna.DouDian.Views
{
    public partial class TenantsView : ContentPage, IXamarinView
    {
        public TenantsView()
        {
            InitializeComponent();
        }

        private async void ListView_OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            await ((TenantsViewModel)BindingContext).LoadMoreTenantsIfNeedsAsync(e.Item as TenantListModel);
        }
    }
}