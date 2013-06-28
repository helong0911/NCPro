using System;
using SvHoo.Domain.Common;
using SvHoo.Service.Facade;
using SvHoo.Service.Database;

namespace SvHoo.Web.Model
{
    public class AreaModel
    {
        public static Message Update(Area info)
        {
            Message msg = new Message();
            if (AreaService.Update(info) > 0)
            {
                msg.Type = MessageType.None;
                msg.Text = "保存管理员信息成功！";
            }
            else
            {
                msg.Type = MessageType.Error;
                msg.Text = "保存管理员信息失败，请重新尝试！";
            }
            return msg;
        }

        public static Message Insert(Area info)
        {
            Message msg = new Message();
            if (AreaService.Insert(info) > 0)
            {
                msg.Type = MessageType.None;
                msg.Text = "添加管理员信息成功！";
            }
            else
            {
                msg.Type = MessageType.Error;
                msg.Text = "添加管理员信息失败，请重新尝试！";
            }
            return msg;
        }

        public static Message Delete(int id)
        {
            Message msg = new Message();
            if (AreaService.Delete(id) > 0)
            {
                msg.Type = MessageType.None;
                msg.Text = "删除管理员成功！";
            }
            else
            {
                msg.Type = MessageType.Error;
                msg.Text = "删除管理员失败，请重新尝试！";
            }
            return msg;
        }
    }
}
