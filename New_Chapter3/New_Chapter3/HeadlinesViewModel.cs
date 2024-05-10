using New_Chapter3.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Web;
using System.Windows.Input;
using System.Threading.Tasks;
using New_Chapter3.Models;
using New_Chapter3.Services;
using System.Text;

namespace New_Chapter3
{
    public class HeadlinesViewModel : ViewModel
    {
        private readonly NewsService newsService;
        public NewsResult CurrentNews { get; set; }
        public HeadlinesViewModel(NewsService newsService)
        {
            this.newsService = newsService;
        }
        public async Task Initialize(string scope)
        {
            var resolvedScope = scope.ToLower() switch
            {
                "local" => NewsScope.Local,
                "global" => NewsScope.Global,
                "headlines" => NewsScope.Headlines,
                _ => NewsScope.Headlines
            };
            await Initialize(resolvedScope);
        }
        public async Task Initialize(NewsScope scope)
        {
            CurrentNews = await newsService.GetNews(scope);
        }
        public ICommand ItemSelected =>
        new Command(async (selectedItem) =>
        {
            var selectedArticle = selectedItem as Article;
            var url = HttpUtility.UrlEncode(selectedArticle.Url);
            // Placeholder for more code later on
        });
    }

}

