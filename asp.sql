select * from Category

insert into Category(Name,Status) values
	(N'Backpacks',1),
	(N'Bags',1),
	(N'Cross bags',1),
	(N'Accessories',1)
go
insert into Product(Name,Image,Price,SalePrice,Description,CategoryId) values
	(N'Mesh Fabric Backpack MF101','/images/products/pd1.jpg',590000,0,N'Ch?t li?u: V?i Polyester 1010D cao c?p ch?ng th?m n??c cao. Quai ?eo và l?ng lót ??m êm, thoát m? hôi không gây nóng l?ng cho ng??i ?eo.',1),
	(N'Mesh Fabric Backpack MF102','/images/products/pd2.jpg',550000,0,N'Ch?t li?u: V?i Polyester 1010D cao c?p ch?ng th?m n??c cao. Quai ?eo và l?ng lót ??m êm, thoát m? hôi không gây nóng l?ng cho ng??i ?eo.',1),
	(N'Mesh Fabric Backpack MF104','/images/products/pd3.jpg',470000,0,N'Ch?t li?u: V?i Polyester 1010D cao c?p ch?ng th?m n??c cao. Quai ?eo và l?ng lót ??m êm, thoát m? hôi không gây nóng l?ng cho ng??i ?eo.',1),
	(N'Mesh Fabric Bumbag MF902','/images/products/pd4.jpg',370000,0,N'Ch?t li?u: V?i Polyester 1010D cao c?p ch?ng th?m n??c cao. Ng?n ch?ng s?c bên trong ??ng v?a t?t c? các dòng ?i?n tho?i.',2),
	(N'Mesh Fabric Shoulder Bag MF201','/images/products/pd5.jpg',270000,0,N'Ch?t li?u: V?i Polyester 1010D cao c?p ch?ng th?m n??c cao. Ng?n ch?ng s?c bên trong ??ng v?a t?t c? các dòng ?i?n tho?i.',2),
	(N'Mesh Fabric Shoulder Bag MF202','/images/products/pd6.jpg',299000,0,N'Ch?t li?u: V?i Polyester 1010D cao c?p ch?ng th?m n??c cao. Ng?n ch?ng s?c bên trong ??ng v?a t?t c? các dòng ?i?n tho?i.',2),
	(N'New Basic Backpack NB102','/images/products/pd7.jpg',460000,0,N'Ch?t li?u: V?i Polyester 1010D cao c?p ch?ng th?m n??c cao. Quai ?eo và l?ng lót ??m êm, thoát m? hôi không gây nóng l?ng cho ng??i ?eo.',1),
	(N'New Basic Backpack NB104','/images/products/pd8.jpg',390000,0,N'Ch?t li?u: V?i Polyester 1010D cao c?p ch?ng th?m n??c cao. Quai ?eo và l?ng lót ??m êm, thoát m? hôi không gây nóng l?ng cho ng??i ?eo.',1),
	(N'Mesh Fabric Cross Bag MF301','/images/products/pd9.jpg',440000,0,N'Ch?t li?u: V?i Polyester 1010D cao c?p ch?ng th?m n??c cao. Quai ?eo và l?ng lót ??m êm, thoát m? hôi không gây nóng l?ng cho ng??i ?eo.',3),
	(N'Mesh Fabric Duffle Bag MF501','/images/products/pd10.jpg',390000,350000,N'Ch?t li?u: V?i Polyester 1010D cao c?p ch?ng th?m n??c cao. ??u kéo BAMA ??c quy?n giúp kéo d? h?n và treo móc d? dàng h?n.',2),
	(N'New Basic Duffle Bag NB502','/images/products/pd11.jpg',370000,320000,N'Ch?t li?u: V?i Polyester 1010D cao c?p ch?ng th?m n??c cao. ??u kéo BAMA ??c quy?n giúp kéo d? h?n và treo móc d? dàng h?n.',2),
	(N'New Basic Totes NB802-S','/images/products/pd12.jpg',490000,470000,N'Ch?t li?u: V?i Polyester 1010D cao c?p ch?ng th?m n??c cao. Ng?n ch?ng s?c: ??ng v?a laptop 14 inch ( ng?n chính ??ng v?a laptop 15.6 inch nh?ng không gài nút b?m ???c )',2),
	(N'BAMA Wallet W606','/images/products/pd13.jpg',240000,210000,N'Ch?t li?u: Da bò Saffiano ch?ng x??c, ch?ng n??c cao. Tính n?ng: Ch?ng th?m, m?m m?i, d? v? sinh, ?? b?n, ?? ch?u nhi?t cao.',6),
	(N'BAMA Wallet W604','/images/products/pd14.jpg',290000,260000,N'Ch?t li?u: Da bò Saffiano ch?ng x??c, ch?ng n??c cao. Tính n?ng: Ch?ng th?m, m?m m?i, d? v? sinh, ?? b?n, ?? ch?u nhi?t cao.',6),
	(N'BAMA Wallet W605','/images/products/pd15.jpg',320000,300000,N'Ch?t li?u: Da bò Saffiano ch?ng x??c, ch?ng n??c cao. Tính n?ng: Ch?ng th?m, m?m m?i, d? v? sinh, ?? b?n, ?? ch?u nhi?t cao.',6),
	(N'New Basic Totes NB801','/images/products/pd16.jpg',550000,530000,N'Ch?t li?u: V?i Polyester 1010D cao c?p ch?ng th?m n??c cao. Ng?n ch?ng s?c: ??ng v?a laptop 14 inch ( ng?n chính ??ng v?a laptop 15.6 inch nh?ng không gài nút b?m ???c )',2),
	(N'New Basic Totes NB802-M','/images/products/pd17.jpg',550000,530000,N'Ch?t li?u: V?i Polyester 1010D cao c?p ch?ng th?m n??c cao. Ng?n ch?ng s?c: ??ng v?a laptop 14 inch ( ng?n chính ??ng v?a laptop 15.6 inch nh?ng không gài nút b?m ???c )',2)
go
select * from Users
insert into Users values
	('michael',LOWER(CONVERT(varchar(32),HASHBYTES('md5','12345678'),2)),'michael@gmail.com','Michael Wu','customer'),
	('admin',LOWER(CONVERT(varchar(32),HASHBYTES('md5','123456'),2)),'admin@gmail.com','Admin','admin')
go

select * from Product

