using Infrastructure.ServiceLocator;

namespace Services.SoundService
{
    public interface ISoundService : IService
    {
        void PlayMouseSound();
    }
}