USE [GBT]
GO

INSERT INTO [dbo].[Cliente]
           ([Nome]
           ,[IsAtivo]
           ,[DataHoraCadastro])
     VALUES
           ('CLIENTE 1'
           ,1
           ,GETDATE())
GO


USE [GBT]
GO

INSERT INTO [dbo].[DNS]
           ([Nome]
           ,[IsAtivo]
           ,[IsAtividade]
           ,[DataHoraCadastro]
           ,[ClienteId])
     VALUES
           ('DNS 1'
           ,1
           ,1
           ,GETDATE()
           ,1)
GO

USE [GBT]
GO

INSERT INTO [dbo].[BancoDados]
           ([Nome]
           ,[IsAtivo]
           ,[DataHoraCadastro]
           ,[ClienteId])
     VALUES
           ('BD1'
           ,1
           ,GETDATE()
           ,1)
GO

USE [GBT]
GO

INSERT INTO [dbo].[Chamado]
           ([Numero]
           ,[IsAtivo]
           ,[DataHoraCadastro]
           ,[DataRecebimento]
           ,[DataEnvioHomologacao]
           ,[DataPublicacao]
           ,[Observacao]
           ,[ScriptText]
           ,[ClienteId]
           ,[BancoDadosId]
           ,[DNSId])
     VALUES
           ('CHAMADO 1'
           ,1
           ,GETDATE()
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,1
           ,1
           ,1)
GO








