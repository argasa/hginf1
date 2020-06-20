using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HGINF
{
    public class WorkBD
    {

        public static void putMessege(string strFIO, string strPC, string strPNum, string strNum, string strText = "")
        {
            using (RequestContext db = new RequestContext())
            {

                Request request = new Request { Name = strFIO, Phon = strPNum, Message = strText, Category = strPC, NomPC = strNum };
                db.Requests.Add(request);
                db.SaveChanges();

                
            }
        }

        public static string  GetPCnum(string IP)
        {
            IP = IP.Replace(',', '.');
            using (RequestContext db = new RequestContext())
            {
                var users = db.IpPCnums;
                foreach (IpPCnum u in users)
                {
                    if (u.IP == IP)
                        return u.PCnum;
                }
            }

            return "111 - 1 - 111";
        }
    }
}
