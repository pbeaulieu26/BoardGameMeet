using BoardGameMeet.Models;
using BoardGameMeet.Network.Responses.Elements;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BoardGameMeet.Services.Interfaces
{
    public interface IBoardGameService
    {
        Task<IEnumerable<BoardGameElement>> UserGameList(User user, CancellationToken token);
    }
}
