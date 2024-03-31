using Xamarin.Forms.Internals;

namespace Bamanna.DouDian.Behaviors
{
    [Preserve(AllMembers = true)]
    public interface IAction
    {
        bool Execute(object sender, object parameter);
    }
}