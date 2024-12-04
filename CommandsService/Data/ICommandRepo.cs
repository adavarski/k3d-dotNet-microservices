using CommandsService.Models;

namespace CommandsService.Data
{
    public interface ICommandRepo
    {
        
        bool SaveChanges();

        #region Platform
        IEnumerable<Platform> GetAllPlatforms();

        void CreatePlatform(Platform platform);

        bool PlatformExists(int platformId);

        bool ExternalPlatformExists(int externalPlatformId);

        #endregion

        #region Command
        IEnumerable<Command> GetCommandsForPlatform(int platformId);

        Command? GetCommand(int platformId, int commandId);

        void CreateCommand(int platformId, Command command);

        #endregion
    }
}
