USE [PiedraPapelTijera]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/01/2024 6:35:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jugadores]    Script Date: 10/01/2024 6:35:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jugadores](
	[IdJugador] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[IdPartida] [int] NOT NULL,
 CONSTRAINT [PK_Jugadores] PRIMARY KEY CLUSTERED 
(
	[IdJugador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Partidas]    Script Date: 10/01/2024 6:35:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partidas](
	[IdPartida] [int] IDENTITY(1,1) NOT NULL,
	[Ganador] [int] NULL,
 CONSTRAINT [PK_Partidas] PRIMARY KEY CLUSTERED 
(
	[IdPartida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Turnos]    Script Date: 10/01/2024 6:35:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turnos](
	[IdTurno] [int] IDENTITY(1,1) NOT NULL,
	[IdPartida] [int] NOT NULL,
	[IdJugadorGanador] [int] NULL,
	[FechaRegistro] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Turnos] PRIMARY KEY CLUSTERED 
(
	[IdTurno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240110185750_migracion de modelos', N'8.0.0')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240110192141_foraneas', N'8.0.0')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240110192327_foraneas null', N'8.0.0')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240110220219_turnos', N'8.0.0')
GO
SET IDENTITY_INSERT [dbo].[Jugadores] ON 
GO
INSERT [dbo].[Jugadores] ([IdJugador], [Nombre], [IdPartida]) VALUES (1, N'string', 1)
GO
INSERT [dbo].[Jugadores] ([IdJugador], [Nombre], [IdPartida]) VALUES (2, N'string', 1)
GO
SET IDENTITY_INSERT [dbo].[Jugadores] OFF
GO
SET IDENTITY_INSERT [dbo].[Partidas] ON 
GO
INSERT [dbo].[Partidas] ([IdPartida], [Ganador]) VALUES (1, 2)
GO
SET IDENTITY_INSERT [dbo].[Partidas] OFF
GO
SET IDENTITY_INSERT [dbo].[Turnos] ON 
GO
INSERT [dbo].[Turnos] ([IdTurno], [IdPartida], [IdJugadorGanador], [FechaRegistro]) VALUES (1, 1, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Turnos] ([IdTurno], [IdPartida], [IdJugadorGanador], [FechaRegistro]) VALUES (2, 1, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Turnos] ([IdTurno], [IdPartida], [IdJugadorGanador], [FechaRegistro]) VALUES (4, 1, 2, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Turnos] ([IdTurno], [IdPartida], [IdJugadorGanador], [FechaRegistro]) VALUES (5, 1, 2, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Turnos] ([IdTurno], [IdPartida], [IdJugadorGanador], [FechaRegistro]) VALUES (6, 1, 2, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Turnos] OFF
GO
ALTER TABLE [dbo].[Turnos] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[Jugadores]  WITH CHECK ADD  CONSTRAINT [FK_Jugadores_Partidas_IdPartida] FOREIGN KEY([IdPartida])
REFERENCES [dbo].[Partidas] ([IdPartida])
GO
ALTER TABLE [dbo].[Jugadores] CHECK CONSTRAINT [FK_Jugadores_Partidas_IdPartida]
GO
ALTER TABLE [dbo].[Turnos]  WITH CHECK ADD  CONSTRAINT [FK_Turnos_Jugadores_IdJugadorGanador] FOREIGN KEY([IdJugadorGanador])
REFERENCES [dbo].[Jugadores] ([IdJugador])
GO
ALTER TABLE [dbo].[Turnos] CHECK CONSTRAINT [FK_Turnos_Jugadores_IdJugadorGanador]
GO
ALTER TABLE [dbo].[Turnos]  WITH CHECK ADD  CONSTRAINT [FK_Turnos_Partidas_IdPartida] FOREIGN KEY([IdPartida])
REFERENCES [dbo].[Partidas] ([IdPartida])
GO
ALTER TABLE [dbo].[Turnos] CHECK CONSTRAINT [FK_Turnos_Partidas_IdPartida]
GO
