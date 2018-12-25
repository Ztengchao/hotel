* [hotel](#hotel)
  * [1 创建sqlserver储存库](#创建sqlserver数据库)             
  
  
# hotel
## 创建sqlserver数据库
```
create database hotel
go

USE hotel
GO

CREATE TABLE Hotel( --酒店表
	hID int IDENTITY(1,1) NOT NULL PRIMARY KEY, --酒店ID
	hName varchar(50) NOT NULL, --酒店名字
	hAddress varchar(60) NOT NULL, --酒店地址
	hPic varchar(80) NOT NULL, --酒店图片
	hIntroduce varchar(100) NULL, --酒店介绍
	hPhone1 char(11) NOT NULL, --酒店电话1
	hPhone2 char(11) NULL --酒店电话2
)
GO

CREATE TABLE HotelAdmin( --酒店管理员
	haAccount char(14) NOT NULL PRIMARY KEY, --管理员账号
	haPassword char(14) NOT NULL, --管理员密码
	haPhone char(11) NOT NULL, --管理员电话
	hID int IDENTITY(1,1) NOT NULL FOREIGN KEY REFERENCES Hotel(hID) --管理员所属酒店
)
GO

CREATE TABLE Room( --酒店房间
	rID int IDENTITY(1,1) NOT NULL PRIMARY KEY, --房间ID
	hID int NOT NULL FOREIGN KEY REFERENCES Hotel(hID),　--酒店ID
	rType nchar(20) NOT NULL, --房间类型
	rValue decimal(8, 2) NULL, --房间一天价格
	rAmount tinyint NOT NULL, --房间余量
	rPeople tinyint NOT NULL, --房间可入住人数
	rIntroduce varchar(100) NULL, --房间介绍
	rPic varchar(80) NOT NULL --房间图片
)
GO

CREATE TABLE [User]( --用户
	uAccount char(14) NOT NULL PRIMARY KEY, --用户账号
	uPassword char(14) NOT NULL, --用户密码
	uName nchar(14) NULL, --用户昵称
	uPhone char(11) NOT NULL --用户电话
)
GO

CREATE TABLE Guest( --旅客
	uAccount char(14) NOT NULL FOREIGN KEY REFERENCES [User](uAccount), --旅客所属用户
	gName char(10) NOT NULL, --旅客姓名
	gID char(14) NOT NULL, --旅客身份证号
	PRIMARY KEY(uAccount, gName)
)
GO

CREATE TABLE [Order]( --订单
	oID int NOT NULL PRIMARY KEY, --订单号
	rID int IDENTITY(1,1) NOT NULL FOREIGN KEY REFERENCES Room(rID), --房间ID
	uAccount char(14) NOT NULL  FOREIGN KEY REFERENCES [User](uAccount), --用户账号
	oInfo nvarchar(50) NOT NULL, --订单旅客信息
	oPhone char(11) NOT NULL, --联系电话
	InTime date NOT NULL, --入住时间
	OutTime date NOT NULL, --离开时间
	oRemark varchar(50) NULL, --用户备注
	oTime datetime NOT NULL, --下单时间
	oStat char(1) NOT NULL DEFAULT('1'), --订单状态，1-已下单，2-酒店已确定，3-已完成的订单，4-已取消的订单
	CONSTRAINT CK_Order CHECK  (OutTime>InTime)
)
GO
```
