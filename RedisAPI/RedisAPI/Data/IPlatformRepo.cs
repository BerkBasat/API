using RedisAPI.Models;

namespace RedisAPI.Data
{
    public interface IPlatformRepo
    {
        void CreatePlatform(Platform plat);
        public Platform? GetPlatformById(string id);
        IEnumerable<Platform?>? GetAllPlatforms();
    }
}