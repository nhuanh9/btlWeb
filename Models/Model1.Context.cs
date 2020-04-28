﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BTL.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MobileStoreManagementEntities : DbContext
    {
        public MobileStoreManagementEntities()
            : base("name=MobileStoreManagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ChiTietDonDH> ChiTietDonDHs { get; set; }
        public virtual DbSet<ChiTietHDB> ChiTietHDBs { get; set; }
        public virtual DbSet<ChiTietHDN> ChiTietHDNs { get; set; }
        public virtual DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public virtual DbSet<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }
        public virtual DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<DonDatHang> DonDatHangs { get; set; }
        public virtual DbSet<HangSX> HangSXes { get; set; }
        public virtual DbSet<HoaDonBan> HoaDonBans { get; set; }
        public virtual DbSet<HoaDonNhap> HoaDonNhaps { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhieuNhapKho> PhieuNhapKhoes { get; set; }
        public virtual DbSet<PhieuXuatKho> PhieuXuatKhoes { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<KHDatHangQuy4> KHDatHangQuy4 { get; set; }
        public virtual DbSet<NCC_SP_Quy2> NCC_SP_Quy2 { get; set; }
        public virtual DbSet<SP> SPs { get; set; }
        public virtual DbSet<SPBanNhieuNhatThang2Nam2019> SPBanNhieuNhatThang2Nam2019 { get; set; }
        public virtual DbSet<tongTienHoaDon> tongTienHoaDons { get; set; }
    
        public virtual ObjectResult<DoanhThuTheoThang_Result> DoanhThuTheoThang(Nullable<int> thang, Nullable<int> nam)
        {
            var thangParameter = thang.HasValue ?
                new ObjectParameter("thang", thang) :
                new ObjectParameter("thang", typeof(int));
    
            var namParameter = nam.HasValue ?
                new ObjectParameter("nam", nam) :
                new ObjectParameter("nam", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DoanhThuTheoThang_Result>("DoanhThuTheoThang", thangParameter, namParameter);
        }
    
        public virtual ObjectResult<NhanVienBanNhieuHangNhat_Result> NhanVienBanNhieuHangNhat(Nullable<int> thang)
        {
            var thangParameter = thang.HasValue ?
                new ObjectParameter("thang", thang) :
                new ObjectParameter("thang", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<NhanVienBanNhieuHangNhat_Result>("NhanVienBanNhieuHangNhat", thangParameter);
        }
    
        public virtual ObjectResult<shoSP_Result> shoSP()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<shoSP_Result>("shoSP");
        }
    
        public virtual ObjectResult<ThongKeSanPhamTheoNhaCungCap_Result> ThongKeSanPhamTheoNhaCungCap(string maNCC)
        {
            var maNCCParameter = maNCC != null ?
                new ObjectParameter("MaNCC", maNCC) :
                new ObjectParameter("MaNCC", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ThongKeSanPhamTheoNhaCungCap_Result>("ThongKeSanPhamTheoNhaCungCap", maNCCParameter);
        }
    
        public virtual ObjectResult<TongChiTheoNam_Result> TongChiTheoNam(Nullable<int> nam)
        {
            var namParameter = nam.HasValue ?
                new ObjectParameter("nam", nam) :
                new ObjectParameter("nam", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TongChiTheoNam_Result>("TongChiTheoNam", namParameter);
        }
    }
}