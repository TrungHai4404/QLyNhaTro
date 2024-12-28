USE [QLyNhaTro]
GO
/****** Object:  Table [dbo].[ChiTietDichVu]    Script Date: 12/29/2024 2:25:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDichVu](
	[MaPhong] [nvarchar](20) NOT NULL,
	[MaDichVu] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC,
	[MaDichVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DichVu]    Script Date: 12/29/2024 2:25:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DichVu](
	[MaDichVu] [nvarchar](20) NOT NULL,
	[TenDichVu] [nvarchar](100) NOT NULL,
	[DonGia] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDichVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 12/29/2024 2:25:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHoaDon] [nvarchar](20) NOT NULL,
	[MaHopDong] [nvarchar](20) NOT NULL,
	[ThangNam] [nvarchar](10) NOT NULL,
	[TienPhong] [decimal](18, 2) NOT NULL,
	[TienDichVu] [decimal](18, 2) NULL,
	[TongTien]  AS ([TienPhong]+isnull([TienDichVu],(0))),
	[TrangThaiThanhToan] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HopDong]    Script Date: 12/29/2024 2:25:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HopDong](
	[MaHopDong] [nvarchar](20) NOT NULL,
	[MaKhachThue] [nvarchar](20) NOT NULL,
	[MaPhong] [nvarchar](20) NOT NULL,
	[NgayKyHopDong] [date] NOT NULL,
	[NgayKetThuc] [date] NULL,
	[TinhTrang] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHopDong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachThue]    Script Date: 12/29/2024 2:25:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachThue](
	[MaKhachThue] [nvarchar](20) NOT NULL,
	[HoTen] [nvarchar](100) NOT NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[CMND_CCCD] [nvarchar](20) NOT NULL,
	[SDT] [nvarchar](15) NULL,
	[DiaChiThuongTru] [nvarchar](200) NULL,
	[NgayBatDauThue] [date] NULL,
	[Avatar] [nvarchar](200) NULL,
	[MaPhong] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKhachThue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiPhong]    Script Date: 12/29/2024 2:25:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiPhong](
	[MaLoaiPhong] [nvarchar](20) NOT NULL,
	[TenLoaiPhong] [nvarchar](50) NOT NULL,
	[DienTich] [decimal](10, 2) NULL,
	[TienIch] [nvarchar](200) NULL,
	[GiaCoBan] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoaiPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhongTro]    Script Date: 12/29/2024 2:25:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongTro](
	[MaPhong] [nvarchar](20) NOT NULL,
	[TenPhong] [nvarchar](50) NOT NULL,
	[MaLoaiPhong] [nvarchar](20) NOT NULL,
	[GiaThue] [decimal](18, 2) NOT NULL,
	[SucChua] [int] NOT NULL,
	[TrangThai] [nvarchar](20) NULL,
	[MoTa] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[HoaDon] ADD  DEFAULT ('Chua thanh toán') FOR [TrangThaiThanhToan]
GO
ALTER TABLE [dbo].[HopDong] ADD  DEFAULT ('Ðang hi?u l?c') FOR [TinhTrang]
GO
ALTER TABLE [dbo].[PhongTro] ADD  DEFAULT ('Tr?ng') FOR [TrangThai]
GO
ALTER TABLE [dbo].[ChiTietDichVu]  WITH CHECK ADD FOREIGN KEY([MaDichVu])
REFERENCES [dbo].[DichVu] ([MaDichVu])
GO
ALTER TABLE [dbo].[ChiTietDichVu]  WITH CHECK ADD FOREIGN KEY([MaPhong])
REFERENCES [dbo].[PhongTro] ([MaPhong])
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([MaHopDong])
REFERENCES [dbo].[HopDong] ([MaHopDong])
GO
ALTER TABLE [dbo].[HopDong]  WITH CHECK ADD FOREIGN KEY([MaKhachThue])
REFERENCES [dbo].[KhachThue] ([MaKhachThue])
GO
ALTER TABLE [dbo].[HopDong]  WITH CHECK ADD FOREIGN KEY([MaPhong])
REFERENCES [dbo].[PhongTro] ([MaPhong])
GO
ALTER TABLE [dbo].[KhachThue]  WITH CHECK ADD FOREIGN KEY([MaPhong])
REFERENCES [dbo].[PhongTro] ([MaPhong])
GO
ALTER TABLE [dbo].[PhongTro]  WITH CHECK ADD FOREIGN KEY([MaLoaiPhong])
REFERENCES [dbo].[LoaiPhong] ([MaLoaiPhong])
GO
