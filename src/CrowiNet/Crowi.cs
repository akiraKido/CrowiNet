using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CrowiNet.Models;
using Jil;

namespace CrowiNet
{
    public class Credentials
    {
        public Credentials(string user, string accessToken)
        {
            AccessToken = accessToken;
            User = user;
        }

        public string AccessToken { get; }
        public string User { get; }

        internal string Query => $"access_token={AccessToken}&user={User}";
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

        public async Task<PageList> GetPageListAsync()
        {
            var targetEndPoint = new Uri( _endPoint, $"./_api/pages.list?{_credentials.Query}" );
            var downloadedString = await _client.DownloadStringTaskAsync(targetEndPoint).ConfigureAwait(false);
            var result = PageList.FromJson(JSON.DeserializeDynamic(downloadedString));
            return result;
        }
        
        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
