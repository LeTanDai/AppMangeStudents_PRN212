CREATE DATABASE PRN212_ManageStudents
GO

USE PRN212_ManageStudents
GO


CREATE TABLE [dbo].[Admin](
	[ID] [varchar](20) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Gender] [varchar](6) NULL,
	[Email] [varchar](50) NULL,
	[phone] [varchar](10) NULL,
	[BirthDay] [date] NULL,
	[PassWord] [varchar](50) NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Assign](
	assignID INT IDENTITY(1,1) PRIMARY KEY,  -- Khóa chính tự động tăng
    IDTeacher VARCHAR(20) NOT NULL,
    IDSubject VARCHAR(10) NOT NULL,
    nameClass VARCHAR(10) NOT NULL,
    schoolYear VARCHAR(9) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Class](
	[nameClass] [varchar](10) NOT NULL,
	[schoolYear] [varchar](9) NOT NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[nameClass] ASC,
	[schoolYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mark](
	[Semester] [varchar](9) NOT NULL,
	[ProgressTest1] [real] NULL,
	[ProgressTest2] [real] NULL,
	[Lab1] [real] NULL,
	[Lab2] [real] NULL,
	[Assignment] [real] NULL,
	[PracticalExam] [real] NULL,
	[FinalExam] [real] NULL,
	[Total] [real] NULL,
	[IDStudent] [varchar](20) NOT NULL,
	[IDSubject] [varchar](10) NOT NULL,
	[nameClass] [varchar](10) NOT NULL,
	[schoolYear] [varchar](9) NOT NULL,
 CONSTRAINT [PK_Mark_1] PRIMARY KEY CLUSTERED 
(
	[Semester] ASC,
	[IDStudent] ASC,
	[IDSubject] ASC,
	[nameClass] ASC,
	[schoolYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Rule](
	[minAge] [int] NOT NULL,
	[maxAge] [int] NOT NULL,
	[passScore] [float] NOT NULL,
	[totalStudent] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Student](
	[IDStudent] [varchar](20) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Gender] [varchar](6) NULL,
	[Email] [varchar](50) NULL,
	[Phone] [varchar](11) NULL,
	[BirthDay] [date] NULL,
	[PassWord] [varchar](50) NULL,
	[isActive] [char](1) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[IDStudent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Student_Class](
	[IDStudent] [varchar](20) NOT NULL,
	[nameClass] [varchar](10) NOT NULL,
	[schoolYear] [varchar](9) NOT NULL,
 CONSTRAINT [PK_Student_Class] PRIMARY KEY CLUSTERED 
(
	[IDStudent] ASC,
	[nameClass] ASC,
	[schoolYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Subject](
	[IDSubject] [varchar](10) NOT NULL,
	[NameSubject] [nvarchar](100) NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[IDSubject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Teacher](
	[IDTeacher] [varchar](20) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Gender] [varchar](6) NULL,
	[Email] [varchar](50) NULL,
	[Phone] [varchar](11) NULL,
	[BirthDay] [date] NULL,
	[PassWord] [varchar](50) NULL,
	[isActive] [char](1) NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[IDTeacher] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Teacher_Subject](
	[IDTeacher] [varchar](20) NOT NULL,
	[IDSubject] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Teacher_Subject] PRIMARY KEY CLUSTERED 
(
	[IDTeacher] ASC,
	[IDSubject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Insert table Admin
INSERT INTO [dbo].[Admin]([ID] ,[Name] ,[Gender] ,[Email] ,[phone] ,[BirthDay] ,[PassWord] ) VALUES
('admin1', N'Nguyễn Văn Hoàng Phúc', 'Male', 'Phuc@gmail.com', '0926615662', '2004-09-27', 'abc@123'),
('admin2', N'Trương Quốc Cường', 'Male', 'Qcu@gmail.com', '0922222222', '2004-09-16', 'abc@123'),
('admin3', N'Lê Thế Bảo', 'Male', 'Lbao@gmail.com', '0933333333', '2004-04-14', 'abc@123'),
('admin4', N'Lê Tấn Đại', 'Male', 'Dai@gmail.com', '0944444444', '2004-09-27', 'abc@123'),
('admin5', N'Huỳnh Trần Văn Trọng', 'Male', 'Trong@gmail.com', '0955555555', '2004-09-27', 'abc@123');
GO

INSERT INTO Teacher(BirthDay, Email, Gender, IDTeacher, isActive, Name, PassWord, Phone) VALUES 
('1985-03-15', 'baolt1404@fpt.edu.vn', 'Male', N'GV001', 'Y', N'Lê Thế Bảo', '123', '1234567890'),
('1978-07-22', 'cuongtq1609@fpt.edu.vn', 'Female', N'GV002', 'Y', N'Trương Quốc Cường', '123', '0987654321'),
('1990-11-30', 'phucnvh2709@fpt.edu.vn', 'Male', N'GV003', 'N', N'Nguyễn Văn Hoàng Phúc', '123', '5551234567'),
('1982-05-05', 'dailt0101@fpt.edu.vn', 'Female', N'GV004', 'Y', N'Lê Tấn Đại', '123', '5557654321'),
('1975-09-10', 'tronghtv1505@fpt.edu.vn', 'Male', N'GV005', 'Y', N'Huỳnh Trần Văn Trọng', '123', '4445556666'),
('1992-12-25', 'phull0304@fpt.edu.vn', 'Female', N'GV006', 'Y', N'Lê Long Phú', '123', '3332221111'),
('1988-01-20', 'ynht0810@fpt.edu.vn', 'Male', N'GV007', 'N', N'Nguyễn Hoài Trân Ý', '123', '7778889999'),
('1995-08-15', 'notq1609@fpt.edu.vn', 'Female', N'GV008', 'Y', N'Trương Quốc Nồ', '123', '2223334444'),
('1983-04-02', 'haiv@fpt.edu.vn', 'Male', N'GV009', 'Y', N'Việt Hải', '123', '6667778888'),
('1979-10-18', 'kietlt@fpt.edu.vn', 'Female', N'GV010', 'N', N'Lê Tuấn Kiệt', '123', '1112223333'),
('1986-02-25', 'huynn1803@fpt.edu.vn', 'Male', N'GV011', 'Y', N'Nguyễn Nhân Huỳnh', '123', '1231231234'),
('1991-06-10', 'minhtt2404@fpt.edu.vn', 'Female', N'GV012', 'Y', N'Trần Thị Minh', '123', '5675675678'),
('1984-08-18', 'thuynh2907@fpt.edu.vn', 'Male', N'GV013', 'N', N'Huỳnh Nhất Thuyên', '123', '6786786789'),
('1993-05-22', 'quanghd@fpt.edu.vn', 'Female', N'GV014', 'Y', N'Hà Đức Quang', '123', '7897897890'),
('1977-11-12', 'phuongtl@fpt.edu.vn', 'Male', N'GV015', 'Y', N'Trần Lâm Phương', '123', '1011011011'),
('1981-03-15', 'danhnt2005@fpt.edu.vn', 'Female', N'GV016', 'Y', N'Nguyễn Thị Danh', '123', '1121121122'),
('1995-09-18', 'longtt1508@fpt.edu.vn', 'Male', N'GV017', 'N', N'Trần Thành Long', '123', '1131131133'),
('1990-02-14', 'tamld@fpt.edu.vn', 'Female', N'GV018', 'Y', N'Lê Đình Tâm', '123', '1141141144'),
('1987-12-01', 'hungvd@fpt.edu.vn', 'Male', N'GV019', 'Y', N'Vũ Đức Hùng', '123', '1151151155'),
('1989-06-25', 'hongnl@fpt.edu.vn', 'Female', N'GV020', 'N', N'Nguyễn Lệ Hồng', '123', '1161161166'),
('1982-10-05', 'binhhp@fpt.edu.vn', 'Male', N'GV021', 'Y', N'Phạm Hải Bình', '123', '1171171177'),
('1980-07-23', 'linhct@fpt.edu.vn', 'Female', N'GV022', 'Y', N'Cao Thị Linh', '123', '1181181188'),
('1994-01-11', 'hoaantt@fpt.edu.vn', 'Male', N'GV023', 'N', N'Trần Thanh Hoài', '123', '1191191199'),
('1983-04-07', 'khoadt@fpt.edu.vn', 'Female', N'GV024', 'Y', N'Đặng Thị Khoa', '123', '1201201200'),
('1976-09-29', 'lamnh@fpt.edu.vn', 'Male', N'GV025', 'Y', N'Nguyễn Hữu Lâm', '123', '1211211211'),
('1989-08-12', 'duongtv@fpt.edu.vn', 'Female', N'GV026', 'Y', N'Trần Vân Dương', '123', '1221221222'),
('1992-02-20', 'hoangtq@fpt.edu.vn', 'Male', N'GV027', 'N', N'Trương Quang Hoàng', '123', '1231231233'),
('1985-11-18', 'giangle@fpt.edu.vn', 'Female', N'GV028', 'Y', N'Lê Ngọc Giang', '123', '1241241244'),
('1986-12-30', 'longhv@fpt.edu.vn', 'Male', N'GV029', 'Y', N'Hoàng Văn Long', '123', '1251251255'),
('1991-07-19', 'ngocnt@fpt.edu.vn', 'Female', N'GV030', 'Y', N'Nguyễn Thanh Ngọc', '123', '1261261266'),
('1991-07-19', 'luannt@fpt.edu.vn', 'Female', N'GV031', 'Y', N'Nguyễn Thanh Luân', '123', '1261261266');
-- Insert table Subject

INSERT INTO [dbo].[Subject]([IDSubject] ,[NameSubject] ) VALUES
('ENT503', 'Summit2'),
('VOV114', 'Vovinam 1'), 
('VOV124', 'Vovinam 2'),
('VOV134', 'Vovinam 3'),
('OTP101', 'Orientation and General Training Program'),
('TMI_ELE', 'Traditional musical instrument	'),
('MAE101', 'Mathematics for Engineering'),
('PRF192', 'Programming Fundamentals'),
('CEA201', 'Computer Organization and Architecture'),
('CSI104', 'Connecting to Computer Science'),
('SSL101c', 'Academic Skills for University Success'),
('NWC203c', 'Computer Networking'),
('MAD101', 'Discrete mathematics'),
('OSG202', 'Operating System'),
('PRO192', 'Object-Oriented Programming'),
('SSG104', 'Communication and In-Group Working Skills'),
('WED201c', 'WEB DESIGN'),
('JPD113', 'Japanese Elementary (Part 1/4)'),
('DBI202', 'Database Systems'),
('CSD201', 'Data Structure and Algorithm'),
('LAB211', 'OOP with Java'),
('PRJ301', 'Java Web Application Development'),
('SWE201c', 'Introduction to Software Engineering'),
('MAS291', 'Statistics & Probability'),
('JPD123', 'Japanese Elementary 1-A1.2'),
('IOT102', 'Internet of things'),
('PRN212', 'Basis Cross-Platform Application Programming With .NET'),
('ITE302c', 'Ethics in IT'),
('SWP391', 'Software development project'),
('SWR302', 'Software Requirement'),
('SWT301', 'Software Testing');
GO


-- Insert table teacher_subject 
INSERT INTO Teacher_Subject ( IDSubject,IDTeacher) VALUES
('ENT503', 'GV001'),
('VOV114', 'GV002'), 
('VOV124', 'GV003'),
('VOV134', 'GV004'),
('OTP101', 'GV005'),
('TMI_ELE', 'GV006'),
('MAE101', 'GV007'),
('PRF192', 'GV008'),
('CEA201', 'GV009'),
('CSI104', 'GV010'),
('SSL101c', 'GV011'),
('NWC203c', 'GV012'),
('MAD101', 'GV013'),
('OSG202', 'GV014'),
('PRO192', 'GV015'),
('SSG104', 'GV016'),
('WED201c', 'GV017'),
('JPD113', 'GV018'),
('DBI202', 'GV019'),
('CSD201', 'GV020'),
('LAB211', 'GV021'),
('PRJ301', 'GV022'),
('SWE201c', 'GV023'),
('MAS291', 'GV024'),
('JPD123', 'GV025'),
('IOT102', 'GV026'),
('PRN212', 'GV027'),
('ITE302c', 'GV028'),
('SWP391', 'GV029'),
('SWR302', 'GV030'),
('SWT301', 'GV031');
GO
-- Insert table Class

INSERT INTO [dbo].[Class] (nameClass, schoolYear)
VALUES 
	('SE18B01', '2021-2022'),
	('SE18B02', '2022-2023'),
	('SE18B03', '2022-2023'),
	('SE18B04', '2023-2024'),
	('SE18B05', '2023-2024'),
	('SE18B06', '2021-2022')
GO

-- Insert table Assign
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV001', N'ENT503', N'SE18B01', N'2021-2022')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV001', N'ENT503', N'SE18B02', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV001', N'ENT503', N'SE18B03', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV001', N'ENT503', N'SE18B04', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV001', N'ENT503', N'SE18B05', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV001', N'ENT503', N'SE18B06', N'2021-2022')

INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV002', N'VOV114', N'SE18B01', N'2021-2022')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV002', N'VOV114', N'SE18B02', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV002', N'VOV114', N'SE18B03', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV002', N'VOV114', N'SE18B04', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV002', N'VOV114', N'SE18B05', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV002', N'VOV114', N'SE18B06', N'2021-2022')

INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV003', N'VOV124', N'SE18B01', N'2021-2022')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV003', N'VOV124', N'SE18B02', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV003', N'VOV124', N'SE18B03', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV003', N'VOV124', N'SE18B04', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV003', N'VOV124', N'SE18B05', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV003', N'VOV124', N'SE18B06', N'2021-2022')

INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV004', N'VOV134', N'SE18B01', N'2021-2022')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV004', N'VOV134', N'SE18B02', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV004', N'VOV134', N'SE18B03', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV004', N'VOV134', N'SE18B04', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV004', N'VOV134', N'SE18B05', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV004', N'VOV134', N'SE18B06', N'2021-2022')

INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV005', N'OTP101', N'SE18B01', N'2021-2022')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV005', N'OTP101', N'SE18B02', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV005', N'OTP101', N'SE18B03', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV005', N'OTP101', N'SE18B04', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV005', N'OTP101', N'SE18B05', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV005', N'OTP101', N'SE18B06', N'2021-2022')

INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV006', N'TMI_ELE', N'SE18B01', N'2021-2022')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV006', N'TMI_ELE', N'SE18B02', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV006', N'TMI_ELE', N'SE18B03', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV006', N'TMI_ELE', N'SE18B04', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV006', N'TMI_ELE', N'SE18B05', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV006', N'TMI_ELE', N'SE18B06', N'2021-2022')



INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV007', N'MAE101', N'SE18B01', N'2021-2022')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV007', N'MAE101', N'SE18B02', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV007', N'MAE101', N'SE18B03', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV007', N'MAE101', N'SE18B04', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV007', N'MAE101', N'SE18B05', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV007', N'MAE101', N'SE18B06', N'2021-2022')

INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV008', N'PRF192', N'SE18B01', N'2021-2022')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV008', N'PRF192', N'SE18B02', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV008', N'PRF192', N'SE18B03', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV008', N'PRF192', N'SE18B04', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV008', N'PRF192', N'SE18B05', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV008', N'PRF192', N'SE18B06', N'2021-2022')

INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV009', N'CEA201', N'SE18B01', N'2021-2022')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV009', N'CEA201', N'SE18B02', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV009', N'CEA201', N'SE18B03', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV009', N'CEA201', N'SE18B04', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV009', N'CEA201', N'SE18B05', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV009', N'CEA201', N'SE18B06', N'2021-2022')

INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV010', N'CSI104', N'SE18B01', N'2021-2022')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV010', N'CSI104', N'SE18B02', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV010', N'CSI104', N'SE18B03', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV010', N'CSI104', N'SE18B04', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV010', N'CSI104', N'SE18B05', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV010', N'CSI104', N'SE18B06', N'2021-2022')

INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV011', N'SSL101c', N'SE18B01', N'2021-2022')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV011', N'SSL101c', N'SE18B02', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV011', N'SSL101c', N'SE18B03', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV011', N'SSL101c', N'SE18B04', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV011', N'SSL101c', N'SE18B05', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV011', N'SSL101c', N'SE18B06', N'2021-2022')


INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV012', N'NWC203c', N'SE18B01', N'2021-2022')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV012', N'NWC203c', N'SE18B02', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV012', N'NWC203c', N'SE18B03', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV012', N'NWC203c', N'SE18B04', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV012', N'NWC203c', N'SE18B05', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV012', N'NWC203c', N'SE18B06', N'2021-2022')


INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV013', N'MAD101', N'SE18B01', N'2021-2022')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV013', N'MAD101', N'SE18B02', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV013', N'MAD101', N'SE18B03', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV013', N'MAD101', N'SE18B04', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV013', N'MAD101', N'SE18B05', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV013', N'MAD101', N'SE18B06', N'2021-2022')

INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV014', N'OSG202', N'SE18B01', N'2021-2022')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV014', N'OSG202', N'SE18B02', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV014', N'OSG202', N'SE18B03', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV014', N'OSG202', N'SE18B04', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV014', N'OSG202', N'SE18B05', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV014', N'OSG202', N'SE18B06', N'2021-2022')


INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV015', N'PRO192', N'SE18B01', N'2021-2022')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV015', N'PRO192', N'SE18B02', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV015', N'PRO192', N'SE18B03', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV015', N'PRO192', N'SE18B04', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV015', N'PRO192', N'SE18B05', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV015', N'PRO192', N'SE18B06', N'2021-2022')

INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV016', N'SSG104', N'SE18B01', N'2021-2022')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV016', N'SSG104', N'SE18B02', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV016', N'SSG104', N'SE18B03', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV016', N'SSG104', N'SE18B04', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV016', N'SSG104', N'SE18B05', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV016', N'SSG104', N'SE18B06', N'2021-2022')


INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV017', N'WED201c', N'SE18B01', N'2021-2022')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV017', N'WED201c', N'SE18B02', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV017', N'WED201c', N'SE18B03', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV017', N'WED201c', N'SE18B04', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV017', N'WED201c', N'SE18B05', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV017', N'WED201c', N'SE18B06', N'2021-2022')



INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV018', N'JPD113', N'SE18B01', N'2021-2022')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV018', N'JPD113', N'SE18B02', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV018', N'JPD113', N'SE18B03', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV018', N'JPD113', N'SE18B04', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV018', N'JPD113', N'SE18B05', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV018', N'JPD113', N'SE18B06', N'2021-2022')


INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV019', N'DBI202', N'SE18B01', N'2021-2022')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV019', N'DBI202', N'SE18B02', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV019', N'DBI202', N'SE18B03', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV019', N'DBI202', N'SE18B04', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV019', N'DBI202', N'SE18B05', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV019', N'DBI202', N'SE18B06', N'2021-2022')

INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV020', N'CSD201', N'SE18B01', N'2021-2022')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV020', N'CSD201', N'SE18B02', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV020', N'CSD201', N'SE18B03', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV020', N'CSD201', N'SE18B04', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV020', N'CSD201', N'SE18B05', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV020', N'CSD201', N'SE18B06', N'2021-2022')


INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV021', N'LAB211', N'SE18B01', N'2021-2022')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV021', N'LAB211', N'SE18B02', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV021', N'LAB211', N'SE18B03', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV021', N'LAB211', N'SE18B04', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV021', N'LAB211', N'SE18B05', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV021', N'LAB211', N'SE18B06', N'2021-2022')


INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV022', N'PRJ301', N'SE18B01', N'2021-2022')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV022', N'PRJ301', N'SE18B02', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV022', N'PRJ301', N'SE18B03', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV022', N'PRJ301', N'SE18B04', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV022', N'PRJ301', N'SE18B05', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV022', N'PRJ301', N'SE18B06', N'2021-2022')


INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV023', N'SWE201c', N'SE18B01', N'2021-2022')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV023', N'SWE201c', N'SE18B02', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV023', N'SWE201c', N'SE18B03', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV023', N'SWE201c', N'SE18B04', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV023', N'SWE201c', N'SE18B05', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV023', N'SWE201c', N'SE18B06', N'2021-2022')


INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV0024', N'MAS291', N'SE18B01', N'2021-2022')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV0024', N'MAS291', N'SE18B02', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV0024', N'MAS291', N'SE18B03', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV0024', N'MAS291', N'SE18B04', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV0024', N'MAS291', N'SE18B05', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV0024', N'MAS291', N'SE18B06', N'2021-2022')


INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV025', N'JPD123', N'SE18B01', N'2021-2022')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV025', N'JPD123', N'SE18B02', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV025', N'JPD123', N'SE18B03', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV025', N'JPD123', N'SE18B04', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV025', N'JPD123', N'SE18B05', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV025', N'JPD123', N'SE18B06', N'2021-2022')

INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV026', N'IOT102', N'SE18B01', N'2021-2022')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV026', N'IOT102', N'SE18B02', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV026', N'IOT102', N'SE18B03', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV026', N'IOT102', N'SE18B04', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV026', N'IOT102', N'SE18B05', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV026', N'IOT102', N'SE18B06', N'2021-2022')


INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV027', N'PRN212', N'SE18B01', N'2021-2022')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV027', N'PRN212', N'SE18B02', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV027', N'PRN212', N'SE18B03', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV027', N'PRN212', N'SE18B04', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV027', N'PRN212', N'SE18B05', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV027', N'PRN212', N'SE18B06', N'2021-2022')

INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV028', N'ITE302c', N'SE18B01', N'2021-2022')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV028', N'ITE302c', N'SE18B02', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV028', N'ITE302c', N'SE18B03', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV028', N'ITE302c', N'SE18B04', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV028', N'ITE302c', N'SE18B05', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV028', N'ITE302c', N'SE18B06', N'2021-2022')


INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV029', N'SWP391', N'SE18B01', N'2021-2022')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV029', N'SWP391', N'SE18B02', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV029', N'SWP391', N'SE18B03', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV029', N'SWP391', N'SE18B04', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV029', N'SWP391', N'SE18B05', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV029', N'SWP391', N'SE18B06', N'2021-2022')


INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV030', N'SWR302', N'SE18B01', N'2021-2022')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV030', N'SWR302', N'SE18B02', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV030', N'SWR302', N'SE18B03', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV030', N'SWR302', N'SE18B04', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV030', N'SWR302', N'SE18B05', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV030', N'SWR302', N'SE18B06', N'2021-2022')


INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV031', N'SWT301', N'SE18B01', N'2021-2022')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV031', N'SWT301', N'SE18B02', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV031', N'SWT301', N'SE18B03', N'2022-2023')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV031', N'SWT301', N'SE18B04', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV031', N'SWT301', N'SE18B05', N'2023-2024')
INSERT [dbo].[Assign] ([IDTeacher], [IDSubject], [nameClass], [schoolYear]) VALUES (N'GV031', N'SWT301', N'SE18B06', N'2021-2022')
GO

-- Insert table Student
INSERT INTO [dbo].[Student] ([IDStudent], [Name], [Gender], [Email], [Phone], [BirthDay], [PassWord], [isActive]) VALUES
('ST001', N'Nguyễn Văn A', 'Male', 'nguyen.vana001@example.com', '0912345678', '1999-02-15', '123', 1),
('ST002', N'Trần Thị B', 'Female', 'tran.thib002@example.com', '0912345679', '2000-05-22', '123', 1),
('ST003', N'Lê Văn C', 'Male', 'le.vanc003@example.com', '0912345680', '1998-11-02', '123', 1),
('ST004', N'Phạm Thị D', 'Female', 'pham.thid004@example.com', '0912345681', '1997-04-18', '123', 0),
('ST005', N'Đỗ Minh E', 'Male', 'do.minhe005@example.com', '0912345682', '2001-09-10', '123', 1),
('ST006', N'Hoàng Thị F', 'Female', 'hoang.thif006@example.com', '0912345683', '1997-12-25', '123', 1),
('ST007', N'Phan Văn G', 'Male', 'phan.vang007@example.com', '0912345684', '1999-06-13', '123', 0),
('ST008', N'Vũ Thị H', 'Female', 'vu.thih008@example.com', '0912345685', '2000-03-27', '123', 1),
('ST009', N'Ngô Văn I', 'Male', 'ngo.vani009@example.com', '0912345686', '1998-10-30', '123', 0),
('ST010', N'Đặng Thị K', 'Female', 'dang.thik010@example.com', '0912345687', '1999-01-04', '123', 1),
('ST011', N'Bùi Văn L', 'Male', 'bui.vanl011@example.com', '0912345688', '1997-08-19', '123', 1),
('ST012', N'Nguyễn Thị M', 'Female', 'nguyen.thim012@example.com', '0912345689', '2000-07-07', '123', 0),
('ST013', N'Trịnh Văn N', 'Male', 'trinh.vann013@example.com', '0912345690', '2001-12-12', '123', 1),
('ST014', N'Lý Thị O', 'Female', 'ly.thio014@example.com', '0912345691', '1998-09-21', '123', 1),
('ST015', N'Nguyễn Văn P', 'Male', 'nguyen.vanp015@example.com', '0912345692', '1999-02-11', '123', 1),
('ST016', N'Trần Thị Q', 'Female', 'tran.thiq016@example.com', '0912345693', '1997-03-16', '123', 0),
('ST017', N'Lê Văn R', 'Male', 'le.vanr017@example.com', '0912345694', '2001-05-01', '123', 1),
('ST018', N'Phạm Thị S', 'Female', 'pham.this018@example.com', '0912345695', '1998-06-18', '123', 1),
('ST019', N'Đỗ Văn T', 'Male', 'do.vant019@example.com', '0912345696', '1999-10-17', '123', 0),
('ST020', N'Hoàng Thị U', 'Female', 'hoang.thiu020@example.com', '0912345697', '1997-11-14', '123', 1),
('ST021', N'Phan Văn V', 'Male', 'phan.vanv021@example.com', '0912345698', '2001-03-22', '123', 1),
('ST022', N'Vũ Thị W', 'Female', 'vu.thiw022@example.com', '0912345699', '1998-12-08', '123', 1),
('ST023', N'Ngô Văn X', 'Male', 'ngo.vanx023@example.com', '0912345700', '1997-07-07', '123', 0),
('ST024', N'Đặng Thị Y', 'Female', 'dang.thiy024@example.com', '0912345701', '2000-09-25', '123', 1),
('ST025', N'Bùi Văn Z', 'Male', 'bui.vanz025@example.com', '0912345702', '2001-02-20', '123', 1),
('ST026', N'Nguyễn Thị AA', 'Female', 'nguyen.thiaa026@example.com', '0912345703', '1999-04-12', '123', 1),
('ST027', N'Trần Văn AB', 'Male', 'tran.vanab027@example.com', '0912345704', '1998-05-30', '123', 0),
('ST028', N'Lê Thị AC', 'Female', 'le.thiac028@example.com', '0912345705', '1997-10-01', '123', 1),
('ST029', N'Phạm Văn AD', 'Male', 'pham.vanad029@example.com', '0912345706', '2000-01-15', '123', 1),
('ST030', N'Đỗ Thị AE', 'Female', 'do.thiae030@example.com', '0912345707', '1999-08-05', '123', 1),
('ST031', N'Hoàng Văn AF', 'Male', 'hoang.vanaf031@example.com', '0912345708', '1997-09-28', '123', 1),
('ST032', N'Phan Thị AG', 'Female', 'phan.thiag032@example.com', '0912345709', '2000-06-16', '123', 1),
('ST033', N'Vũ Văn AH', 'Male', 'vu.vanah033@example.com', '0912345710', '1999-03-09', '123', 0),
('ST034', N'Ngô Thị AI', 'Female', 'ngo.thiai034@example.com', '0912345711', '1997-05-06', '123', 1),
('ST035', N'Đặng Văn AJ', 'Male', 'dang.vanaj035@example.com', '0912345712', '2001-10-13', '123', 1),
('ST036', N'Bùi Thị AK', 'Female', 'bui.thiak036@example.com', '0912345713', '1998-02-26', '123', 1),
('ST037', N'Nguyễn Văn AL', 'Male', 'nguyen.vanal037@example.com', '0912345714', '1999-11-14', '123', 1),
('ST038', N'Trần Thị AM', 'Female', 'tran.thiam038@example.com', '0912345715', '1997-04-22', '123', 0),
('ST039', N'Lê Văn AN', 'Male', 'le.vanan039@example.com', '0912345716', '1998-12-04', '123', 1),
('ST040', N'Phạm Thị AO', 'Female', 'pham.thiao040@example.com', '0912345717', '1999-08-18', '123', 1),
('ST041', N'Đỗ Văn AP', 'Male', 'do.vanap041@example.com', '0912345718', '2000-03-14', '123', 1),
('ST042', N'Hoàng Thị AQ', 'Female', 'hoang.thiaq042@example.com', '0912345719', '1997-09-09', '123', 1),
('ST043', N'Phan Văn AR', 'Male', 'phan.vanar043@example.com', '0912345720', '2001-07-24', '123', 0),
('ST044', N'Vũ Thị AS', 'Female', 'vu.thias044@example.com', '0912345721', '1998-06-20', '123', 1),
('ST045', N'Ngô Văn AT', 'Male', 'ngo.vanat045@example.com', '0912345722', '1999-10-07', '123', 1),
('ST046', N'Đặng Thị AU', 'Female', 'dang.thiau046@example.com', '0912345723', '1997-02-13', '123', 1),
('ST047', N'Bùi Văn AV', 'Male', 'bui.vanav047@example.com', '0912345724', '2000-08-30', '123', 1),
('ST048', N'Nguyễn Thị AW', 'Female', 'nguyen.thiaw048@example.com', '0912345725', '1998-05-24', '123', 0),
('ST049', N'Trần Văn AX', 'Male', 'tran.vanax049@example.com', '0912345726', '1997-06-15', '123', 1),
('ST050', N'Lê Thị AY', 'Female', 'le.thiay050@example.com', '0912345727', '2000-04-11', '123', 1),
('ST051', N'Phạm Văn AZ', 'Male', 'pham.vanaz051@example.com', '0912345728', '1999-09-22', '123', 1),
('ST052', N'Đỗ Thị BA', 'Female', 'do.thiba052@example.com', '0912345729', '1997-08-30', '123', 1),
('ST053', N'Hoàng Văn BB', 'Male', 'hoang.vanbb053@example.com', '0912345730', '2001-01-19', '123', 0),
('ST054', N'Phan Thị BC', 'Female', 'phan.thibc054@example.com', '0912345731', '1998-07-28', '123', 1),
('ST055', N'Vũ Văn BD', 'Male', 'vu.vanbd055@example.com', '0912345732', '1999-04-09', '123', 1),
('ST056', N'Ngô Thị BE', 'Female', 'ngo.thibe056@example.com', '0912345733', '1997-12-01', '123', 1),
('ST057', N'Đặng Văn BF', 'Male', 'dang.vanbf057@example.com', '0912345734', '2000-07-22', '123', 0),
('ST058', N'Bùi Thị BG', 'Female', 'bui.thibg058@example.com', '0912345735', '1998-11-25', '123', 1),
('ST059', N'Nguyễn Văn BH', 'Male', 'nguyen.vanbh059@example.com', '0912345736', '1997-06-05', '123', 1),
('ST060', N'Trần Thị BI', 'Female', 'tran.thibi060@example.com', '0912345737', '2001-09-17', '123', 1);
GO

-- Insert table Student_Class

INSERT INTO [dbo].[Student_Class] (IDStudent, nameClass, schoolYear)
VALUES
    -- Lớp SE18B01 - 2021-2022
    ('ST001', 'SE18B01', '2021-2022'),
    ('ST012', 'SE18B01', '2021-2022'),
    ('ST023', 'SE18B01', '2021-2022'),
    ('ST034', 'SE18B01', '2021-2022'),
    ('ST045', 'SE18B01', '2021-2022'),
    ('ST056', 'SE18B01', '2021-2022'),

    -- Lớp SE18B02 - 2022-2023
    ('ST002', 'SE18B02', '2022-2023'),
    ('ST013', 'SE18B02', '2022-2023'),
    ('ST024', 'SE18B02', '2022-2023'),
    ('ST035', 'SE18B02', '2022-2023'),
    ('ST046', 'SE18B02', '2022-2023'),
    ('ST007', 'SE18B02', '2022-2023'),  

    -- Lớp SE18B03 - 2022-2023
    ('ST003', 'SE18B03', '2022-2023'),
    ('ST014', 'SE18B03', '2022-2023'),
    ('ST025', 'SE18B03', '2022-2023'),
    ('ST036', 'SE18B03', '2022-2023'),
    ('ST047', 'SE18B03', '2022-2023'),
    ('ST018', 'SE18B03', '2022-2023'),  

    -- Lớp SE18B04 - 2023-2024
    ('ST004', 'SE18B04', '2023-2024'),
    ('ST015', 'SE18B04', '2023-2024'),
    ('ST026', 'SE18B04', '2023-2024'),
    ('ST037', 'SE18B04', '2023-2024'),
    ('ST048', 'SE18B04', '2023-2024'),
    ('ST059', 'SE18B04', '2023-2024'),

	 -- Lớp SE18B05 - 2023-2024
	('ST029', 'SE18B05', '2023-2024'),  
    ('ST040', 'SE18B05', '2023-2024'),
	('ST041', 'SE18B05', '2023-2024'),
	('ST042', 'SE18B05', '2023-2024'),
	('ST043', 'SE18B05', '2023-2024'),
	('ST044', 'SE18B05', '2023-2024'),

    -- Lớp SE18B06 - 2021-2022
    ('ST005', 'SE18B06', '2021-2022'),
    ('ST016', 'SE18B06', '2021-2022'),
    ('ST027', 'SE18B06', '2021-2022'),
    ('ST038', 'SE18B06', '2021-2022'),
    ('ST049', 'SE18B06', '2021-2022'),
    ('ST060', 'SE18B06', '2021-2022');
    
GO

-- Insert table Mark
INSERT INTO [dbo].[Mark]([Semester], [ProgressTest1], [ProgressTest2], [Lab1], [Lab2], [Assignment], [PracticalExam], [FinalExam], [Total], [IDStudent], [IDSubject], [nameClass], [schoolYear]) VALUES
    ('Spring', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST002', 'ENT503', 'SE18B02', '2022-2023'),
    ('Fall', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST002', 'VOV114', 'SE18B02', '2022-2023'),
    ('Summer', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST002', 'VOV124', 'SE18B02', '2022-2023'),
    ('Fall', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST002', 'VOV134', 'SE18B02', '2022-2023'),
    ('Spring', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST002', 'OTP101', 'SE18B02', '2022-2023'),
    ('Summer', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST002', 'TMI_ELE', 'SE18B02', '2022-2023'),
    ('Fall', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST002', 'MAE101', 'SE18B02', '2022-2023'),
    ('Spring', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST002', 'PRF192', 'SE18B02', '2022-2023'),
    ('Summer', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST002', 'CEA201', 'SE18B02', '2022-2023'),
    ('Fall', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST002', 'CSI104', 'SE18B02', '2022-2023'),
    ('Spring', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST002', 'SSL101c', 'SE18B02', '2022-2023'),
    ('Summer', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST002', 'NWC203c', 'SE18B02', '2022-2023'),
    ('Fall', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST002', 'MAD101', 'SE18B02', '2022-2023'),
    ('Spring', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST002', 'OSG202', 'SE18B02', '2022-2023'),
    ('Summer', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST002', 'PRO192', 'SE18B02', '2022-2023'),
    ('Fall', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST002', 'SSG104', 'SE18B02', '2022-2023'),
    ('Spring', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST002', 'WED201c', 'SE18B02', '2022-2023'),
    ('Summer', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST002', 'JPD113', 'SE18B02', '2022-2023'),
    ('Fall', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST002', 'DBI202', 'SE18B02', '2022-2023'),
    ('Spring', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST002', 'CSD201', 'SE18B02', '2022-2023'),
    ('Summer', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST002', 'LAB211', 'SE18B02', '2022-2023'),
    ('Fall', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST002', 'PRJ301', 'SE18B02', '2022-2023'),
    ('Spring', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST002', 'SWE201c', 'SE18B02', '2022-2023'),
    ('Summer', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST002', 'MAS291', 'SE18B02', '2022-2023'),
    ('Fall', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST002', 'JPD123', 'SE18B02', '2022-2023'),
    ('Spring', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST002', 'IOT102', 'SE18B02', '2022-2023'),
    ('Summer', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST002', 'PRN212', 'SE18B02', '2022-2023'),
    ('Fall', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST002', 'ITE302c', 'SE18B02', '2022-2023'),
    ('Spring', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST002', 'SWP391', 'SE18B02', '2022-2023'),
	 
    ('Spring', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST013', 'ENT503', 'SE18B02', '2022-2023'),
    ('Fall', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST024', 'VOV114', 'SE18B02', '2022-2023'),
    ('Summer', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST035', 'VOV124', 'SE18B02', '2022-2023'),
    ('Fall', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST046', 'VOV134', 'SE18B02', '2022-2023'),
    ('Spring', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST013', 'OTP101', 'SE18B02', '2022-2023'),
    ('Summer', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST024', 'TMI_ELE', 'SE18B02', '2022-2023'),
    ('Fall', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST035', 'MAE101', 'SE18B02', '2022-2023'),
    ('Spring', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST046', 'PRF192', 'SE18B02', '2022-2023'),
    ('Summer', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST013', 'CEA201', 'SE18B02', '2022-2023'),
    ('Fall', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST024', 'CSI104', 'SE18B02', '2022-2023'),
    ('Spring', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST035', 'SSL101c', 'SE18B02', '2022-2023'),
    ('Summer', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST046', 'NWC203c', 'SE18B02', '2022-2023'),
    ('Fall', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST013', 'MAD101', 'SE18B02', '2022-2023'),
    ('Spring', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST024', 'OSG202', 'SE18B02', '2022-2023'),
    ('Summer', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST035', 'PRO192', 'SE18B02', '2022-2023'),
    ('Fall', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST046', 'SSG104', 'SE18B02', '2022-2023'),
    ('Spring', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST013', 'WED201c', 'SE18B02', '2022-2023'),
    ('Summer', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST024', 'JPD113', 'SE18B02', '2022-2023'),
    ('Fall', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST035', 'DBI202', 'SE18B02', '2022-2023'),
    ('Spring', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST046', 'CSD201', 'SE18B02', '2022-2023'),
    ('Summer', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST013', 'LAB211', 'SE18B02', '2022-2023'),
    ('Fall', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST024', 'PRJ301', 'SE18B02', '2022-2023'),
    ('Spring', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST035', 'SWE201c', 'SE18B02', '2022-2023'),
    ('Summer', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST046', 'MAS291', 'SE18B02', '2022-2023'),
    ('Fall', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST013', 'JPD123', 'SE18B02', '2022-2023'),
    ('Spring', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST024', 'IOT102', 'SE18B02', '2022-2023'),
    ('Summer', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST035', 'PRN212', 'SE18B02', '2022-2023'),
    ('Fall', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST046', 'ITE302c', 'SE18B02', '2022-2023'),
    ('Spring', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST013', 'SWP391', 'SE18B02', '2022-2023'),
    ('Fall', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST035', 'SWR302', 'SE18B02', '2022-2023'),
    ('Spring', 8.5, 9.0, 8.0, 9.5, 9.0, 8.5, 8.0, 8.8, 'ST046', 'SWT301', 'SE18B02', '2022-2023');
GO

-- Insert table Rule
INSERT INTO [dbo].[Rule] ([minAge], [maxAge], [passScore], [totalStudent]) VALUES
(18, 22, 5.0, 60)
GO

SELECT * FROM [dbo].Assign
SELECT * FROM [dbo].Teacher
SELECT * FROM [dbo].[Subject]
SELECT * FROM [dbo].Mark
SELECT * FROM [dbo].Student_Class
SELECT * FROM [dbo].Class
SELECT * FROM [dbo].Teacher_Subject
SELECT * FROM [dbo].Student
SELECT * FROM [dbo].[Rule]
SELECT * FROM [dbo].[Admin]

DELETE FROM [dbo].Assign
DELETE FROM [dbo].Teacher_Subject
DELETE FROM [dbo].Teacher
DELETE FROM [dbo].[Subject]
DELETE FROM [dbo].Mark
DELETE FROM [dbo].Student_Class
DELETE FROM [dbo].Class
DELETE FROM [dbo].Student
DELETE FROM [dbo].[Rule]


-- CONSTRAINT

ALTER TABLE [dbo].[Assign]  WITH CHECK ADD  CONSTRAINT [FK_Assign_Class] FOREIGN KEY([nameClass], [schoolYear])
REFERENCES [dbo].[Class] ([nameClass], [schoolYear])
GO

ALTER TABLE [dbo].[Assign] CHECK CONSTRAINT [FK_Assign_Class]
GO

ALTER TABLE [dbo].[Assign]  WITH CHECK ADD  CONSTRAINT [FK_Assign_Teacher_Subject] FOREIGN KEY([IDTeacher], [IDSubject])
REFERENCES [dbo].[Teacher_Subject] ([IDTeacher], [IDSubject])
GO

ALTER TABLE [dbo].[Assign] CHECK CONSTRAINT [FK_Assign_Teacher_Subject]
GO


ALTER TABLE [dbo].[Mark]  WITH CHECK ADD  CONSTRAINT [FK_Mark_Student_Class] FOREIGN KEY([IDStudent], [nameClass], [schoolYear])
REFERENCES [dbo].[Student_Class] ([IDStudent], [nameClass], [schoolYear])
GO

ALTER TABLE [dbo].[Mark] CHECK CONSTRAINT [FK_Mark_Student_Class]
GO

ALTER TABLE [dbo].[Mark]  WITH CHECK ADD  CONSTRAINT [FK_Mark_Subject] FOREIGN KEY([IDSubject])
REFERENCES [dbo].[Subject] ([IDSubject])
GO

ALTER TABLE [dbo].[Mark] CHECK CONSTRAINT [FK_Mark_Subject]
GO

ALTER TABLE [dbo].[Student_Class]  WITH CHECK ADD  CONSTRAINT [FK_Student_Class_Class] FOREIGN KEY([nameClass], [schoolYear])
REFERENCES [dbo].[Class] ([nameClass], [schoolYear])
GO

ALTER TABLE [dbo].[Student_Class] CHECK CONSTRAINT [FK_Student_Class_Class]
GO

ALTER TABLE [dbo].[Student_Class]  WITH CHECK ADD  CONSTRAINT [FK_Student_Class_Student] FOREIGN KEY([IDStudent])
REFERENCES [dbo].[Student] ([IDStudent])
GO

ALTER TABLE [dbo].[Student_Class] CHECK CONSTRAINT [FK_Student_Class_Student]
GO

ALTER TABLE [dbo].[Teacher_Subject]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Subject_Subject] FOREIGN KEY([IDSubject])
REFERENCES [dbo].[Subject] ([IDSubject])
GO

ALTER TABLE [dbo].[Teacher_Subject] CHECK CONSTRAINT [FK_Teacher_Subject_Subject]
GO

ALTER TABLE [dbo].[Teacher_Subject]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Subject_Teacher] FOREIGN KEY([IDTeacher])
REFERENCES [dbo].[Teacher] ([IDTeacher])
GO

ALTER TABLE [dbo].[Teacher_Subject] CHECK CONSTRAINT [FK_Teacher_Subject_Teacher]
GO

ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [CHECK_GENDER_STUDENT] CHECK  (([Gender]='Female' OR [Gender]='Male'))
GO

ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [CHECK_GENDER_STUDENT]
GO

ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [CHECK_GENDER_TEACHER] CHECK  (([Gender]='Female' OR [Gender]='Male'))
GO

ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [CHECK_GENDER_TEACHER]
GO

USE [master]
GO

ALTER DATABASE  PRN212_ManageStudents SET  READ_WRITE 
GO

DROP DATABASE PRN212_ManageStudents