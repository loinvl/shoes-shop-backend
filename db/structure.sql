# drop database if exists shoes_shop;
create database if not exists shoes_shop character set UTF8 collate utf8_vietnamese_ci;
use shoes_shop;

create table storeadmin
(
	StoreAdminID int auto_increment,
    HashPassword text not null,
    Email varchar(100) not null,
    
    constraint PkStoreAdmin primary key(StoreAdminID)
);

create table store
(
	StoreID int auto_increment,
	StoreName nvarchar(50) not null,
    Address text not null,
    Email varchar(100) not null,
    Phone char(10) not null,
    constraint PkStore primary key(StoreID)
);

create table customer
(
	CustomerID int auto_increment,
    CustomerName nvarchar(50) not null,
    HashPassword text not null,
    Email varchar(100) not null,
    Phone char(10),
    Address text,
    AvatarLink text,
    AccountStatus int default 0, ### 0: normal, 1: verified, 2: blocked, 3: deleted
    UserRole int default 0, ### 0: customer, 1: admin
    
    constraint PkCustomer primary key(CustomerID)
);

create table shoesmodel
(
	ShoesModelID int auto_increment,
    ShoesModelName text not null,
    BrandID int not null,
    ShoesModelDescription text,
	ShoesModelStatus int default 0, ### 0: stocking, 1: out stock, 2: deleted
    constraint PkShoesModel primary key(ShoesModelID)
);

create table shoes
(
    ShoesID int auto_increment,
	ShoesModelID int not null,
    Color nvarchar(20),
    Size int, check (Size >= 0),
    UnitPrice int not null, check(UnitPrice >= 0),
    Quantity int not null, check(Quantity >= 0),
    ShoesStatus int default 0, ### 0: con hang, 1: het hang, 2: da xoa
    
    constraint PkShoes primary key(ShoesID)
);

create table brand
(
	BrandID int auto_increment,
    BrandName nvarchar(50) not null,
    
    constraint PkBrand primary key(BrandID)
);

create table shoesmodelimage
(
	ImageID int auto_increment,
	ShoesModelID int not null,
    ImageLink text default null,
    
    constraint PkShoesModelImage primary key(ImageID)
);

create table cartdetail
(
	CustomerID int not null,
    ShoesID int not null,
    Quantity int not null, check(Quantity > 0),
    
    constraint PkCartDetail primary key(CustomerID, ShoesID)
);

create table rate
(
    PurchaseOrderID int not null,
    ShoesID int not null,
    CustomerID int not null,
	RateStar int not null, check(RateStar >= 0 and RateStar <=5),
    Content text,
    RateTime datetime not null,
    ImageLink text,
    
    constraint PkRate primary key(PurchaseOrderID, ShoesID)
);

create table purchaseorder
(
	PurchaseOrderID int auto_increment,
    CustomerID int not null,
    CustomerName nvarchar(50) not null,
    Phone char(10) not null,
    Email varchar(100) not null,
    OrderTime datetime not null,
    Address text  not null,
    OrderStatus int not null default 0, ### 0: da dat, 1: da goi hang, 2: dang van chuyen, 3: dang giao, 4: da nhan, 5: da huy
    Note text,

    constraint PkPurchaseOrder primary key(PurchaseOrderID)
);

create table orderdetail
(
    PurchaseOrderID int not null,
	ShoesID int not null,
    UnitPrice int not null, check(UnitPrice >= 0),
    Quantity int not null, check(Quantity > 0),

	constraint PkOrderDetail primary key(PurchaseOrderID, ShoesID)
);

alter table shoesmodel
	add constraint ShoesModel_FkBrandID foreign key (BrandID) references brand(BrandID);
    
alter table shoes
	add constraint Shoes_FkShoesModelID foreign key (ShoesModelID) references shoesmodel(ShoesModelID);
    
alter table cartdetail
	add constraint CartDetail_FkCustomerID foreign key (CustomerID) references customer(CustomerID),
    add constraint CartDetail_FkShoesID	foreign key(ShoesID) references shoes(ShoesID);
    
alter table shoesmodelimage
	add constraint ShoesModelImage_FkShoesModelID foreign key(ShoesModelID) references shoesmodel(ShoesModelID);
    
alter table purchaseorder
	add constraint PurchaseOrder_FkCustomerID foreign key(CustomerID) references customer(CustomerID);
    
alter table orderdetail
	add constraint OrderDetail_FkPurchaseOrderID foreign key(PurchaseOrderID) references purchaseorder(PurchaseOrderID),
	add constraint OrderDetail_FkShoesID foreign key(ShoesID) references shoes(ShoesID);
    
alter table rate
	add constraint Rate_FkOrder foreign key(PurchaseOrderID, ShoesID) references orderdetail(PurchaseOrderID, ShoesID),
    add constraint Rate_FkCustomerID foreign key(CustomerID) references customer(CustomerID);
    
    
#SET GLOBAL sql_mode=(SELECT REPLACE(@@sql_mode,'ONLY_FULL_GROUP_BY',''));
### The end
