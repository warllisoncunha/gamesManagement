IF EXISTS (SELECT * FROM sys.databases WHERE name = 'gamesDb')
BEGIN
	USE gamesDb
	
	/****** Object:  Table [dbo].[BorrowedGame]    Script Date: 24/07/2023 16:38:18 ******/
	SET ANSI_NULLS ON
	
	SET QUOTED_IDENTIFIER ON
	
	CREATE TABLE [dbo].[BorrowedGame](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[FriendId] [int] NOT NULL,
		[GameId] [int] NOT NULL,
		[TakeDate] [datetime] NOT NULL,
		[DevolutionDate] [datetime] NOT NULL,
		[Observation] [varchar](100) NULL,
	 CONSTRAINT [BorrowedGameId] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]
	
	/****** Object:  Table [dbo].[Friend]    Script Date: 24/07/2023 16:38:18 ******/
	SET ANSI_NULLS ON
	SET QUOTED_IDENTIFIER ON
	CREATE TABLE [dbo].[Friend](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Name] [varchar](80) NOT NULL,
		[Description] [varchar](100) NULL,
		[IsActive] [bit] NOT NULL,
	 CONSTRAINT [FriendId] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]
	/****** Object:  Table [dbo].[Game]    Script Date: 24/07/2023 16:38:18 ******/
	SET ANSI_NULLS ON
	SET QUOTED_IDENTIFIER ON
	CREATE TABLE [dbo].[Game](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Name] [varchar](80) NOT NULL,
		[Description] [varchar](100) NULL,
		[IsActive] [bit] NOT NULL,
	 CONSTRAINT [GameId] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]
	ALTER TABLE [dbo].[Friend] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
	ALTER TABLE [dbo].[Game] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
	ALTER TABLE [dbo].[BorrowedGame]  WITH CHECK ADD  CONSTRAINT [FK_BorrowedGame_Friend_FriendId] FOREIGN KEY([FriendId])
	REFERENCES [dbo].[Friend] ([Id])
	ALTER TABLE [dbo].[BorrowedGame] CHECK CONSTRAINT [FK_BorrowedGame_Friend_FriendId]
	ALTER TABLE [dbo].[BorrowedGame]  WITH CHECK ADD  CONSTRAINT [FK_BorrowedGame_Game_GameId] FOREIGN KEY([GameId])
	REFERENCES [dbo].[Game] ([Id])
	ALTER TABLE [dbo].[BorrowedGame] CHECK CONSTRAINT [FK_BorrowedGame_Game_GameId]
END;
GO