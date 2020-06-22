namespace ExCSS
{
    public sealed class PerspectiveTransform : ITransform
    {
        private readonly Length _distance;

        public PerspectiveTransform(Length distance)
        {
            _distance = distance;
        }

        public TransformMatrix ComputeMatrix()
        {
            return new TransformMatrix(
                1f, 
                0f, 
                0f,
                0f,
                1f,
                0f,
                0f,
                0f,
                1f,
                0f,
                0f,
                0f,
                0f,
                0f,
                -1f/_distance.ToPixel());
        }
    }
}