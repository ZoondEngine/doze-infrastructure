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

        public ProductContext()
            : base()
        {
            MetaLoader = Create<ArticleMetaLoader>();
        }

        public ArticleView[] GetArticles(List<Article> networkArticleData)
        {
            return null;
        }
    }
}
