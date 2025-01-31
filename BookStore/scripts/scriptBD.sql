USE [master]
GO
/****** Object:  Database [BookStore]    Script Date: 29.01.2025 14:47:44 ******/
CREATE DATABASE [BookStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookStore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BookStore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BookStore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BookStore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BookStore] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookStore] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BookStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookStore] SET RECOVERY FULL 
GO
ALTER DATABASE [BookStore] SET  MULTI_USER 
GO
ALTER DATABASE [BookStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BookStore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BookStore] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BookStore', N'ON'
GO
ALTER DATABASE [BookStore] SET QUERY_STORE = ON
GO
ALTER DATABASE [BookStore] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BookStore]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 29.01.2025 14:47:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[AuthorID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NULL,
	[Bio] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[AuthorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 29.01.2025 14:47:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[AuthorID] [int] NULL,
	[GenreID] [int] NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[Stock] [int] NOT NULL,
 CONSTRAINT [PK__Books__3DE0C227040B89D0] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 29.01.2025 14:47:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[GenreID] [int] IDENTITY(1,1) NOT NULL,
	[GenreName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[GenreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 29.01.2025 14:47:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[BookID] [int] NOT NULL,
	[OrderDate] [datetime] NULL,
	[DeliveryAddress] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 29.01.2025 14:47:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 29.01.2025 14:47:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NULL,
	[Username] [nvarchar](50) NOT NULL,
	[PasswordHash] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[CreatedAt] [datetime] NULL,
	[RoleID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([AuthorID], [FirstName], [LastName], [Patronymic], [Bio]) VALUES (12, N'Александр', N'Пушкин', N'Сергеевич', N'-')
INSERT [dbo].[Authors] ([AuthorID], [FirstName], [LastName], [Patronymic], [Bio]) VALUES (14, N'-', N'-', N'-', N'-')
INSERT [dbo].[Authors] ([AuthorID], [FirstName], [LastName], [Patronymic], [Bio]) VALUES (20, N'Test', N'Author', N'Testovich', N'Test biography')
INSERT [dbo].[Authors] ([AuthorID], [FirstName], [LastName], [Patronymic], [Bio]) VALUES (21, N'Test', N'Author', N'Testovich', N'Test biography')
SET IDENTITY_INSERT [dbo].[Authors] OFF
GO
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([BookID], [Title], [AuthorID], [GenreID], [Price], [Stock]) VALUES (4, N'сборник стихов', 12, 5, CAST(567.00 AS Decimal(10, 2)), 65)
INSERT [dbo].[Books] ([BookID], [Title], [AuthorID], [GenreID], [Price], [Stock]) VALUES (5, N'2', 12, 5, CAST(564.00 AS Decimal(10, 2)), 6)
INSERT [dbo].[Books] ([BookID], [Title], [AuthorID], [GenreID], [Price], [Stock]) VALUES (7, N'Test Book', 12, 5, CAST(9.99 AS Decimal(10, 2)), 10)
INSERT [dbo].[Books] ([BookID], [Title], [AuthorID], [GenreID], [Price], [Stock]) VALUES (9, N'Test Book', 12, 5, CAST(9.99 AS Decimal(10, 2)), 10)
INSERT [dbo].[Books] ([BookID], [Title], [AuthorID], [GenreID], [Price], [Stock]) VALUES (10, N'Test Book', 12, 5, CAST(9.99 AS Decimal(10, 2)), 10)
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([GenreID], [GenreName]) VALUES (5, N'Стих')
INSERT [dbo].[Genres] ([GenreID], [GenreName]) VALUES (8, N'777')
INSERT [dbo].[Genres] ([GenreID], [GenreName]) VALUES (10, N'Test Genre')
INSERT [dbo].[Genres] ([GenreID], [GenreName]) VALUES (12, N'Test Genre1')
INSERT [dbo].[Genres] ([GenreID], [GenreName]) VALUES (14, N'Test Genre1')
INSERT [dbo].[Genres] ([GenreID], [GenreName]) VALUES (16, N'Test Genre1')
INSERT [dbo].[Genres] ([GenreID], [GenreName]) VALUES (18, N'Test Genre1')
INSERT [dbo].[Genres] ([GenreID], [GenreName]) VALUES (20, N'Test Genre1')
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderID], [UserID], [BookID], [OrderDate], [DeliveryAddress]) VALUES (2, 6, 4, CAST(N'2025-01-25T00:00:00.000' AS DateTime), N'adress')
INSERT [dbo].[Orders] ([OrderID], [UserID], [BookID], [OrderDate], [DeliveryAddress]) VALUES (3, 6, 5, CAST(N'2025-01-25T00:00:00.000' AS DateTime), N'adress2')
INSERT [dbo].[Orders] ([OrderID], [UserID], [BookID], [OrderDate], [DeliveryAddress]) VALUES (4, 8, 5, CAST(N'2025-01-01T00:00:00.000' AS DateTime), N'adress3')
INSERT [dbo].[Orders] ([OrderID], [UserID], [BookID], [OrderDate], [DeliveryAddress]) VALUES (5, 8, 4, CAST(N'2025-01-25T19:39:59.223' AS DateTime), N'testadress')
INSERT [dbo].[Orders] ([OrderID], [UserID], [BookID], [OrderDate], [DeliveryAddress]) VALUES (6, 8, 5, CAST(N'2025-01-25T19:39:59.307' AS DateTime), N'testadress')
INSERT [dbo].[Orders] ([OrderID], [UserID], [BookID], [OrderDate], [DeliveryAddress]) VALUES (7, 8, 4, CAST(N'2025-01-25T19:41:07.673' AS DateTime), N'12')
INSERT [dbo].[Orders] ([OrderID], [UserID], [BookID], [OrderDate], [DeliveryAddress]) VALUES (8, 6, 4, CAST(N'2025-01-25T19:43:48.883' AS DateTime), N'укпуцкпукп')
INSERT [dbo].[Orders] ([OrderID], [UserID], [BookID], [OrderDate], [DeliveryAddress]) VALUES (9, 6, 4, CAST(N'2025-01-28T17:51:33.910' AS DateTime), N'Adres')
INSERT [dbo].[Orders] ([OrderID], [UserID], [BookID], [OrderDate], [DeliveryAddress]) VALUES (10, 6, 5, CAST(N'2025-01-28T17:51:33.970' AS DateTime), N'Adres')
INSERT [dbo].[Orders] ([OrderID], [UserID], [BookID], [OrderDate], [DeliveryAddress]) VALUES (11, 6, 4, CAST(N'2025-01-28T18:06:12.290' AS DateTime), N'Adres')
INSERT [dbo].[Orders] ([OrderID], [UserID], [BookID], [OrderDate], [DeliveryAddress]) VALUES (12, 6, 5, CAST(N'2025-01-28T18:06:12.300' AS DateTime), N'Adres')
INSERT [dbo].[Orders] ([OrderID], [UserID], [BookID], [OrderDate], [DeliveryAddress]) VALUES (13, 6, 4, CAST(N'2025-01-28T18:10:23.130' AS DateTime), N'Adres')
INSERT [dbo].[Orders] ([OrderID], [UserID], [BookID], [OrderDate], [DeliveryAddress]) VALUES (14, 6, 5, CAST(N'2025-01-28T18:10:23.187' AS DateTime), N'Adres')
INSERT [dbo].[Orders] ([OrderID], [UserID], [BookID], [OrderDate], [DeliveryAddress]) VALUES (15, 6, 4, CAST(N'2025-01-28T18:20:37.173' AS DateTime), N'Adres')
INSERT [dbo].[Orders] ([OrderID], [UserID], [BookID], [OrderDate], [DeliveryAddress]) VALUES (16, 6, 5, CAST(N'2025-01-28T18:20:37.183' AS DateTime), N'Adres')
INSERT [dbo].[Orders] ([OrderID], [UserID], [BookID], [OrderDate], [DeliveryAddress]) VALUES (17, 6, 4, CAST(N'2025-01-28T18:22:03.327' AS DateTime), N'Adres')
INSERT [dbo].[Orders] ([OrderID], [UserID], [BookID], [OrderDate], [DeliveryAddress]) VALUES (18, 6, 5, CAST(N'2025-01-28T18:22:03.337' AS DateTime), N'Adres')
INSERT [dbo].[Orders] ([OrderID], [UserID], [BookID], [OrderDate], [DeliveryAddress]) VALUES (19, 6, 4, CAST(N'2025-01-28T18:47:48.310' AS DateTime), N'Adres')
INSERT [dbo].[Orders] ([OrderID], [UserID], [BookID], [OrderDate], [DeliveryAddress]) VALUES (20, 6, 5, CAST(N'2025-01-28T18:47:48.320' AS DateTime), N'Adres')
INSERT [dbo].[Orders] ([OrderID], [UserID], [BookID], [OrderDate], [DeliveryAddress]) VALUES (21, 6, 4, CAST(N'2025-01-28T19:12:21.777' AS DateTime), N'Adres')
INSERT [dbo].[Orders] ([OrderID], [UserID], [BookID], [OrderDate], [DeliveryAddress]) VALUES (22, 6, 5, CAST(N'2025-01-28T19:12:21.787' AS DateTime), N'Adres')
INSERT [dbo].[Orders] ([OrderID], [UserID], [BookID], [OrderDate], [DeliveryAddress]) VALUES (23, 6, 4, CAST(N'2025-01-28T19:20:29.407' AS DateTime), N'Adres')
INSERT [dbo].[Orders] ([OrderID], [UserID], [BookID], [OrderDate], [DeliveryAddress]) VALUES (24, 6, 5, CAST(N'2025-01-28T19:20:29.417' AS DateTime), N'Adres')
INSERT [dbo].[Orders] ([OrderID], [UserID], [BookID], [OrderDate], [DeliveryAddress]) VALUES (25, 6, 4, CAST(N'2025-01-28T19:21:35.073' AS DateTime), N'Adres')
INSERT [dbo].[Orders] ([OrderID], [UserID], [BookID], [OrderDate], [DeliveryAddress]) VALUES (26, 6, 5, CAST(N'2025-01-28T19:21:35.073' AS DateTime), N'Adres')
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRoles] ON 

INSERT [dbo].[UserRoles] ([RoleID], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[UserRoles] ([RoleID], [RoleName]) VALUES (2, N'User')
SET IDENTITY_INSERT [dbo].[UserRoles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Patronymic], [Username], [PasswordHash], [Email], [CreatedAt], [RoleID]) VALUES (3, N'123', N'123', N'123', N'123', N'123', N'123', CAST(N'2025-01-25T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Patronymic], [Username], [PasswordHash], [Email], [CreatedAt], [RoleID]) VALUES (6, N'222', N'222', N'222', N'222', N'222', N'222', CAST(N'2025-01-25T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Patronymic], [Username], [PasswordHash], [Email], [CreatedAt], [RoleID]) VALUES (8, N'uuu', N'uuu', N'uuu', N'uuu', N'uuu', N'uuu', CAST(N'2025-01-25T00:00:00.000' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__536C85E4AC3B65A2]    Script Date: 29.01.2025 14:47:45 ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__A9D1053447D52913]    Script Date: 29.01.2025 14:47:45 ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK__Books__AuthorID__3D5E1FD2] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Authors] ([AuthorID])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK__Books__AuthorID__3D5E1FD2]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK__Books__GenreID__3E52440B] FOREIGN KEY([GenreID])
REFERENCES [dbo].[Genres] ([GenreID])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK__Books__GenreID__3E52440B]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK__Orders__BookID__48CFD27E] FOREIGN KEY([BookID])
REFERENCES [dbo].[Books] ([BookID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK__Orders__BookID__48CFD27E]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[UserRoles] ([RoleID])
GO
USE [master]
GO
ALTER DATABASE [BookStore] SET  READ_WRITE 
GO
