namespace FlvExtract
{
    public class DummyAudioWriter : IAudioWriter
    {
        public string Path
        {
            get
            {
                return null;
            }
        }

        public AudioFormat AudioFormat => AudioFormat.Mp3;

        public void Dispose()
        {
        }

        public void WriteChunk(byte[] chunk, uint timeStamp)
        {
        }
    }

    public class DummyVideoWriter : IVideoWriter
    {
        public string Path
        {
            get
            {
                return null;
            }
        }

        public VideoFormat VideoFormat => VideoFormat.H264;

        public void Finish(FractionUInt32 averageFrameRate)
        {
        }

        public void WriteChunk(byte[] chunk, uint timeStamp, int frameType)
        {
        }
    }
}