
create database Music;
go
use Music;
go
create table KhuVuc(
IdKhuVuc int primary key identity,
TenKhuVuc nvarchar(255)
);
go
create table TheLoai(
IdTheLoai int primary key identity,
TenTheLoai nvarchar(255),
AnhTheLoai nvarchar(Max)
);
go

create table NgheSi(
IdNgheSi int primary key identity,
TenNgheSi nvarchar(255),
AnhNgheSi nvarchar(max),
IdKhuVuc int,
MoTa nvarchar(Max),
LuotQuanTam int,
Hot bit,
Constraint FK_NgheSi_IdNgheSi
Foreign key(IdKhuVuc) references KhuVuc(IdKhuVuc),
);
go
create table Album(
IdAlbum int primary key identity,
TenAlbum nvarchar(255),
AnhAlbum nvarchar(max),
IdKhuVuc int,
IdNgheSi int,
Hot bit,
Constraint FK_Album_IdNgheSi
Foreign key(IdNgheSi) references NgheSi(IdNgheSi),
Constraint FK_Album_IdKhuVuc
Foreign key(IdKhuVuc) references KhuVuc(IdKhuVuc)
);
create table BaiHat(
IdBaiHat int primary key identity,
TenBaiHat nvarchar(255),
AnhBaiHat nvarchar(Max),
LoiBaihat nvarchar(Max),
NgayPhatHanh datetime,
Top100 bit,
LuotNghe int,
LuotTai int,
LuotThich int,
LinkBaiHat nvarchar(Max),
LinkChiaSe nvarchar(Max),
IdNgheSi int,
IdTheLoai int,
IdAlbum int,
Constraint FK_BaiHat_IdNgheSi
Foreign key(IdNgheSi) references NgheSi(IdNgheSi),
Constraint FK_BaiHat_IdTheLoai
Foreign key(IdTheLoai) references TheLoai(IdTheLoai),
Constraint FK_BaiHat_IdAlbum
Foreign key(IdAlbum) references Album(IdAlbum)
);
go
create table NguoiDung(
IdNguoiDung int primary key identity,
TaiKhoan nvarchar(100),
MatKhau nvarchar(100),
TenNguoiDung nvarchar(255),
AnhDaiDien nvarchar(max),
DiaChi nvarchar(255),
Email nvarchar(255)
);
go
create table LoaiTaiKhoan(
IdLoaiTaiKhoan int primary key identity,
LoaiTaiKhoan nvarchar(100)
);
go
create table TaiKhoan(
IdTaiKhoan int primary key identity,
TaiKhoan nvarchar(100),
MatKhau nvarchar(100),
IdLoaiTaiKhoan int,
Constraint FK_TaiKhoan_IdLoaiTaiKhoan
Foreign key(IdLoaiTaiKhoan) references LoaiTaiKhoan(IdLoaiTaiKhoan)
);
go
create table Tintuc(
IdTinTuc int primary key identity,
TieuDeTinTuc nvarchar(255),
AnhTieuDe nvarchar(max),
NoiDung nvarchar(max),
ThoiGian datetime,
IdTaiKhoan int,
Constraint FK_Tintuc_IdTaiKhoan
Foreign key(IdTaiKhoan) references TaiKhoan(IdTaiKhoan)
);
go
create table Video(
IdVideo int  primary key identity,
TieuDe nvarchar(255),
IdNgheSi int,
IdKhuVuc int,
Poster nvarchar(max),
LinkVideoMp4 nvarchar(max),
LuotXem int,
LuotThich int,
Constraint FK_Video_IdNgheSi
Foreign key(IdNgheSi) references NgheSi(IdNgheSi),
Constraint FK_Video_IdKhuVuc
Foreign key(IdKhuVuc) references KhuVuc(IdKhuVuc)
);
go
create table BaiHatYeuThich(
IdBaiHatYeuThich  int  primary key identity,
IdNguoiDung int,
IdBaiHat int,
TrangThaiThich nvarchar(max),
Constraint FK_BaiHatYeuThich_IdNguoiDung
Foreign key(IdNguoiDung) references NguoiDung(IdNguoiDung),
Constraint FK_BaiHatYeuThich_IdBaiHat
Foreign key(IdBaiHat) references BaiHat(IdBaiHat)
);
go
create table AlbumYeuThich(
IdAlbumYeuThich  int  primary key identity,
IdNguoiDung int,
IdAlbum int,
Constraint FK_AlbumYeuThich_IdNguoiDung
Foreign key(IdNguoiDung) references NguoiDung(IdNguoiDung),
Constraint FK_AlbumYeuThich_IdAlbum
Foreign key(IdAlbum) references Album(IdAlbum)
);
go
create table NgheSiYeuThich(
IdNgheSiYeuThich  int  primary key identity,
IdNguoiDung int,
IdNgheSi int,
Constraint FK_NgheSiYeuThich_IdNguoiDung
Foreign key(IdNguoiDung) references NguoiDung(IdNguoiDung),
Constraint FK_NgheSiYeuThich_IdNgheSi
Foreign key(IdNgheSi) references NgheSi(IdNgheSi)
);
go
create table VideoYeuThich(
IdVideoYeuThich  int  primary key identity,
IdNguoiDung int,
IdVideo int,
Constraint FK_VideoYeuThich_IdNguoiDung
Foreign key(IdNguoiDung) references NguoiDung(IdNguoiDung),
Constraint FK_VideoYeuThich_IdVideo
Foreign key(IdVideo) references Video(IdVideo)
);
go
create table BinhLuan(
IdBinhLuan  int  primary key identity,
IdNguoiDung int,
Idchung int,
NoiDungBinhLuan nvarchar(max),
ThuocTinh nvarchar(255),
Constraint FK_BinhLuan_NguoiDung
Foreign key(IdNguoiDung) references NguoiDung(IdNguoiDung),
Constraint FK_BinhLuan_BaiHat
Foreign key(Idchung) references BaiHat(IdBaiHat),
Constraint FK_BinhLuan_Video
Foreign key(Idchung) references Video(IdVideo)
);
go
create table NhacCaNhan(
IdNhacCaNhan int  primary key identity,
IdNguoiDung int,
TenBaiHat nvarchar(500),
NgheSiThucHien nvarchar(500),
LinkNhac nvarchar(max),
AnhBaiHat nvarchar(max),
Constraint FK_NhacCaNhan_IdNguoiDung
Foreign key(IdNguoiDung) references NguoiDung(IdNguoiDung),
);
go

--Thêm Dữ Liệu Bảng KhuVuc
insert into KhuVuc(TenKhuVuc) values(N'Việt Nam');
insert into KhuVuc(TenKhuVuc) values(N'Hàn Quốc');
insert into KhuVuc(TenKhuVuc) values(N'Nhật Bản');
insert into KhuVuc(TenKhuVuc) values(N'Trung Quốc');
insert into KhuVuc(TenKhuVuc) values(N'Thái Lan');
insert into KhuVuc(TenKhuVuc) values(N'Mĩ');
insert into KhuVuc(TenKhuVuc) values(N'Âu Mĩ');

--Thêm Dữ Liệu Bảng TheLoai
insert into TheLoai(TenTheLoai,AnhTheLoai) values(N'Nhạc trẻ','img1.jpg');
insert into TheLoai(TenTheLoai,AnhTheLoai) values(N'Cổ Điển','img2.jpg');
insert into TheLoai(TenTheLoai,AnhTheLoai) values(N'Hip Hop','img3.jpg');
insert into TheLoai(TenTheLoai,AnhTheLoai) values(N'Rock','img4.jpg');
insert into TheLoai(TenTheLoai,AnhTheLoai) values(N'Nhạc Dance','img5.jpg');
insert into TheLoai(TenTheLoai,AnhTheLoai) values(N'EDM','img6.jpg');
insert into TheLoai(TenTheLoai,AnhTheLoai) values(N'Jazz','img7.jpg');
insert into TheLoai(TenTheLoai,AnhTheLoai) values(N'Metal','img8.jpg');
insert into TheLoai(TenTheLoai,AnhTheLoai) values(N'Pop','img9.jpg');
insert into TheLoai(TenTheLoai,AnhTheLoai) values(N'Folk','img10.jpg');
insert into TheLoai(TenTheLoai,AnhTheLoai) values(N'Indie','img11.jpg');
insert into TheLoai(TenTheLoai,AnhTheLoai) values(N'Soul','img12.jpg');
insert into TheLoai(TenTheLoai,AnhTheLoai) values(N'Blues','img13.jpg');

--Thêm dữ liệu bảng Nghệ sĩ
go
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Jack','jack.jpg',1,N'Năm 2019, Jack ra mắt ca khúc "Hồng Nhan". Bài hát nhanh chóng trở thành một hiện tượng trong giới trẻ Việt Nam.
Thừa thắng xông lên, Jack kết hợp cùng K-ICM ra mắt "Bạc Phận", và cũng như trước đó, hài hát nhanh chóng dẫn đầu các bảng xếp hạng âm nhạc trong nước.
Cũng trong thời gian này, Jack quyết định đầu quân về công ty ICM, chung một nhà với K-ICM. Bộ đôi liên tiếp ra mắt những ca khúc "khủng" như: "Sóng Gió", "Em Gì Ơi"...
Cuối năm 2019, sau những lùm xùm với K-ICM và công ty quản lý, Jack rời khỏi ICM.
Đầu năm 2020, Jack ra mắt ca khúc "Là Một Thằng Con Trai" đánh dấu điểm khởi đầu cho sự nghiệp solo của anh.','462000','1');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values (N'Lê Bảo Bình','lebaobinh.jpg',1,N'Lê Bảo Bình sinh năm 1990 ở Hà Nội được biết đến là một ca sĩ , nhạc sĩ không còn xa lạ gì với giới trẻ Việt Nam 
anh đang là cái tên gây sốt trong cộng đồng mạng với loạt ca khúc nói về gia đình, cha mẹ, 
những người tha hương xa nhà rất nhiều ý nghĩa. Hiện tại Lê Bảo Bình có khá nhiều ca khúc Hot do chính anh sáng tác được đông đảo người hâm mộ yêu thích như: Hỏi Thăm Nhau , 
Người Phản Bội , Yêu Vội Vàng , Kết Thúc Lâu Rồi ,Để Cho Anh Khóc , Chẳng Bao Giờ Quên , Tập Cô Đơn ....','209000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values (N'Quân A.P','quanAP.jpg',1,N'Được giới trẻ biết đến, yêu mến và ưu ái với hàng loạt những danh xưng có cánh như “soái ca cover”, “hotboy cover”, “Sát thủ cover làm bay màu bản gốc”... Anh chàng từng gây sốt bởi gương mặt điển trai, thư sinh, dễ khiến fan nữ “đổ gục” từ cái nhìn đầu tiên với đôi mắt một mí dễ thương, nụ cười tỏa nắng đầy cuốn hút.
Đặc biệt, Quân A.P còn sở hữu màu giọng nam tính, chất trầm khàn đặc trưng, ấm áp... Đây được cho là thứ “vũ khí” để anh chàng chinh phục người yêu nhạc bởi hàng loạt những bản cover hàng chục triệu view trên mạng xã hội như “Chiều hôm ấy”, “Đừng như thói quen”, “Đừng ai nhắc về cô ấy”... Trước khi debut với sản phẩm âm nhạc đầu tay, qua những sản phẩm cover ấn tượng,
Quân A.P đã có một lượng fan nhất định trên Facebook và nhiều trang mạng xã hội khác.','75000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('ERIK','erik.jpg',1,N'ERIK tham gia Giọng Hát Việt Nhí năm 2013 và dừng lại ở vị trí top 15.
Năm 2014, anh tham gia cuộc thi của St.319 Entertainment và trở thành thực tập sinh.
Năm 2016, ERIK debut với ca khúc Pop ballad "Sau Tất Cả". Ca khúc nhanh chóng trở thành cơn sốt đối với giới trẻ.
Năm 2017, ERIK rời công ty. Anh kết hợp với MIN trong ca khúc "Ghen". Bài hát là bước tiến nổi bật trong sự nghiệp ca hát của anh.
Từ 2018 đến nay, ERIK đều đặn ra mắt các bản hit: "Chạm Đáy Nỗi Đau" (2018), "Đừng Có Mơ" (2018), "Anh Ta Là Sao" (2019), "Có Tất Cả Nhưng Thiếu Anh" (2019)...
Đầu năm 2020, phiên bản mới của "Ghen" là "Ghen Cô Vy" ra mắt trong thời điểm dịch COVID-19 được đón nhận, không chỉ trong nước mà cả trên thế giới.','173000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Thanh Hưng','thanhhung.jpg',1,N'- Năm 2010, thi đỗ vào trường Cao Đẳng Nghệ Thuật Hà Nội.
- Năm 2011, đc chọn vào 1 trong những học sinh ưu tú đại diện đoàn trường đi thi band nhóm nhạc toàn quốc tổ chức ở Đà Nẵng và giành giải nhất.
- Năm 2012, đi thi cuộc thi VietNamIdol, gây ấn tượng với ban giám khảo đặc biệt là chị Mỹ Tâm, và đã đc chị Tâm đại diện chương trình gọi điện trưc tiếp trao vé vàng. Đạt vị trí top 10 với những ca khúc tự sáng tác lúc đó: Tìm về lời ru, Thuộc Về Em,...
- Năm 2013, ra mắt sản phẩm Đợi Em Về, Anh là chàng ngố, Tìm về lời ru.
- Năm 2018, ra mắt Sai Người Sai Thời Điểm và liên tục đứng top 3 trên bảng xếp hạng Zingchart,','49000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Minh Vương M4U','minhvuong.jpg',1,N'Năm 2007, Minh Vương tham gia nhóm M4U từ những ngày đầu thành lập.
Sau khi nhóm M4U tan rã, Minh Vương trở thành ca sĩ solo, anh lấy nghệ danh Minh Vương M4U để hoạt động. Vào năm 2008, Minh Vương M4U sáng tác và trình bày ca khúc "Mưa", sau đó là "Nhớ Em" vào năm 2010.
Cuối năm 2011, ca khúc "Nỗi Đau Xót Xa" của anh trở thành hit được yêu thích, đánh dấu sự thăng hoa trong sự nghiệp.
Các năm sau đó anh đều đặn ra sản phẩm mới, nổi bật có "Anh Nhớ Em Người Yêu Cũ", "Em Ơi Lên Phố" hay "Em Sẽ Là Cô Dâu". Đặc biệt sự kết hợp giữa anh và Hương Ly trong "Nắm" và "Thê Tử" vào năm 2019 đạt được nhiều thành công.
Đầu năm 2020, Minh Vương M4U trở lại với ca khúc "Trúc Xinh" (cùng Việt, ACV" và "Cuộc Sống Xa Nhà".','55000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Mr Siro','siro.jpg',1,N'Là một nhạc sỹ có khả năng tự trình bày những ca khúc do chính anh sáng tác được khán giả đặc biệt yêu thích. Từ năm 2008, Mr. Siro sớm có được những bài HIT đầu tay như Em, Melancholy, Mây, Giấc Mơ Của Anh, I miss you từ năm cho đến gần đây (2012, 2013, 2014) Mr. Siro lập HIT liên tục với những sáng tác liên tiếp đứng đầu các bảng xếp hạng trong suốt nhiều tuần liền như Lắng Nghe Nước Mắt, Bức Tranh Từ Nước Mắt, Không Cần Thêm Một Ai Nữa (ft BigDaddy), Em Đã Sai Vì Em Tin (Bích Phương). Gần đây nhất là bài Em Gái Mưa (Hương Tràm) đang nằm trong top bảng xếp hạng của Zing MP3.
Năm 2013, anh đạt nhiều giải thưởng quan trọng do Làn Sóng Xanh và Zing Music Award trao giúp con đường âm nhạc của ngày ngày một rộng mở hơn.','321000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Binz','binz.jpg',1,N'Tham gia cộng đồng underground Việt từ năm 2008, Binz đã từng là artist của một số diễn đàn rap như Midsiderap, GVR. Được biết tới rộng rãi hơn trong năm 2010 với mixtape ”M-da Legend” & những sản phẩm đáng chú ý kết hợp với rapper Cá Chép của Vietdreamerz, người nghe rap nhớ tới Binz là một artist trẻ miền Trung có giọng hát ngọt ngào, kĩ thuật tốt và luôn mới mẻ.','73000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Liz Kim Cương','kimcuong.jpg',1,N'Liz Kim Cương từng học ở Học viện Âm nhạc Quốc gia. Cô tham gia nhiều cuộc thi, nổi bật có thể kể đến top 4 Ngôi sao Việt năm 2014. Sau cuộc thi, cô được đào tạo tại Hàn Quốc và ra mắt nhóm LIME vào 2 năm sau đó. Có khả năng vũ đạo và giọng hát trầm đặc biệt, cô trở thành giọng hát chính và đảm nhận vị trí trưởng nhóm.
Cô giành được giải Quán quân Bạn Là Ngôi Sao năm 2017, có hai MV cá nhân là "Tâm Tư Giữ Riêng Em" và "Phải Thật Hạnh Phúc".
Tháng 5 2019, nhóm LIME tuyên bố tan rã, cô đầu quân về công ty của Trịnh Thăng Bình.
Tháng 7 cùng năm, cô góp giọng trong "Cho Anh Xin Thêm Một Phút Nữa" của Trịnh Thăng Bình.','14000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values (N'Nhật Phong','nhatphong.jpg',1,N'ca sĩ Nhật Phong tên thật là Nguyễn Thế Bình, sinh năm 1992 tại Lào Cai. Được đào tạo bài bản tại Học viện Âm nhạc Quốc gia Việt Nam
Dòng nhạc : Nhạc Trẻ, Nhạc Cổ Trang
Cung hoàng đạo: Bọ Cạp (Scorpio)
Ngày sinh của Nhật Phong: 19/11','36000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values (N'Châu Khải Phong','chaukhaiphong.jpg',1,N'Tài vặt: có thể sáng tác và chơi 2 loại nhạc cụ ghita va organ.
Thần tượng: Bằng Kiều và Đàm vĩnh Hưng.
Bất ngờ đã tạo tên tuổi bằng ca khúc Anh thích em như xưa hồi vào năm 2011, Châu Khải Phong đã nhanh chóng trở thành một cái tên rất ăn khách, đặc biệt là ở trên các sân khấu phía nam.
Sau khi anh tốt nghiệp Đại học Văn hóa Nghệ thuật Quân đội, với những kiến thức về âm nhạc được học ở tại nhà trường cùng với niềm đam mê về ca hát, Châu Khải Phong đã về đầu quân cho công ty giải trí Hải Âu và cũng đã nhanh chóng gửi đến khán giả nhiều những sản phẩm âm nhạc chất lượng.','195000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('AMEE','amee.jpg',1,N'Có vẻ ngoài dễ thương và chất giọng ngọt ngào, AMEE gặt hái thành công với những ca khúc nhạc Pop có phần lời thả thính trong sáng như Exs Hate Me, Anh Nhà Ở Đâu Thế, Đen Đá Không Đường...
15 tuổi, AMEE trở thành thực tập sinh của St.319 Entertainment.
Tháng 2 2019, cô góp giọng trong Exs Hate Me của B Ray và Masew.
Tháng 4 2019, cô debut với Anh Nhà Ở Đâu Thế cùng B Ray, nhanh chóng thu hút một lực lượng lớn người nghe.
Tháng 5, bộ đôi ra mắt sản phẩm hợp tác thứ ba là Đen Đá Không Đường. Bài hát tiếp tục gây sốt với giới trẻ.
Tháng 7, cô kết hợp với Andiez trong Anh Đánh Rơi Người Yêu Này và tháng 10 với VIRUSS trong Trời Giấu Trời Mang Đi, kết thúc một năm thành công của tân binh khủng long AMEE.
Đầu năm 2020, AMEE góp giọng trong Do For Love của B Ray và Masew. Và chỉ nửa tháng sau, AMEE ra mắt ca khúc Sao Anh Chưa Về Nhà kết hợp cùng Ricky Star.','76000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values (N'Anh Quân Idol','anhquan.jpg',1,N'Sau khi tốt nghiệp phổ thông trung học, Quân dự thi vào trường Nhạc Viện Hà Nội năm 2006, nay là Học Viện Âm nhạc Quốc gia Việt Nam. Và theo học khoa thanh nhạc hệ chính quy.
Sở hữu một giọng nam cao, sáng và lạ Quân cũng có trong tay nhiều tấm bằng khen từ những cuộc thi hát với quy mô không nhỏ:
- Năm 2007 giải nhất giọng hát hay hàng tháng với ca khúc Rêu Phong.
- 2011 giải bạc cuộc thi tiếng hát truyền hình tỉnh Quang Ninh
- Gần đây nhất năm 2012 Quân đã dự thi cuộc thi VN idol và đã lọt vào Top7 người cuối cùng. Được đánh giá khá cao về chuyên môn từ phía hội đồng nghệ thuật, xong a Quân đã dừng lại ở vị trí số 7 do khán giả bình bầu.','16000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Masew','masew.jpg',1,N'Masew gắn bó với âm nhạc từ năm lớp 10 và dần nổi tiếng trong giới underground bằng những bản remix bắt tai. Anh là thành viên của AVN Team chuyên Rap, Hiphop, EDM.
Năm 2017, Masew gây chú ý cho giới nghe nhạc đại chúng khi cùng Nhật Nguyễn, một tên tuổi khác của giới underground phối lại ca khúc "Túy Âm" của Xesi. Ca khúc nhanh chóng đạt thứ hạng cao trên các bảng xếp hạng âm nhạc.
Từ đó, những bản phối của Masew rất được quan tâm, có thể kể đến "Điều Khác Lạ" (Đạt G, Ngọc Haleyy), "Buồn Của Anh" (K-ICM, Đạt G), "Kém Duyên" (Rum, NIT)... đặc biệt ca khúc "Em Hơi Mệt Với Bạn Thân Anh" do Trang Pháp sáng tác, Hương Giang trình bày với bản phối của Masew giành được giải thưởng lớn của Zing Music Awards.','52000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values (N'Trịnh Thanh Bình','trinhthanhbinh.jpg',1,N'Trịnh Thăng Bình là một ca sĩ, nhạc sĩ, diễn viên và nhà sản xuất âm nhạc nổi tiếng Việt Nam.

Năm 2006, nam ca sĩ gia nhập nhóm La Thăng cùng hai thành viên Minh Tuấn, Việt Hải.

Năm 2008 anh tách nhóm và phát triển sự nghiệp hát solo. Trịnh Thăng Bình ra mắt album đầu tay mang chính tên mình để khẳng định lối đi riêng cũng như vai trò sáng tác nhạc.

Năm 2011, nam ca sĩ phát hành album thứ hai Summer love với nhiều hit được các bạn trẻ yêu mến như: Lời chưa nói, Đã biết sẽ có ngày hôm qua, Đã lâu không gặp...

Năm 2013 anh phát hành ca khúc hit Người ấy.

Ngoài ca hát, Trịnh Thăng Bình còn tham gia đóng phim như: Có lẽ nào ta yêu nhau, Anh em sinh đôi, Blog và người đẹp, Tam nam vẫn phú…

Hiện tại anh là giám đốc công ty cổ phần Bpro Entertainment, chuyên sản xuất âm nhạc và tổ chức sự kiện.','127000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values (N'Dương Hồng Loan','duonghongloan.jpg',1,N'Dương Hồng Loan là một ca sĩ với dòng nhạc trữ tình đằm thắm được đông đảo các bạn biết đến và yêu mến.
Sở hữu một chất giọng thật ngọt ngào truyền cảm, rất hợp để hát những bản nhạc trữ tình, những làn điệu dân ca hay những bài hát mang âm hưởng dân ca. Cũng chính vì thế mà cô đã chọn dòng nhạc này để phục vụ khán giả.

Năm 2008, từ Đồng Tháp, Hồng Loan khăn gói lên Sài Gòn đi học. Hồng Loan khi còn học ở TP. Hồ Chí Minh, tình cờ chị đi qua một phòng trà tại quận Gò Vấp nhìn thấy đăng bản tuyển ca sĩ trẻ hát nhạc trữ tình, chị đăng ký dự thi, kết quả Hồng Loan được chủ phòng trà ký hợp đồng biểu diễn.

Năm 2007, Hồng Loan chính thức bước vào con đường hát chuyên nghiệp, Hồng Loan đã phát hành 2 album nhạc trữ tình được đông đảo khán giả đón nhận và được các Đài Phát thanh - Truyền hình mời tham gia biểu diễn nhiều chương trình văn nghệ lớn.','62000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values (N'Đạt G','datG.jpg',1,N'ạt G tham gia giới underground và là thành viên của Vietcover Squad team, có mối quan hệ thân thiết với Masew và B Ray.
Năm 2017, ca khúc ballad "Buồn Của Anh" (cùng K-ICM và Masew) được đón nhận nồng nhiệt, Đạt G được giới nghe nhạc chú ý.
Nửa năm sau, "Buồn Không Em" tiếp tục thành công không kém, mở đường cho sự nghiệp của Đạt G, anh có liên tiếp những bản hit được đón nhận như "Thêm Bao Nhiêu Lâu", "Khó Vẽ Nụ Cười" và "Bánh Mì Không" với DuUyen... với lợi thế pha trộn giữa rap và giai điệu ballad lôi cuốn người nghe.
Đạt G cũng là tác giả của nhiều bản hit triệu lượt nghe như "Anh Ơi Ở Lại" của Chi Pu, "Có Như Không Có" của Hiền Hồ hay "Còn Thương Thì Không Để Cho Em Khóc" của Miu Lê...','101000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Karik','karik.jpg',1,N'Karik tham gia nhóm nhảy Freestyle năm 2006 nhưng 2008 phải nghỉ vì chấn thương. Anh chuyển sang Rap để giải tỏa cảm xúc.
Ban đầu, Karik tự mình mày mò từ flow, lyrics và beat cho đến cách tự thu âm và dần dần được cộng đồng Underground công nhận sau cuối năm 2009.
Năm 2012 anh vinh dự là nghệ sĩ nhạc Rap đầu tiên đoạt giải MTV Việt Nam.
Các bài hát phát hành sau đó đều được khán giả yêu thích như: "Anh Không Đòi Quà", "Ế", "Rắc Rối"...
Năm 2018 Karik kết hợp cùng Orange trong bài hát "Người Lạ Ơi", bài hát trở thành hiện tượng của năm. Sau đó, cả hai còn hợp tác trong "Mình Từng Yêu Như Thế" và "Vô Thường".
Đầu năm 2019, Karik tung ra sản phẩm đậm chất cá nhân mang tên "Anh Em Tao".','202000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values (N'Đức Phúc','ducphuc.jpg',1,N'Đức Phúc là Quán quân Giọng hát Việt mùa 3 đồng thời là sinh viên trường Đại học Xây dựng Hà Nội. Hiện anh đang hoạt động nghệ thuật với vai trò ca sĩ do công ty Mỹ Tâm Entertainment quản lý.

Năm 2015 anh tham gia cuộc thi Giọng hát Việt. Trước khi tham gia Giọng hát Việt anh cũng đã từng tham gia hai cuộc thi khác đó là Vietnam Idol và Vietnams Got Talent nhưng đều bị loại ở ngay vòng đầu. Sau 6 tháng tham gia cuộc thi dưới sự đẫn dắt của Mỹ Tâm vào ngày 20/09/2015 anh chính thức trở thành quán quân nam đầu tiên của Giọng hát Việt với tỷ lệ tin nhắn bình chọn áp đảo 49.25%.
Sau hơn 2 tháng kể từ khi đăng quang ngôi vị Quán quân chương trình The Voice, Đức Phúc chính thức giới thiệu đến công chúng và khán giả yêu âm nhạc sản phẩm đầu tay của mình, MV “Chỉ Một Câu”. MV được sự hỗ trợ thực hiện từ Công ty MT Entertainment của ca sĩ Mỹ Tâm. Đây có thể xem là việc làm nhằm hiện thực hóa lời hứa sẽ đồng hành, hỗ trợ cậu học trò nhỏ mà “Họa mi tóc nâu” từng hứa trong cuộc thi The Voice. Không quá bất ngờ nhưng điều này cũng tạo ra nhiều thú vị bởi từ trước đến nay Mỹ Tâm gần như chưa bao giờ chính thức nhận lời hỗ trợ “toàn tập” cho bất kỳ ca sĩ trẻ nào.','141000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values (N'Trịnh ĐÌnh Quang','trinhdinhquang.jpg',1,N'Trịnh Đình Quang sinh ra trong gia đình không có ai theo nghệ thuật. Anh đỗ và tốt nghiệp trường Đại học Văn Hóa Nghệ Thuật khoa Piano vào năm 2012 và Nam tiến để theo đuổi đam mê âm nhạc nhưng khởi đầu khá khó khăn.
May mắn đầu tiên đã mỉm cười với anh khi tham gia vào một ứng dụng hát nhạc trực tuyến. Những ca khúc anh sáng tác và trình bày nhận được sự ủng hộ, mở đường cho anh trở thành ca sĩ chuyên nghiệp.
Hiện nay Trịnh Đình Quang đã sở hữu một công ty sản xuất nhạc Qstudio.
Ngoài ca hát, Trịnh Đình Quang còn là tác giả của nhiều ca khúc như "Một Tình Yêu Đúng Nghĩa" (Hồ Quang Hiếu), "Nếu Không Thể Đến Với Nhau" (The Men)...
Screen reader support enabled.','103000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values (N'Lệ Quyên','lequyen.jpg',1,N'Lệ Quyên tên thật là Vũ Lệ Quyên sinh ngày 02/04/1981 tại Hà Nội, là ca sĩ dòng nhạc nhẹ của Việt Nam.

Từ khi còn là sinh viên khoa Quần Chúng - Đại học Văn hóa (Hà Nội) Lệ Quyên đã bắt đầu bước vào con đường ca hát . Tuy nhiên, sự nghiệp ca hát chuyên nghiệp của cô chỉ bắt đầu từ năm 2002 khi được chọn tham gia hát bài hát của nhà tài trợ cho SEA Games 22 tại Việt Nam.

Năm 2005, Lệ Quyên cho ra mắt khán giả album đầu tay, Giấc mơ có thật, album đã đưa tên tuổi của Lệ Quyên đến với khán giả cả nước trở thành một nữ ca sĩ trẻ có triển vọng của làng âm nhạc Việt Nam. Với chất giọng khỏe và trầm của mình, nhiều ca khúc đã trở thành hit ca khúc của năm như: Giấc mơ có thật, Thôi đừng chiêm bao, Trăng chiều, Hãy trả lời em.','104000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values (N'Dạt Kaa','datkaa.jpg',1,N'Chưa cập nhật','6000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('X2X','x2x.jpg',1,N'X2X hoạt động từ năm 2018 với các thành viên JokeS Bii (rapper và là trưởng nhóm), Phát Hồ (hát chính), Sinike (sáng tác) và DinhLong (nhà sản xuất âm nhạc).
Các thành viên đều là những chàng trai trẻ tuổi và đến với âm nhạc bằng đam mê.
X2X bất ngờ nổi tiếng qua bản hit "Cô Thắm Không Về" trong năm 2019. Trước đó, X2X đã có MV đầu tiên là "Cô Gái Miền Tây" vào cuối năm 2018. Sau đó nhóm X2X tiếp tục cho ra mắt các sản phẩm như: "Phụ Duyên" (2019), "Thiệp Hồng Người Dưng" (2019), "Cố Giang Tình" (2020) và nhận được những phản ứng tích cực từ khán giả.','16000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values (N'Khắc Việt','khacviet.jpg',1,N'Tốt nghiệp khoa Thanh nhạc nhưng Khắc Việt bắt đầu với việc sáng tác.
Năm 2019 anh ra mắt ca khúc đầu tay với tựa đề "Quên".
Năm 2010, album "Yêu Lại Từ Đầu" được ra mắt. Bốn bài hát trong album gồm "Yêu Lại Từ Đầu", "Như Vậy Nhé", "Em Thế Nào" và "Quên" đều trở thành hit và được yêu thích.
Thông minh và nhạy bén với thị hiếu âm nhạc, từ đó đến nay, Khắc Việt ra mắt nhiều bản hit được yêu thích như "Khó", "Suy Nghĩ Trong Anh", "Yêu Mà" (cùng Dương Hoàng Yến)...
Với vai trò nhạc sĩ, anh đứng sau thành công của "Bước Qua Đời Nhau" (Lê Bảo Bình), "Tìm Lại Bầu Trời" (Tuấn Hưng), "Ngỡ" (Quang Hà), "Không Phải Em Đúng Không" (Dương Hoàng Yến)...','77000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values (N'Quang Lê','quangle.jpg',1,N'Quang Lê sinh ra tại Huế, trong gia đình gồm 6 anh em và một người chị nuôi, Quang Lê là con thứ 3 trong gia đình. Đầu những năm 1990, Quang Lê theo gia đình sang định cư tại bang Missouri, Mỹ. Hoạt động ca hát ở các sân khấu hải ngoại, anh tạo nên ấn tượng sâu sắc với khán giả qua dáng vẻ thư sinh cùng giọng hát trầm ấm và giàu tình cảm đậm chất Huế. Anh liên tiếp được trung tâm phát hành liên tiếp các album và đều tạo được tiếng vang lớn. Năm 2010 đến nay, Quang Lê thường xuyên tổ chức các hoạt động biểu diễn tại Việt Nam cũng như các hoạt động khác','52000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values (N'Sơn Tùng M-TP','sontung.jpg',1,N'M-TP tên thật là Nguyễn Thanh Tùng. Cậu thanh niên sinh năm 1994 ở Thái Bình sớm bị hip hop hớp hồn giống như bao bạn bè đồng trang lứa. Và với niềm đam mê này, M-TP quyết tâm khăn gói tới Hà Nội học hỏi thêm về hip hop. Sau khi tốt nghiệp cấp 3, anh chàng dự định sẽ đầu quân làm học viên tại Học viện M4Me để rèn dũa khả năng ca hát, sáng tác... trước khi chính thức theo đuổi con đường âm nhạc.

Ngoài đam mê ca hát, M-TP còn có khả năng sáng tác, chơi piano và nhảy cực đỉnh. Với thế mạnh này, anh chàng không ngừng cố gắng học tập các bậc đàn anh đàn chị và đã có trong tay một hành trang khá khủng những sáng tác của riêng mình.
','534000','');
go
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('BLACKPINK','BLACKPINK.jpg',2,N'BLACKPINK (Hangul: 블랙핑크; Romaja quốc ngữ: Beullaek Pingkeu, thường được viết cách điệu thành BLACK PINK, BLACKPINK hay BLΛƆKPIИK)

Vào ngày 29/06/2016, YG Entertainment đã chính thức tiết lộ girlgroup mới của họ sẽ chỉ gồm bốn thành viên đã công bố từ trước, đồng thời nhóm sẽ có tên là Black Pink.

Đại diện YG Entertainment cho biết: "Ý nghĩa của tên gọi Black Pink là để phản bác lại cách nhìn nhận phổ biến về màu hồng. Hồng thường được sử dụng để thể hiện vẻ xinh đẹp nhưng BLACKPINK mang ý nghĩa "Xinh đẹp không phải là tất cả". Nó còn mang nghĩa biểu tượng rằng họ là một nhóm không chỉ sở hữu ngoại hình xinh đẹp mà còn cực kỳ tài năng và cá tính".

Nhóm được thành lập vào năm 2016 và quản lý bởi công ty YG Entertainment bao gồm 4 thành viên: Jisoo sinh ngày 03/01/1995.
Jennie sinh ngày 16/01/1996.
Rosé sinh ngày 11/02/1997.
Lisa sinh ngày 27/03/1997.
YG thông báo rằng Black Pink sẽ không có trưởng nhóm vì công ty muốn cả bốn thành viên cùng hỗ trợ lẫn nhau.

Nhóm chính thức ra mắt vào lúc 8:00PM (KST) ngày 08/08/2016 với hai đĩa đơn "BOOMBAYAH" và "Whistle", nằm trong album đĩa đơn đầu tay "SQUARE ONE". Black Pink lập kỉ lục là nhóm nhạc nữ được đề cử và giành chiến thắng trên các show âm nhạc nhanh nhất kể từ khi ra mắt và bắt đầu quảng bá. Nhóm được no.1 trên Inkigayo chỉ sau 13 ngày debut.

Trước khi ra mắt: Ngày 01/06/2016, YG Entertainment bắt đầu giới thiệu hình ảnh teaser cho sự ra mắt của nhóm nhạc nữ mới, thành viên đầu tiên được tiết lộ là Jennie Kim, thực tập sinh khá nổi tiếng của YG, người trước đây đã hợp tác với các nghệ sĩ cùng công ty, trong đó có G-Dragon qua ca khúc "Black" (2012).

Ngày 08/06, hình ảnh của thành viên Lisa, một cô nàng bí ẩn gây nhiều ấn tượng với những video được đăng tải trên kênh Youtube của công ty. Lisa là thành viên ngoại quốc đầu tiên trong lịch sử nhà YG và được biết đến là người duy nhất dành chiến thắng trong cuộc thi YG Audition tại Thái Lan vào năm 2010.','291000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('BIGBANG','BIGBANG.jpg',2,N'Big Bang (Tiếng Triều Tiên: 빅뱅), thường được viết là BIGBANG, là một nhóm nhạc nam của Hàn Quốc với 5 thành viên thuộc YG Entertainment. Big Bang được biết đến lần đầu tiên qua những tập phim tài liệu ghi lại quá trình hình thành của họ được chiếu trên TV với tựa đề The Big Bang Documentary từ tháng 7 đến tháng 8 năm 2006. Những tập phim này cũng được phát lại trên GomTV và MTV Hàn Quốc. Thời điểm này nhóm có 6 thành viên, sau đó một thành viên đã phải rời khỏi nhóm (SO-1, Jang Hyun Seung) trong lúc các tập tài liệu đang phát sóng trước khi nhóm chính thức ra mắt, để cuối cùng trở thành đội hình 5 thành viên như hiện nay gồm: G-Dragon, T.O.P, Taeyang, Daesung và Seungri.
Dưới sự dẫn dắt của YG Entertainment, Big Bang liên tiếp phát hành những chuỗi single và EP và đạt được những thành công khá khiêm tốn. Cả nhóm chỉ thật sự đột phá với EP Always ("Luôn luôn") được phát hành vào năm 2007, làm tiền đề cho single số một của họ là "Lies" (Korean: 거짓말; Âm đọc: Geojitmal, Nghĩa: dối trá ). Những EP tiếp theo của họ là Hot Issue và Stand Up khẳng định vị trí của họ trong số những nhóm nhạc hip-hop hàng đầu tại Hàn Quốc. Sau khi được trao giải "Nghệ sĩ của năm" của chương trình Mnet KM Music Festival và giải thưởng "Seoul Gayo Daesang", cả nhóm mở rộng hoạt động sang thị trường Nhật Bản bằng việc phát hành một số mini album và single được phát sóng trên các kênh truyền thông. Tuy nhiên, những sản phẩm này không có được bất kỳ sự quảng bá nào cho đến khi single thật sự đầu tiên tại Nhật Bản của họ là My Heaven ("Thiên đường của tôi") chính thức ra mắt vào năm kế tiếp.
Cuối năm 2009, Big Bang trở thành tên tuổi nghệ sĩ được tìm kiếm nhiều nhất tại Hàn Quốc. Họ cũng trở thành nhóm nhạc nước ngoài đầu tiên tại Nhật Bản nhận được giải thưởng của Truyền hình cáp Nhật Bản với hạng mục "Nghệ sĩ mới". Trong thời gian gần đây, các thành viên của nhóm dành thời gian cho những công việc cá nhân: Taeyang và G-Dragon phát hành những sản phẩm solo trong khi T.O.P, Daesung và Seungri bắt đầu sự nghiệp diễn xuất.
Vũ đạo của họ không quá cầu kì như SNSD, SUJU, 2PM,... mà đơn giản thận thuộc dễ học đối với mọi người. Tuy nhiên, mỗi ngày họ luôn luôn cố gắng trau dồi, thể hiện bản thân của mình qua từng điệu nhảy. Bằng chứng là trưởng nhóm G-dragon đã rất thành công trong single "Heartbreaker". Với vũ đạo đặc biệt, cách thể hiện không giống ai nhưng đầy cá tính, Big Bang chắc chắc sẽ làm nên điều kì diệu trong những năm tới.
','52000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('IU','IU.jpg',2,N'Năm 2007, IU ký hợp đồng với Kakao M, debut với album "Lost And Found" năm 2008. Các album "Growing Up" và "IU...IM" ra mắt năm 2009 đều thành công.
Năm 2010, với ca khúc "Good Day" trong album "Real", IU trở thành ca sĩ "quốc dân".
Tiếp nối thành công, IU ra mắt album "Real" và "Last Fantasy" năm 2011 và "Morden Times" năm 2013, đánh dấu sự trưởng thành trong phong cách âm nhạc và chứng minh khả năng sáng tác nhạc của cô.
Các album tiếp theo lần lượt ra mắt "A Flower Bookmark", "Chat-Shire", "Palette"... tiếp tục thống trị các bảng xếp hạng âm nhạc. IU hiện đang là nghệ sĩ nữ solo thành công nhất của làng giải trí Hàn Quốc với vô số thành tích đáng gờm. Ngoài ra, cô còn được biết đến với vai trò diễn viên.
','69000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('TAEYEON','TAEYEON.jpg',2,N'Năm 2007, Taeyeon ra mắt cùng nhóm Girls Generation trực thuộc SM Entertainment. Nhóm ra mắt nhiều album, đạt nhiều giải thưởng và có đông người hâm mộ khắp thế giới.
Cô còn hoạt động trong nhóm nhỏ như Girls Generation-TTS hay SM The Ballad.
Tháng 10 năm 2015, Taeyeon debut với tư cách ca sĩ solo với mini-album đầu tay "I". Mini-album thứ hai "Why" được phát hành vào tháng 6 năm 2016. Sau đó là album phòng thu đầu tay "My Voice" năm 2017 và album thứ hai "Purpose" năm 2019. Tất cả đều thành công về mặt thương mại và được giới chuyên môn đánh giá cao. Cô nhận được nhiều giải thưởng danh giá: giải Bonsang nhiều năm liên tiếp của Golden Disc Awards, Nghệ Sĩ Nữ Xuất Sắc Nhất của Mnet Asian Music Awards năm 2016.','40000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Punch','Punch.jpg',2,N'Chưa cập nhật','5000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Ailee','Ailee.jpg',2,N'Ailee lớn lên ở Mỹ và bắt đầu ca hát trên Youtube. Trước khi ra mắt tại Hàn, Ailee hoạt động với Muzo Entertainment tại Mỹ.
Năm 2010, Ailee trở về Hàn và trở thành nghệ sĩ của YMC Entertainment. Trong thời gian này, cô tham gia diễn xuất trước khi chính thức debut với "Heaven" vào năm 2012. Sau đó, cô ra mắt 4 mini album và full album đầu tiên "A New Empire".
Năm 2017, bản OST "I Will Go To You Like The First Snow" của Aliee đạt thành tích khủng, càn quét tất cả các bảng xếp hạng và giành tổng cộng 6 chiếc cúp danh giá trong năm.
Tháng 2 năm 2019, Ailee rời công ty YMC Entertainment. Cô ra mắt full album thứ 2 mang tên "butterFLY" vào tháng 7. Và tháng 9, Ailee thành lập công ty Rocket3 Entertainment.','9000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Davichi','Davichi.jpg',2,N'Năm 2008, Davichi được thành lập gồm có hai thành viên, Lee Hae-ri và Kang Min-kyung. Nhóm phát hành album debut "Amarath" vào tháng 2, và ca khúc trong album "I Love You Even Though I Hate You" đoạt giải Tân binh của tháng ở Cyworld Digital Music Awards. Nhóm cũng giành được giải Nghệ Sĩ Mới Xuất Sắc Nhất của cả ba lễ trao giải Mnet, Golden Disk và Seoul Music.
Từ 2009 đến nay, Davichi ra mắt thêm 2 album phòng thu "Mystic Ballad" (2013) và "&10" (2018), cùng nhiều đĩa đơn đều giành thứ hạng cao trên các bảng xếp hạng.
Davichi cũng được xem là nhóm nhạc nữ thành công trên mặt trận nhạc số, và khi thể hiện các ca khúc nhạc phim, với thể loại chủ yếu là Ballad và R&B.','29000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('EXO','EXO.jpg',2,N'Chưa cập nhật','111000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Chanyeol','Chanyeol.jpg',2,N'hanyeol trở thành thực tập sinh của SM Entertainment từ năm 2008.
Năm 2012, anh debut với tư cách thành viên nhóm nhạc EXO. Bài hát debut "Mama" ra mắt vào tháng 4.
Cùng với EXO, Chanyeol đạt được nhiều thành tựu âm nhạc trong nước và trên thế giới. Ngoài ra, Chanyeol còn hoạt động trong nhóm nhỏ là EXO-K và EXO-SC.
Anh cũng có nhiều bản hit đứng tên cá nhân như, "Give Me That", "I Hate You" với Viên San San hay "Stay With Me" với Punch... Ngoài ra, anh còn sử dụng nghệ danh LOEY và phát hành "Familiar", "Slow Walk".
Chanyeol cũng có khả năng sáng tác, anh tham gia sản xuất một số bài hát trong album của nhóm EXO.
Ngoài âm nhạc, Chanyeol còn tham gia đóng phim và dẫn chương trình.','19000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('iKON','iKON.jpg',2,N'iKON (tiếng Hàn: 아이콘) là nhóm nhạc Hàn Quốc được thành lập bởi YG Entertainment.

Nhóm nhạc này có bảy thành viên gồm: B.I, Bobby, Kim Jinhwan, Koo Junhoe, Song Yunhyeong, Kim Donghyuk và Jung Chanwoo. Theo giám đốc điều hành YG, Yang Hyun Suk, chữ "C" trong "ICON" đã được thay thế bằng "K" trong "Korea" với ý nghĩa một nhóm nhạc biểu tượng đưa âm nhạc và văn hóa của Hàn Quốc và âm nhạc của nhóm sẽ được toàn châu Á biết đến.

Mặc dù iKON chỉ mới chính thức ra mắt vào năm 2015 nhưng trước đó các thành viên (trừ Chan-woo) đã được biết đến dưới danh nghĩa Team B trên chương trình sống còn do YG Entertainment tổ chức là "WIN: Who Is Next" được phát sóng vào năm 2013 và có tên iKON (cùng với Chan-woo) sau chương trình "Mix & Match" (cũng do YG entertainment tổ chức).

Nhóm đã ra mắt chính thức tại Hàn Quốc thông qua việc phát hành một single từ album đầu tiên của họ là "My Type" trong Welcome Back, iKON đã biễu diễn sân khấu đầu tiên mang tên "Debut Concert SHOWTIME" của họ vào ngày 04/10/2015 trên Inkigayo của đài SBS.

Tên fandom chính thức của nhóm là iKONIC, KONBAT là lightstick chính thức. Khẩu hiệu của nhóm là "Get Ready? SHOWTIME!".

Vào ngày 30/05, nhóm phát hành đĩa đơn "#WYD" (viết tắt "What You Doing"). Ca khúc đứng vị trí số ba trên bảng xếp hạng nhạc số. Vào ngày 10/08, đĩa đơn Dumb & Dumber phát hành đầu tiên tại Nhật Bản. Đĩa đơn được phát hành vào ngày 28 với một phiên bản CD + DVD và một phiên bản CD. Lượng tiêu thụ và stream đứng vị trí số một trên cả hai bảng xếp hạng Oricon Daily Single Album và bảng xếp hạng Oricon Weekly Single Album. Đĩa đơn cũng xếp số 1 trên bảng Weekly Hot 100 và Top Weekly Singles Sales của Billboard Nhật Bản.

Các album đã phát hành:
My Type (Single) (2016)
New Kids Begin (Japanese Version) (2017)','15000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('SUGA','SUGA.jpg',2,N'Chưa cập nhật','291000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('EVERGLOW','EVERGLOW.jpg',2,N'Chưa cập nhật','6000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Mamamoo','Mamamoo.jpg',2,N'Chưa cập nhật','23000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Baekhyun','Baekhyun.jpg',2,N'Chưa cập nhật','14000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Treasure','Treasure.jpg',2,N'Chưa cập nhật','2000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('SNSD','SNSD.jpg',2,N'Chưa cập nhật','132000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('V','V.jpg',2,N'Chưa cập nhật','39000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Apink','Apink.jpg',2,N'Chưa cập nhật','14000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Kim Na Young','KimNaYoung.jpg',2,N'Chưa cập nhật','774','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Jiyeon','Jiyeon.jpg',2,N'Chưa cập nhật','10000','');
go
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Kenshi Yonezu','KenshiYonezu.jpg',3,N'Chưa cập nhật','2000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('DEPAPEPE','DEPAPEPE.jpg',3,N'Chưa cập nhật','153','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('LiSA','LiSA.jpg',3,N'Chưa cập nhật','2000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Kitaro','Kitaro.jpg',3,N'Chưa cập nhật','576','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Skull','Skull.png',3,N'Chưa cập nhật','159','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Aimer','Aimer.jpg',3,N'Chưa cập nhật','1000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('7!!','7!!.jpg',3,N'Chưa cập nhật','273','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Hatsune Miku','HatsuneMiku.jpg',3,N'Chưa cập nhật','25000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Supernova','Supernova.jpg',3,N'Chưa cập nhật','146','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Toshiro Masuda','ToshiroMasuda.jpg',3,N'Chưa cập nhật','276','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('ReoNa','ReoNa.jpg',3,N'Chưa cập nhật','151','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Relax α Wave','Relax α Wave.png',3,N'Chưa cập nhật','48','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('DJ Okawari','DJOkawari.jpg',3,N'Chưa cập nhật','366','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('KANA-BOON','KANABOON.jpg',3,N'Chưa cập nhật','170','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('ASCA','ASCA.jpg',4,N'Chưa cập nhật','136','');
go
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Alan Walker','AlanWalker.jpg',4,N'Chưa cập nhật','247000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Selena Gomez','SelenaGomez.jpg',4,N'Chưa cập nhật','290000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Selena Gomez','SelenaGomez.jpg',4,N'Chưa cập nhật','875','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('K-391','K391.jpg',4,N'Chưa cập nhật','7000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Richard Clayderman','RichardClayderman.jpg',4,N'Chưa cập nhật','3000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Sia','Sia.jpg',4,N'Chưa cập nhật','15000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('DEAMN','DEAMN.jpg',4,N'Chưa cập nhật','34000','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Sasha Sloan','SashaSloan.jpg',4,N'Chưa cập nhật','882','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Dream Baby','DreamBaby.jpg',4,N'Chưa cập nhật','577','');
insert into NgheSi (TenNgheSi,AnhNgheSi,IdKhuVuc,MoTa,LuotQuanTam,Hot) values ('Martin Garrix','MartinGarrix.jpg',4,N'Chưa cập nhật','33000','');

--Thêm Dữ Liệu Bảng Album
insert into Album(TenAlbum,AnhAlbum,IdKhuVuc,IdNgheSi,Hot) values(N'Hoa Hải Đường','hoahaiduong.jpg',1,1,1);
--Them bang Album
insert into Album(TenAlbum,AnhAlbum,IdKhuVuc,IdNgheSi,Hot) values(N'Ai mang cô đơn đi','aimangcodondi.jpg',1,1,1);
insert into Album(TenAlbum,AnhAlbum,IdKhuVuc,IdNgheSi,Hot) values(N'Khác biệt to lớn','khacbiettolon.jpg',1,1,1);
insert into Album(TenAlbum,AnhAlbum,IdKhuVuc,IdNgheSi,Hot) values(N'Có tất cả nhưng thiếu anh','cotatcanhungthieuanh.jpg',1,1,1);
insert into Album(TenAlbum,AnhAlbum,IdKhuVuc,IdNgheSi,Hot) values(N'Thích Thì Đến(Single)','thichthiden.jpg',1,1,1);
insert into Album(TenAlbum,AnhAlbum,IdKhuVuc,IdNgheSi,Hot) values(N'Sau Tất Cả','sautatca.jpg',1,1,1);
insert into Album(TenAlbum,AnhAlbum,IdKhuVuc,IdNgheSi,Hot) values(N'Sóng Gió','songgio.jpg',1,1,1);
insert into Album(TenAlbum,AnhAlbum,IdKhuVuc,IdNgheSi,Hot) values(N'Bạc Phận','bacphan.jpg',1,1,1);
--
insert into Album(TenAlbum,AnhAlbum,IdKhuVuc,IdNgheSi,Hot) values(N'Em Của Ngày Hôm Qua','emcuangayhomqua.jpg',1,1,1);
insert into Album(TenAlbum,AnhAlbum,IdKhuVuc,IdNgheSi,Hot) values(N'Em Sẽ Là Cô Dâu(Single)','emselacodau.jpg',1,1,1);
insert into Album(TenAlbum,AnhAlbum,IdKhuVuc,IdNgheSi,Hot) values(N'Bigcityboi (Single)','Bigcityboi.jpg',1,1,1);
insert into Album(TenAlbum,AnhAlbum,IdKhuVuc,IdNgheSi,Hot) values(N'Tình Yêu Chắp Vá','tinhyeuchapva.jpg',1,1,1);
insert into Album(TenAlbum,AnhAlbum,IdKhuVuc,IdNgheSi,Hot) values(N'Hỏi Thăm Nhau','hoithamnhau.jpg',1,1,1);
insert into Album(TenAlbum,AnhAlbum,IdKhuVuc,IdNgheSi,Hot) values(N'LoveNote (Single)','LoveNote.jpg',1,1,1);
insert into Album(TenAlbum,AnhAlbum,IdKhuVuc,IdNgheSi,Hot) values(N'Chàng Trai Năm Ấy OST','changtrainamay.jpg',1,1,1);
--Thêm bảng bài hát
insert into BaiHat(TenBaiHat,AnhBaiHat,LoiBaihat,NgayPhatHanh,Top100,LuotNghe,LuotTai,LuotThich,LinkBaiHat,LinkChiaSe,IdNgheSi,IdTheLoai,IdAlbum) values (N'Hoa hải đường',N'hoahaiduong.jpg',N'hoahaiduong.txt','9/22/2020',1,51000000,1300000,340000,N'hoahaiduong.mp3','https://zingmp3.vn/bai-hat/Hoa-Hai-Duong-Jack/ZWDAAU8Z.html',1,1,1)
insert into BaiHat(TenBaiHat,AnhBaiHat,LoiBaihat,NgayPhatHanh,Top100,LuotNghe,LuotTai,LuotThich,LinkBaiHat,LinkChiaSe,IdNgheSi,IdTheLoai,IdAlbum) values (N'Sóng Gió',N'songgio.jpg',N'songgio.txt','7/12/2020',1,40000000,1200000,300000,N'songgio.mp3','https://zingmp3.vn/bai-hat/Song-Gio-Jack-K-ICM/ZWAEIUUB.html',1,1,7)
insert into BaiHat(TenBaiHat,AnhBaiHat,LoiBaihat,NgayPhatHanh,Top100,LuotNghe,LuotTai,LuotThich,LinkBaiHat,LinkChiaSe,IdNgheSi,IdTheLoai,IdAlbum) values (N'Bạc Phận',N'bacphan.jpg',N'bacphan.txt','7/20/2020',1,34000000,900000,280000,N'bacphan.mp3','https://zingmp3.vn/bai-hat/Bac-Phan-Jack-K-ICM/ZWAD0OB6.html',1,1,8)
insert into BaiHat(TenBaiHat,AnhBaiHat,LoiBaihat,NgayPhatHanh,Top100,LuotNghe,LuotTai,LuotThich,LinkBaiHat,LinkChiaSe,IdNgheSi,IdTheLoai,IdAlbum) values (N'Thích Thì Đến',N'thichthiden.jpg',N'thichthiden.txt','5/2/2020',0,23000000,1100000,200000,N'thichthiden.mp3','https://zingmp3.vn/bai-hat/Thich-Thi-Den-Le-Bao-Binh/ZWBWAIDA.html',2,1,5)
insert into BaiHat(TenBaiHat,AnhBaiHat,LoiBaihat,NgayPhatHanh,Top100,LuotNghe,LuotTai,LuotThich,LinkBaiHat,LinkChiaSe,IdNgheSi,IdTheLoai) values (N'Bỏ Lỡ Một người',N'bolomotnguoi.jpg',N'bolomotnguoi.txt','2/5/2020',1,34000000,2310000,240000,N'bolomotnguoi.mp3','https://zingmp3.vn/bai-hat/Bo-Lo-Mot-Nguoi-Le-Bao-Binh/ZWCZDFCA.html',2,1)
insert into BaiHat(TenBaiHat,AnhBaiHat,LoiBaihat,NgayPhatHanh,Top100,LuotNghe,LuotTai,LuotThich,LinkBaiHat,LinkChiaSe,IdNgheSi,IdTheLoai) values (N'Bước Qua Đời Nhau',N'buocquadoinhau.jpg',N'buocquadoinhau.txt','3/15/2020',1,34500000,800000,341000,N'buocquadoinhau.mp3','https://zingmp3.vn/bai-hat/Buoc-Qua-Doi-Nhau-Le-Bao-Binh/ZWAE8CBC.html',2,1)
insert into BaiHat(TenBaiHat,AnhBaiHat,LoiBaihat,NgayPhatHanh,Top100,LuotNghe,LuotTai,LuotThich,LinkBaiHat,LinkChiaSe,IdNgheSi,IdTheLoai) values (N'Bông Hoa Đẹp Nhất',N'bonghoadepnhat.jpg',N'bonghoadepnhat.txt','7/20/2020',1,34000000,900000,280000,N'bonghoadepnhat.mp3','https://zingmp3.vn/bai-hat/Bong-Hoa-Dep-Nhat-Quan-A-P/ZWDZCE80.html',3,1)
insert into BaiHat(TenBaiHat,AnhBaiHat,LoiBaihat,NgayPhatHanh,Top100,LuotNghe,LuotTai,LuotThich,LinkBaiHat,LinkChiaSe,IdNgheSi,IdTheLoai) values (N'Ai Là Người Thương Em',N'ailanguoithuongem.jpg',N'ailanguoithuongem.txt','5/2/2020',0,23000000,1100000,200000,N'ailanguoithuongem.mp3','https://zingmp3.vn/bai-hat/Ai-La-Nguoi-Thuong-Em-Quan-A-P/ZWADZBB9.html',3,1)
insert into BaiHat(TenBaiHat,AnhBaiHat,LoiBaihat,NgayPhatHanh,Top100,LuotNghe,LuotTai,LuotThich,LinkBaiHat,LinkChiaSe,IdNgheSi,IdTheLoai,IdAlbum) values (N'Sau Tất Cả',N'sautatca.jpg',N'sautatca.txt','2/5/2020',1,34000000,2310000,240000,N'sautatca.mp3','https://zingmp3.vn/bai-hat/Sau-Tat-Ca-ERIK/ZW7O777O.html',4,1,6)
insert into BaiHat(TenBaiHat,AnhBaiHat,LoiBaihat,NgayPhatHanh,Top100,LuotNghe,LuotTai,LuotThich,LinkBaiHat,LinkChiaSe,IdNgheSi,IdTheLoai) values (N'Em Không Sai Chúng Ta Sai',N'emkhongsaichungtasai.jpg',N'emkhongsaichungtasai.txt','3/15/2020',1,34500000,800000,341000,N'emkhongsaichungtasai.mp3','https://zingmp3.vn/bai-hat/Em-Khong-Sai-Chung-Ta-Sai-ERIK/ZWBOWD78.html',4,1)
insert into BaiHat(TenBaiHat,AnhBaiHat,LoiBaihat,NgayPhatHanh,Top100,LuotNghe,LuotTai,LuotThich,LinkBaiHat,LinkChiaSe,IdNgheSi,IdTheLoai) values (N'Bao Giờ Đủ Lớn',N'baogiodulon.jpg',N'baogiodulon.txt','7/20/2020',1,34000000,900000,280000,N'baogiodulon.mp3','https://zingmp3.vn/bai-hat/Bao-Gio-Du-Lon-ERIK/ZWDBC8CD.html',4,1)
insert into BaiHat(TenBaiHat,AnhBaiHat,LoiBaihat,NgayPhatHanh,Top100,LuotNghe,LuotTai,LuotThich,LinkBaiHat,LinkChiaSe,IdNgheSi,IdTheLoai) values (N'Thay Tôi Yêu Cô Ấy',N'thaytoiyeucoay.jpg',N'thaytoiyeucoay.txt','5/2/2020',0,23000000,1100000,200000,N'thaytoiyeucoay.mp3','https://zingmp3.vn/bai-hat/Thay-Toi-Yeu-Co-Ay-Thanh-Hung/ZWAEU0EE.html',5,1)
insert into BaiHat(TenBaiHat,AnhBaiHat,LoiBaihat,NgayPhatHanh,Top100,LuotNghe,LuotTai,LuotThich,LinkBaiHat,LinkChiaSe,IdNgheSi,IdTheLoai) values (N'Đúng Người Đúng Thời Điểm',N'dungnguoidungthoidiem.jpg',N'dungnguoidungthoidiem.txt','2/5/2020',1,34000000,2310000,240000,N'dungnguoidungthoidiem.mp3','https://zingmp3.vn/bai-hat/Dung-Nguoi-Dung-Thoi-Diem-Thanh-Hung/ZWAWZ0AI.html',5,1)
insert into BaiHat(TenBaiHat,AnhBaiHat,LoiBaihat,NgayPhatHanh,Top100,LuotNghe,LuotTai,LuotThich,LinkBaiHat,LinkChiaSe,IdNgheSi,IdTheLoai) values (N'Ai đợi Mình Được mãi',N'aidoiduocminhmai.jpg',N'aidoiduocminhmai.txt','3/15/2020',1,34500000,800000,341000,N'aidoiduocminhmai.mp3','https://zingmp3.vn/bai-hat/Ai-Doi-Minh-Duoc-Mai-Thanh-Hung/ZWBICDCO.html',5,1)
insert into BaiHat(TenBaiHat,AnhBaiHat,LoiBaihat,NgayPhatHanh,Top100,LuotNghe,LuotTai,LuotThich,LinkBaiHat,LinkChiaSe,IdNgheSi,IdTheLoai) values (N'Một Bước Yêu Vạn Dặm Đau',N'motbuocyeuvandamdau.jpg',N'motbuocyeuvandamdau.txt','3/15/2020',1,34500000,800000,341000,N'motbuocyeuvandamdau.mp3','https://zingmp3.vn/bai-hat/Mot-Buoc-Yeu-Van-Dam-Dau-Mr-Siro/ZWABWOFZ.html',7,1)
insert into BaiHat(TenBaiHat,AnhBaiHat,LoiBaihat,NgayPhatHanh,Top100,LuotNghe,LuotTai,LuotThich,LinkBaiHat,LinkChiaSe,IdNgheSi,IdTheLoai) values (N'Ánh Nắng Của Anh',N'anhnangcuaanh.jpg',N'anhnangcuaanh.txt','2/5/2020',1,34000000,2310000,240000,N'anhnangcuaanh.mp3','https://zingmp3.vn/bai-hat/Anh-Nang-Cua-Anh-Cho-Em-Den-Ngay-Mai-OST-Duc-Phuc/ZW78BW9D.html',19,1)
--them Bảng loại tài khoản
insert into LoaiTaiKhoan(LoaiTaiKhoan) values(N'ADMIN');
insert into LoaiTaiKhoan(LoaiTaiKhoan) values(N'KHÁCH');
insert into LoaiTaiKhoan(LoaiTaiKhoan) values(N'NHÂN VIÊN');
--them Bảng tài khoản
insert into TaiKhoan(TaiKhoan,MatKhau,IdLoaiTaiKhoan) values (N'admin',N'admin',1);
--Thêm bảng Tin Tức
insert into Tintuc(TieuDeTinTuc,NoiDung,ThoiGian,IdTaiKhoan) values (N'Quang Hải đá bóng với Jack để gây quỹ ủng hộ miền Trung',N'tintucjack.txt',N'2020/10/18',1);
--Update bảng nghệ sĩ--
Update NgheSi set Hot = 1;
--Thêm dữ liệu bảng Video--
insert into Video(TieuDe, IdNgheSi, IdKhuVuc, Poster, LinkVideoMp4,LuotXem, LuotThich) values(N'Khác Biệt To Lớn', 15, 1, 'khacbiettolon.jpg','khacbiettolon.mp4', 20000, 200000);
insert into Video(TieuDe, IdNgheSi, IdKhuVuc, Poster, LinkVideoMp4,LuotXem, LuotThich) values(N'Bỏ Lỡ Một Người', 2, 1, 'bolomotnguoi.jpg','bolomotnguoi.mp4', 20000, 200000);
insert into Video(TieuDe, IdNgheSi, IdKhuVuc, Poster, LinkVideoMp4,LuotXem, LuotThich) values(N'Em Không Sai Chúng Ta Sai', 4, 1, 'emkhongsaichungtasai.jpg','emkhongsaichungtasai.mp4', 20000, 200000);
insert into Video(TieuDe, IdNgheSi, IdKhuVuc, Poster, LinkVideoMp4,LuotXem, LuotThich) values(N'Hơn Cả Yêu', 19, 1, 'honcayeu.jpg','honcayeu.mp4', 20000, 200000);
insert into Video(TieuDe, IdNgheSi, IdKhuVuc, Poster, LinkVideoMp4,LuotXem, LuotThich) values(N'Sóng Gió', 1, 1, 'songgio.jpg','songgio.mp4', 20000, 200000);
insert into Video(TieuDe, IdNgheSi, IdKhuVuc, Poster, LinkVideoMp4,LuotXem, LuotThich) values(N'Em Ơi Lên Phố', 6, 1, 'emoilenpho.jpg','emoilenpho.mp4', 20000, 200000);
insert into Video(TieuDe, IdNgheSi, IdKhuVuc, Poster, LinkVideoMp4,LuotXem, LuotThich) values(N'Khác Biệt', 24, 1, 'khacbiet.jpg','khacbiet.mp4', 20000, 200000);
insert into Video(TieuDe, IdNgheSi, IdKhuVuc, Poster, LinkVideoMp4,LuotXem, LuotThich) values(N'Bánh Mì Không', 17, 1, 'banhmikhong.jpg','banhmikhong.mp4', 20000, 200000);
insert into Video(TieuDe, IdNgheSi, IdKhuVuc, Poster, LinkVideoMp4,LuotXem, LuotThich) values(N'Ai Là Người Thương Em', 3, 1, 'ailanguoithuongem.jpg','ailanguoithuongem.mp4', 20000, 200000);
go
--Thêm bảng người dùng--
insert into NguoiDung(TaiKhoan,MatKhau,TenNguoiDung,AnhDaiDien,DiaChi,Email) values('manh2604','26042001',N'Phạm Đức Mạnh', '', N'Hà Nội', 'ducmanhdv@gmail.com');
select * from Album;
select * from Video;
select * from BaiHat as bh, Album as ab where bh.IdAlbum = ab.IdAlbum;
--Update bảng bài hát
update BaiHat set AnhBaiHat = 'anhnangcuaanh_16.jpg' where IdBaiHat = 16;
go
select * from NgheSi;

select * from Tintuc;

select * from KhuVuc;

select * from NguoiDung;



select * from Album

select * from BaiHatYeuThich;
select * from VideoYeuThich;

select * from TaiKhoan;


select * from BinhLuan;



delete from BinhLuan where IdBinhLuan = 9

select * from NhacCaNhan;


select * from NgheSiYeuThich;

select * from TinTuc;

select * from BinhLuan, NguoiDung where BinhLuan.IdNguoiDung = NguoiDung.IdNguoiDung;



