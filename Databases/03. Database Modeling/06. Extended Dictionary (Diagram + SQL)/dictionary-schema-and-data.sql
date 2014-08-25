USE [master]
GO
CREATE DATABASE [Dictionary]
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Dictionary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Dictionary] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Dictionary] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Dictionary] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Dictionary] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Dictionary] SET ARITHABORT OFF 
GO
ALTER DATABASE [Dictionary] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Dictionary] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Dictionary] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Dictionary] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Dictionary] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Dictionary] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Dictionary] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Dictionary] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Dictionary] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Dictionary] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Dictionary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Dictionary] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Dictionary] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Dictionary] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Dictionary] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Dictionary] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Dictionary] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Dictionary] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Dictionary] SET  MULTI_USER 
GO
ALTER DATABASE [Dictionary] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Dictionary] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Dictionary] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Dictionary] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Dictionary] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Dictionary]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
    [LanguageId] [int] IDENTITY(1,1) NOT NULL,
    [Language] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
    [LanguageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartOfSpeechTypes](
    [TypeId] [int] IDENTITY(1,1) NOT NULL,
    [Type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PartOfSpeechTypes] PRIMARY KEY CLUSTERED 
(
    [TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words](
    [WordId] [int] IDENTITY(1,1) NOT NULL,
    [Word] [nvarchar](50) NOT NULL,
    [LanguageId] [int] NOT NULL,
    [PartOfSpeechTypeId] [int] NULL,
    [AntonymWordId] [int] NULL,
 CONSTRAINT [PK_Words] PRIMARY KEY CLUSTERED 
(
    [WordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words_Explanations](
    [WordId] [int] NOT NULL,
    [ExplanationLanguageId] [int] NOT NULL,
    [Explanation] [nvarchar](300) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words_Hyponyms](
    [WordId] [int] NOT NULL,
    [HyponymWordId] [int] NOT NULL,
 CONSTRAINT [PK_Words_Hyponyms] PRIMARY KEY CLUSTERED 
(
    [WordId] ASC,
    [HyponymWordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words_Synonyms](
    [WordId] [int] NOT NULL,
    [SynonymWordId] [int] NOT NULL,
 CONSTRAINT [PK_Words_Synonyms] PRIMARY KEY CLUSTERED 
(
    [WordId] ASC,
    [SynonymWordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words_Translations](
    [WordId] [int] NOT NULL,
    [TranslationWordId] [int] NOT NULL,
 CONSTRAINT [PK_Words_Translations] PRIMARY KEY CLUSTERED 
(
    [WordId] ASC,
    [TranslationWordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Languages] ON 

GO
INSERT [dbo].[Languages] ([LanguageId], [Language]) VALUES (1, N'Bulgarian')
GO
INSERT [dbo].[Languages] ([LanguageId], [Language]) VALUES (2, N'English')
GO
INSERT [dbo].[Languages] ([LanguageId], [Language]) VALUES (3, N'Russian')
GO
INSERT [dbo].[Languages] ([LanguageId], [Language]) VALUES (4, N'French')
GO
INSERT [dbo].[Languages] ([LanguageId], [Language]) VALUES (5, N'German')
GO
INSERT [dbo].[Languages] ([LanguageId], [Language]) VALUES (6, N'Italian')
GO
INSERT [dbo].[Languages] ([LanguageId], [Language]) VALUES (7, N'Ukrainian')
GO
INSERT [dbo].[Languages] ([LanguageId], [Language]) VALUES (8, N'British English')
GO
INSERT [dbo].[Languages] ([LanguageId], [Language]) VALUES (9, N'Turkish')
GO
SET IDENTITY_INSERT [dbo].[Languages] OFF
GO
SET IDENTITY_INSERT [dbo].[PartOfSpeechTypes] ON 

GO
INSERT [dbo].[PartOfSpeechTypes] ([TypeId], [Type]) VALUES (1, N'verb')
GO
INSERT [dbo].[PartOfSpeechTypes] ([TypeId], [Type]) VALUES (2, N'noun')
GO
INSERT [dbo].[PartOfSpeechTypes] ([TypeId], [Type]) VALUES (3, N'adjective')
GO
SET IDENTITY_INSERT [dbo].[PartOfSpeechTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Words] ON 

GO
INSERT [dbo].[Words] ([WordId], [Word], [LanguageId], [PartOfSpeechTypeId], [AntonymWordId]) VALUES (1, N'conspire', 2, NULL, NULL)
GO
INSERT [dbo].[Words] ([WordId], [Word], [LanguageId], [PartOfSpeechTypeId], [AntonymWordId]) VALUES (2, N'plan', 2, 2, NULL)
GO
INSERT [dbo].[Words] ([WordId], [Word], [LanguageId], [PartOfSpeechTypeId], [AntonymWordId]) VALUES (3, N'core', 2, NULL, NULL)
GO
INSERT [dbo].[Words] ([WordId], [Word], [LanguageId], [PartOfSpeechTypeId], [AntonymWordId]) VALUES (4, N'center', 2, NULL, NULL)
GO
INSERT [dbo].[Words] ([WordId], [Word], [LanguageId], [PartOfSpeechTypeId], [AntonymWordId]) VALUES (5, N'fume', 2, NULL, NULL)
GO
INSERT [dbo].[Words] ([WordId], [Word], [LanguageId], [PartOfSpeechTypeId], [AntonymWordId]) VALUES (6, N'gas', 2, 2, NULL)
GO
INSERT [dbo].[Words] ([WordId], [Word], [LanguageId], [PartOfSpeechTypeId], [AntonymWordId]) VALUES (7, N'smoke', 2, NULL, NULL)
GO
INSERT [dbo].[Words] ([WordId], [Word], [LanguageId], [PartOfSpeechTypeId], [AntonymWordId]) VALUES (8, N'gaudy', 2, NULL, NULL)
GO
INSERT [dbo].[Words] ([WordId], [Word], [LanguageId], [PartOfSpeechTypeId], [AntonymWordId]) VALUES (9, N'garish', 2, NULL, NULL)
GO
INSERT [dbo].[Words] ([WordId], [Word], [LanguageId], [PartOfSpeechTypeId], [AntonymWordId]) VALUES (10, N'flashy', 2, NULL, NULL)
GO
INSERT [dbo].[Words] ([WordId], [Word], [LanguageId], [PartOfSpeechTypeId], [AntonymWordId]) VALUES (11, N'showy', 2, NULL, NULL)
GO
INSERT [dbo].[Words] ([WordId], [Word], [LanguageId], [PartOfSpeechTypeId], [AntonymWordId]) VALUES (12, N'brook', 2, NULL, NULL)
GO
INSERT [dbo].[Words] ([WordId], [Word], [LanguageId], [PartOfSpeechTypeId], [AntonymWordId]) VALUES (13, N'stream', 2, NULL, NULL)
GO
INSERT [dbo].[Words] ([WordId], [Word], [LanguageId], [PartOfSpeechTypeId], [AntonymWordId]) VALUES (14, N'среда', 1, NULL, NULL)
GO
INSERT [dbo].[Words] ([WordId], [Word], [LanguageId], [PartOfSpeechTypeId], [AntonymWordId]) VALUES (15, N'център', 1, NULL, NULL)
GO
INSERT [dbo].[Words] ([WordId], [Word], [LanguageId], [PartOfSpeechTypeId], [AntonymWordId]) VALUES (16, N'ядро', 1, 2, NULL)
GO
INSERT [dbo].[Words] ([WordId], [Word], [LanguageId], [PartOfSpeechTypeId], [AntonymWordId]) VALUES (17, N'центр', 3, NULL, NULL)
GO
INSERT [dbo].[Words] ([WordId], [Word], [LanguageId], [PartOfSpeechTypeId], [AntonymWordId]) VALUES (18, N'середина', 3, 2, NULL)
GO
INSERT [dbo].[Words] ([WordId], [Word], [LanguageId], [PartOfSpeechTypeId], [AntonymWordId]) VALUES (19, N'ось', 3, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Words] OFF
GO
INSERT [dbo].[Words_Explanations] ([WordId], [ExplanationLanguageId], [Explanation]) VALUES (1, 2, N'to secretly plan with someone to do something that is harmful or illegal')
GO
INSERT [dbo].[Words_Explanations] ([WordId], [ExplanationLanguageId], [Explanation]) VALUES (1, 2, N'to happen in a way that produces bad or unpleasant results')
GO
INSERT [dbo].[Words_Explanations] ([WordId], [ExplanationLanguageId], [Explanation]) VALUES (2, 2, N'a set of actions that have been thought of as a way to do or achieve something')
GO
INSERT [dbo].[Words_Explanations] ([WordId], [ExplanationLanguageId], [Explanation]) VALUES (2, 2, N'something that a person intends to do')
GO
INSERT [dbo].[Words_Explanations] ([WordId], [ExplanationLanguageId], [Explanation]) VALUES (2, 2, N'a detailed agreement for telephone service, medical care, insurance, etc.')
GO
INSERT [dbo].[Words_Explanations] ([WordId], [ExplanationLanguageId], [Explanation]) VALUES (2, 1, N'Предварително обмислен ред за извършване на нещо, срок за изпълнението му. План за действие. Календарен план.')
GO
INSERT [dbo].[Words_Explanations] ([WordId], [ExplanationLanguageId], [Explanation]) VALUES (2, 1, N'Кратко набелязване на съдържанието на нещо. План на изказване. План на роман. План конспект.')
GO
INSERT [dbo].[Words_Explanations] ([WordId], [ExplanationLanguageId], [Explanation]) VALUES (1, 1, N'Организиране на нелегална дейност. Занимавам се с конспирация.')
GO
INSERT [dbo].[Words_Explanations] ([WordId], [ExplanationLanguageId], [Explanation]) VALUES (1, 1, N'Запазване в тайна, прикриване на някаква дейност или проява. За конспирация излязох на разходка.')
GO
INSERT [dbo].[Words_Explanations] ([WordId], [ExplanationLanguageId], [Explanation]) VALUES (15, 1, N'Точка, която е еднаквоотдалечена от всички точки на окръжност или кълбо.')
GO
INSERT [dbo].[Words_Explanations] ([WordId], [ExplanationLanguageId], [Explanation]) VALUES (15, 2, N'the middle point or part of something')
GO
INSERT [dbo].[Words_Synonyms] ([WordId], [SynonymWordId]) VALUES (1, 2)
GO
INSERT [dbo].[Words_Synonyms] ([WordId], [SynonymWordId]) VALUES (3, 4)
GO
INSERT [dbo].[Words_Synonyms] ([WordId], [SynonymWordId]) VALUES (5, 6)
GO
INSERT [dbo].[Words_Synonyms] ([WordId], [SynonymWordId]) VALUES (5, 7)
GO
INSERT [dbo].[Words_Synonyms] ([WordId], [SynonymWordId]) VALUES (6, 7)
GO
INSERT [dbo].[Words_Synonyms] ([WordId], [SynonymWordId]) VALUES (8, 9)
GO
INSERT [dbo].[Words_Synonyms] ([WordId], [SynonymWordId]) VALUES (8, 10)
GO
INSERT [dbo].[Words_Synonyms] ([WordId], [SynonymWordId]) VALUES (8, 11)
GO
INSERT [dbo].[Words_Synonyms] ([WordId], [SynonymWordId]) VALUES (9, 10)
GO
INSERT [dbo].[Words_Synonyms] ([WordId], [SynonymWordId]) VALUES (9, 11)
GO
INSERT [dbo].[Words_Synonyms] ([WordId], [SynonymWordId]) VALUES (10, 11)
GO
INSERT [dbo].[Words_Synonyms] ([WordId], [SynonymWordId]) VALUES (12, 13)
GO
INSERT [dbo].[Words_Synonyms] ([WordId], [SynonymWordId]) VALUES (14, 15)
GO
INSERT [dbo].[Words_Synonyms] ([WordId], [SynonymWordId]) VALUES (14, 16)
GO
INSERT [dbo].[Words_Synonyms] ([WordId], [SynonymWordId]) VALUES (15, 16)
GO
INSERT [dbo].[Words_Synonyms] ([WordId], [SynonymWordId]) VALUES (17, 18)
GO
INSERT [dbo].[Words_Synonyms] ([WordId], [SynonymWordId]) VALUES (17, 19)
GO
INSERT [dbo].[Words_Synonyms] ([WordId], [SynonymWordId]) VALUES (18, 19)
GO
INSERT [dbo].[Words_Translations] ([WordId], [TranslationWordId]) VALUES (3, 14)
GO
INSERT [dbo].[Words_Translations] ([WordId], [TranslationWordId]) VALUES (3, 15)
GO
INSERT [dbo].[Words_Translations] ([WordId], [TranslationWordId]) VALUES (3, 16)
GO
INSERT [dbo].[Words_Translations] ([WordId], [TranslationWordId]) VALUES (4, 14)
GO
INSERT [dbo].[Words_Translations] ([WordId], [TranslationWordId]) VALUES (4, 15)
GO
INSERT [dbo].[Words_Translations] ([WordId], [TranslationWordId]) VALUES (4, 16)
GO
INSERT [dbo].[Words_Translations] ([WordId], [TranslationWordId]) VALUES (14, 17)
GO
INSERT [dbo].[Words_Translations] ([WordId], [TranslationWordId]) VALUES (14, 18)
GO
INSERT [dbo].[Words_Translations] ([WordId], [TranslationWordId]) VALUES (14, 19)
GO
INSERT [dbo].[Words_Translations] ([WordId], [TranslationWordId]) VALUES (15, 17)
GO
INSERT [dbo].[Words_Translations] ([WordId], [TranslationWordId]) VALUES (15, 18)
GO
INSERT [dbo].[Words_Translations] ([WordId], [TranslationWordId]) VALUES (15, 19)
GO
INSERT [dbo].[Words_Translations] ([WordId], [TranslationWordId]) VALUES (16, 17)
GO
INSERT [dbo].[Words_Translations] ([WordId], [TranslationWordId]) VALUES (16, 18)
GO
INSERT [dbo].[Words_Translations] ([WordId], [TranslationWordId]) VALUES (16, 19)
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Languages] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([LanguageId])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Languages]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_PartOfSpeechTypes] FOREIGN KEY([PartOfSpeechTypeId])
REFERENCES [dbo].[PartOfSpeechTypes] ([TypeId])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_PartOfSpeechTypes]
GO
ALTER TABLE [dbo].[Words_Explanations]  WITH CHECK ADD  CONSTRAINT [FK_Words_Explanations_Languages] FOREIGN KEY([ExplanationLanguageId])
REFERENCES [dbo].[Languages] ([LanguageId])
GO
ALTER TABLE [dbo].[Words_Explanations] CHECK CONSTRAINT [FK_Words_Explanations_Languages]
GO
ALTER TABLE [dbo].[Words_Explanations]  WITH CHECK ADD  CONSTRAINT [FK_Words_Explanations_Words] FOREIGN KEY([WordId])
REFERENCES [dbo].[Words] ([WordId])
GO
ALTER TABLE [dbo].[Words_Explanations] CHECK CONSTRAINT [FK_Words_Explanations_Words]
GO
ALTER TABLE [dbo].[Words_Hyponyms]  WITH CHECK ADD  CONSTRAINT [FK_Words_Hyponyms_Words] FOREIGN KEY([WordId])
REFERENCES [dbo].[Words] ([WordId])
GO
ALTER TABLE [dbo].[Words_Hyponyms] CHECK CONSTRAINT [FK_Words_Hyponyms_Words]
GO
ALTER TABLE [dbo].[Words_Hyponyms]  WITH CHECK ADD  CONSTRAINT [FK_Words_Hyponyms_Words1] FOREIGN KEY([HyponymWordId])
REFERENCES [dbo].[Words] ([WordId])
GO
ALTER TABLE [dbo].[Words_Hyponyms] CHECK CONSTRAINT [FK_Words_Hyponyms_Words1]
GO
ALTER TABLE [dbo].[Words_Synonyms]  WITH CHECK ADD  CONSTRAINT [FK_Words_Synonyms_Words_1] FOREIGN KEY([WordId])
REFERENCES [dbo].[Words] ([WordId])
GO
ALTER TABLE [dbo].[Words_Synonyms] CHECK CONSTRAINT [FK_Words_Synonyms_Words_1]
GO
ALTER TABLE [dbo].[Words_Synonyms]  WITH CHECK ADD  CONSTRAINT [FK_Words_Synonyms_Words_2] FOREIGN KEY([SynonymWordId])
REFERENCES [dbo].[Words] ([WordId])
GO
ALTER TABLE [dbo].[Words_Synonyms] CHECK CONSTRAINT [FK_Words_Synonyms_Words_2]
GO
ALTER TABLE [dbo].[Words_Translations]  WITH CHECK ADD  CONSTRAINT [FK_Words_Translations_Words] FOREIGN KEY([WordId])
REFERENCES [dbo].[Words] ([WordId])
GO
ALTER TABLE [dbo].[Words_Translations] CHECK CONSTRAINT [FK_Words_Translations_Words]
GO
ALTER TABLE [dbo].[Words_Translations]  WITH CHECK ADD  CONSTRAINT [FK_Words_Translations_Words_2] FOREIGN KEY([TranslationWordId])
REFERENCES [dbo].[Words] ([WordId])
GO
ALTER TABLE [dbo].[Words_Translations] CHECK CONSTRAINT [FK_Words_Translations_Words_2]
GO
USE [master]
GO
ALTER DATABASE [Dictionary] SET  READ_WRITE 
GO
