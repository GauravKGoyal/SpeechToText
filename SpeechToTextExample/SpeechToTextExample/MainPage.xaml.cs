using System;
using System.Threading.Tasks;
using Android.Support.V4.Content;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Plugin.TextToSpeech;
using Xamarin.Forms;

namespace SpeechToTextExample
{
    public partial class MainPage : ContentPage
    {
        private bool isRecording;

        public MainPage()
        {
            InitializeComponent();

            CheckPermission();

            CrossTextToSpeech.Current.Speak(WelcomeEntry.Text);
            VoiceRecorder = DependencyService.Get<IVoiceRecorder>();
            SpeechService = new SpeechService(new AuthenticationService(Constants.BingSpeechApiKey));
        }

        public IVoiceRecorder VoiceRecorder { get; set; }

        protected async override void OnAppearing()
        {
            await SpeechService.InitAuth();
            base.OnAppearing();
        }

        public SpeechService SpeechService { get; set; }

        private async Task CheckPermission()
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Microphone);
            if (status != PermissionStatus.Granted)
            {
                var results =
                    await CrossPermissions.Current.RequestPermissionsAsync(new[]
                        {Permission.Microphone, Permission.Storage});
            }
        }

        private async void StartButtonClicked(object sender, EventArgs e)
        {
            if (isRecording)
            {
                return;
            }
            VoiceRecorder.StartRecording();

            isRecording = true;
        }

        private async void StopButtonClicked(object sender, EventArgs e)
        {
            if (!isRecording)
            {
                return;
            }

            VoiceRecorder.StopRecording();
            var speechResult = await SpeechService.RecognizeSpeechAsync(Constants.AudioFilename);

            if (!string.IsNullOrWhiteSpace(speechResult.DisplayText))
            {
                ResultEntry.Text = ResultEntry.Text + speechResult.DisplayText;
            }

            isRecording = false;
        }
    }
}