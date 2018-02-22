using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CrowiNet.Models;
using Jil;

namespace CrowiNet
{
    public class Credentials
    {
        public Credentials(string accessToken)
        {
            AccessToken = accessToken;
        }

        public string AccessToken { get; }

        internal string Query => $"access_token={AccessToken}";
    }

    internal static class StringExtensions
    {
        internal static dynamic ToJson( this string jsonString ) => JSON.DeserializeDynamic( jsonString );
    }

    public class Crowi : IDisposable
    {
        private readonly Uri _endPoint;
        private readonly Credentials _credentials;
        private readonly WebClient _client = new WebClient();

        public Crowi(Uri endPoint, Credentials credentials)
        {
            _endPoint = endPoint ?? throw new ArgumentNullException(nameof(credentials));
            _credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
        }

        public async Task<PagesListResult> GetPageListAsync(IPathParameter parameter)
        {
            var targetEndPoint = new Uri(_endPoint, $"./_api/pages.list?{_credentials.Query}&{parameter.PathParameter}");
            var downloadedString = await _client.DownloadStringTaskAsync(targetEndPoint).ConfigureAwait(false);
            var result = PagesListResult.FromJson(downloadedString.ToJson());
            return result;
        }

        public async Task<UsersResult> GetUsersAsync()
        {
            var targetEndPoint = new Uri( _endPoint, $"./_api/users.list?{_credentials.Query}" );
            var downloadedString = await _client.DownloadStringTaskAsync( targetEndPoint ).ConfigureAwait( false );
            var result = UsersResult.FromJson( downloadedString.ToJson() );
            return result;
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }

    public class UsersResult
    {
        private UsersResult() { }

        public static UsersResult FromJson(dynamic json)
        {
            var users = new List<UserInfo>();
            foreach (var user in json["users"])
            {
                users.Add( UserInfo.FromJson( user ) );
            }

            var result = new UsersResult
            {
                Users = users.ToArray(),
                Ok = json["ok"]
            };
            return result;
        }

        public UserInfo[] Users { get; private set; }
        public bool Ok { get; private set; }
    }
}
