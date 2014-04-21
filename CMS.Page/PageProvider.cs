using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Page
{
    using CMS.Data;

    public class PageProvider
    {
        public static CMSPage GetPageById(Guid id) {

            var page = Repository.GetPageById(id);

            return CMSPage.Create(page);

        }

        public static void SavePage(CMSPage page) {
           Repository.SavePage(CMSPage.CreateEntity(page));
        }
    }
}
