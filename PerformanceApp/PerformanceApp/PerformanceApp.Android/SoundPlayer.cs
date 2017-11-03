﻿using Android.Media;
using Xamarin.Forms;

[assembly: Dependency(typeof(PerformanceApp.Droid.SoundPlayer))]

namespace PerformanceApp.Droid
{
    public class SoundPlayer : PerformanceApp.IPlatformSoundPlayer
    {
        AudioTrack previousAudioTrack;

        public void PlaySound(int samplingRate, byte[] pcmData)
        {
            if (previousAudioTrack != null) {
                previousAudioTrack.Stop();
                previousAudioTrack.Release();
            }

            AudioTrack audioTrack = new AudioTrack(Stream.Music, samplingRate, ChannelOut.Mono, Android.Media.Encoding.Pcm16bit, pcmData.Length * sizeof(short), AudioTrackMode.Static);

            audioTrack.Write(pcmData, 0, pcmData.Length);
            audioTrack.Play();
            previousAudioTrack = audioTrack;
        }
    }
}
