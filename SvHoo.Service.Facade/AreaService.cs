using SvHoo.Service.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SvHoo.Service.Facade
{
    public class AreaService
    {
        public static Area GetModel(int sysNo)
        {
            DatabaseEntities de = new DatabaseEntities();
            return (from item in de.Area
                    where item.SysNo == 0
                    select item).FirstOrDefault();
        }

        public static int Insert(Area info)
        {
            DatabaseEntities de = new DatabaseEntities();
            de.Area.Add(info);
            return de.SaveChanges();
        }

        public static int Update(Area info)
        {
            DatabaseEntities de = new DatabaseEntities();
            var obj = (from item in de.Area
                       where item.SysNo == info.SysNo
                       select item).FirstOrDefault();

            if (obj != null)
            {
                obj.Parent = info.Parent;
                obj.Priority = info.Priority;
                obj.Title = info.Title;
                return de.SaveChanges();
            }
            return 0;
        }

        public static int Delete(int sysNo)
        {
            DatabaseEntities de = new DatabaseEntities();
            var list = (from item in de.Area
                        where item.SysNo == 0
                        select item).ToList();
            if (list != null)
            {
                list.ForEach(item =>
                {
                    de.Area.Remove(item);
                });
                return de.SaveChanges();
            }
            return 0;
        }
    }
}
