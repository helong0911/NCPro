//using System;
//using System.Web;
//using System.Collections.Generic;
//using SvHoo.Framework.Web.Utils;
//using SvHoo.Domain.Cookie;
//using SvHoo.Domain.Web.Shopping;
//using SvHoo.Web.Model;
//using SvHoo.Web.UI.Common.Helper;

//namespace SvHoo.Web.UI.Helper
//{
//    class CookieHelper
//    {
//        #region Shopping

//        //public static List<ShoppingItem> ShoppingCart
//        //{
//        //    get
//        //    {
//        //        List<ShoppingItem> list = new List<ShoppingItem>();
//        //        string cookie = HttpCookieHelper.GetValue(Config.SHOPPINGCART);
//        //        if (!string.IsNullOrEmpty(cookie))
//        //        {
//        //            string[] pro = cookie.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
//        //            if (pro != null && pro.Length > 0)
//        //            {
//        //                foreach (string proItem in pro)
//        //                {
//        //                    string[] ite = proItem.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
//        //                    list.Add(new ShoppingItem(int.Parse(ite[0]), int.Parse(ite[1])));
//        //                }
//        //            }
//        //        }
//        //        return list;
//        //    }
//        //    set
//        //    {
//        //        string cookie = string.Empty;
//        //        if (value != null && value.Count > 0)
//        //        {
//        //            value.ForEach(item =>
//        //            {
//        //                cookie = string.Format("{0}.{1},{2}", cookie, item.SysNo, item.Quantity);
//        //            });
//        //        }
//        //        HttpCookieHelper.SetCookie(Config.SHOPPINGCART, cookie);
//        //    }
//        //}

//        #endregion

//        public static int Languages
//        {
//            get
//            {
//                string cookie = HttpCookieHelper.GetValue(Config.LANGUAGES);
//                if (string.IsNullOrEmpty(cookie))
//                {
//                    return 0;
//                }
//                else
//                {
//                    return int.Parse(cookie);
//                }
//            }
//            set
//            {
//                HttpCookieHelper.SetCookie(Config.LOGINUSER, value.ToString());
//            }
//        }

//        #region User Login

//        /// <summary>
//        /// 获取/设置,当前后台登录用户对象
//        /// </summary>
//        //public static CustomerInfo LoginUser
//        //{
//        //    set
//        //    {
//        //        HttpContext.Current.Session[Config.LOGINUSER] = value;
//        //        if (value == null)
//        //        {
//        //            HttpCookieHelper.SetTokenCookie(Config.LOGINUSER);
//        //        }
//        //        else
//        //        {
//        //            HttpCookieHelper.SetTokenCookie(Config.LOGINUSER, value.SysNo);
//        //        }
//        //    }
//        //    get
//        //    {
//        //        CustomerInfo _pUser = null;
//        //        if (IsLogin)
//        //        {
//        //            _pUser = HttpContext.Current.Session[Config.LOGINUSER] as CustomerInfo;
//        //        }
//        //        return _pUser;
//        //    }
//        //}

//        /// <summary>
//        /// 判断当前后台用户是否为登录状态
//        /// </summary>
//        public static bool IsLogin
//        {
//            get
//            {
//                if (HttpContext.Current.Session[Config.LOGINUSER] != null)
//                {
//                    return true;
//                }
//                else
//                {
//                    return CookieLogin();
//                }
//            }
//        }

//        private static bool CookieLogin()
//        {
//            CookieTokenEntity cte = HttpCookieHelper.GetTokenCookie(Config.LOGINUSER);
//            if (cte.IsValid)
//            {
//                //CustomerInfo user = CustomerModel.GetCustomerInfo(cte.SysNo);
//                //if (user != null)
//                //{
//                //    LoginUser = user;
//                //    return true;
//                //}
//                return false;
//            }
//            return false;
//        }

//        #endregion
//    }
//}
