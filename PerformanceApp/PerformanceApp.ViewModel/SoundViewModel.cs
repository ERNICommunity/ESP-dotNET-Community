using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PerformanceApp.ViewModel
{
    public class SoundViewModel : ViewModelBase, IHandle<SoundMessage>
    {
        public SoundViewModel()
        {
            EventAggregator.Subscribe(this);

            PlaySound1 = new Command(Sound1Clicked);
            PlaySound2 = new Command(Sound2Clicked);
        }

        public ICommand PlaySound1 { get; private set; }
        public ICommand PlaySound2 { get; private set; }

        double[] frequencies = { 523.25, 622.25, 739.99, 880 };
        private void Sound1Clicked(object sender)
        {
            EventAggregator.Publish(new SoundMessage()
            {
                Frequency = frequencies[2],
                Duration = 500
            });
        }

        private void Sound2Clicked(object sender)
        {
            EventAggregator.Publish(new SoundMessage()
            {
                Frequency = frequencies[3],
                Duration = 500
            });
        }

        public void Handle(SoundMessage message)
        {
            PerformanceApp.SoundPlayer.PlaySound(message.Frequency, message.Duration);
        }
    }
}
