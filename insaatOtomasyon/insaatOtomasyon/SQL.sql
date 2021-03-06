USE [insaatOtomasyon]
GO
/****** Object:  Table [dbo].[Bölge_Gider_Kayit]    Script Date: 29.03.2022 14:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bölge_Gider_Kayit](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Bölge_Adi] [varchar](50) NULL,
	[iscilik] [int] NULL,
	[Elektrik] [int] NULL,
	[Su] [int] NULL,
 CONSTRAINT [PK_Bölge_Gider_Kayit] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bölge_Kayit]    Script Date: 29.03.2022 14:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bölge_Kayit](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Bölge_Adi] [varchar](50) NULL,
	[Adres] [varchar](50) NULL,
	[Aciklama] [varchar](150) NULL,
 CONSTRAINT [PK_Bölge_Kayit] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bölge_Malzeme_Kaydi]    Script Date: 29.03.2022 14:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bölge_Malzeme_Kaydi](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Bölge_Adi] [varchar](50) NULL,
	[Malzeme_Adi] [varchar](50) NULL,
	[Miktar] [int] NULL,
 CONSTRAINT [PK_Bölge_Malzeme_Kaydi] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fatura_Kayit]    Script Date: 29.03.2022 14:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fatura_Kayit](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Firma_Adi] [varchar](50) NULL,
	[Fatura_No] [int] NULL,
	[Fatura_Tarihi] [datetime] NULL,
	[irsaliye_No] [int] NULL,
	[irsaliye_Tarih] [datetime] NULL,
	[Malzeme_Adi] [varchar](50) NULL,
	[Malzeme_Miktari] [int] NULL,
	[Malzeme_Birimi] [varchar](50) NULL,
	[Malzeme_Birim_Fiyat] [int] NULL,
	[Kdv_Orani] [varchar](50) NULL,
	[Kdv_Tutari] [float] NULL,
	[Fatura_Toplami] [float] NULL,
 CONSTRAINT [PK_Fatura_Kayit] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Firma_Kayit]    Script Date: 29.03.2022 14:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Firma_Kayit](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Firma_Adi] [varchar](50) NOT NULL,
	[Kategori] [varchar](50) NULL,
	[Aciklama] [varchar](150) NULL,
 CONSTRAINT [PK_Firma_Kayit] PRIMARY KEY CLUSTERED 
(
	[Firma_Adi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanici_Giris]    Script Date: 29.03.2022 14:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanici_Giris](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Kullanici_Adi] [varchar](50) NULL,
	[Kullanici_Sifre] [int] NULL,
 CONSTRAINT [PK_Kullanici_Giris] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Malzeme_Kayit]    Script Date: 29.03.2022 14:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Malzeme_Kayit](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Malzeme_Adi] [varchar](50) NOT NULL,
	[Malzeme_Birim_Fiyat] [int] NULL,
	[Aciklama] [varchar](50) NULL,
 CONSTRAINT [PK_Malzeme_Kayit] PRIMARY KEY CLUSTERED 
(
	[Malzeme_Adi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personel]    Script Date: 29.03.2022 14:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Personel_Adi] [varchar](50) NULL,
	[Personel_Soyadi] [varchar](50) NULL,
	[Personel_Maas] [int] NULL,
	[Personel_Departman] [varchar](50) NULL,
	[Personel_Sgk_Fiyat] [int] NULL,
 CONSTRAINT [PK_Personel] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bölge_Gider_Kayit] ON 

INSERT [dbo].[Bölge_Gider_Kayit] ([id], [Bölge_Adi], [iscilik], [Elektrik], [Su]) VALUES (4, N'Karadeniz', 444, 6565, 55)
INSERT [dbo].[Bölge_Gider_Kayit] ([id], [Bölge_Adi], [iscilik], [Elektrik], [Su]) VALUES (5, N'Karadeniz', 444, 6565, 55)
INSERT [dbo].[Bölge_Gider_Kayit] ([id], [Bölge_Adi], [iscilik], [Elektrik], [Su]) VALUES (6, N'llkoo', 64646, 6565, 55)
SET IDENTITY_INSERT [dbo].[Bölge_Gider_Kayit] OFF
GO
SET IDENTITY_INSERT [dbo].[Bölge_Kayit] ON 

INSERT [dbo].[Bölge_Kayit] ([id], [Bölge_Adi], [Adres], [Aciklama]) VALUES (1, N'Karadeniz', N'Sofular mahallesi', N'sağdan ikinci kapı')
INSERT [dbo].[Bölge_Kayit] ([id], [Bölge_Adi], [Adres], [Aciklama]) VALUES (2, N'Akdeniz', N'Antalya Konyaaltı Sahil Tarafı', N'Açıklama yok ')
INSERT [dbo].[Bölge_Kayit] ([id], [Bölge_Adi], [Adres], [Aciklama]) VALUES (3, N'Ege', N'asfasf', N'')
INSERT [dbo].[Bölge_Kayit] ([id], [Bölge_Adi], [Adres], [Aciklama]) VALUES (5, N'İç Anadolu', N'adana merkez ', N'merkez cami yanı')
SET IDENTITY_INSERT [dbo].[Bölge_Kayit] OFF
GO
SET IDENTITY_INSERT [dbo].[Bölge_Malzeme_Kaydi] ON 

INSERT [dbo].[Bölge_Malzeme_Kaydi] ([id], [Bölge_Adi], [Malzeme_Adi], [Miktar]) VALUES (3, N'Akdeniz', N'Duvar Kağıdı', 150)
INSERT [dbo].[Bölge_Malzeme_Kaydi] ([id], [Bölge_Adi], [Malzeme_Adi], [Miktar]) VALUES (6, N'Akdeniz', N'ffb41', 4545)
INSERT [dbo].[Bölge_Malzeme_Kaydi] ([id], [Bölge_Adi], [Malzeme_Adi], [Miktar]) VALUES (10, N'Karadeniz', N'asdasf', 22)
INSERT [dbo].[Bölge_Malzeme_Kaydi] ([id], [Bölge_Adi], [Malzeme_Adi], [Miktar]) VALUES (12, N'Ege', N'fgfg', 4)
INSERT [dbo].[Bölge_Malzeme_Kaydi] ([id], [Bölge_Adi], [Malzeme_Adi], [Miktar]) VALUES (13, N'Karadeniz', N'Hello', 99)
SET IDENTITY_INSERT [dbo].[Bölge_Malzeme_Kaydi] OFF
GO
SET IDENTITY_INSERT [dbo].[Fatura_Kayit] ON 

INSERT [dbo].[Fatura_Kayit] ([id], [Firma_Adi], [Fatura_No], [Fatura_Tarihi], [irsaliye_No], [irsaliye_Tarih], [Malzeme_Adi], [Malzeme_Miktari], [Malzeme_Birimi], [Malzeme_Birim_Fiyat], [Kdv_Orani], [Kdv_Tutari], [Fatura_Toplami]) VALUES (2, N'Selcuklu', 2424, CAST(N'2022-03-28T23:56:03.837' AS DateTime), 24242, CAST(N'2022-03-28T23:56:03.830' AS DateTime), N'Tahta', 2, N'TON', 10, N'%18', 3600, 23600)
INSERT [dbo].[Fatura_Kayit] ([id], [Firma_Adi], [Fatura_No], [Fatura_Tarihi], [irsaliye_No], [irsaliye_Tarih], [Malzeme_Adi], [Malzeme_Miktari], [Malzeme_Birimi], [Malzeme_Birim_Fiyat], [Kdv_Orani], [Kdv_Tutari], [Fatura_Toplami]) VALUES (6, N'Hello', 3, CAST(N'2022-03-29T00:23:39.807' AS DateTime), 3, CAST(N'2022-03-29T00:23:39.800' AS DateTime), N'tafff', 3, N'KG', 22, N'%8', 5.28000020980835, 71.279998779296875)
INSERT [dbo].[Fatura_Kayit] ([id], [Firma_Adi], [Fatura_No], [Fatura_Tarihi], [irsaliye_No], [irsaliye_Tarih], [Malzeme_Adi], [Malzeme_Miktari], [Malzeme_Birimi], [Malzeme_Birim_Fiyat], [Kdv_Orani], [Kdv_Tutari], [Fatura_Toplami]) VALUES (7, N'Hello', 3, CAST(N'2022-03-29T00:23:39.000' AS DateTime), 3, CAST(N'2022-03-29T00:23:39.000' AS DateTime), N'tafff', 4, N'KG', 22, N'%18', 15.840000152587891, 103.83999633789063)
INSERT [dbo].[Fatura_Kayit] ([id], [Firma_Adi], [Fatura_No], [Fatura_Tarihi], [irsaliye_No], [irsaliye_Tarih], [Malzeme_Adi], [Malzeme_Miktari], [Malzeme_Birimi], [Malzeme_Birim_Fiyat], [Kdv_Orani], [Kdv_Tutari], [Fatura_Toplami]) VALUES (9, N'Hello', 343, CAST(N'2021-03-29T12:10:29.387' AS DateTime), 53535, CAST(N'2021-03-29T12:10:29.377' AS DateTime), N'tafff', 3, N'KG', 22, N'%18', 11.880000114440918, 77.879997253417969)
INSERT [dbo].[Fatura_Kayit] ([id], [Firma_Adi], [Fatura_No], [Fatura_Tarihi], [irsaliye_No], [irsaliye_Tarih], [Malzeme_Adi], [Malzeme_Miktari], [Malzeme_Birimi], [Malzeme_Birim_Fiyat], [Kdv_Orani], [Kdv_Tutari], [Fatura_Toplami]) VALUES (10, N'Hello', 43242, CAST(N'2022-03-29T14:01:06.177' AS DateTime), 23623, CAST(N'2022-03-29T14:01:06.170' AS DateTime), N'Tahta', 3, N'KG', 10, N'%18', 5.4000000953674316, 35.400001525878906)
SET IDENTITY_INSERT [dbo].[Fatura_Kayit] OFF
GO
SET IDENTITY_INSERT [dbo].[Firma_Kayit] ON 

INSERT [dbo].[Firma_Kayit] ([id], [Firma_Adi], [Kategori], [Aciklama]) VALUES (6, N'dfhdfh', N'srydfh', N'dfgjdfjdfj')
INSERT [dbo].[Firma_Kayit] ([id], [Firma_Adi], [Kategori], [Aciklama]) VALUES (4, N'Hello', N'Guys', N'merhaba')
INSERT [dbo].[Firma_Kayit] ([id], [Firma_Adi], [Kategori], [Aciklama]) VALUES (2, N'Selam', N'Mazot', N'asfasf')
INSERT [dbo].[Firma_Kayit] ([id], [Firma_Adi], [Kategori], [Aciklama]) VALUES (5, N'Selcuklu', N'Taş', N'')
SET IDENTITY_INSERT [dbo].[Firma_Kayit] OFF
GO
SET IDENTITY_INSERT [dbo].[Kullanici_Giris] ON 

INSERT [dbo].[Kullanici_Giris] ([id], [Kullanici_Adi], [Kullanici_Sifre]) VALUES (1, N'insaat', 123456)
SET IDENTITY_INSERT [dbo].[Kullanici_Giris] OFF
GO
SET IDENTITY_INSERT [dbo].[Malzeme_Kayit] ON 

INSERT [dbo].[Malzeme_Kayit] ([id], [Malzeme_Adi], [Malzeme_Birim_Fiyat], [Aciklama]) VALUES (6, N'Hello', 6446, N'knkall')
INSERT [dbo].[Malzeme_Kayit] ([id], [Malzeme_Adi], [Malzeme_Birim_Fiyat], [Aciklama]) VALUES (4, N'tafff', 22, N'dgadsg')
INSERT [dbo].[Malzeme_Kayit] ([id], [Malzeme_Adi], [Malzeme_Birim_Fiyat], [Aciklama]) VALUES (2, N'Tahta', 10, N'x kişisi adına tahsil edilmiştir.')
SET IDENTITY_INSERT [dbo].[Malzeme_Kayit] OFF
GO
SET IDENTITY_INSERT [dbo].[Personel] ON 

INSERT [dbo].[Personel] ([id], [Personel_Adi], [Personel_Soyadi], [Personel_Maas], [Personel_Departman], [Personel_Sgk_Fiyat]) VALUES (1, N'Ferit', N'Parlak', 5550, N'Muhasebeci', 1250)
SET IDENTITY_INSERT [dbo].[Personel] OFF
GO
ALTER TABLE [dbo].[Fatura_Kayit]  WITH CHECK ADD  CONSTRAINT [FK_Fatura_Kayit_Firma_Kayit] FOREIGN KEY([Firma_Adi])
REFERENCES [dbo].[Firma_Kayit] ([Firma_Adi])
GO
ALTER TABLE [dbo].[Fatura_Kayit] CHECK CONSTRAINT [FK_Fatura_Kayit_Firma_Kayit]
GO
ALTER TABLE [dbo].[Fatura_Kayit]  WITH CHECK ADD  CONSTRAINT [FK_Fatura_Kayit_Malzeme_Kayit] FOREIGN KEY([Malzeme_Adi])
REFERENCES [dbo].[Malzeme_Kayit] ([Malzeme_Adi])
GO
ALTER TABLE [dbo].[Fatura_Kayit] CHECK CONSTRAINT [FK_Fatura_Kayit_Malzeme_Kayit]
GO
