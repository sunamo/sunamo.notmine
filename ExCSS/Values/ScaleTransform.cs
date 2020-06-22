namespace ExCSS
{
    public sealed class ScaleTransform : ITransform
    {
        private readonly float _sx;
        private readonly float _sy;
        private readonly float _sz;

        public ScaleTransform(float sx, float sy, float sz)
        {
            _sx = sx;
            _sy = sy;
            _sz = sz;
        }

        public TransformMatrix ComputeMatrix()
        {
            return new TransformMatrix(_sx, 0f, 0f, 0f, _sy, 0f, 0f, 0f, _sz, 0f, 0f, 0f, 0f, 0f, 0f);
        }
    }
}