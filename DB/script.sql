CREATE DATABASE NET1711_231_5_K16231InternManagement

USE NET1711_231_5_K16231InternManagement
GO
/****** Object:  Table [dbo].[Company]    Script Date: 5/16/2024 3:24:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[CompanyID] [int] NOT NULL,
	[CompanyName] [nvarchar](100) NULL,
	[CompanyAddress] [nvarchar](255) NULL,
	[CompanyPhone] [varchar](10) NULL,
	[CompanyEmail] [varchar](320) NULL,
	[Description] [nvarchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 5/16/2024 3:24:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] NOT NULL,
	[EmployeeName] [nvarchar](100) NULL,
	[EmployeeAddress] [nvarchar](255) NULL,
	[EmployeePhone] [varchar](10) NULL,
	[EmployeeEmail] [varchar](320) NULL,
	[CompanyID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InternProfile]    Script Date: 5/16/2024 3:24:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InternProfile](
	[InternID] [int] NOT NULL,
	[InternName] [nvarchar](100) NULL,
	[InternAddress] [nvarchar](255) NULL,
	[InternEmail] [varchar](320) NULL,
	[InternPhone] [varchar](10) NULL,
	[University] [nvarchar](50) NULL,
	[Major] [nvarchar](50) NULL,
	[MentorID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[InternID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MentorIntern]    Script Date: 5/16/2024 3:24:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MentorIntern](
	[MentorInternID] [int] NOT NULL,
	[InternID] [int] NULL,
	[MentorID] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MentorInternID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MentorProfile]    Script Date: 5/16/2024 3:24:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MentorProfile](
	[MentorID] [int] NOT NULL,
	[MentorName] [nvarchar](100) NULL,
	[MentorAddress] [nvarchar](255) NULL,
	[MentorPhone] [varchar](10) NULL,
	[MentorEmail] [varchar](320) NULL,
PRIMARY KEY CLUSTERED 
(
	[MentorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProgramIntern]    Script Date: 5/16/2024 3:24:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgramIntern](
	[ProgramInternID] [int] NOT NULL,
	[InternID] [int] NULL,
	[ProgramID] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProgramInternID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProgramTask]    Script Date: 5/16/2024 3:24:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgramTask](
	[ProgramTaskID] [int] NOT NULL,
	[TaskID] [int] NULL,
	[ProgramID] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProgramTaskID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 5/16/2024 3:24:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[StatusID] [int] NOT NULL,
	[StatusName] [nvarchar](1) NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 5/16/2024 3:24:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[TaskID] [int] NOT NULL,
	[MentorID] [int] NULL,
	[InternID] [int] NULL,
	[TaskName] [nvarchar](100) NULL,
	[TaskDecription] [ntext] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[StatusID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TaskID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskManage]    Script Date: 5/16/2024 3:24:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskManage](
	[TaskManageID] [int] NOT NULL,
	[TaskID] [int] NULL,
	[InternID] [int] NULL,
	[MentorID] [int] NULL,
	[StatusID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TaskManageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrainingProgram]    Script Date: 5/16/2024 3:24:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrainingProgram](
	[ProgramID] [int] NOT NULL,
	[ProgramName] [nvarchar](100) NULL,
	[ProgramDecription] [ntext] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProgramID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[InternProfile]  WITH CHECK ADD FOREIGN KEY([MentorID])
REFERENCES [dbo].[MentorProfile] ([MentorID])
GO
ALTER TABLE [dbo].[MentorIntern]  WITH CHECK ADD FOREIGN KEY([InternID])
REFERENCES [dbo].[InternProfile] ([InternID])
GO
ALTER TABLE [dbo].[MentorIntern]  WITH CHECK ADD FOREIGN KEY([MentorID])
REFERENCES [dbo].[MentorProfile] ([MentorID])
GO
ALTER TABLE [dbo].[ProgramIntern]  WITH CHECK ADD FOREIGN KEY([InternID])
REFERENCES [dbo].[InternProfile] ([InternID])
GO
ALTER TABLE [dbo].[ProgramIntern]  WITH CHECK ADD FOREIGN KEY([ProgramID])
REFERENCES [dbo].[TrainingProgram] ([ProgramID])
GO
ALTER TABLE [dbo].[ProgramTask]  WITH CHECK ADD FOREIGN KEY([ProgramID])
REFERENCES [dbo].[TrainingProgram] ([ProgramID])
GO
ALTER TABLE [dbo].[ProgramTask]  WITH CHECK ADD FOREIGN KEY([TaskID])
REFERENCES [dbo].[Task] ([TaskID])
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD FOREIGN KEY([InternID])
REFERENCES [dbo].[InternProfile] ([InternID])
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD FOREIGN KEY([MentorID])
REFERENCES [dbo].[MentorProfile] ([MentorID])
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([StatusID])
GO
ALTER TABLE [dbo].[TaskManage]  WITH CHECK ADD FOREIGN KEY([InternID])
REFERENCES [dbo].[InternProfile] ([InternID])
GO
ALTER TABLE [dbo].[TaskManage]  WITH CHECK ADD FOREIGN KEY([MentorID])
REFERENCES [dbo].[MentorProfile] ([MentorID])
GO
ALTER TABLE [dbo].[TaskManage]  WITH CHECK ADD FOREIGN KEY([StatusID])
REFERENCES [dbo].[Status] ([StatusID])
GO
ALTER TABLE [dbo].[TaskManage]  WITH CHECK ADD FOREIGN KEY([TaskID])
REFERENCES [dbo].[Task] ([TaskID])
GO
