namespace SpeechToTextExample
{
    public static class Constants
    {
        public static readonly string AuthenticationTokenEndpoint = "https://api.cognitive.microsoft.com/sts/v1.0";
        public static readonly string BingSpeechApiKey = "143b234b9dcd4749842e26d777bef3e2";
        public static readonly string SpeechRecognitionEndpoint = "https://speech.platform.bing.com/speech/recognition/interactive/cognitiveservices/v1?language=en-US";  // https://speech.platform.bing.com/speech/recognition/interactive/cognitiveservices/v1
        public static readonly string AudioContentType = @"audio/wav; codec=""audio/pcm""; samplerate=88000";
        public static readonly string AudioFilename = "gaurav.wav";
    }
}