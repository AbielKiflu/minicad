namespace MiniCAD.Domain.Scene
{
    public sealed class SceneManager
    {
        private readonly List<SceneObject3D> _objects = new();

        public IReadOnlyList<SceneObject3D> Objects => _objects;

        public void Add(SceneObject3D obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
            _objects.Add(obj);
        }

        public bool Remove(Guid id)
        {
            var obj = _objects.FirstOrDefault(x => x.Id == id);

            if (obj == null)
                return false;

            return _objects.Remove(obj);
        }

        public void Clear()
        {
            _objects.Clear();
        }
}
}
