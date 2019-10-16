using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CNWeb.Models;
namespace CNWeb.Models
{
    public class Item_GioHang
    {
        OnlineShopDbConText db = new OnlineShopDbConText();
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string HinhAnh { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public double TongTien { get { return DonGia * SoLuong; } }
        
        public Item_GioHang(int MaSP)
        {
            this.MaSP = MaSP;
            SanPham sp = db.SanPhams.SingleOrDefault(s => s.IDSanPham == MaSP);
            TenSP = sp.TenSanPham;
            HinhAnh = sp.HinhAnh;
            DonGia = (double)sp.DonGia;
            SoLuong = 1;
        }
        public Item_GioHang(int MaSP, int SL)
        {
            this.MaSP = MaSP;
            SanPham sp = db.SanPhams.SingleOrDefault(s => s.IDSanPham == MaSP);
            TenSP = sp.TenSanPham;
            HinhAnh = sp.HinhAnh;
            DonGia = (double)sp.DonGia;
            SoLuong = SL;
        }
    }
}