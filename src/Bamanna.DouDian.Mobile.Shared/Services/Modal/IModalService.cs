using System.Threading.Tasks;
using Bamanna.DouDian.Views;
using Xamarin.Forms;

namespace Bamanna.DouDian.Services.Modal
{
    public interface IModalService
    {
        Task ShowModalAsync(Page page);

        Task ShowModalAsync<TView>(object navigationParameter) where TView : IXamarinView;

        Task<Page> CloseModalAsync();
    }
}
