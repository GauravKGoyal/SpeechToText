using System;
using Android.Media;
using Java.Util.Zip;
using SpeechToTextExample.Droid;
using Xamarin.Forms;
using Exception = System.Exception;

//[assembly: Dependency(typeof(VoiceRecorder))]
//https://docs.microsoft.com/en-us/xamarin/android/app-fundamentals/android-audio

namespace SpeechToTextExample.Droid
{
    public class VoiceRecorder : IVoiceRecorder
    {
        private string filePath;
        private MediaRecorder recorder;
        private MediaPlayer player;

        public VoiceRecorder()
        {
            var fileLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            filePath = System.IO.Path.Combine(fileLocation, "gauravfileName");
        }

        private void EnsureInitiazed()
        {
            if (Initialized)
            {
                return;
            }

            const string rec = Android.Content.PM.PackageManager.FeatureMicrophone;
            if (rec != "android.hardware.microphone")
            {
                throw new InvalidOperationException("You don't seem to have a microphone to record with");
            }
            try
            {
                recorder = new MediaRecorder();
                recorder.Reset();
                recorder.SetAudioSource(AudioSource.Mic);
                recorder.SetOutputFormat(OutputFormat.ThreeGpp);
                recorder.SetAudioEncoder(AudioEncoder.AmrNb);
                recorder.SetOutputFile(filePath);
                recorder.Prepare();

                // player = new MediaPlayer();
                Initialized = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private bool Initialized { get; set; }

        public void StartRecording()
        {
            EnsureInitiazed();
            try
            {
                //if (System.IO.File.Exists(filePath))
                //{
                //    System.IO.File.Delete(filePath);
                //}

                recorder.Start(); 
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.StackTrace);
            }
        }

        public void StopRecording()
        {
            EnsureInitiazed();

            try
            {
                recorder.Stop();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void StartPlayer()
        {
            player.Reset();
            player.SetDataSource(filePath);
            player.Prepare();
            player.Start();
        }

        public void StopPlayer()
        {
            player.Stop();
        }

        public void Dispose()
        {
            recorder.Release();
            recorder = null;

            player.Release();
            player = null;
        }
    }
}