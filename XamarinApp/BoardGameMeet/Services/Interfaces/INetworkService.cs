using BoardGameMeet.Network.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace BoardGameMeet.Services.Interfaces
{
    public interface INetworkService
    {
        Task SetToken(string token);
        Task<TResp> GetAsync<TResp>(string path, CancellationToken cancellationToken) where TResp : BaseResponse;
        Task<TResp> PostAsync<TReq, TResp>(string path, TReq requestObject, CancellationToken cancellationToken) where TResp : BaseResponse;
        Task<TResp> PutAsync<TReq, TResp>(string path, TReq requestObject, CancellationToken cancellationToken) where TResp : BaseResponse;
    }
}
