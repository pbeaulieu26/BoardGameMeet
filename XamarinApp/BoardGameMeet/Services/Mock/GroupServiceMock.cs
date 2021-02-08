using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BoardGameMeet.Models;
using BoardGameMeet.Services.Interfaces;

namespace BoardGameMeet.Services.Mock
{
    public class GroupServiceMock : IGroupService
    {
        public async Task<IEnumerable<Group>> GetMyGroups(CancellationToken token)
        {
            var groups = new List<Group>
            {
                new Group
                {
                    Name = "Bitconnect",
                    Members = new List<User>
                    {
                        new User
                        {
                            Name = "Pat"
                        },
                        new User
                        {
                            Name = "Roy"
                        },
                        new User
                        {
                            Name = "Morel"
                        }
                    }
                }
            };

            return await Task.FromResult(groups);
        }
    }
}
