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
    public class DovizKuruViewModel
    {

        public DovizData DovizData { get; set; }
        private HttpClient client;

        public bool IsRefreshing { get; set; }
        public ObservableCollection<DovizItem> Items { get; set; }

        public DovizKuruViewModel()
        {
            client = new HttpClient();
        }
        public ICommand Get =>
             new Command(async () =>
             {
                 await GetDoviz();
             });
        public async Task GetDoviz()
        {
            var url = "https://api.genelpara.com/embed/altin.json";
            IsRefreshing = true;
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = await JsonSerializer.DeserializeAsync<DovizData>(responseStream);
                    DovizData = data;


                    Items = new ObservableCollection<DovizItem>()
                    {
                        new DovizItem { Title = "Dolar", satis = data.USD.satis, alis = data.USD.alis, fark = data.USD.degisim, yon = data.USD.d_yon },
                        new DovizItem { Title = "Euro", satis = data.EUR.satis, alis = data.EUR.alis, fark = data.EUR.degisim, yon = data.EUR.d_yon },
                        new DovizItem { Title = "Sterlin", satis = data.GBP.satis, alis = data.GBP.alis, fark = data.GBP.degisim, yon = data.GBP.d_yon },
                        new DovizItem { Title = "Gram Altin", satis = data.GA.satis, alis = data.GA.alis, fark = data.GA.degisim, yon = data.GA.d_yon },
                        new DovizItem { Title = "Çeyrek Altin", satis = data.C.satis, alis = data.C.alis, fark = data.C.degisim, yon = data.C.d_yon },
                        new DovizItem { Title = "Gümüş", satis = data.GAG.satis, alis = data.GAG.alis, fark = data.GAG.degisim, yon = data.GAG.d_yon },
                        new DovizItem { Title = "BTC(USD)", satis = data.BTC.satis, alis = data.BTC.alis, fark = data.BTC.degisim, yon = data.BTC.d_yon },
                        new DovizItem { Title = "ETH(USD)", satis = data.ETH.satis, alis = data.ETH.alis, fark = data.ETH.degisim, yon = data.ETH.d_yon },
                        new DovizItem { Title = "BIST 100", satis = data.XU100.satis, alis = data.XU100.alis, fark = data.XU100.degisim },
                    };
                }
            }
            IsRefreshing = false;
        }
    }
}
