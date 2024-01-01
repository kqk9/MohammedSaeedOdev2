using GorselProgramlamaOdev2.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GorselProgramlamaOdev2.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class HaberlerViewModel
    {
        public HaberlerModel haberlerModel { get; set; }
        public ObservableCollection<Item> Haberler { get; set; } = new ObservableCollection<Item>();
        public ObservableCollection<HaberlerCategories> Categorys { get; set; } = new ObservableCollection<HaberlerCategories>();
        public HttpClient client { get; set; }
        public bool IsRefreshing { get; set; }

        private HaberlerCategories selectedCategory;

        public HaberlerCategories SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                if (selectedCategory != value)
                {
                    selectedCategory = value;
                    // GetHaberler(); 
                }
            }
        }

        public Item SelectedHaber { get; set; }

        public HaberlerViewModel()
        {
            client = new HttpClient();
            Categorys = new ObservableCollection<HaberlerCategories>()
            {
                new HaberlerCategories() { Category = "Manşet", Link = "https://www.trthaber.com/manset_articles.rss"},
                new HaberlerCategories() { Category = "Son Dakika", Link = "https://www.trthaber.com/sondakika_articles.rss"},
                new HaberlerCategories() { Category = "Gündem", Link = "https://www.trthaber.com/gundem_articles.rss"},
                new HaberlerCategories() { Category = "Ekonomi", Link = "https://www.trthaber.com/ekonomi_articles.rss"},
                new HaberlerCategories() { Category = "Spor", Link = "https://www.trthaber.com/spor_articles.rss"},
                new HaberlerCategories() { Category = "Bilim Teknoloji", Link = "https://www.trthaber.com/bilim_teknoloji_articles.rss"},
                new HaberlerCategories() { Category = "Güncel", Link = "https://www.trthaber.com/guncel_articles.rss"},
                new HaberlerCategories() { Category = "Eğitim", Link = "https://www.trthaber.com/egitim_articles.rss"},
            };

            SelectedCategory = Categorys.FirstOrDefault();
        }

        public ICommand GetNewsCommand =>
            new Command(async () =>
            {
                await GetHaberler();
            });

        public ICommand selectedChange =>
          new Command(async () =>
          {
              await GetHaberler();
          });

        public ICommand ThresholdReachedCommand =>
            new Command(async () =>
            {
                //await GetHaberler();
            });

        public async Task GetHaberler(int lastItem = 0)
        {
            try
            {
                var url = $"https://api.rss2json.com/v1/api.json?rss_url={SelectedCategory.Link}";
                IsRefreshing = true;

                Haberler.Clear();

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        var data = await JsonSerializer.DeserializeAsync<HaberlerModel>(responseStream);
                        haberlerModel = data;

                        var pageItems = data.items.Skip(lastItem).Take(3);

                        foreach (var item in pageItems)
                        {
                            var uniqueKey = item.title;
                            var exists = Haberler.Any(existingItem => existingItem.title == uniqueKey);
                            if (!exists)
                            {
                                Haberler.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                IsRefreshing = false;
            }
        }
    }
}
