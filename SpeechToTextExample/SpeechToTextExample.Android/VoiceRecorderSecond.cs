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
    public class VoiceRecorder2 : IVoiceRecorder
    {
        //static string filePath = "/sdcard/Music/testAudio.mp3";
        static string filePath = "/data/data/Example_WorkingWithAudio.Example_WorkingWithAudio/files/testAudio.mp4";
        MediaRecorder recorder = null;

        public void StartRecording()
        {
            try
            {
                if (System.IO.File.Exists(filePath))
                    System.IO.File.Delete(filePath);


                if (recorder == null)
                    recorder = new MediaRecorder(); // Initial state.
                else
                    recorder.Reset();

                recorder.SetAudioSource(AudioSource.Mic);
                recorder.SetOutputFormat(OutputFormat.Mpeg4);
                recorder.SetAudioEncoder(AudioEncoder.AmrNb); // Initialized state.
                recorder.SetOutputFile(filePath); // DataSourceConfigured state.
                recorder.Prepare(); // Prepared state
                recorder.Start(); // Recording state.

            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.StackTrace);
            }
        }

        public void StopRecording()
        {
            if (recorder != null)
            {
                recorder.Stop();
                recorder.Release();
                recorder = null;
            }
        }

        public void Dispose()
        {
            StopRecording();
        }
    }
}