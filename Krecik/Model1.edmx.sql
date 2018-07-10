
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/22/2017 11:23:34
-- Generated from EDMX file: C:\Users\mmmat\documents\visual studio 2017\Projects\Krecik\Krecik\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [25532460_1];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Dostawy_szczegolyDostawy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dostawy_szczegolySet] DROP CONSTRAINT [FK_Dostawy_szczegolyDostawy];
GO
IF OBJECT_ID(N'[dbo].[FK_DostawcyDostawy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DostawySet] DROP CONSTRAINT [FK_DostawcyDostawy];
GO
IF OBJECT_ID(N'[dbo].[FK_FakturyDostawy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DostawySet] DROP CONSTRAINT [FK_FakturyDostawy];
GO
IF OBJECT_ID(N'[dbo].[FK_FakturyKlienci_Faktury]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FakturyKlienci] DROP CONSTRAINT [FK_FakturyKlienci_Faktury];
GO
IF OBJECT_ID(N'[dbo].[FK_FakturyKlienci_Klienci]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FakturyKlienci] DROP CONSTRAINT [FK_FakturyKlienci_Klienci];
GO
IF OBJECT_ID(N'[dbo].[FK_KlienciZamowienia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ZamowieniaSet] DROP CONSTRAINT [FK_KlienciZamowienia];
GO
IF OBJECT_ID(N'[dbo].[FK_FakturyZamowienia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ZamowieniaSet] DROP CONSTRAINT [FK_FakturyZamowienia];
GO
IF OBJECT_ID(N'[dbo].[FK_Magazyn_glownyDostawy_szczegoly]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dostawy_szczegolySet] DROP CONSTRAINT [FK_Magazyn_glownyDostawy_szczegoly];
GO
IF OBJECT_ID(N'[dbo].[FK_DostawcyMagazyn_glowny]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Magazyn_glownySet] DROP CONSTRAINT [FK_DostawcyMagazyn_glowny];
GO
IF OBJECT_ID(N'[dbo].[FK_Identyfikatory_produktowMagazyn_glowny]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Magazyn_glownySet] DROP CONSTRAINT [FK_Identyfikatory_produktowMagazyn_glowny];
GO
IF OBJECT_ID(N'[dbo].[FK_Identyfikatory_produktowZamowienia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ZamowieniaSet] DROP CONSTRAINT [FK_Identyfikatory_produktowZamowienia];
GO
IF OBJECT_ID(N'[dbo].[FK_Kategorie_produktowMagazyn_glowny]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Magazyn_glownySet] DROP CONSTRAINT [FK_Kategorie_produktowMagazyn_glowny];
GO
IF OBJECT_ID(N'[dbo].[FK_Kategorie_produktowIdentyfikatory_produktow]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Identyfikatory_produktowSet] DROP CONSTRAINT [FK_Kategorie_produktowIdentyfikatory_produktow];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[DostawySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DostawySet];
GO
IF OBJECT_ID(N'[dbo].[Dostawy_szczegolySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dostawy_szczegolySet];
GO
IF OBJECT_ID(N'[dbo].[Magazyn_glownySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Magazyn_glownySet];
GO
IF OBJECT_ID(N'[dbo].[Kategorie_produktowSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kategorie_produktowSet];
GO
IF OBJECT_ID(N'[dbo].[Identyfikatory_produktowSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Identyfikatory_produktowSet];
GO
IF OBJECT_ID(N'[dbo].[ZamowieniaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ZamowieniaSet];
GO
IF OBJECT_ID(N'[dbo].[DostawcySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DostawcySet];
GO
IF OBJECT_ID(N'[dbo].[KlienciSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KlienciSet];
GO
IF OBJECT_ID(N'[dbo].[FakturySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FakturySet];
GO
IF OBJECT_ID(N'[dbo].[FakturyKlienci]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FakturyKlienci];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'DostawySet'
CREATE TABLE [dbo].[DostawySet] (
    [Id_dostawy] int IDENTITY(1,1) NOT NULL,
    [Id_dostawcy] nvarchar(max)  NOT NULL,
    [Data_odbioru] nvarchar(max)  NOT NULL,
    [Koszt] nvarchar(max)  NOT NULL,
    [Id_faktury] nvarchar(max)  NOT NULL,
    [Dostawcy_Id_dostawcy] int  NOT NULL,
    [Faktury_Id_faktury] int  NOT NULL
);
GO

-- Creating table 'Dostawy_szczegolySet'
CREATE TABLE [dbo].[Dostawy_szczegolySet] (
    [Id_dostawy] int IDENTITY(1,1) NOT NULL,
    [Etykieta_produktu] nvarchar(max)  NOT NULL,
    [Cena_pozycji] nvarchar(max)  NOT NULL,
    [Ilosc_dostarczonych] nvarchar(max)  NOT NULL,
    [Dostawy_Id_dostawy] int  NOT NULL,
    [Magazyn_glowny_Etykieta_produktu] int  NOT NULL
);
GO

-- Creating table 'Magazyn_glownySet'
CREATE TABLE [dbo].[Magazyn_glownySet] (
    [Etykieta_produktu] int IDENTITY(1,1) NOT NULL,
    [Id_dostawcy] nvarchar(max)  NOT NULL,
    [Ilosc_na_stanie] nvarchar(max)  NOT NULL,
    [Id_kategorii] nvarchar(max)  NOT NULL,
    [Id_produktu] nvarchar(max)  NOT NULL,
    [Dostawcy_Id_dostawcy] int  NOT NULL,
    [Identyfikatory_produktow_Id_produktu] int  NOT NULL,
    [Kategorie_produktow_Id_kategorii] int  NOT NULL
);
GO

-- Creating table 'Kategorie_produktowSet'
CREATE TABLE [dbo].[Kategorie_produktowSet] (
    [Id_kategorii] int IDENTITY(1,1) NOT NULL,
    [Kategoria_nadrzedna] nvarchar(max)  NOT NULL,
    [Opis_kategorii] nvarchar(max)  NOT NULL,
    [Nazwa_cechy] nvarchar(max)  NOT NULL,
    [Wartość_cechy] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Identyfikatory_produktowSet'
CREATE TABLE [dbo].[Identyfikatory_produktowSet] (
    [Id_produktu] int IDENTITY(1,1) NOT NULL,
    [Id_kategorii] nvarchar(max)  NOT NULL,
    [Nazwa_produktu] nvarchar(max)  NOT NULL,
    [Wartosc_jednostkowa] nvarchar(max)  NOT NULL,
    [Wartosc_cechy] nvarchar(max)  NOT NULL,
    [Kategorie_produktow_Id_kategorii] int  NOT NULL
);
GO

-- Creating table 'ZamowieniaSet'
CREATE TABLE [dbo].[ZamowieniaSet] (
    [Id_zamowienia] int IDENTITY(1,1) NOT NULL,
    [Id_klienta] nvarchar(max)  NOT NULL,
    [Id_produktu] nvarchar(max)  NOT NULL,
    [Etykieta_produktu] nvarchar(max)  NOT NULL,
    [Ilosc] nvarchar(max)  NOT NULL,
    [Kwota] nvarchar(max)  NOT NULL,
    [Id_faktury] nvarchar(max)  NOT NULL,
    [Data_zlozenia_zaowienia] nvarchar(max)  NOT NULL,
    [Data_zrealizowania_zamowienia] nvarchar(max)  NOT NULL,
    [Klienci_Id_klienta] int  NOT NULL,
    [Faktury_Id_faktury] int  NOT NULL,
    [Identyfikatory_produktow_Id_produktu] int  NOT NULL
);
GO

-- Creating table 'DostawcySet'
CREATE TABLE [dbo].[DostawcySet] (
    [Id_dostawcy] int IDENTITY(1,1) NOT NULL,
    [Nazwa_pelna] nvarchar(max)  NOT NULL,
    [Nazwa_skrocona] nvarchar(max)  NOT NULL,
    [Imie] nvarchar(max)  NOT NULL,
    [Nazwisko] nvarchar(max)  NOT NULL,
    [Adres] nvarchar(max)  NOT NULL,
    [NIP] nvarchar(max)  NOT NULL,
    [Uwagi] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'KlienciSet'
CREATE TABLE [dbo].[KlienciSet] (
    [Id_klienta] int IDENTITY(1,1) NOT NULL,
    [Nazwisko] nvarchar(max)  NOT NULL,
    [Imie] nvarchar(max)  NOT NULL,
    [Nazwa_firmy] nvarchar(max)  NOT NULL,
    [Kod_pocztowy] nvarchar(max)  NOT NULL,
    [Miasto] nvarchar(max)  NOT NULL,
    [Ulica] nvarchar(max)  NOT NULL,
    [Nr_domu] nvarchar(max)  NOT NULL,
    [Nr_lokalu] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'FakturySet'
CREATE TABLE [dbo].[FakturySet] (
    [Id_faktury] int IDENTITY(1,1) NOT NULL,
    [Id_klienta] nvarchar(max)  NOT NULL,
    [Sposob_platnosci] nvarchar(max)  NOT NULL,
    [Termin_platnosci] nvarchar(max)  NOT NULL,
    [Data_wystawienia] nvarchar(max)  NOT NULL,
    [Status_faktury] nvarchar(max)  NOT NULL,
    [Typ_faktury] nvarchar(max)  NOT NULL,
    [Rozdaj_faktury] nvarchar(max)  NOT NULL,
    [Rabat] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'FakturyKlienci'
CREATE TABLE [dbo].[FakturyKlienci] (
    [Faktury_Id_faktury] int  NOT NULL,
    [Klienci_Id_klienta] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id_dostawy] in table 'DostawySet'
ALTER TABLE [dbo].[DostawySet]
ADD CONSTRAINT [PK_DostawySet]
    PRIMARY KEY CLUSTERED ([Id_dostawy] ASC);
GO

-- Creating primary key on [Id_dostawy] in table 'Dostawy_szczegolySet'
ALTER TABLE [dbo].[Dostawy_szczegolySet]
ADD CONSTRAINT [PK_Dostawy_szczegolySet]
    PRIMARY KEY CLUSTERED ([Id_dostawy] ASC);
GO

-- Creating primary key on [Etykieta_produktu] in table 'Magazyn_glownySet'
ALTER TABLE [dbo].[Magazyn_glownySet]
ADD CONSTRAINT [PK_Magazyn_glownySet]
    PRIMARY KEY CLUSTERED ([Etykieta_produktu] ASC);
GO

-- Creating primary key on [Id_kategorii] in table 'Kategorie_produktowSet'
ALTER TABLE [dbo].[Kategorie_produktowSet]
ADD CONSTRAINT [PK_Kategorie_produktowSet]
    PRIMARY KEY CLUSTERED ([Id_kategorii] ASC);
GO

-- Creating primary key on [Id_produktu] in table 'Identyfikatory_produktowSet'
ALTER TABLE [dbo].[Identyfikatory_produktowSet]
ADD CONSTRAINT [PK_Identyfikatory_produktowSet]
    PRIMARY KEY CLUSTERED ([Id_produktu] ASC);
GO

-- Creating primary key on [Id_zamowienia] in table 'ZamowieniaSet'
ALTER TABLE [dbo].[ZamowieniaSet]
ADD CONSTRAINT [PK_ZamowieniaSet]
    PRIMARY KEY CLUSTERED ([Id_zamowienia] ASC);
GO

-- Creating primary key on [Id_dostawcy] in table 'DostawcySet'
ALTER TABLE [dbo].[DostawcySet]
ADD CONSTRAINT [PK_DostawcySet]
    PRIMARY KEY CLUSTERED ([Id_dostawcy] ASC);
GO

-- Creating primary key on [Id_klienta] in table 'KlienciSet'
ALTER TABLE [dbo].[KlienciSet]
ADD CONSTRAINT [PK_KlienciSet]
    PRIMARY KEY CLUSTERED ([Id_klienta] ASC);
GO

-- Creating primary key on [Id_faktury] in table 'FakturySet'
ALTER TABLE [dbo].[FakturySet]
ADD CONSTRAINT [PK_FakturySet]
    PRIMARY KEY CLUSTERED ([Id_faktury] ASC);
GO

-- Creating primary key on [Faktury_Id_faktury], [Klienci_Id_klienta] in table 'FakturyKlienci'
ALTER TABLE [dbo].[FakturyKlienci]
ADD CONSTRAINT [PK_FakturyKlienci]
    PRIMARY KEY CLUSTERED ([Faktury_Id_faktury], [Klienci_Id_klienta] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Dostawy_Id_dostawy] in table 'Dostawy_szczegolySet'
ALTER TABLE [dbo].[Dostawy_szczegolySet]
ADD CONSTRAINT [FK_Dostawy_szczegolyDostawy]
    FOREIGN KEY ([Dostawy_Id_dostawy])
    REFERENCES [dbo].[DostawySet]
        ([Id_dostawy])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Dostawy_szczegolyDostawy'
CREATE INDEX [IX_FK_Dostawy_szczegolyDostawy]
ON [dbo].[Dostawy_szczegolySet]
    ([Dostawy_Id_dostawy]);
GO

-- Creating foreign key on [Dostawcy_Id_dostawcy] in table 'DostawySet'
ALTER TABLE [dbo].[DostawySet]
ADD CONSTRAINT [FK_DostawcyDostawy]
    FOREIGN KEY ([Dostawcy_Id_dostawcy])
    REFERENCES [dbo].[DostawcySet]
        ([Id_dostawcy])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DostawcyDostawy'
CREATE INDEX [IX_FK_DostawcyDostawy]
ON [dbo].[DostawySet]
    ([Dostawcy_Id_dostawcy]);
GO

-- Creating foreign key on [Faktury_Id_faktury] in table 'DostawySet'
ALTER TABLE [dbo].[DostawySet]
ADD CONSTRAINT [FK_FakturyDostawy]
    FOREIGN KEY ([Faktury_Id_faktury])
    REFERENCES [dbo].[FakturySet]
        ([Id_faktury])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FakturyDostawy'
CREATE INDEX [IX_FK_FakturyDostawy]
ON [dbo].[DostawySet]
    ([Faktury_Id_faktury]);
GO

-- Creating foreign key on [Faktury_Id_faktury] in table 'FakturyKlienci'
ALTER TABLE [dbo].[FakturyKlienci]
ADD CONSTRAINT [FK_FakturyKlienci_Faktury]
    FOREIGN KEY ([Faktury_Id_faktury])
    REFERENCES [dbo].[FakturySet]
        ([Id_faktury])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Klienci_Id_klienta] in table 'FakturyKlienci'
ALTER TABLE [dbo].[FakturyKlienci]
ADD CONSTRAINT [FK_FakturyKlienci_Klienci]
    FOREIGN KEY ([Klienci_Id_klienta])
    REFERENCES [dbo].[KlienciSet]
        ([Id_klienta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FakturyKlienci_Klienci'
CREATE INDEX [IX_FK_FakturyKlienci_Klienci]
ON [dbo].[FakturyKlienci]
    ([Klienci_Id_klienta]);
GO

-- Creating foreign key on [Klienci_Id_klienta] in table 'ZamowieniaSet'
ALTER TABLE [dbo].[ZamowieniaSet]
ADD CONSTRAINT [FK_KlienciZamowienia]
    FOREIGN KEY ([Klienci_Id_klienta])
    REFERENCES [dbo].[KlienciSet]
        ([Id_klienta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KlienciZamowienia'
CREATE INDEX [IX_FK_KlienciZamowienia]
ON [dbo].[ZamowieniaSet]
    ([Klienci_Id_klienta]);
GO

-- Creating foreign key on [Faktury_Id_faktury] in table 'ZamowieniaSet'
ALTER TABLE [dbo].[ZamowieniaSet]
ADD CONSTRAINT [FK_FakturyZamowienia]
    FOREIGN KEY ([Faktury_Id_faktury])
    REFERENCES [dbo].[FakturySet]
        ([Id_faktury])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FakturyZamowienia'
CREATE INDEX [IX_FK_FakturyZamowienia]
ON [dbo].[ZamowieniaSet]
    ([Faktury_Id_faktury]);
GO

-- Creating foreign key on [Magazyn_glowny_Etykieta_produktu] in table 'Dostawy_szczegolySet'
ALTER TABLE [dbo].[Dostawy_szczegolySet]
ADD CONSTRAINT [FK_Magazyn_glownyDostawy_szczegoly]
    FOREIGN KEY ([Magazyn_glowny_Etykieta_produktu])
    REFERENCES [dbo].[Magazyn_glownySet]
        ([Etykieta_produktu])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Magazyn_glownyDostawy_szczegoly'
CREATE INDEX [IX_FK_Magazyn_glownyDostawy_szczegoly]
ON [dbo].[Dostawy_szczegolySet]
    ([Magazyn_glowny_Etykieta_produktu]);
GO

-- Creating foreign key on [Dostawcy_Id_dostawcy] in table 'Magazyn_glownySet'
ALTER TABLE [dbo].[Magazyn_glownySet]
ADD CONSTRAINT [FK_DostawcyMagazyn_glowny]
    FOREIGN KEY ([Dostawcy_Id_dostawcy])
    REFERENCES [dbo].[DostawcySet]
        ([Id_dostawcy])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DostawcyMagazyn_glowny'
CREATE INDEX [IX_FK_DostawcyMagazyn_glowny]
ON [dbo].[Magazyn_glownySet]
    ([Dostawcy_Id_dostawcy]);
GO

-- Creating foreign key on [Identyfikatory_produktow_Id_produktu] in table 'Magazyn_glownySet'
ALTER TABLE [dbo].[Magazyn_glownySet]
ADD CONSTRAINT [FK_Identyfikatory_produktowMagazyn_glowny]
    FOREIGN KEY ([Identyfikatory_produktow_Id_produktu])
    REFERENCES [dbo].[Identyfikatory_produktowSet]
        ([Id_produktu])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Identyfikatory_produktowMagazyn_glowny'
CREATE INDEX [IX_FK_Identyfikatory_produktowMagazyn_glowny]
ON [dbo].[Magazyn_glownySet]
    ([Identyfikatory_produktow_Id_produktu]);
GO

-- Creating foreign key on [Identyfikatory_produktow_Id_produktu] in table 'ZamowieniaSet'
ALTER TABLE [dbo].[ZamowieniaSet]
ADD CONSTRAINT [FK_Identyfikatory_produktowZamowienia]
    FOREIGN KEY ([Identyfikatory_produktow_Id_produktu])
    REFERENCES [dbo].[Identyfikatory_produktowSet]
        ([Id_produktu])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Identyfikatory_produktowZamowienia'
CREATE INDEX [IX_FK_Identyfikatory_produktowZamowienia]
ON [dbo].[ZamowieniaSet]
    ([Identyfikatory_produktow_Id_produktu]);
GO

-- Creating foreign key on [Kategorie_produktow_Id_kategorii] in table 'Magazyn_glownySet'
ALTER TABLE [dbo].[Magazyn_glownySet]
ADD CONSTRAINT [FK_Kategorie_produktowMagazyn_glowny]
    FOREIGN KEY ([Kategorie_produktow_Id_kategorii])
    REFERENCES [dbo].[Kategorie_produktowSet]
        ([Id_kategorii])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Kategorie_produktowMagazyn_glowny'
CREATE INDEX [IX_FK_Kategorie_produktowMagazyn_glowny]
ON [dbo].[Magazyn_glownySet]
    ([Kategorie_produktow_Id_kategorii]);
GO

-- Creating foreign key on [Kategorie_produktow_Id_kategorii] in table 'Identyfikatory_produktowSet'
ALTER TABLE [dbo].[Identyfikatory_produktowSet]
ADD CONSTRAINT [FK_Kategorie_produktowIdentyfikatory_produktow]
    FOREIGN KEY ([Kategorie_produktow_Id_kategorii])
    REFERENCES [dbo].[Kategorie_produktowSet]
        ([Id_kategorii])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Kategorie_produktowIdentyfikatory_produktow'
CREATE INDEX [IX_FK_Kategorie_produktowIdentyfikatory_produktow]
ON [dbo].[Identyfikatory_produktowSet]
    ([Kategorie_produktow_Id_kategorii]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------