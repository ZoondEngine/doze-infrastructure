using Doze.Nt.Client.Network;
using Jareem.Network.Packets.News.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Nt.Client.ProductSubview
{
    public class ProductContext : DozeObject
    {
        private ArticleMetaLoader MetaLoader { get; set; }
        private NetworkClientObject NetworkClient { get; set; }

        public ProductContext()
            : base()
        {
            MetaLoader = Create<ArticleMetaLoader>();
            NetworkClient = FindObjectOfType<NetworkClientObject>();

        }

        public ArticleView[] GetArticles()
        {
            return null;
        }

        public ArticleView[] GetArticlesByProductIdentifier()
        {

        }
    }
}
