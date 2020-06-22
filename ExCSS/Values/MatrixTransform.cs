namespace ExCSS
{
    public sealed class MatrixTransform : ITransform
    {
        private readonly float[] _values;

        public MatrixTransform(float[] values)
        {
            _values = values;
        }

        public TransformMatrix ComputeMatrix()
        {
            return new TransformMatrix(_values);
        }
    }
}