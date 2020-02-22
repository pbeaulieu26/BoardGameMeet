using BoardGameMeet.Network.Client;
using BoardGameMeet.Network.Responses;
using BoardGameMeet.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BoardGameMeet.Services
{
    public class NetworkService : INetworkService
    {
        private const string RootUrl = "https://www.boardgameatlas.com/api";
        private const string ContentType = "application/x-www-form-urlencoded";
        private const string TokenKey = "jwt";

        private readonly Dictionary<string, string> _header = new Dictionary<string, string>();
        private readonly RestClient _restClient = new RestClient(ContentType);

        public NetworkService()
        {
            if (Application.Current.Properties.TryGetValue(TokenKey, out var token))
            {
                _header[TokenKey] = token.ToString();
            }
        }

        public async Task SetToken(string token)
        {
            _header[TokenKey] = token;
            Application.Current.Properties[TokenKey] = token;
            await Application.Current.SavePropertiesAsync();
        }

        public async Task<TResp> GetAsync<TResp>(string path, CancellationToken cancellationToken) where TResp : BaseResponse
        {
            return await Execute(async () => await _restClient.GetAsync<TResp>(new Uri($"{RootUrl}{path}"), _header, cancellationToken));
        }

        public async Task<TResp> PostAsync<TReq, TResp>(string path, TReq requestObject, CancellationToken cancellationToken) where TResp : BaseResponse
        {
            return await Execute(async () => await _restClient.PostAsync<TReq, TResp>(new Uri($"{RootUrl}{path}"), requestObject, _header, cancellationToken));
        }

        public async Task<TResp> PutAsync<TReq, TResp>(string path, TReq requestObject, CancellationToken cancellationToken) where TResp : BaseResponse
        {
            return await Execute(async () => await _restClient.PutAsync<TReq, TResp>(new Uri($"{RootUrl}{path}"), requestObject, _header, cancellationToken));
        }

        private async Task<TResp> Execute<TResp>(Func<Task<TResp>> request)
        {
            try
            {
                return await Task.Run(async() => await request?.Invoke());
            }
            catch (Exception e) when (e is ApiException ae && (ae.StatusCode == ApiStatus.Unauthorized || ae.StatusCode == ApiStatus.Forbidden))
            {
                // Ask for authentification
                throw;
            }
        }
    }
}
