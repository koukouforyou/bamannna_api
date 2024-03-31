using System;
using Bamanna.DouDian.Core;
using Bamanna.DouDian.Core.Dependency;
using Bamanna.DouDian.Services.Permission;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bamanna.DouDian.Extensions.MarkupExtensions
{
    [ContentProperty("Text")]
    public class HasPermissionExtension : IMarkupExtension
    {
        public string Text { get; set; }
        
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (ApplicationBootstrapper.AbpBootstrapper == null || Text == null)
            {
                return false;
            }

            var permissionService = DependencyResolver.Resolve<IPermissionService>();
            return permissionService.HasPermission(Text);
        }
    }
}