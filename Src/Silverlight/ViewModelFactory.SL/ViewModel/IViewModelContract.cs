using System.ComponentModel;

namespace ViewModelFactory.ViewModel
{

    public interface IViewModelContract
    {
        string Message { get; set; }
        int ViewCount { get; set; }

        [DefaultValue("Green")]
        string FavoriteColor { get; set; }
    }

}