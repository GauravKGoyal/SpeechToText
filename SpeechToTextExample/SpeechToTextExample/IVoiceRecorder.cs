using System;

namespace SpeechToTextExample
{
    public interface IVoiceRecorder : IDisposable
    {
        void StartRecording();
        void StopRecording();
    }
}