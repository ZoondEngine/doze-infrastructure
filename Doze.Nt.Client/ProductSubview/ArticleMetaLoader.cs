using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Doze.Nt.Client.ProductSubview
{
    public class ArticleMetaLoader : DozeObject
    {
        public const string UNKNOWN_PATH = "unknown";

        public string MetaCachePath;
        public string MetaCacheFilesExtension;

        public ArticleMetaLoader()
            : base()
        { }

        public void Init(string metaCachePath, string metaFilesExtension)
        {
            MetaCachePath = metaCachePath;
            MetaCacheFilesExtension = metaFilesExtension;
        }

        public string CacheMeta(string link)
        {
            var fn = ParseFilenameFromLink(link);
            if(!IsMetaCached(fn))
            {
                if (LoadMeta(link))
                {
                    return GetMetaPath(fn);
                }
                else
                {
                    return "unknown";
                }
            }
            else
            {
                return GetMetaPath(fn);
            }
        }

        public async Task<string> CacheMetaAsync(string metaLink)
            => await Task.Run(() => CacheMeta(metaLink));

        private bool LoadMeta(string link)
        {
            WebClient wc = new WebClient();
            wc.DownloadFile(new Uri(link), GetMetaPath(ParseFilenameFromLink(link)));

            return IsMetaCached(ParseFilenameFromLink(link));
        }

        public override void Destroy()
        {
            MetaCachePath = null;
            MetaCacheFilesExtension = null;
        }

        public bool IsMetaCached(string fileName)
            => File.Exists(GetMetaPath(fileName));

        public string GetMetaPath(string fileName)
            => $"{MetaCachePath}\\{fileName}.{MetaCacheFilesExtension}";

        public string ParseFilenameFromLink(string link)
            => link.Split('/').Last().Split('.')[0];

        public bool IsUnknownMetaPath(string metaPath)
            => metaPath == UNKNOWN_PATH;
    }
}
