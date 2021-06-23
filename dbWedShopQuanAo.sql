create database WEDQLSHOPQUANAO
go
use WEDQLSHOPQUANAO
go


drop database WEDQLSHOPQUANAO
go
create table TaiKhoan
(
	MaTK int identity primary key,
	TenTK nvarchar(50),
	MatKhau nvarchar(100)
)
go
insert into TaiKhoan
values ('admin','c4ca4238a0b923820dcc509a6f75849b')
select * from KhachHang
create table KhachHang
(
	MaKH int identity(1,1) primary key,
	TaiKhoan nvarchar(50),
	MatKhau nvarchar(100) not null,
	TenKH nvarchar(100),
	Email nvarchar(50) not null,	
)
go
drop table KhachHang
insert into KhachHang
values  (N'ALFKI', N'iloveyou', N'Maria Anders', N'nnghiem@yahoo.com'),
		(N'ANATR', N'iloveyou', N'Ana Trujillo', N'nnghiem@yahoo.com'),
		(N'ANTON', N'iloveyou', N'Antonio Moreno', N'nnghiem@yahoo.com'),
		(N'AROUT', N'iloveyou', N'Thomas Hardy', N'nnghiem@yahoo.com'),
		(N'BERGS', N'iloveyou', N'Christina Berglund', N'nnghiem@yahoo.com'),
		(N'BLAUS', N'iloveyou', N'Hanna Moos', N'nnghiem@yahoo.com')
go

create table TheLoai
(
	MaTL int identity(1,1) primary key,
	Ten nvarchar(100),
)
go
 insert into TheLoai
 values (N'Áo Khoác'),
		(N'Áo Thun'),
		(N'Quần Jeans'),
		(N'Quần')
go


create table NhaCungCap
(
	MaNCC int identity(1,1) primary key,
	TenNCC nvarchar(50),
	Logo nvarchar(50),
	Email nvarchar(50),
	SDT nvarchar(50)

)
go

insert into NhaCungCap
values (N'Hàn Quốc', N'logoHQ.PNG', N'pike@yahoo.com', N'0987345876'),
		(N'Trung Quốc', N'logoTQ.PNG', N'pike@yahoo.com', N'0987345876'),
		(N'Nhật Bản', N'logoNB.PNG', N'pike@yahoo.com', N'0987345876'),
		(N'Việt Nam', N'logoVN.jpg', N'pike@yahoo.com', N'0987345876')
		
go

create table SanPham
(
	MaSP int identity(1,1) primary key,
	MaTL int,
	MaNCC int,
	TenSP nvarchar(100),
	DonGia float,
	Anh nvarchar(50),
	constraint fk_SP_TL foreign key(MaTL) references TheLoai(MaTL),
	constraint fk_SP_NCC foreign key(MaNCC) references NhaCungCap(MaNCC)
)
go
select * from TheLoai
select * from NhaCungCap

insert into SanPham
values (1,1,N'Áo phao',400000,'aophao.jfif'),
		(2,2,N'Áo dù',200000,'aodu.jfif'),
		(3,3,N'Quần đùi',40000,'quandui.png'),
		(2,4,N'Áo khoác kiểu Hàn',100000,'khoac_kieuhan,jpg'),
		(1,2,N'Áo phông kiểu Nhật',150000,'phongnhat.jpg'),
		(4,1,N'Quần jean',450000,'jeans.jpg'),
		(3,4,N'Áo khoác jean',300000,'khoac_jeans.jpg'),
		(1,2,N'Áo thun 3 lỗ',40000,'3lo.jfif'),
		(2,3,N'Áo thun in hình gấu',150000,'aothun_gau.png')
go
select * from SanPham
select * from SanPham where MaTL = 1

create table DonHang
(
	MaDH int identity primary key,
	MaKH int,
	NgayBan datetime not null,
	TongTien float not null,
	constraint fk_HD_KH foreign key(MaKH) references KhachHang(MaKH)
)
go
select * from KhachHang
set dateformat dmy
insert into DonHang
values (1,12/10/2020,150000),
		(2,03/12/2020,1500000)
go

select * from DonHang
go

create table ChiTietDH
(
	MaCTDH int identity(1,1) primary key,
	MaDH int,
	MaSP int ,
	SoLuong int not null,
	DonGia int not null,
	constraint fk_CTHD_DH foreign key(MaDH) references DonHang(MaDH),
	constraint fk_CTHD_SP foreign key(MaSP) references SanPham(MaSP)
)
go
select * from DonHang
select * from SanPham
insert into ChiTietDH
values (2,1,2,100000)
go



