using System;
using New_Chapter3.Services;
using New_Chapter3.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace New_Chapter3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeadlinesView : ContentPage
    {
        public HeadlinesView()
        {
            InitializeComponent();
            Task.Run(async () => await Initialize("Headlines"));
        }
        public HeadlinesView(string scope)
        {
            InitializeComponent();
            Title = $"{scope} news";
            Task.Run(async () => await Initialize(scope));
        }
        private async Task Initialize(string scope)
        {
            var viewModel = Resolver.Resolve<HeadlinesViewModel>();
            BindingContext = viewModel;
            await viewModel.Initialize(scope);
        }
    }
}