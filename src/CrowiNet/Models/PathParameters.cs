using System;

namespace CrowiNet
{
    public interface IPathParameter
    {
        string PathParameter { get; }
    }


    public class Path : IPathParameter
    {
        private readonly string _pathName;

        public Path(string pathName)
        {
            if (pathName == null) throw new ArgumentNullException(nameof(pathName));
            if (pathName[0] != '/') throw new ArgumentException("pathName should start with /");

            _pathName = pathName;
        }

        public string PathParameter => $"path={_pathName}";
    }

    public class User : IPathParameter
    {
        private readonly string _userName;

        public User(string userName)
        {
            _userName = userName ?? throw new ArgumentNullException(nameof(userName));
        }

        public string PathParameter => $"user={_userName}";
    }
}