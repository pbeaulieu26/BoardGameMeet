using BoardGameMeet.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BoardGameMeet.Services.Interfaces
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>> GetMyGroups(CancellationToken token);
    }
}
