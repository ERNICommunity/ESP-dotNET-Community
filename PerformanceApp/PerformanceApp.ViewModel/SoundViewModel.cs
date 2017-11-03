using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PerformanceApp.ViewModel
{
    public class SoundViewModel : ViewModelBase
    {
        public SoundViewModel()
        {
            PlaySound1 = new Command(Sound1Clicked);
            PlaySound2 = new Command(Sound2Clicked);
        }

        public ICommand PlaySound1 { get; private set; }
        public ICommand PlaySound2 { get; private set; }

        double[] frequencies = { 523.25, 622.25, 739.99, 880 };
        private void Sound1Clicked(object sender)
        {
            // PerformanceApp.SoundPlayer.PlaySound(frequencies[0], 500);
            PerformanceApp.SoundPlayer.PlaySound(frequencies[2], 500);
        }

        private void Sound2Clicked(object sender)
        {
            //PerformanceApp.SoundPlayer.PlaySound(frequencies[1], 500);
            PerformanceApp.SoundPlayer.PlaySound(frequencies[3], 500);
        }
    }
}
