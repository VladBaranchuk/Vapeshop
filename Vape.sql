create database Vape;
use Vape;
	

--�������


create table Section(
	section_id int IDENTITY(1,1) primary key,
	name varchar(128)
);

insert into Section(name)
	values  ('pod'),
			('tobacco heating systems'),
			('vaping liquid'),
			('vapes')


create table Brand(
	brand_id int IDENTITY(1,1) primary key,
	brand varchar(50)
);

insert into Brand(brand)
	values  ('Pons'),
			('Barz'),
			('Tugboat'),
			('IQOS'),
			('Lemon Twist'),
			('Maxwells'),
			('ReSalt'),
			('Smoant')


create table Manufacturer(
	manufacturer_id int IDENTITY(1,1) primary key,
	manufacturer varchar(100)
);

insert into Manufacturer(manufacturer)
	values  ('Pons'),
			('Barz'),
			('Tugboat'),
			('IQOS'),
			('Daddys Vapor'),
			('Maxwells'),
			('Vardex'),
			('Smoant')


create table Country(
	country_id int IDENTITY(1,1) primary key,
	country varchar(50)
);

insert into Country(country)
	values  ('�����'),
			('����������� �����'),
			('������')


--�������


create table Products(
	product_id int IDENTITY(1,1) primary key,
	country_id int foreign key references Country(country_id),
	brand_id int foreign key references Brand(brand_id),
	manufacturer_id int foreign key references Manufacturer(manufacturer_id),
	section_id int foreign key references Section(section_id),
	name varchar(128),
	price int

);

insert into Products(country_id, brand_id, manufacturer_id, section_id, name, price)
	values  (1, 1, 1, 1, '����������� ����������� �������� Pons Disposable Device Strawberry Lychee', '359'),
			(1, 1, 1, 1, '����������� ����������� �������� Pons Disposable Device Tropical Fruits', '359'),
			(1, 1, 1, 1, '����������� ����������� �������� Pons Disposable Device Mango', '359'),
			(1, 1, 1, 1, '����������� ����������� �������� Pons Disposable Device Banana Gum', '359'),

			(1, 4, 4, 2, '�������� IQOS 3 DUOS', '4990'),
			(1, 4, 4, 2, 'IQOS 2.4 PLUS ��������', '2990'),
			(1, 4, 4, 2, '�������� ���������� IQOS 3 / IQOS 3 DUOS', '2500'),

			(2, 5, 5, 3, '�������� Berry Twist Berry Medley Lemonade', '890'),
			(3, 6, 6, 3, 'Maxwells: �������� Baikal', '690'),
			(3, 7, 7, 3, '�������� ReSalt ����� Gold (10 ��)', '690'),
			(3, 7, 7, 3, '�������� ReSalt ������ Gold (10 ��)', '690'),

			(1, 8, 8, 4, 'Smoant Charon Baby POD Kit 750 mah with �������� Charon Baby', '1790'),
			(1, 8, 8, 4, 'Smoant Battlestar Baby Pod Kit 750mAh 15W', '1990'),
			(1, 8, 8, 4, 'Smoant Pasito POD Kit 1100 mah', '2390')


--�������

create table Users(
	user_id int IDENTITY(1,1) primary key,
	name varchar(128),
	surname varchar(128),
	login varchar(128),
	password varchar(512)
);

insert into Users(name, surname, login, password)
	values('Administrator', '', 'administrator@gmail.com', '4ea20c3d6154c421d08e62d422ad0186'),
		('Glad', 'Valakas', 'Valakas032145@gmail.com', '8681b1aa44fc535311cb22cbb2cac014')	

create table Vaping_liquid(
	vaping_liquid_id int IDENTITY(1,1) primary key,
	product_id int foreign key references Products(product_id),
	taste varchar(128),
	volume varchar(16),
	strong varchar(16)
);

insert into Vaping_liquid(product_id, taste, volume, strong)
	values  (8, '�������, ������, �������, �������', '60', '0'),
			(9, '��������� ����������� ����-���� �� ������� 1973 ����', '100', '0'),
			(10, '�����', '10', '20'),
			(11, '������', '10', '20')

create table Tobacco_heating_systems(
	ths_id int IDENTITY(1,1) primary key,
	product_id int foreign key references Products(product_id),
	battery_capacity varchar(16)
);

insert into Tobacco_heating_systems(product_id, battery_capacity)
	values  (5, '2900'),
			(6, '2900'),
			(7, '2900')

create table Vapes(
	vape_id int IDENTITY(1,1) primary key,
	product_id int foreign key references Products(product_id),
	peak_power varchar(16)
);

insert into Vapes(product_id, peak_power)
	values  (12, '15W'),
			(13, '15W'),
			(14, '25W')

create table Pod(
	pod_id int IDENTITY(1,1) primary key,
	product_id int foreign key references Products(product_id),
	battery_capacity varchar(16)
);

insert into Pod(product_id, battery_capacity)
	values  (1, '280'),
			(2, '280'),
			(3, '280'),
			(4, '280')


create table Basket(
	basket_id int IDENTITY(1,1) primary key,
	user_id int foreign key references Users(user_id),
	complete varchar(16) DEFAULT 'false',
	confirm varchar(16) DEFAULT 'false'
);

create table Orders(
	order_id int IDENTITY(1,1) primary key,
	basket_id int foreign key references Basket(basket_id),
	product_id int foreign key references Products(product_id)
);


