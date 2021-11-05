using NAudio.Wave;
using System;

namespace GeneticAlgorithmMusicProject.HelperClasses
{
    public class AudioController
    {
        public WaveOutEvent PlaybackWaveOutEvent { get; set; }
        public MediaFoundationReader MediaPlayer { get; set; }

        public AudioController(string chosenFilePath)
        {
            //Dispose any audio previously loaded so multiple uses can be done
            PlaybackWaveOutEvent = new WaveOutEvent();
            MediaPlayer = new MediaFoundationReader(chosenFilePath);
            PlaybackWaveOutEvent.Init(MediaPlayer);
        }

        public void PlayAudio()
        {
            PlaybackWaveOutEvent.Play();
            PlaybackWaveOutEvent.PlaybackStopped += OnPlaybackStopped;
        }

        private void OnPlaybackStopped(object sender, EventArgs e)
        {
            MediaPlayer.CurrentTime = TimeSpan.FromSeconds(0);
        }

        public int GetSongLengthInMilliseconds()
        {
            if (MediaPlayer != null)
            {
                return Convert.ToInt32(MediaPlayer.TotalTime.TotalMilliseconds);
            }

            return 0;
        }

        public void PauseAudio()
        {
            PlaybackWaveOutEvent.Pause();
        }

        public void StopAudio()
        {
            PlaybackWaveOutEvent.Stop();
        }

        public void RepositionAudioTime(int seconds)
        {
            MediaPlayer.CurrentTime = TimeSpan.FromSeconds(seconds);
        }

        public void DisposeAudio()
        {
            PlaybackWaveOutEvent.Dispose();
            MediaPlayer.Dispose();
        }
    }
}
