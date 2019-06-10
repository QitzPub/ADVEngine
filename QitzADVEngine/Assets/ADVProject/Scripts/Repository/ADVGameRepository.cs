
using Qitz.ArchitectureCore;

namespace Qitz.ADVGame
{
    public interface IADVGameRepository
    {
    }

    public class ADVGameRepository : ARepository, IADVGameRepository
    {
        ADVGameDataStore aDVGameDataStore;
        public ADVGameRepository(string macro)
        {
            this.aDVGameDataStore = new ADVGameDataStore(macro);
        }
    }
}