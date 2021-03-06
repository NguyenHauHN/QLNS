USE [QLNS]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 05/09/2017 11:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Admin](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Username] [nvarchar](250) NULL,
	[Password] [nvarchar](250) NULL,
	[Address] [nvarchar](250) NULL,
	[Gender] [int] NOT NULL CONSTRAINT [DF_Admin_Gender]  DEFAULT ((1)),
	[Email] [nvarchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[CreateDate] [datetime] NULL CONSTRAINT [DF_Admin_CreateDate]  DEFAULT (getdate()),
	[Status] [int] NULL CONSTRAINT [DF_Admin_Status]  DEFAULT ((1)),
	[Avatar] [nvarchar](250) NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Department]    Script Date: 05/09/2017 11:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](250) NULL,
	[Address] [nvarchar](250) NULL,
	[Phone] [varchar](50) NULL,
	[Status] [int] NULL CONSTRAINT [DF_Department_Status]  DEFAULT ((1)),
	[CreateDate] [datetime] NULL CONSTRAINT [DF_Department_CreateDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 05/09/2017 11:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](250) NULL,
	[Address] [nvarchar](250) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[Birthday] [datetime] NULL,
	[Gender] [int] NOT NULL CONSTRAINT [DF_NhanVien_Gender]  DEFAULT ((1)),
	[StartDate] [datetime] NULL CONSTRAINT [DF_NhanVien_StartDate]  DEFAULT (getdate()),
	[EndDate] [datetime] NULL,
	[GraduateShool] [nvarchar](250) NULL,
	[Degree] [int] NULL,
	[Note] [nvarchar](250) NULL,
	[Status] [int] NULL CONSTRAINT [DF_NhanVien_Status]  DEFAULT ((1)),
	[DepartmentID] [bigint] NULL,
	[Avatar] [nvarchar](250) NULL,
	[Salary] [decimal](18, 0) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([ID], [Name], [Username], [Password], [Address], [Gender], [Email], [Phone], [CreateDate], [Status], [Avatar]) VALUES (1, N'admin', N'admin', N'81dc9bdb52d04dc20036dbd8313ed055', NULL, 1, N'admin@gmail.com', NULL, CAST(N'2017-05-08 08:50:43.180' AS DateTime), 1, N'~/Images/user.png')
INSERT [dbo].[Admin] ([ID], [Name], [Username], [Password], [Address], [Gender], [Email], [Phone], [CreateDate], [Status], [Avatar]) VALUES (3, N'admin1234', N'admin123', N'81dc9bdb52d04dc20036dbd8313ed055', NULL, 1, N'admin@gmail.com', N'0123456789', CAST(N'2017-05-09 22:52:15.137' AS DateTime), 1, N'~/Images/Cream-Stylish-Designed-Coat-1jpg.jpg')
SET IDENTITY_INSERT [dbo].[Admin] OFF
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([ID], [Code], [Name], [Address], [Phone], [Status], [CreateDate]) VALUES (1, N'PB1', N'PB1', N'DC1', N'0123456', 1, CAST(N'2017-05-08 10:21:00.543' AS DateTime))
INSERT [dbo].[Department] ([ID], [Code], [Name], [Address], [Phone], [Status], [CreateDate]) VALUES (4, N'PB3', N'Pb3', NULL, NULL, 1, CAST(N'2017-05-08 21:44:29.210' AS DateTime))
INSERT [dbo].[Department] ([ID], [Code], [Name], [Address], [Phone], [Status], [CreateDate]) VALUES (5, N'PB5', N'PB5', N'test', N'0123456', 1, CAST(N'2017-05-08 23:15:18.437' AS DateTime))
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([ID], [Code], [Name], [Address], [Email], [Phone], [Birthday], [Gender], [StartDate], [EndDate], [GraduateShool], [Degree], [Note], [Status], [DepartmentID], [Avatar], [Salary]) VALUES (2, N'NV2', N'NV2', N'test', N'test@gmail.com', N'0123456789', NULL, 1, CAST(N'2017-05-08 21:46:10.770' AS DateTime), NULL, N'Đại học', NULL, NULL, 1, 1, N'~/Images/Cream-Stylish-Designed-Coat-1jpg.jpg', CAST(20000000 AS Decimal(18, 0)))
INSERT [dbo].[Employee] ([ID], [Code], [Name], [Address], [Email], [Phone], [Birthday], [Gender], [StartDate], [EndDate], [GraduateShool], [Degree], [Note], [Status], [DepartmentID], [Avatar], [Salary]) VALUES (3, N'NV4', N'NV8', N'test', N'test@gmail.com', N'012345', NULL, 1, NULL, NULL, N'Đại học', NULL, NULL, 1, 4, N'~/Images/Blueorange-silk-shirt-1.jpg', CAST(20000000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Employee] OFF
