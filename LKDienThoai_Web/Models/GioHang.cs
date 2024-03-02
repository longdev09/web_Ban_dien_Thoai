using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LKDienThoai_Web.Models
{
    public class GioHang
    {
        public List<ILinhKien> dsLk;

        // khoi tao gio hang
        public GioHang()
        {
            dsLk = new List<ILinhKien>();
        }
        public void ThemGio(string maLk)
        {
            ILinhKien a = new ILinhKien(maLk);
            dsLk.Add(a);

        }

        public int DemSL()
        {
            return dsLk.Count();
        }
        public int TongTien()
        {
            int TongTien = 0;
            foreach(ILinhKien i in dsLk)
            {
                TongTien += i.donGia * i.slMua;
            }
            return TongTien;
        }
        public void Xoa(string malK)
        {
            var i = dsLk.Single(t => t.maLK == malK);
            dsLk.Remove(i);
        }
        public void XoaH()
        {
            dsLk.Clear();
               
        }
        public void CapNhatSl(string ma, int sl)
        {
            for (int i = 0; i < dsLk.Count; i++ )
            {
                if (dsLk[i].maLK == ma)
                {
                    dsLk[i].slMua = sl;
                    break;
                }
            }
        }

        


    }
}