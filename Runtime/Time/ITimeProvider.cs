// ReSharper disable InconsistentNaming
namespace Plugins.AAA.Core.Runtime.Time
{
    public interface ITimeProvider
    {
        public float time { get; }
        public float unscaledTime { get; }
        public float fixedTime { get; }
        public float timeScale { get; }
        public float deltaTime { get; }
        public float fixedDeltaTime { get; }
    }

    public class UnityTimeProvider : ITimeProvider
    {
        public float time => UnityEngine.Time.time;
        public float unscaledTime => UnityEngine.Time.unscaledTime;
        public float fixedTime => UnityEngine.Time.fixedTime;
        public float timeScale => UnityEngine.Time.timeScale;
        public float deltaTime => UnityEngine.Time.deltaTime;
        public float fixedDeltaTime => UnityEngine.Time.fixedDeltaTime;
    }

    public class TimeProvider : ITimeProvider
    {
        public static ITimeProvider TimeProviderInstance;
        public float time => 0;
        public float unscaledTime => 0;
        public float fixedTime => 0;
        public float timeScale => 1;
        public float deltaTime => 0.01f;
        public float fixedDeltaTime => 0.02f;
    }
}