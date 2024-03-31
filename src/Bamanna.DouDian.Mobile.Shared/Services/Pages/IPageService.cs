using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bamanna.DouDian.Services.Pages
{
    public interface IPageService
    {
        Page MainPage { get; set; }

        Task<Page> CreatePage(Type viewType, object navigationParameter);
    }
}
