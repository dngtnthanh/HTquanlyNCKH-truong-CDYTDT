USE [HTquanlyNCKH]
GO
/****** Object:  Table [dbo].[Acount]    Script Date: 26/5/2022 11:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Acount](
	[Username] [nvarchar](50) NOT NULL,
	[Password] [ntext] NULL,
	[Fullname] [ntext] NULL,
	[Permission] [int] NULL,
	[Email] [ntext] NULL,
	[Lock] [int] NULL,
	[Active] [int] NULL,
 CONSTRAINT [PK_Acount] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Articles]    Script Date: 26/5/2022 11:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles](
	[articlesID] [int] IDENTITY(1,1) NOT NULL,
	[atlName] [nvarchar](255) NULL,
	[scientistID] [int] NULL,
	[nationID] [int] NULL,
	[atlSummary] [nvarchar](500) NULL,
	[keyID] [int] NULL,
	[magazineID] [int] NULL,
	[Point] [nvarchar](255) NULL,
	[statusID] [int] NULL,
	[atlLink] [varchar](500) NULL,
	[typeID] [int] NULL,
	[atlPublication] [nvarchar](255) NULL,
	[fieldID] [int] NULL,
	[atlNumber] [nvarchar](255) NULL,
	[atlPageToPage] [nvarchar](255) NULL,
	[atlPublicationDate] [date] NULL,
	[atlCreateDate] [datetime] NULL,
	[atlModifierDate] [datetime] NULL,
	[atlCreateUser] [int] NULL,
	[atlModifierUser] [int] NULL,
 CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED 
(
	[articlesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArtType]    Script Date: 26/5/2022 11:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArtType](
	[typeID] [int] IDENTITY(1,1) NOT NULL,
	[typName] [nvarchar](255) NULL,
	[typDescription] [nvarchar](500) NULL,
	[typCreateDate] [datetime] NULL,
	[typModifierDate] [datetime] NULL,
	[typCreateUser] [int] NULL,
	[typModifierUser] [int] NULL,
 CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED 
(
	[typeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classification]    Script Date: 26/5/2022 11:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classification](
	[classifiID] [int] IDENTITY(1,1) NOT NULL,
	[clsName] [nvarchar](255) NOT NULL,
	[clsDescription] [nvarchar](500) NULL,
	[clsCreateDate] [datetime] NULL,
	[clsModifierDate] [datetime] NULL,
	[clsCreateUser] [int] NULL,
	[clsModifierUser] [int] NULL,
	[clsOrder] [int] NULL,
 CONSTRAINT [PK_Classification] PRIMARY KEY CLUSTERED 
(
	[classifiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Conference]    Script Date: 26/5/2022 11:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conference](
	[conferenceID] [int] IDENTITY(1,1) NOT NULL,
	[cfrName] [nvarchar](255) NULL,
	[cfrDescription] [nvarchar](500) NULL,
	[cfrCreateDate] [datetime] NULL,
	[cfrModifierDate] [datetime] NULL,
	[cfrCreateUser] [int] NULL,
	[cfrModifierUser] [int] NULL,
 CONSTRAINT [PK_Conference] PRIMARY KEY CLUSTERED 
(
	[conferenceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Council]    Script Date: 26/5/2022 11:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Council](
	[councilID] [int] NOT NULL,
	[cniName] [nvarchar](255) NULL,
	[cniChairman] [nvarchar](255) NULL,
	[cniSecretary] [nvarchar](255) NULL,
	[cniReviewer] [nvarchar](500) NULL,
	[cniComment] [nvarchar](500) NULL,
 CONSTRAINT [PK_Council] PRIMARY KEY CLUSTERED 
(
	[councilID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Degree]    Script Date: 26/5/2022 11:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Degree](
	[degreeID] [int] IDENTITY(1,1) NOT NULL,
	[degName] [nvarchar](255) NULL,
	[degDescription] [nvarchar](500) NULL,
	[degCreateDate] [datetime] NULL,
	[degModifierDate] [datetime] NULL,
	[degCreateUser] [int] NULL,
	[degModifierUser] [int] NULL,
 CONSTRAINT [PK_Degree] PRIMARY KEY CLUSTERED 
(
	[degreeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Field]    Script Date: 26/5/2022 11:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Field](
	[fieldID] [int] IDENTITY(1,1) NOT NULL,
	[fieName] [nvarchar](255) NULL,
	[fieDescription] [nvarchar](500) NULL,
	[fieCreateDate] [datetime] NULL,
	[fieModifierDate] [datetime] NULL,
	[fieCreateUser] [int] NULL,
	[fieModifierUser] [int] NULL,
 CONSTRAINT [PK_Field] PRIMARY KEY CLUSTERED 
(
	[fieldID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Foreign]    Script Date: 26/5/2022 11:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Foreign](
	[foreignID] [int] IDENTITY(1,1) NOT NULL,
	[fgnName] [nvarchar](255) NOT NULL,
	[fgnDescription] [nvarchar](500) NULL,
	[fgnCreateDate] [datetime] NULL,
	[fgnModifierDate] [datetime] NULL,
	[fgnCreateUser] [int] NULL,
	[fgnModifierUser] [int] NULL,
 CONSTRAINT [PK_ForeignLanguage] PRIMARY KEY CLUSTERED 
(
	[foreignID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Intro]    Script Date: 26/5/2022 11:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Intro](
	[introID] [int] IDENTITY(1,1) NOT NULL,
	[itdName] [nvarchar](255) NULL,
	[itdSummary] [nvarchar](500) NULL,
	[itdIcon] [text] NULL,
	[itdCreateDate] [datetime] NULL,
	[itdModifierDate] [datetime] NULL,
	[itdCreateUser] [int] NULL,
	[itdModifierUser] [int] NULL,
 CONSTRAINT [PK_Intro] PRIMARY KEY CLUSTERED 
(
	[introID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KeyWord]    Script Date: 26/5/2022 11:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KeyWord](
	[keyID] [int] IDENTITY(1,1) NOT NULL,
	[keyName] [nvarchar](255) NULL,
	[keyDescription] [nvarchar](500) NULL,
	[keyCreateDate] [datetime] NULL,
	[keyModifierDate] [datetime] NULL,
	[keyCreateUser] [int] NULL,
	[keyModifierUser] [int] NULL,
 CONSTRAINT [PK_KeyWord] PRIMARY KEY CLUSTERED 
(
	[keyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nation]    Script Date: 26/5/2022 11:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nation](
	[nationID] [int] IDENTITY(1,1) NOT NULL,
	[natName] [nvarchar](255) NULL,
	[natTwoCode] [char](2) NULL,
	[natThreeCode] [char](3) NULL,
	[natDescription] [nvarchar](500) NULL,
	[natCreateDate] [datetime] NULL,
	[natModifierDate] [datetime] NULL,
	[natCreateUser] [int] NULL,
	[natModifierUser] [int] NULL,
 CONSTRAINT [PK_Nation] PRIMARY KEY CLUSTERED 
(
	[nationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Place]    Script Date: 26/5/2022 11:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Place](
	[placeID] [int] IDENTITY(1,1) NOT NULL,
	[plaName] [nvarchar](255) NULL,
	[plaDescription] [nvarchar](500) NULL,
	[plaCreateDate] [datetime] NULL,
	[plaModifierDate] [datetime] NULL,
	[plaCreateUser] [int] NULL,
	[plaModifierUser] [int] NULL,
 CONSTRAINT [PK_Place] PRIMARY KEY CLUSTERED 
(
	[placeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Scientist]    Script Date: 26/5/2022 11:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Scientist](
	[scientistID] [int] IDENTITY(1,1) NOT NULL,
	[sctFirstName] [nvarchar](255) NULL,
	[sctLastName] [nvarchar](255) NULL,
	[sctFullName] [nvarchar](255) NULL,
	[sctSex] [nvarchar](10) NULL,
	[sctBirthday] [date] NULL,
	[PlaceID] [int] NULL,
	[sctImage] [text] NULL,
	[degreeID] [int] NULL,
	[unitID] [int] NULL,
	[fieldID] [int] NULL,
	[sctWorkingProcess] [nvarchar](500) NULL,
	[sctResult] [nvarchar](500) NULL,
	[foreignID] [int] NULL,
	[sctAddress] [nvarchar](255) NULL,
	[sctPhone] [varchar](15) NULL,
	[sctEmail] [varchar](255) NULL,
	[sctCreateDate] [datetime] NULL,
	[sctModifierDate] [datetime] NULL,
	[sctCreateUser] [int] NULL,
	[sctModifierUser] [int] NULL,
 CONSTRAINT [PK_Scientist] PRIMARY KEY CLUSTERED 
(
	[scientistID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slider]    Script Date: 26/5/2022 11:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slider](
	[sliderID] [int] IDENTITY(1,1) NOT NULL,
	[sldH5] [nvarchar](255) NULL,
	[sldH1] [nvarchar](255) NULL,
	[sldContent] [nvarchar](255) NULL,
	[sldImage] [text] NULL,
	[sldDescription] [nvarchar](500) NULL,
	[sldCreateDate] [datetime] NULL,
	[sldModifierDate] [datetime] NULL,
	[sldCreateUser] [int] NULL,
	[ModifierUser] [int] NULL,
 CONSTRAINT [PK_Slider] PRIMARY KEY CLUSTERED 
(
	[sliderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 26/5/2022 11:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[statusID] [int] IDENTITY(1,1) NOT NULL,
	[stsName] [nvarchar](255) NOT NULL,
	[stsDescription] [nvarchar](500) NULL,
	[stsCreateDate] [datetime] NULL,
	[stsModifierDate] [datetime] NULL,
	[stsCreateUser] [int] NULL,
	[stsModifierUser] [int] NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[statusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Topic]    Script Date: 26/5/2022 11:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topic](
	[topicID] [int] IDENTITY(1,1) NOT NULL,
	[scientistID] [int] NULL,
	[classifiID] [int] NULL,
	[statusID] [int] NULL,
	[acceptsID] [int] NULL,
	[fieldID] [int] NULL,
	[tpcYear] [varchar](4) NULL,
	[tpcName] [nvarchar](255) NULL,
	[tpcSummary] [ntext] NULL,
	[tpcCode] [nvarchar](255) NULL,
	[tpcStartDate] [date] NULL,
	[tpcEndDate] [date] NULL,
	[tpcDateOfAcceptance] [date] NULL,
	[tpcProofFile] [text] NULL,
	[tpcReviewBoard] [nvarchar](500) NULL,
	[tpcCreateData] [datetime] NULL,
	[tpcModifierData] [datetime] NULL,
	[tpcCreateUser] [int] NULL,
	[tpcModifierUser] [int] NULL,
	[tpcDeleteData] [datetime] NULL,
	[tpcDeleteUser] [int] NULL,
	[tpcImage] [text] NULL,
	[tpcAcceptance] [ntext] NULL,
	[tpcFile] [ntext] NULL,
 CONSTRAINT [PK_Topic] PRIMARY KEY CLUSTERED 
(
	[topicID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Unit]    Script Date: 26/5/2022 11:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[unitID] [int] IDENTITY(1,1) NOT NULL,
	[untName] [nvarchar](255) NULL,
	[untDescription] [nvarchar](500) NULL,
	[untCreateDate] [datetime] NULL,
	[untModifierDate] [datetime] NULL,
	[untCreateUser] [int] NULL,
	[untModifierUser] [int] NULL,
 CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED 
(
	[unitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Acount] ([Username], [Password], [Fullname], [Permission], [Email], [Lock], [Active]) VALUES (N'duongthanh', N'123456', N'Dương Tấn Thành', 1, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Articles] ON 

INSERT [dbo].[Articles] ([articlesID], [atlName], [scientistID], [nationID], [atlSummary], [keyID], [magazineID], [Point], [statusID], [atlLink], [typeID], [atlPublication], [fieldID], [atlNumber], [atlPageToPage], [atlPublicationDate], [atlCreateDate], [atlModifierDate], [atlCreateUser], [atlModifierUser]) VALUES (1, N'Deep Convolutional Neural Network for Emotion Recognition of Vietnamese', 11, 179, N'Tạp chí Khoa học Quản lý Giáo dục (Journal of Educational Management Science)', 3, NULL, N'A', NULL, N'https://www.hust.edu.vn/documents/93739/175321/2019-2020+Scopus.pdf/ccd45be6-2e9a-44ea-a474-5939515dae8c', 4, N'Tạp chí Scopus', 14, N'23525', N'1-23', CAST(N'2022-04-07' AS Date), CAST(N'2022-04-07T00:00:00.000' AS DateTime), CAST(N'2022-04-07T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Articles] ([articlesID], [atlName], [scientistID], [nationID], [atlSummary], [keyID], [magazineID], [Point], [statusID], [atlLink], [typeID], [atlPublication], [fieldID], [atlNumber], [atlPageToPage], [atlPublicationDate], [atlCreateDate], [atlModifierDate], [atlCreateUser], [atlModifierUser]) VALUES (4, N'Development of an IgY-based lateral flow immunoassay for detection of fumonisin B in maize', 1, 179, NULL, 4, NULL, N'A', NULL, N'	https://www.hust.edu.vn/documents/93739/175321/2019-2020+Scopus.pdf/ccd45be6-2e9a-44ea-a474-5939515dae8c', 4, N' Tạp chí Scopus, Q4', 14, N'37632', N'5-34', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Articles] ([articlesID], [atlName], [scientistID], [nationID], [atlSummary], [keyID], [magazineID], [Point], [statusID], [atlLink], [typeID], [atlPublication], [fieldID], [atlNumber], [atlPageToPage], [atlPublicationDate], [atlCreateDate], [atlModifierDate], [atlCreateUser], [atlModifierUser]) VALUES (6, N'Applying the change management model of Hellriegel D. a3nd Slocum J. W. to improve teachers’ scientific research abilities at the Center for Foreign Languages, University of Information and Technology', 5, 166, NULL, 2, NULL, N'A', NULL, N'	https://www.hust.edu.vn/documents/93739/175321/2019-2020+Scopus.pdf/ccd45be6-2e9a-44ea-a474-5939515dae8c', 4, N'Tạp chí Scopus', 14, N'23242', N'1-22', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Articles] OFF
GO
SET IDENTITY_INSERT [dbo].[ArtType] ON 

INSERT [dbo].[ArtType] ([typeID], [typName], [typDescription], [typCreateDate], [typModifierDate], [typCreateUser], [typModifierUser]) VALUES (1, N'Công nghệ mới', NULL, CAST(N'2022-03-18T23:23:23.840' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[ArtType] ([typeID], [typName], [typDescription], [typCreateDate], [typModifierDate], [typCreateUser], [typModifierUser]) VALUES (2, N'Chống Covid 19', NULL, CAST(N'2022-03-18T23:23:44.297' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[ArtType] ([typeID], [typName], [typDescription], [typCreateDate], [typModifierDate], [typCreateUser], [typModifierUser]) VALUES (3, N'Khoa học dữ liệu', NULL, CAST(N'2022-03-18T23:32:37.000' AS DateTime), CAST(N'2022-03-18T23:34:46.417' AS DateTime), NULL, NULL)
INSERT [dbo].[ArtType] ([typeID], [typName], [typDescription], [typCreateDate], [typModifierDate], [typCreateUser], [typModifierUser]) VALUES (4, N'Kỹ thuật máy tính', NULL, CAST(N'2022-03-18T23:35:09.670' AS DateTime), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[ArtType] OFF
GO
SET IDENTITY_INSERT [dbo].[Classification] ON 

INSERT [dbo].[Classification] ([classifiID], [clsName], [clsDescription], [clsCreateDate], [clsModifierDate], [clsCreateUser], [clsModifierUser], [clsOrder]) VALUES (12, N'Cấp quốc tế', N'Phân loại các đề tài thuộc cấp quốc tế', CAST(N'2022-03-03T16:26:00.000' AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[Classification] ([classifiID], [clsName], [clsDescription], [clsCreateDate], [clsModifierDate], [clsCreateUser], [clsModifierUser], [clsOrder]) VALUES (22, N'Cấp cơ sở', N'Mô tả cấp cơ sở', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Classification] ([classifiID], [clsName], [clsDescription], [clsCreateDate], [clsModifierDate], [clsCreateUser], [clsModifierUser], [clsOrder]) VALUES (23, N'Cấp bộ', N'Mô tả cấp bộ', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Classification] ([classifiID], [clsName], [clsDescription], [clsCreateDate], [clsModifierDate], [clsCreateUser], [clsModifierUser], [clsOrder]) VALUES (1064, N'Cấp trường', NULL, CAST(N'2022-04-20T21:03:06.000' AS DateTime), CAST(N'2022-05-22T16:34:00.727' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Classification] ([classifiID], [clsName], [clsDescription], [clsCreateDate], [clsModifierDate], [clsCreateUser], [clsModifierUser], [clsOrder]) VALUES (1071, N'Khác', NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Classification] OFF
GO
SET IDENTITY_INSERT [dbo].[Conference] ON 

INSERT [dbo].[Conference] ([conferenceID], [cfrName], [cfrDescription], [cfrCreateDate], [cfrModifierDate], [cfrCreateUser], [cfrModifierUser]) VALUES (4, N'Hội nghị hợp tác quốc tế', NULL, CAST(N'2022-03-19T21:34:56.000' AS DateTime), CAST(N'2022-04-21T18:32:49.517' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Conference] OFF
GO
SET IDENTITY_INSERT [dbo].[Degree] ON 

INSERT [dbo].[Degree] ([degreeID], [degName], [degDescription], [degCreateDate], [degModifierDate], [degCreateUser], [degModifierUser]) VALUES (0, N'Đại học', NULL, CAST(N'2022-03-16T23:59:49.477' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Degree] ([degreeID], [degName], [degDescription], [degCreateDate], [degModifierDate], [degCreateUser], [degModifierUser]) VALUES (1, N'Cao đẳng', NULL, CAST(N'2022-03-17T00:02:27.000' AS DateTime), CAST(N'2022-05-05T10:12:48.610' AS DateTime), NULL, NULL)
INSERT [dbo].[Degree] ([degreeID], [degName], [degDescription], [degCreateDate], [degModifierDate], [degCreateUser], [degModifierUser]) VALUES (3, N'Trung cấp', NULL, CAST(N'2022-03-17T00:03:51.000' AS DateTime), CAST(N'2022-05-05T10:12:51.167' AS DateTime), NULL, NULL)
INSERT [dbo].[Degree] ([degreeID], [degName], [degDescription], [degCreateDate], [degModifierDate], [degCreateUser], [degModifierUser]) VALUES (5, N'Thạc sĩ', NULL, CAST(N'2022-03-22T09:11:00.390' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Degree] ([degreeID], [degName], [degDescription], [degCreateDate], [degModifierDate], [degCreateUser], [degModifierUser]) VALUES (6, N'Tiến sĩ', NULL, CAST(N'2022-03-22T09:11:05.050' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Degree] ([degreeID], [degName], [degDescription], [degCreateDate], [degModifierDate], [degCreateUser], [degModifierUser]) VALUES (9, N'Khác', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Degree] OFF
GO
SET IDENTITY_INSERT [dbo].[Field] ON 

INSERT [dbo].[Field] ([fieldID], [fieName], [fieDescription], [fieCreateDate], [fieModifierDate], [fieCreateUser], [fieModifierUser]) VALUES (12, N'Khoa học máy tính', N'Khoa học Máy tính(Computer science) là ngành nghiên cứu về máy tính và các hệ thống tính toán, quy trình và cách hoạt động của máy tính, cải thiện và nâng cao hiệu suất cho các thuật toán, công nghệ mới, giao tiếp giữa máy tính và con người. Thông qua ngành này giúp các bạn  có thể xây dựng các phẩm phần mềm trí tuệ nhân tạo, máy học...', CAST(N'2022-03-10T22:49:59.840' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Field] ([fieldID], [fieName], [fieDescription], [fieCreateDate], [fieModifierDate], [fieCreateUser], [fieModifierUser]) VALUES (13, N'Kỹ thuật máy tính', N'Ngành Kỹ thuật máy tính (KTMT) là một ngành khá đặc biệt trong nhóm ngành Công nghệ thông tin, là ngành học kết hợp kiến thức cả hai lĩnh vực Điện tử và Công nghệ thông tin', CAST(N'2022-03-10T22:50:46.193' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Field] ([fieldID], [fieName], [fieDescription], [fieCreateDate], [fieModifierDate], [fieCreateUser], [fieModifierUser]) VALUES (14, N'Công nghệ thông tin', NULL, CAST(N'2022-03-11T15:22:43.000' AS DateTime), CAST(N'2022-03-11T23:32:22.710' AS DateTime), NULL, NULL)
INSERT [dbo].[Field] ([fieldID], [fieName], [fieDescription], [fieCreateDate], [fieModifierDate], [fieCreateUser], [fieModifierUser]) VALUES (29, N'Khác', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Field] OFF
GO
SET IDENTITY_INSERT [dbo].[Foreign] ON 

INSERT [dbo].[Foreign] ([foreignID], [fgnName], [fgnDescription], [fgnCreateDate], [fgnModifierDate], [fgnCreateUser], [fgnModifierUser]) VALUES (8, N'Trưởng phòng CNTT', NULL, CAST(N'2022-03-17T16:06:27.000' AS DateTime), CAST(N'2022-05-24T08:09:13.667' AS DateTime), NULL, NULL)
INSERT [dbo].[Foreign] ([foreignID], [fgnName], [fgnDescription], [fgnCreateDate], [fgnModifierDate], [fgnCreateUser], [fgnModifierUser]) VALUES (9, N'Phó phòng CNTT', NULL, CAST(N'2022-03-17T16:06:40.000' AS DateTime), CAST(N'2022-05-24T08:09:19.923' AS DateTime), NULL, NULL)
INSERT [dbo].[Foreign] ([foreignID], [fgnName], [fgnDescription], [fgnCreateDate], [fgnModifierDate], [fgnCreateUser], [fgnModifierUser]) VALUES (10, N'Nhân viên CNTT', NULL, CAST(N'2022-03-17T16:06:46.000' AS DateTime), CAST(N'2022-05-24T08:09:31.063' AS DateTime), NULL, NULL)
INSERT [dbo].[Foreign] ([foreignID], [fgnName], [fgnDescription], [fgnCreateDate], [fgnModifierDate], [fgnCreateUser], [fgnModifierUser]) VALUES (13, N'Khác', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Foreign] OFF
GO
SET IDENTITY_INSERT [dbo].[Intro] ON 

INSERT [dbo].[Intro] ([introID], [itdName], [itdSummary], [itdIcon], [itdCreateDate], [itdModifierDate], [itdCreateUser], [itdModifierUser]) VALUES (1, N'Quản Lý Các Đề Tài Nghiên Cứu Khoa Học', N'Thành viên xét duyệt đề tài, hội đồng, kết quả phân loại đề tài, đánh giá, nghiệm thu', N'<i class="fa fa-3x fa-graduation-cap text-primary mb-4"></i>', CAST(N'2022-03-30T15:03:10.000' AS DateTime), CAST(N'2022-03-30T15:28:56.177' AS DateTime), NULL, NULL)
INSERT [dbo].[Intro] ([introID], [itdName], [itdSummary], [itdIcon], [itdCreateDate], [itdModifierDate], [itdCreateUser], [itdModifierUser]) VALUES (2, N'Kê Khai Các Công Trình Nghiên Cứu', N'Bài báo quốc tế, nghiên cứu khoa học tại cơ sở, bài viết hội thảo', N'<i class="fa fa-3x fa-globe text-primary mb-4"></i>', CAST(N'2022-03-30T15:30:16.810' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Intro] ([introID], [itdName], [itdSummary], [itdIcon], [itdCreateDate], [itdModifierDate], [itdCreateUser], [itdModifierUser]) VALUES (3, N'Quản Lý Đề Tài Nghiên Cứu Khoa Học', N'Thành viên xét duyệt đề tài, hội đồng, kết quả phân loại đề tài, đánh giá, nghiệm thu,..', N'<i class= "fa fa-3x fa-home text-primary mb-4"></i>', CAST(N'2022-03-30T15:30:16.810' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Intro] ([introID], [itdName], [itdSummary], [itdIcon], [itdCreateDate], [itdModifierDate], [itdCreateUser], [itdModifierUser]) VALUES (4, N'Báo Cáo, Thống Kê', N'Lý lịch khoa học, kết quả nghiệm thu, công bố Website', N'<i class="fa fa-3x fa-table  text-primary mb-4"></i>', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Intro] OFF
GO
SET IDENTITY_INSERT [dbo].[KeyWord] ON 

INSERT [dbo].[KeyWord] ([keyID], [keyName], [keyDescription], [keyCreateDate], [keyModifierDate], [keyCreateUser], [keyModifierUser]) VALUES (2, N'Blockchain', NULL, CAST(N'2022-03-18T23:38:27.483' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[KeyWord] ([keyID], [keyName], [keyDescription], [keyCreateDate], [keyModifierDate], [keyCreateUser], [keyModifierUser]) VALUES (3, N'AI', NULL, CAST(N'2022-05-05T10:14:03.843' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[KeyWord] ([keyID], [keyName], [keyDescription], [keyCreateDate], [keyModifierDate], [keyCreateUser], [keyModifierUser]) VALUES (4, N'Network', NULL, CAST(N'2022-05-05T10:14:11.663' AS DateTime), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[KeyWord] OFF
GO
SET IDENTITY_INSERT [dbo].[Nation] ON 

INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (1, N'Afghanistan', N'AF', N'AFG', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (2, N'Aland Islands', N'AX', N'ALA', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (3, N'Albania', N'AL', N'ALB', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (4, N'Algeria', N'DZ', N'DZA', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (5, N'American Samoa', N'AS', N'ASM', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (6, N'Andorra', N'AD', N'AND', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (7, N'Angola', N'AO', N'AGO', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (8, N'Anguilla', N'AI', N'AIA', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (9, N'Antarctica', N'AQ', N'ATA', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (10, N'Antigua and Barbuda', N'AG', N'ATG', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (11, N'Argentina', N'AR', N'ARG', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (12, N'Armenia', N'AM', N'ARM', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (13, N'Aruba', N'AW', N'ABW', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (14, N'Australia', N'AU', N'AUS', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (15, N'Austria', N'AT', N'AUT', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (16, N'Azerbaijan', N'AZ', N'AZE', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (17, N'Bahamas', N'BS', N'BHS', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (18, N'Bahrain', N'BH', N'BHR', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (19, N'Bangladesh', N'BD', N'BGD', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (20, N'Barbados', N'BB', N'BRB', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (21, N'Belarus', N'BY', N'BLR', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (22, N'Belgium', N'BE', N'BEL', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (23, N'Belize', N'BZ', N'BLZ', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (24, N'Benin', N'BJ', N'BEN', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (25, N'Bermuda', N'BM', N'BMU', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (26, N'Bhutan', N'BT', N'BTN', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (27, N'Bolivia', N'BO', N'BOL', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (28, N'Bonaire, Sint Eustatius and Saba', N'BQ', N'BES', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (29, N'Bosnia and Herzegovina', N'BA', N'BIH', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (30, N'Botswana', N'BW', N'BWA', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (31, N'Bouvet Island', N'BV', N'BVT', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (32, N'Brazil', N'BR', N'BRA', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (33, N'British Indian Ocean Territory', N'IO', N'IOT', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (34, N'Brunei', N'BN', N'BRN', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (35, N'Bulgaria', N'BG', N'BGR', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (36, N'Burkina Faso', N'BF', N'BFA', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (37, N'Burundi', N'BI', N'BDI', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (38, N'Cambodia', N'KH', N'KHM', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (39, N'Cameroon', N'CM', N'CMR', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (40, N'Canada', N'CA', N'CAN', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (41, N'Cape Verde', N'CV', N'CPV', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (42, N'Cayman Islands', N'KY', N'CYM', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (43, N'Central African Republic', N'CF', N'CAF', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (44, N'Chad', N'TD', N'TCD', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (45, N'Chile', N'CL', N'CHL', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (46, N'China', N'CN', N'CHN', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (47, N'Christmas Island', N'CX', N'CXR', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (48, N'Cocos (Keeling) Islands', N'CC', N'CCK', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (49, N'Colombia', N'CO', N'COL', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (50, N'Comoros', N'KM', N'COM', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (51, N'Congo', N'CG', N'COG', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (52, N'Cook Islands', N'CK', N'COK', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (53, N'Costa Rica', N'CR', N'CRI', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (54, N'Ivory Coast', N'CI', N'CIV', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (55, N'Croatia', N'HR', N'HRV', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (56, N'Cuba', N'CU', N'CUB', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (57, N'Curacao', N'CW', N'CUW', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (58, N'Cyprus', N'CY', N'CYP', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (59, N'Czech Republic', N'CZ', N'CZE', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (60, N'Democratic Republic of the Congo', N'CD', N'COD', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (61, N'Denmark', N'DK', N'DNK', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (62, N'Djibouti', N'DJ', N'DJI', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (63, N'Dominica', N'DM', N'DMA', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (64, N'Dominican Republic', N'DO', N'DOM', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (65, N'Ecuador', N'EC', N'ECU', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (66, N'Egypt', N'EG', N'EGY', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (67, N'El Salvador', N'SV', N'SLV', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (68, N'Equatorial Guinea', N'GQ', N'GNQ', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (69, N'Eritrea', N'ER', N'ERI', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (70, N'Estonia', N'EE', N'EST', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (71, N'Ethiopia', N'ET', N'ETH', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (72, N'Falkland Islands (Malvinas)', N'FK', N'FLK', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (73, N'Faroe Islands', N'FO', N'FRO', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (74, N'Fiji', N'FJ', N'FJI', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (75, N'Finland', N'FI', N'FIN', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (76, N'France', N'FR', N'FRA', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (77, N'French Guiana', N'GF', N'GUF', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (78, N'French Polynesia', N'PF', N'PYF', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (79, N'French Southern Territories', N'TF', N'ATF', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (80, N'Gabon', N'GA', N'GAB', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (81, N'Gambia', N'GM', N'GMB', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (82, N'Georgia', N'GE', N'GEO', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (83, N'Germany', N'DE', N'DEU', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (84, N'Ghana', N'GH', N'GHA', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (85, N'Gibraltar', N'GI', N'GIB', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (86, N'Greece', N'GR', N'GRC', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (87, N'Greenland', N'GL', N'GRL', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (88, N'Grenada', N'GD', N'GRD', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (89, N'Guadaloupe', N'GP', N'GLP', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (90, N'Guam', N'GU', N'GUM', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (91, N'Guatemala', N'GT', N'GTM', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (92, N'Guernsey', N'GG', N'GGY', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (93, N'Guinea', N'GN', N'GIN', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (94, N'Guinea-Bissau', N'GW', N'GNB', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (95, N'Guyana', N'GY', N'GUY', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (96, N'Haiti', N'HT', N'HTI', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (97, N'Heard Island and McDonald Islands', N'HM', N'HMD', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (98, N'Honduras', N'HN', N'HND', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (99, N'Hong Kong', N'HK', N'HKG', NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (100, N'Hungary', N'HU', N'HUN', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (101, N'Iceland', N'IS', N'ISL', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (102, N'India', N'IN', N'IND', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (103, N'Indonesia', N'ID', N'IDN', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (104, N'Iran', N'IR', N'IRN', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (105, N'Iraq', N'IQ', N'IRQ', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (106, N'Ireland', N'IE', N'IRL', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (107, N'Isle of Man', N'IM', N'IMN', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (108, N'Israel', N'IL', N'ISR', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (109, N'Italy', N'IT', N'ITA', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (110, N'Jamaica', N'JM', N'JAM', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (111, N'Japan', N'JP', N'JPN', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (112, N'Jersey', N'JE', N'JEY', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (113, N'Jordan', N'JO', N'JOR', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (114, N'Kazakhstan', N'KZ', N'KAZ', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (115, N'Kenya', N'KE', N'KEN', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (116, N'Kiribati', N'KI', N'KIR', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (117, N'Kosovo', N'XK', N'---', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (118, N'Kuwait', N'KW', N'KWT', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (119, N'Kyrgyzstan', N'KG', N'KGZ', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (120, N'Laos', N'LA', N'LAO', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (121, N'Latvia', N'LV', N'LVA', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (122, N'Lebanon', N'LB', N'LBN', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (123, N'Lesotho', N'LS', N'LSO', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (124, N'Liberia', N'LR', N'LBR', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (125, N'Libya', N'LY', N'LBY', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (126, N'Liechtenstein', N'LI', N'LIE', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (127, N'Lithuania', N'LT', N'LTU', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (128, N'Luxembourg', N'LU', N'LUX', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (129, N'Macao', N'MO', N'MAC', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (130, N'Macedonia', N'MK', N'MKD', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (131, N'Madagascar', N'MG', N'MDG', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (132, N'Malawi', N'MW', N'MWI', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (133, N'Malaysia', N'MY', N'MYS', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (134, N'Maldives', N'MV', N'MDV', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (135, N'Mali', N'ML', N'MLI', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (136, N'Malta', N'MT', N'MLT', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (137, N'Marshall Islands', N'MH', N'MHL', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (138, N'Martinique', N'MQ', N'MTQ', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (139, N'Mauritania', N'MR', N'MRT', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (140, N'Mauritius', N'MU', N'MUS', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (141, N'Mayotte', N'YT', N'MYT', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (142, N'Mexico', N'MX', N'MEX', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (143, N'Micronesia', N'FM', N'FSM', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (144, N'Moldava', N'MD', N'MDA', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (145, N'Monaco', N'MC', N'MCO', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (146, N'Mongolia', N'MN', N'MNG', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (147, N'Montenegro', N'ME', N'MNE', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (148, N'Montserrat', N'MS', N'MSR', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (149, N'Morocco', N'MA', N'MAR', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (150, N'Mozambique', N'MZ', N'MOZ', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (151, N'Myanmar (Burma)', N'MM', N'MMR', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (152, N'Namibia', N'NA', N'NAM', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (153, N'Nauru', N'NR', N'NRU', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (154, N'Nepal', N'NP', N'NPL', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (155, N'Netherlands', N'NL', N'NLD', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (156, N'New Caledonia', N'NC', N'NCL', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (157, N'New Zealand', N'NZ', N'NZL', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (158, N'Nicaragua', N'NI', N'NIC', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (159, N'Niger', N'NE', N'NER', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (160, N'Nigeria', N'NG', N'NGA', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (161, N'Niue', N'NU', N'NIU', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (162, N'Norfolk Island', N'NF', N'NFK', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (163, N'North Korea', N'KP', N'PRK', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (164, N'Northern Mariana Islands', N'MP', N'MNP', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (165, N'Norway', N'NO', N'NOR', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (166, N'Oman', N'OM', N'OMN', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (167, N'Pakistan', N'PK', N'PAK', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (168, N'Palau', N'PW', N'PLW', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (169, N'Palestine', N'PS', N'PSE', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (170, N'Panama', N'PA', N'PAN', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (171, N'Papua New Guinea', N'PG', N'PNG', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (172, N'Paraguay', N'PY', N'PRY', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (173, N'Peru', N'PE', N'PER', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (174, N'Phillipines', N'PH', N'PHL', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (175, N'Pitcairn', N'PN', N'PCN', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (176, N'Poland', N'PL', N'POL', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (177, N'Portugal', N'PT', N'PRT', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (178, N'Puerto Rico', N'PR', N'PRI', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (179, N'Qatar', N'QA', N'QAT', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (180, N'Reunion', N'RE', N'REU', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (181, N'Romania', N'RO', N'ROU', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (182, N'Russia', N'RU', N'RUS', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (183, N'Rwanda', N'RW', N'RWA', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (184, N'Saint Barthelemy', N'BL', N'BLM', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (185, N'Saint Helena', N'SH', N'SHN', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (186, N'Saint Kitts and Nevis', N'KN', N'KNA', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (187, N'Saint Lucia', N'LC', N'LCA', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (188, N'Saint Martin', N'MF', N'MAF', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (189, N'Saint Pierre and Miquelon', N'PM', N'SPM', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (190, N'Saint Vincent and the Grenadines', N'VC', N'VCT', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (191, N'Samoa', N'WS', N'WSM', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (192, N'San Marino', N'SM', N'SMR', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (193, N'Sao Tome and Principe', N'ST', N'STP', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (194, N'Saudi Arabia', N'SA', N'SAU', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (195, N'Senegal', N'SN', N'SEN', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (196, N'Serbia', N'RS', N'SRB', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (197, N'Seychelles', N'SC', N'SYC', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (198, N'Sierra Leone', N'SL', N'SLE', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (199, N'Singapore', N'SG', N'SGP', NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (200, N'Sint Maarten', N'SX', N'SXM', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (201, N'Slovakia', N'SK', N'SVK', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (202, N'Slovenia', N'SI', N'SVN', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (203, N'Solomon Islands', N'SB', N'SLB', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (204, N'Somalia', N'SO', N'SOM', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (205, N'South Africa', N'ZA', N'ZAF', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (206, N'South Georgia and the South Sandwich Islands', N'GS', N'SGS', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (207, N'South Korea', N'KR', N'KOR', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (208, N'South Sudan', N'SS', N'SSD', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (209, N'Spain', N'ES', N'ESP', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (210, N'Sri Lanka', N'LK', N'LKA', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (211, N'Sudan', N'SD', N'SDN', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (212, N'Suriname', N'SR', N'SUR', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (213, N'Svalbard and Jan Mayen', N'SJ', N'SJM', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (214, N'Swaziland', N'SZ', N'SWZ', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (215, N'Sweden', N'SE', N'SWE', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (216, N'Switzerland', N'CH', N'CHE', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (217, N'Syria', N'SY', N'SYR', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (218, N'Taiwan', N'TW', N'TWN', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (219, N'Tajikistan', N'TJ', N'TJK', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (220, N'Tanzania', N'TZ', N'TZA', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (221, N'Thailand', N'TH', N'THA', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (222, N'Timor-Leste (East Timor)', N'TL', N'TLS', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (223, N'Togo', N'TG', N'TGO', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (224, N'Tokelau', N'TK', N'TKL', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (225, N'Tonga', N'TO', N'TON', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (226, N'Trinidad and Tobago', N'TT', N'TTO', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (227, N'Tunisia', N'TN', N'TUN', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (228, N'Turkey', N'TR', N'TUR', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (229, N'Turkmenistan', N'TM', N'TKM', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (230, N'Turks and Caicos Islands', N'TC', N'TCA', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (231, N'Tuvalu', N'TV', N'TUV', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (232, N'Uganda', N'UG', N'UGA', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (233, N'Ukraine', N'UA', N'UKR', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (234, N'United Arab Emirates', N'AE', N'ARE', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (235, N'United Kingdom', N'GB', N'GBR', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (236, N'United States', N'US', N'USA', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (237, N'United States Minor Outlying Islands', N'UM', N'UMI', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (238, N'Uruguay', N'UY', N'URY', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (239, N'Uzbekistan', N'UZ', N'UZB', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (240, N'Vanuatu', N'VU', N'VUT', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (241, N'Vatican City', N'VA', N'VAT', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (242, N'Venezuela', N'VE', N'VEN', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (243, N'Vietnam', N'VN', N'VNM', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (244, N'Virgin Islands, British', N'VG', N'VGB', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (245, N'Virgin Islands, US', N'VI', N'VIR', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (246, N'Wallis and Futuna', N'WF', N'WLF', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (247, N'Western Sahara', N'EH', N'ESH', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (248, N'Yemen', N'YE', N'YEM', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (249, N'Zambia', N'ZM', N'ZMB', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nation] ([nationID], [natName], [natTwoCode], [natThreeCode], [natDescription], [natCreateDate], [natModifierDate], [natCreateUser], [natModifierUser]) VALUES (250, N'Zimbabwe', N'ZW', N'ZWE', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Nation] OFF
GO
SET IDENTITY_INSERT [dbo].[Place] ON 

INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (2, N'Vĩnh Long', NULL, CAST(N'2022-03-17T16:11:23.323' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (4, N'Đồng Tháp', NULL, CAST(N'2022-04-27T23:45:06.467' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (5, N'An Giang', NULL, CAST(N'2022-04-27T23:45:06.467' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (6, N'Bà Rịa – Vũng Tàu', NULL, CAST(N'2022-04-27T23:45:06.467' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (7, N'Bắc Giang', NULL, CAST(N'2022-04-27T23:45:06.467' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (8, N'Bắc Kạn', NULL, CAST(N'2022-04-27T23:45:06.467' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (9, N'Bạc Liêu', NULL, CAST(N'2022-04-27T23:45:06.467' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (10, N'Bắc Ninh', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (11, N'Bến Tre', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (12, N'Bình Định', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (13, N'Bình Dương', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (14, N'Bình Phước', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (15, N'Bình Thuận', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (16, N'Cà Mau', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (17, N'Cần Thơ', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (18, N'Cao Bằng', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (19, N'Đà Nẵng', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (20, N'Đắk Lắk', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (21, N'Đắk Nông', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (22, N'Điện Biên', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (23, N'Đồng Nai', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (24, N'Gia Lai', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (25, N'Hà Giang', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (26, N'Hà Nam', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (27, N'Hà Nội', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (28, N'Hà Tĩnh', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (29, N'Hải Dương', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (30, N'Hải Phòng', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (31, N'Hậu Giang', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (32, N'Hòa Bình', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (33, N'Hưng Yên', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (34, N'Khánh Hòa', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (35, N'Kiên Giang', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (36, N'Kon Tum', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (37, N'Lai Châu', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (38, N'Lâm Đồng', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (39, N'Lạng Sơn', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (40, N'Lào Cai', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (41, N'Long An', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (42, N'Nam Định', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (43, N'Nghệ An', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (44, N'Ninh Bình', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (45, N'Ninh Thuận', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (46, N'Phú Thọ', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (47, N'Phú Yên', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (48, N'Quảng Bình', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (49, N'Quảng Nam', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (50, N'Quảng Ngãi', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (51, N'Quảng Ninh', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (52, N'Quảng Trị', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (53, N'Sóc Trăng', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (54, N'Sơn La', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (55, N'Tây Ninh', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (56, N'Thái Bình', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (57, N'Thái Nguyên', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (58, N'Thanh Hóa', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (59, N'Thừa Thiên Huế', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (60, N'Tiền Giang', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (61, N'TP Hồ Chí Minh', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (62, N'Trà Vinh', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (63, N'Tuyên Quang', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (64, N'Vĩnh Phúc', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (65, N'Yên Bái', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Place] ([placeID], [plaName], [plaDescription], [plaCreateDate], [plaModifierDate], [plaCreateUser], [plaModifierUser]) VALUES (67, N'Khác', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Place] OFF
GO
SET IDENTITY_INSERT [dbo].[Scientist] ON 

INSERT [dbo].[Scientist] ([scientistID], [sctFirstName], [sctLastName], [sctFullName], [sctSex], [sctBirthday], [PlaceID], [sctImage], [degreeID], [unitID], [fieldID], [sctWorkingProcess], [sctResult], [foreignID], [sctAddress], [sctPhone], [sctEmail], [sctCreateDate], [sctModifierDate], [sctCreateUser], [sctModifierUser]) VALUES (1, N'Dương Tấn', N'Thành', N'Dương Tấn Thành - KH1', N'Nam', CAST(N'2000-08-26' AS Date), 4, N'chup-hinh-the-589x800.jpg', 0, 1, 12, N'Thực tập sinh trường Cao Đẳng Y Tế Đồng Tháp thời gian từ 11/11/2021 đến 10/3/2022', N'Thực hiện tốt nhiệm vụ', 10, N'79, huyện Cao Lãnh, tỉnh ĐT', N'012345678', N'duongthanh6959@gmail.com', CAST(N'2022-04-04T14:40:58.000' AS DateTime), CAST(N'2022-05-26T22:40:40.190' AS DateTime), NULL, NULL)
INSERT [dbo].[Scientist] ([scientistID], [sctFirstName], [sctLastName], [sctFullName], [sctSex], [sctBirthday], [PlaceID], [sctImage], [degreeID], [unitID], [fieldID], [sctWorkingProcess], [sctResult], [foreignID], [sctAddress], [sctPhone], [sctEmail], [sctCreateDate], [sctModifierDate], [sctCreateUser], [sctModifierUser]) VALUES (4, N'Hồ Ngọc Vinh', N'Quang', N'Hồ Ngọc Vinh Quang - KH4', N'Nam', CAST(N'2000-04-28' AS Date), 2, N'team-1.jpg', 6, 2, 12, NULL, NULL, 8, N'Đồng Tháp', NULL, N'vinhquang934@gmail.com', CAST(N'2022-04-04T18:00:52.693' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Scientist] ([scientistID], [sctFirstName], [sctLastName], [sctFullName], [sctSex], [sctBirthday], [PlaceID], [sctImage], [degreeID], [unitID], [fieldID], [sctWorkingProcess], [sctResult], [foreignID], [sctAddress], [sctPhone], [sctEmail], [sctCreateDate], [sctModifierDate], [sctCreateUser], [sctModifierUser]) VALUES (5, N'Lê Thành', N'Nhân', N'Lê Thành Nhân - KH5', N'Nam', CAST(N'2000-05-04' AS Date), 2, N'user1-128x128.jpg', 0, 2, 12, NULL, NULL, 8, N'Đồng Tháp', NULL, N'nhan9334@gmail.com', CAST(N'2022-04-04T23:22:57.187' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Scientist] ([scientistID], [sctFirstName], [sctLastName], [sctFullName], [sctSex], [sctBirthday], [PlaceID], [sctImage], [degreeID], [unitID], [fieldID], [sctWorkingProcess], [sctResult], [foreignID], [sctAddress], [sctPhone], [sctEmail], [sctCreateDate], [sctModifierDate], [sctCreateUser], [sctModifierUser]) VALUES (6, N'Nguyễn Văn ', N'Lâm', N'Nguyễn Văn Lâm - KH6', N'Nam', CAST(N'2022-03-05' AS Date), 2, N'user8-128x128.jpg', 6, 2, 12, NULL, NULL, 8, N'Đồng Tháp', NULL, N'vana2394@gmail.com', CAST(N'2022-04-06T08:40:54.917' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Scientist] ([scientistID], [sctFirstName], [sctLastName], [sctFullName], [sctSex], [sctBirthday], [PlaceID], [sctImage], [degreeID], [unitID], [fieldID], [sctWorkingProcess], [sctResult], [foreignID], [sctAddress], [sctPhone], [sctEmail], [sctCreateDate], [sctModifierDate], [sctCreateUser], [sctModifierUser]) VALUES (7, N'Lê Hồ Hoàng', N'Huy', N'Lê Hồ Hoàng Huy - KH7', N'Nam', CAST(N'2000-09-23' AS Date), 2, N'user1-128x128.jpg', 1, 2, 14, NULL, NULL, 8, N'Đồng Tháp', NULL, N'huy2754@gmail.com', CAST(N'2022-04-06T08:54:20.287' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Scientist] ([scientistID], [sctFirstName], [sctLastName], [sctFullName], [sctSex], [sctBirthday], [PlaceID], [sctImage], [degreeID], [unitID], [fieldID], [sctWorkingProcess], [sctResult], [foreignID], [sctAddress], [sctPhone], [sctEmail], [sctCreateDate], [sctModifierDate], [sctCreateUser], [sctModifierUser]) VALUES (11, N'Dương', N'Siro', N'Dương Siro - KH11', N'Nam', NULL, 4, N'bi-quyet-song-cua-nguoi-thanh-dat.jpg', 6, 2, 14, NULL, NULL, 10, NULL, NULL, NULL, CAST(N'2022-04-06T08:54:20.287' AS DateTime), CAST(N'2022-05-22T15:45:20.677' AS DateTime), NULL, NULL)
INSERT [dbo].[Scientist] ([scientistID], [sctFirstName], [sctLastName], [sctFullName], [sctSex], [sctBirthday], [PlaceID], [sctImage], [degreeID], [unitID], [fieldID], [sctWorkingProcess], [sctResult], [foreignID], [sctAddress], [sctPhone], [sctEmail], [sctCreateDate], [sctModifierDate], [sctCreateUser], [sctModifierUser]) VALUES (12, N'Hồ Quang', N'Thoại', N'Hồ Quang Thoại - KH12', N'Nữ', CAST(N'2022-05-22' AS Date), 4, N'mo-thay-be-gai-0-600x314.jpg', 6, 2, 14, N'ádasd', N'12ed ', 8, N'Đồng Tháp', N'21312', N'duongthanh6959@gmail.com', CAST(N'2022-04-06T08:54:20.287' AS DateTime), CAST(N'2022-05-22T14:01:47.540' AS DateTime), NULL, NULL)
INSERT [dbo].[Scientist] ([scientistID], [sctFirstName], [sctLastName], [sctFullName], [sctSex], [sctBirthday], [PlaceID], [sctImage], [degreeID], [unitID], [fieldID], [sctWorkingProcess], [sctResult], [foreignID], [sctAddress], [sctPhone], [sctEmail], [sctCreateDate], [sctModifierDate], [sctCreateUser], [sctModifierUser]) VALUES (14, N' Nguyễn', N'Hoàng', N'Nguyễn Hoàng - KH14', N'Nam', CAST(N'2022-05-03' AS Date), 4, N'mo-thay-be-gai-0-600x314.jpg', 0, 2, 14, NULL, NULL, 9, NULL, NULL, NULL, CAST(N'2022-04-06T08:54:20.287' AS DateTime), CAST(N'2022-05-22T13:51:34.300' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Scientist] OFF
GO
SET IDENTITY_INSERT [dbo].[Slider] ON 

INSERT [dbo].[Slider] ([sliderID], [sldH5], [sldH1], [sldContent], [sldImage], [sldDescription], [sldCreateDate], [sldModifierDate], [sldCreateUser], [ModifierUser]) VALUES (1, N'TRƯỜNG ĐẠI HỌC ĐỒNG THÁP', N'QUẢN LÝ ĐỀ TÀI NGHIÊN CỨU KHOA HỌC', N'Nhằm đảm bảo thực hiện hoạt động nghiên cứu khoa học đúng quy định và kiểm soát chất lượng nghiên cứu một cách hiệu quả.', N'130669836.jpg', N'2342', CAST(N'2022-03-22T22:03:27.000' AS DateTime), CAST(N'2022-05-26T22:13:10.067' AS DateTime), NULL, NULL)
INSERT [dbo].[Slider] ([sliderID], [sldH5], [sldH1], [sldContent], [sldImage], [sldDescription], [sldCreateDate], [sldModifierDate], [sldCreateUser], [ModifierUser]) VALUES (2, N'TRƯỜNG ĐẠI HỌC ĐỒNG THÁP', N'QUẢN LÝ THÔNG TIN NHÀ KHOA HỌC', N'Nâng cao trách nhiệm của các đơn vị trong việc phối hợp thực hiện quy định về                                quản lý đề tài nghiên cứu khoa học của Trường Cao Đẳng Y Tế Đồng Tháp.', N'carousel-2.jpg', N'5', CAST(N'2022-03-22T22:05:16.000' AS DateTime), CAST(N'2022-05-26T22:12:11.507' AS DateTime), NULL, NULL)
INSERT [dbo].[Slider] ([sliderID], [sldH5], [sldH1], [sldContent], [sldImage], [sldDescription], [sldCreateDate], [sldModifierDate], [sldCreateUser], [ModifierUser]) VALUES (24, N'TRƯỜNG ĐẠI HỌC ĐỒNG THÁP', N'TRUNG TÂM PHÁT TRIỂN PHẦN MỀM', N'Thi công và phát triển phần mềm ứng dụng cho công việc và học tập', N'04-1-1024x683.jpg', NULL, NULL, CAST(N'2022-05-26T22:33:57.587' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Slider] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([statusID], [stsName], [stsDescription], [stsCreateDate], [stsModifierDate], [stsCreateUser], [stsModifierUser]) VALUES (4, N'Đang đề xuất', NULL, CAST(N'2022-03-15T22:51:18.450' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Status] ([statusID], [stsName], [stsDescription], [stsCreateDate], [stsModifierDate], [stsCreateUser], [stsModifierUser]) VALUES (5, N'Đã nghiệm thu', NULL, CAST(N'2022-03-15T22:51:26.737' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Status] ([statusID], [stsName], [stsDescription], [stsCreateDate], [stsModifierDate], [stsCreateUser], [stsModifierUser]) VALUES (7, N'Đang thực hiện', NULL, CAST(N'2022-03-15T22:51:54.967' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Status] ([statusID], [stsName], [stsDescription], [stsCreateDate], [stsModifierDate], [stsCreateUser], [stsModifierUser]) VALUES (8, N'Khác', NULL, CAST(N'2022-03-16T19:35:08.000' AS DateTime), CAST(N'2022-05-22T04:06:37.490' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[Topic] ON 

INSERT [dbo].[Topic] ([topicID], [scientistID], [classifiID], [statusID], [acceptsID], [fieldID], [tpcYear], [tpcName], [tpcSummary], [tpcCode], [tpcStartDate], [tpcEndDate], [tpcDateOfAcceptance], [tpcProofFile], [tpcReviewBoard], [tpcCreateData], [tpcModifierData], [tpcCreateUser], [tpcModifierUser], [tpcDeleteData], [tpcDeleteUser], [tpcImage], [tpcAcceptance], [tpcFile]) VALUES (4, 1, 23, 4, NULL, 12, N'2022', N'Hệ thống quản lý nghiên cứu khoa học', N'Dự án “Hệ thống quản lý nghiên cứu khoa học cho trường Cao Đẳng Y Tế Đồng Tháp” bao gồm các tính năng: - Thông tin nhà khoa học, nhà nghiên cứu (sơ yếu lý lịch, trình độ chuyên môn, quá trình công tác, kết quả nghiên cứu,…) - Kê khai các công nghiên cứu: Bài báo quốc tế, nghiên cứu khoa học tại cơ sở, bài viết hội thảo,… - Quản lý đề tài nghiên cứu khoa học: thông tin thành viên xét duyệt đề tài, hội đồng, kết quả phân loại đề tài, đánh giá, nghiệm thu. - Báo cáo, thống kê: lý lịch khoa học, kết quả nghiệm thu, công bố trên Website,…- In ấn các biểu mẫu, văn bản theo qui định. - Các chức năng bổ sung (được bổ sung trong quá trình thực hiện dự án).', N'00001', CAST(N'2022-03-17' AS Date), NULL, NULL, N'35.pptx', N'Nhóm IT trường Cao Đẳng Y Tế Đồng Tháp', CAST(N'2022-03-16T18:23:12.000' AS DateTime), CAST(N'2022-05-26T09:00:06.670' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Topic] ([topicID], [scientistID], [classifiID], [statusID], [acceptsID], [fieldID], [tpcYear], [tpcName], [tpcSummary], [tpcCode], [tpcStartDate], [tpcEndDate], [tpcDateOfAcceptance], [tpcProofFile], [tpcReviewBoard], [tpcCreateData], [tpcModifierData], [tpcCreateUser], [tpcModifierUser], [tpcDeleteData], [tpcDeleteUser], [tpcImage], [tpcAcceptance], [tpcFile]) VALUES (5, 1, 23, 7, NULL, 14, N'2021', N'Nghiên cứu, rà soát và sửa đổi quy chuẩn kỹ thuật về chất lượng dịch vụ IPTV trên mạng viễn thông công cộng cố định(QCVN 84:2014/BTTTT)', NULL, N'0234', NULL, NULL, NULL, NULL, NULL, CAST(N'2022-03-16T18:28:08.000' AS DateTime), CAST(N'2022-05-26T08:59:33.773' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Topic] ([topicID], [scientistID], [classifiID], [statusID], [acceptsID], [fieldID], [tpcYear], [tpcName], [tpcSummary], [tpcCode], [tpcStartDate], [tpcEndDate], [tpcDateOfAcceptance], [tpcProofFile], [tpcReviewBoard], [tpcCreateData], [tpcModifierData], [tpcCreateUser], [tpcModifierUser], [tpcDeleteData], [tpcDeleteUser], [tpcImage], [tpcAcceptance], [tpcFile]) VALUES (10, 6, 23, 7, NULL, 12, N'2022', N'Xây dựng hệ thống quản lý cơ sở vật chất', NULL, N'14134', CAST(N'2022-03-09' AS Date), NULL, NULL, NULL, NULL, CAST(N'2022-03-19T19:23:25.000' AS DateTime), CAST(N'2022-05-26T08:56:30.803' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Topic] ([topicID], [scientistID], [classifiID], [statusID], [acceptsID], [fieldID], [tpcYear], [tpcName], [tpcSummary], [tpcCode], [tpcStartDate], [tpcEndDate], [tpcDateOfAcceptance], [tpcProofFile], [tpcReviewBoard], [tpcCreateData], [tpcModifierData], [tpcCreateUser], [tpcModifierUser], [tpcDeleteData], [tpcDeleteUser], [tpcImage], [tpcAcceptance], [tpcFile]) VALUES (11, 4, 22, 5, NULL, 14, N'2000', N'	 Nghiên cứu kinh nghiệm của các Quỹ phổ cập viễn thông (USF) trên thế giới và khuyến nghị vận dụng ở Việt Nam', NULL, N'34234', CAST(N'2020-05-21' AS Date), CAST(N'2022-05-27' AS Date), CAST(N'2022-05-18' AS Date), NULL, NULL, CAST(N'2022-03-19T19:38:05.000' AS DateTime), CAST(N'2022-05-26T08:58:49.287' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Topic] ([topicID], [scientistID], [classifiID], [statusID], [acceptsID], [fieldID], [tpcYear], [tpcName], [tpcSummary], [tpcCode], [tpcStartDate], [tpcEndDate], [tpcDateOfAcceptance], [tpcProofFile], [tpcReviewBoard], [tpcCreateData], [tpcModifierData], [tpcCreateUser], [tpcModifierUser], [tpcDeleteData], [tpcDeleteUser], [tpcImage], [tpcAcceptance], [tpcFile]) VALUES (21, 1, 23, 7, NULL, 14, N'2000', N'	 Nghiên cứu, rà soát và sửa đổi quy chuẩn kỹ thuật về pin lithium cho thiết bị cầm tay(QCVN 101:2016/BTTTT)', NULL, N'53345', CAST(N'0001-01-01' AS Date), NULL, NULL, NULL, NULL, CAST(N'2022-04-05T23:04:37.000' AS DateTime), CAST(N'2022-05-26T08:58:33.913' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Topic] ([topicID], [scientistID], [classifiID], [statusID], [acceptsID], [fieldID], [tpcYear], [tpcName], [tpcSummary], [tpcCode], [tpcStartDate], [tpcEndDate], [tpcDateOfAcceptance], [tpcProofFile], [tpcReviewBoard], [tpcCreateData], [tpcModifierData], [tpcCreateUser], [tpcModifierUser], [tpcDeleteData], [tpcDeleteUser], [tpcImage], [tpcAcceptance], [tpcFile]) VALUES (22, 1, 23, 7, NULL, 14, N'2020', N'Nghiên cứu xây dựng giải pháp ảo hóa các thiết bị đặt tại cơ sở của khách hàng (vCPE) ', N'Dự án “Hệ thống quản lý nghiên cứu khoa học cho trường Cao Đẳng Y Tế Đồng Tháp” bao gồm các tính năng: -	Thông tin nhà khoa học, nhà nghiên cứu (sơ yếu lý lịch, trình độ chuyên môn, quá trình công tác, kết quả nghiên cứu,…) -	Kê khai các công nghiên cứu: Bài báo quốc tế, nghiên cứu khoa học tại cơ sở, bài viết hội thảo,… -	Quản lý đề tài nghiên cứu khoa học: thông tin thành viên xét duyệt đề tài, hội đồng, kết quả phân loại đề tài, đánh giá, nghiệm thu. -	Báo cáo, thống kê: lý lịch khoa học, kết quả nghiệm thu, công bố trên Website,… -	In ấn các biểu mẫu, văn bản theo qui định. -	Các chức năng bổ sung (được bổ sung trong quá trình thực hiện dự án).', N'20003', CAST(N'0001-01-01' AS Date), NULL, NULL, NULL, N'Nhóm IT trường Cao Đẳng Y Tế Đồng Tháp', CAST(N'2022-04-08T10:45:31.000' AS DateTime), CAST(N'2022-05-26T08:57:29.687' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Topic] ([topicID], [scientistID], [classifiID], [statusID], [acceptsID], [fieldID], [tpcYear], [tpcName], [tpcSummary], [tpcCode], [tpcStartDate], [tpcEndDate], [tpcDateOfAcceptance], [tpcProofFile], [tpcReviewBoard], [tpcCreateData], [tpcModifierData], [tpcCreateUser], [tpcModifierUser], [tpcDeleteData], [tpcDeleteUser], [tpcImage], [tpcAcceptance], [tpcFile]) VALUES (29, 1, 1064, 5, NULL, 14, N'2022', N'Nghiên cứu, xây dựng mạng truyền thông quang tốc độ cao dựa trên HAP phục vụ khắc phục thảm họa thiên nhiên', NULL, N'12264', CAST(N'0001-01-01' AS Date), NULL, NULL, NULL, NULL, CAST(N'2022-04-20T21:03:35.000' AS DateTime), CAST(N'2022-05-26T08:57:46.427' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Topic] ([topicID], [scientistID], [classifiID], [statusID], [acceptsID], [fieldID], [tpcYear], [tpcName], [tpcSummary], [tpcCode], [tpcStartDate], [tpcEndDate], [tpcDateOfAcceptance], [tpcProofFile], [tpcReviewBoard], [tpcCreateData], [tpcModifierData], [tpcCreateUser], [tpcModifierUser], [tpcDeleteData], [tpcDeleteUser], [tpcImage], [tpcAcceptance], [tpcFile]) VALUES (31, 1, 1064, 4, NULL, 14, N'2022', N'Nghiên cứu chế tạo thử nghiệm thiết bị mạng định nghĩa bằng phần mềm cho các ứng dụng IoT', NULL, N'42355', CAST(N'2022-05-21' AS Date), NULL, NULL, NULL, NULL, CAST(N'2022-04-28T06:29:06.000' AS DateTime), CAST(N'2022-05-26T08:57:59.397' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Topic] ([topicID], [scientistID], [classifiID], [statusID], [acceptsID], [fieldID], [tpcYear], [tpcName], [tpcSummary], [tpcCode], [tpcStartDate], [tpcEndDate], [tpcDateOfAcceptance], [tpcProofFile], [tpcReviewBoard], [tpcCreateData], [tpcModifierData], [tpcCreateUser], [tpcModifierUser], [tpcDeleteData], [tpcDeleteUser], [tpcImage], [tpcAcceptance], [tpcFile]) VALUES (35, 7, 1064, 5, NULL, 14, N'2022', N'Nghiên cứu giao thức định tuyến IPv6 ứng dụng cho mạng không dây công suất thấp', NULL, N'54665', CAST(N'2022-02-23' AS Date), CAST(N'2022-05-24' AS Date), CAST(N'2022-05-25' AS Date), NULL, NULL, CAST(N'2022-05-19T01:50:08.000' AS DateTime), CAST(N'2022-05-26T08:58:13.207' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Topic] OFF
GO
SET IDENTITY_INSERT [dbo].[Unit] ON 

INSERT [dbo].[Unit] ([unitID], [untName], [untDescription], [untCreateDate], [untModifierDate], [untCreateUser], [untModifierUser]) VALUES (1, N'Phòng thông tin và khảo thí', NULL, CAST(N'2022-03-17T16:37:01.000' AS DateTime), CAST(N'2022-03-17T16:37:18.177' AS DateTime), NULL, NULL)
INSERT [dbo].[Unit] ([unitID], [untName], [untDescription], [untCreateDate], [untModifierDate], [untCreateUser], [untModifierUser]) VALUES (2, N'Phòng kế toán', NULL, CAST(N'2022-03-17T16:37:11.233' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Unit] ([unitID], [untName], [untDescription], [untCreateDate], [untModifierDate], [untCreateUser], [untModifierUser]) VALUES (4, N'Khác', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Unit] OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Điểm công trình' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Articles', @level2type=N'COLUMN',@level2name=N'Point'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Đường dẫn đến Website công bố bài báo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Articles', @level2type=N'COLUMN',@level2name=N'atlLink'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nơi xuất bản' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Articles', @level2type=N'COLUMN',@level2name=N'atlPublication'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mã số xếp loại đề tài: vd mã số đề tài là 3 có tên là Cấp cơ sở ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Classification', @level2type=N'COLUMN',@level2name=N'classifiID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Foreign', @level2type=N'COLUMN',@level2name=N'foreignID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Foreign', @level2type=N'COLUMN',@level2name=N'fgnDescription'
GO
