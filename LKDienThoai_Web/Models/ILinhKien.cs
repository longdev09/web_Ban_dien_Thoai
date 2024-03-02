using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LKDienThoai_Web.Models
{
    public class ILinhKien
    {
        DuLieu_LkDTDataContext dl = new DuLieu_LkDTDataContext();
        public string maLK {set; get;}
        public string tenLK { set; get; }
        public string moTa { set; get; }
        public string hinhAnh { set; get; }
        public int donGia { set; get; }
        public int soluongTon { set; get; }
        public int slMua { set; get; }

        public ILinhKien (string mlk)
        {
          
            maLK = mlk;
            LinhKien a = dl.LinhKiens.FirstOrDefault(t => t.MaLK == maLK);
            tenLK = a.TenLK;
            moTa = a.MoTa;
            hinhAnh = a.HinhAnh;
            donGia = int.Parse(a.DonGia.ToString());
            soluongTon = int.Parse(a.SLTon.ToString());
            slMua = 1;
        }

    }
}