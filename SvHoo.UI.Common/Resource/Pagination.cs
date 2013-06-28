using System;
using System.IO;
using System.Text;
using SvHoo.UI.Common.Helper;

namespace SvHoo.UI.Common.Resource
{
    public class Pagination
    {
        const string PAGETAG = "page";
        const int PAGENUM = 7;

        private string requestPage = null;
        public string RequestPage
        {
            get { return string.IsNullOrEmpty(requestPage) ? HttpContextHelper.Request.Path : requestPage; }
            set { requestPage = value; }
        }

        /// <param name="total">总记录数</param>
        /// <param name="per">每页记录数</param>
        /// <param name="page">当前页数</param>
        /// <param name="query_string">Url参数</param>
        public string GetPagination(int total, int per, int page)
        {
            int allpage = 0;
            int next = page;
            int pre = 1;
            int startcount = 0;
            int endcount = 0;
            StringBuilder sbpag = new StringBuilder();
            string query_url = GetRequestUrl();
            if (query_url.Contains("?"))
            {
                query_url += "&page=";
            }
            else
            {
                query_url += "?page=";
            }
            if (page < 1) { page = 1; }
            //计算总页数
            if (per != 0)
            {
                allpage = (total / per);
                allpage = ((total % per) != 0 ? allpage + 1 : allpage);
                allpage = (allpage == 0 ? 1 : allpage);
            }
            if (page > 1)
            {
                pre = page - 1;
            }
            if (page < allpage)
            {
                next = page + 1;
            }
            startcount = (page + PAGENUM) > allpage ? allpage - PAGENUM * 2 : page - PAGENUM;//中间页起始序号            
            endcount = page < PAGENUM + 1 ? PAGENUM * 2 + 1 : page + PAGENUM;//中间页终止序号

            if (startcount < 1) { startcount = 1; } //为了避免输出的时候产生负数，设置如果小于1就从序号1开始
            if (allpage < endcount) { endcount = allpage; }//页码+5的可能性就会产生最终输出序号大于总页码，那么就要将其控制在页码数之内
            sbpag.Append("<span>共");
            sbpag.Append(allpage);
            sbpag.Append("页</span>");

            sbpag.Append("<a href=\"");
            sbpag.Append(query_url);
            sbpag.Append("1\">首页</a><a href=\"");
            sbpag.Append(query_url);
            sbpag.Append(pre);
            sbpag.Append("\">上一页</a>");

            //中间页处理，这个增加时间复杂度，减小空间复杂度
            for (int i = startcount; i <= endcount; i++)
            {
                if (page == i)
                {
                    sbpag.Append("<font>");
                    sbpag.Append(i);
                    sbpag.Append("</font>");
                }
                else
                {
                    sbpag.Append("<a href=\"");
                    sbpag.Append(query_url);
                    sbpag.Append(i);
                    sbpag.Append("\">");
                    sbpag.Append(i);
                    sbpag.Append("</a>");
                }
            }
            sbpag.Append("<a href=\"");
            sbpag.Append(query_url);
            sbpag.Append(next);
            sbpag.Append("\">下一页</a><a href=\"");
            sbpag.Append(query_url);
            sbpag.Append(allpage);
            sbpag.Append("\">末页</a>");

            //pagestr += "<select onchange=\"javascript:window.location=this.value\" >";

            //for (int i = 1; i <= allpage; i++)
            //{
            //    if (i == page)
            //    {
            //        pagestr += "<option  value=\"" + query_string + "?page=" + i + "\" selected>第" + i + "页</option>";
            //    }
            //    else
            //    {
            //        pagestr += "<option  value=\"" + query_string + "?page=" + i + "\" >第" + i + "页</option>";
            //    }
            //}
            //pagestr += "</select>";


            return sbpag.ToString();
        }

        private string GetRequestUrl()
        {
            StringBuilder sburl = new StringBuilder();
            string[] par = HttpContextHelper.Request.QueryString.AllKeys;
            foreach (string str in par)
            {
                if (PAGETAG.CompareTo(str) == 0)
                {
                    continue;
                }
                sburl.Append("&");
                sburl.Append(str);
                sburl.Append("=");
                sburl.Append(HttpContextHelper.Server.UrlEncode(HttpContextHelper.Request.QueryString[str]));
            }
            if (sburl.Length > 5)
            {
                sburl.Remove(0, 1);
                sburl.Insert(0, "?");
            }
            sburl.Insert(0, RequestPage);
            return sburl.ToString();
        }
    }
}
