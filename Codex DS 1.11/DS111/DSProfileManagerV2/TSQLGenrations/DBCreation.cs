// *************************************************************************************
// ** DS 1.10 
// ** (C) Copyright By 2007-2023 By Irakli Lomidze
// *************************************************************************************
// ** Date: 2023-04-05
// ** Version 1.1

using System;

namespace DSProfileMaker.TSQLGenerators
{
    internal class DBCreation
    {
        public DBCreation()
        {
            
        }
        public static string DBCreationScript(string DatabaseName, string path)
        {
            string s =
                "USE [master] " + Environment.NewLine +
                "GO " + Environment.NewLine +
               $"CREATE DATABASE[{DatabaseName}]" + Environment.NewLine +
                "CONTAINMENT = NONE " + Environment.NewLine +
                "ON PRIMARY " + Environment.NewLine +
               $"(NAME = N'{DatabaseName}_Data', FILENAME = N'{path}\\{DatabaseName}_data.mdf' , SIZE = 10240KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10 %), " + Environment.NewLine +
                "FILEGROUP[Blobs] " + Environment.NewLine +
               $"(NAME = N'{DatabaseName}_Blobs', FILENAME = N'{path}\\{DatabaseName}_blobs_data.ndf', SIZE = 16512KB, MAXSIZE = UNLIMITED, FILEGROWTH = 10 %) " + Environment.NewLine +
                "LOG ON " + Environment.NewLine +
               $"(NAME = N'{DatabaseName}_Log', FILENAME = N'{path}\\{DatabaseName}_log.ldf' , SIZE = 12416KB , MAXSIZE = 2048GB , FILEGROWTH = 10 %) " + Environment.NewLine +
                "WITH CATALOG_COLLATION = DATABASE_DEFAULT " + Environment.NewLine +
                "GO " + Environment.NewLine +
                                                             Environment.NewLine +
                "IF(1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled')) " + Environment.NewLine +
                "begin " + Environment.NewLine +
               $"EXEC[{DatabaseName}].[dbo].[sp_fulltext_database] @action = 'enable'" + Environment.NewLine +
                "end " + Environment.NewLine +
                "GO" + Environment.NewLine +
                                                                                         Environment.NewLine +
               $"ALTER DATABASE[{DatabaseName}] SET ANSI_NULL_DEFAULT OFF" + Environment.NewLine +
                "GO" + Environment.NewLine +
                                                                                         Environment.NewLine +
               $"ALTER DATABASE[{DatabaseName}] SET ANSI_NULLS OFF " + Environment.NewLine +
                "GO" + Environment.NewLine +
                                                                                         Environment.NewLine +
               $"ALTER DATABASE[{DatabaseName}] SET ANSI_PADDING OFF " + Environment.NewLine +
                "GO" + Environment.NewLine +
                                                                                         Environment.NewLine +
               $"ALTER DATABASE[{DatabaseName}] SET ANSI_WARNINGS OFF " + Environment.NewLine +
                "GO" + Environment.NewLine +
                                                                                         Environment.NewLine +
               $"ALTER DATABASE[{DatabaseName}] SET ARITHABORT OFF " + Environment.NewLine +
                "GO" + Environment.NewLine +
                                                                                         Environment.NewLine +
               $"ALTER DATABASE[{DatabaseName}] SET AUTO_CLOSE OFF" + Environment.NewLine +
                "GO" + Environment.NewLine +
                                                                                         Environment.NewLine +
                $"ALTER DATABASE[{DatabaseName}] SET AUTO_SHRINK OFF" + Environment.NewLine +
                 "GO" + Environment.NewLine +
                                                                                         Environment.NewLine +
                $"ALTER DATABASE[{DatabaseName}] SET AUTO_UPDATE_STATISTICS ON" + Environment.NewLine +
                 "GO" + Environment.NewLine +
                                                                             Environment.NewLine +

                $"ALTER DATABASE[{DatabaseName}] SET CURSOR_CLOSE_ON_COMMIT OFF" + Environment.NewLine +
                 "GO" + Environment.NewLine +
                                                                             Environment.NewLine +
                $"ALTER DATABASE[{DatabaseName}] SET CURSOR_DEFAULT  GLOBAL" + Environment.NewLine +
                 "GO" + Environment.NewLine +
                                                                             Environment.NewLine +
                $"ALTER DATABASE[{DatabaseName}] SET CONCAT_NULL_YIELDS_NULL OFF" + Environment.NewLine +
                 "GO" + Environment.NewLine +
                                                                             Environment.NewLine +
                $"ALTER DATABASE[{DatabaseName}] SET NUMERIC_ROUNDABORT OFF" + Environment.NewLine +
                 "GO" + Environment.NewLine +
                                                                             Environment.NewLine +
                $"ALTER DATABASE[{DatabaseName}] SET QUOTED_IDENTIFIER OFF" + Environment.NewLine +
                 "GO" + Environment.NewLine +
                                                                             Environment.NewLine +
                $"ALTER DATABASE[{DatabaseName}] SET RECURSIVE_TRIGGERS OFF" + Environment.NewLine +
                 "GO" + Environment.NewLine +
                                                                             Environment.NewLine +
                $"ALTER DATABASE[{DatabaseName}] SET DISABLE_BROKER" + Environment.NewLine +
                 "GO" + Environment.NewLine +
                                                                             Environment.NewLine +
                $"ALTER DATABASE[{DatabaseName}] SET AUTO_UPDATE_STATISTICS_ASYNC OFF" + Environment.NewLine +
                 "GO" + Environment.NewLine +
                                                                             Environment.NewLine +
                $"ALTER DATABASE[{DatabaseName}] SET DATE_CORRELATION_OPTIMIZATION OFF" + Environment.NewLine +
                 "GO" + Environment.NewLine +
                                                                             Environment.NewLine +
                $"ALTER DATABASE[{DatabaseName}] SET TRUSTWORTHY OFF" + Environment.NewLine +
                 "GO" + Environment.NewLine +
                                                                             Environment.NewLine +
                $"ALTER DATABASE[{DatabaseName}] SET ALLOW_SNAPSHOT_ISOLATION OFF" + Environment.NewLine +
                 "GO" + Environment.NewLine +
                                                                             Environment.NewLine +
                $"ALTER DATABASE[{DatabaseName}] SET PARAMETERIZATION SIMPLE" + Environment.NewLine +
                 "GO" + Environment.NewLine +
                                                                             Environment.NewLine +
                $"ALTER DATABASE[{DatabaseName}] SET READ_COMMITTED_SNAPSHOT OFF" + Environment.NewLine +
                 "GO" + Environment.NewLine +
                                                                             Environment.NewLine +
                $"ALTER DATABASE[{DatabaseName}] SET HONOR_BROKER_PRIORITY OFF" + Environment.NewLine +
                 "GO" + Environment.NewLine +
                                                                             Environment.NewLine +
                $"ALTER DATABASE[{DatabaseName}] SET RECOVERY FULL" + Environment.NewLine +
                 "GO" + Environment.NewLine +
                                                                             Environment.NewLine +
                $"ALTER DATABASE[{DatabaseName}] SET MULTI_USER" + Environment.NewLine +
                 "GO" + Environment.NewLine +
                                                                             Environment.NewLine +
                $"ALTER DATABASE[{DatabaseName}] SET PAGE_VERIFY TORN_PAGE_DETECTION" + Environment.NewLine +
                 "GO" + Environment.NewLine +
                                                                             Environment.NewLine +
                $"ALTER DATABASE[{DatabaseName}] SET DB_CHAINING OFF" + Environment.NewLine +
                 "GO" + Environment.NewLine +
                                                                             Environment.NewLine +
                $"ALTER DATABASE[{DatabaseName}] SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF)" + Environment.NewLine +
                 "GO" + Environment.NewLine +
                                                                             Environment.NewLine +
                $"ALTER DATABASE[{DatabaseName}] SET TARGET_RECOVERY_TIME = 0 SECONDS" + Environment.NewLine +
                 "GO" + Environment.NewLine +
                                                                             Environment.NewLine +
                $"ALTER DATABASE[{DatabaseName}] SET DELAYED_DURABILITY = DISABLED" + Environment.NewLine +
                 "GO" + Environment.NewLine +
                                                                             Environment.NewLine +
                $"ALTER DATABASE[{DatabaseName}] SET ACCELERATED_DATABASE_RECOVERY = OFF" + Environment.NewLine +
                 "GO" + Environment.NewLine +
                                                                             Environment.NewLine +
                $"ALTER DATABASE[{DatabaseName}] SET QUERY_STORE = OFF" + Environment.NewLine +
                 "GO" + Environment.NewLine +
                                                                             Environment.NewLine +
                $"ALTER DATABASE[{DatabaseName}] SET READ_WRITE" + Environment.NewLine +
                 "GO" + Environment.NewLine;

            return s;

        }
    }
}
