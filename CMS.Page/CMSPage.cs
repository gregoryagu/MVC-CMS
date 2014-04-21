using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Page
{
    using AutoMapper;

    using CMS.Core;
    using CMS.Data;

    public class CMSPage
    {

        public string Action { get; set; }

        static CMSPage() {
            Mapper.CreateMap<PageEntity, CMSPage>();
            Mapper.CreateMap<CMSPage, PageEntity>();
        }
        
        public static CMSPage Create(Data.PageEntity page) {
            return Mapper.Map<CMSPage>(page);
        }
        public string Title { get; set; }

        [System.Web.Mvc.AllowHtml]
        public string Body { get; set; }
        
        public Guid Id { get; set; }

        public ViewMode ViewMode { get; set; }

        internal static PageEntity CreateEntity(CMSPage page) {
            return Mapper.Map<PageEntity>(page);
        }

        
    }
}
