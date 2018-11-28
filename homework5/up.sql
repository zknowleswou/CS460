USE [aspnet-ConnectionString-00170b09-317b-498c-9342-e59bcc940760]
GO

/****** Object:  Table [dbo].[Request]    Script Date: 11/5/2018 9:24:57 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Request](
	[RequestId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](250) NOT NULL,
	[LastName] [varchar](250) NOT NULL,
	[PhoneNumber] [varchar](20) NOT NULL,
	[ApartmentName] [varchar](250) NOT NULL,
	[UnitNumber] [varchar](20) NOT NULL,
	[DescriptionOfIssue] [varchar](2000) NOT NULL,
	[EntrancePermission] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Request] PRIMARY KEY CLUSTERED 
(
	[RequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




USE [aspnet-ConnectionString-00170b09-317b-498c-9342-e59bcc940760]
GO

INSERT INTO [dbo].[Request]
           ([FirstName]
           ,[LastName]
           ,[PhoneNumber]
           ,[ApartmentName]
           ,[UnitNumber]
           ,[DescriptionOfIssue]
           ,[EntrancePermission]
		   ,[CreateDate])
     VALUES
           ('Some'
           ,'Guy'
           ,'4423235643'
           ,'Sunberry Shame Shanty'
           ,'105B'
           ,'Everything is broken'
           ,1
		   ,GETDATE())
GO

