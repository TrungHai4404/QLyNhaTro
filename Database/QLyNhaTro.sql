﻿CREATE DATABASE QLyNhaTro
GO

USE QLyNhaTro
GO

-- Tạo bảng LoaiPhong
CREATE TABLE LoaiPhong (
    MaLoaiPhong NVARCHAR(20) PRIMARY KEY,
    TenLoaiPhong NVARCHAR(50) NOT NULL,
    DienTich DECIMAL(10, 2), -- Diện tích phòng (m²)
    TienIch NVARCHAR(200),  -- Tiện ích đi kèm
    GiaCoBan DECIMAL(18, 2) NOT NULL -- Giá cơ bản của loại phòng
);

-- Tạo bảng PhongTro
CREATE TABLE PhongTro (
    MaPhong NVARCHAR(20) PRIMARY KEY,
    TenPhong NVARCHAR(50) NOT NULL,
    MaLoaiPhong NVARCHAR(20) NOT NULL, -- Tham chiếu đến bảng LoaiPhong
    GiaThue DECIMAL(18, 2) NOT NULL,
    SucChua INT NOT NULL, -- Sức chứa tối đa của phòng
    TrangThai NVARCHAR(20) DEFAULT 'Trống',
    MoTa NVARCHAR(200),
    FOREIGN KEY (MaLoaiPhong) REFERENCES LoaiPhong(MaLoaiPhong)
);

-- Tạo bảng KhachThue
CREATE TABLE KhachThue (
    MaKhachThue NVARCHAR(20) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE,
    GioiTinh NVARCHAR(10),
    CMND_CCCD NVARCHAR(20) NOT NULL,
    SDT NVARCHAR(15),
    DiaChiThuongTru NVARCHAR(200),
    NgayBatDauThue DATE NOT NULL,
    Avatar NVARCHAR(200),
    MaPhong NVARCHAR(20), -- Tham chiếu đến bảng PhongTro
    FOREIGN KEY (MaPhong) REFERENCES PhongTro(MaPhong)
);

-- Tạo bảng HopDong
CREATE TABLE HopDong (
    MaHopDong NVARCHAR(20) PRIMARY KEY,
    MaKhachThue NVARCHAR(20) NOT NULL,
    MaPhong NVARCHAR(20) NOT NULL,
    NgayKyHopDong DATE NOT NULL,
    NgayKetThuc DATE,
    TinhTrang NVARCHAR(20) DEFAULT 'Đang hiệu lực',
    FOREIGN KEY (MaKhachThue) REFERENCES KhachThue(MaKhachThue),
    FOREIGN KEY (MaPhong) REFERENCES PhongTro(MaPhong)
);

-- Tạo bảng DichVu
CREATE TABLE DichVu (
    MaDichVu NVARCHAR(20) PRIMARY KEY,
    TenDichVu NVARCHAR(100) NOT NULL,
    DonGia DECIMAL(18, 2) NOT NULL
);

-- Tạo bảng HoaDon
CREATE TABLE HoaDon (
    MaHoaDon NVARCHAR(20) PRIMARY KEY,
    MaHopDong NVARCHAR(20) NOT NULL,
    ThangNam NVARCHAR(10) NOT NULL,
    TienPhong DECIMAL(18, 2) NOT NULL,
    TienDichVu DECIMAL(18, 2),
    TongTien AS (TienPhong + ISNULL(TienDichVu, 0)), -- Cột tính toán
    TrangThaiThanhToan NVARCHAR(20) DEFAULT 'Chưa thanh toán',
    FOREIGN KEY (MaHopDong) REFERENCES HopDong(MaHopDong)
);

-- Tạo bảng ChiTietDichVu
CREATE TABLE ChiTietDichVu (
    MaPhong NVARCHAR(20) NOT NULL, 
    MaDichVu NVARCHAR(20) NOT NULL, 
    PRIMARY KEY (MaPhong, MaDichVu), 
    FOREIGN KEY (MaPhong) REFERENCES PhongTro(MaPhong),
    FOREIGN KEY (MaDichVu) REFERENCES DichVu(MaDichVu)
);
-- Thêm dữ liệu vào bảng LoaiPhong
-- Dữ liệu mẫu cho bảng LoaiPhong
INSERT INTO LoaiPhong (MaLoaiPhong, TenLoaiPhong, DienTich, TienIch, GiaCoBan)
VALUES
('LP01', 'Phòng Đơn', 15.00, 'WiFi, Máy lạnh', 1500000),
('LP02', 'Phòng Đôi', 20.00, 'WiFi, Máy lạnh, Tủ lạnh', 2500000);


-- Dữ liệu mẫu cho bảng DichVu
INSERT INTO DichVu (MaDichVu, TenDichVu, DonGia)
VALUES
('DV01', 'WiFi', 100000),
('DV02', 'Nước sinh hoạt', 30000),
('DV03', 'Điện', 50000),
('DV04', 'Vệ sinh', 20000),
('DV05', 'Bảo trì', 150000);





