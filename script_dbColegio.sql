
create database [dbColegio]
go

USE [dbColegio]
GO
/****** Object:  Table [dbo].[Alumno]    Script Date: 12/04/2018 21:24:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumno](
	[AlumnoID] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [nvarchar](50) NOT NULL,
	[Apellidos] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[Sexo] [nchar](1) NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
 CONSTRAINT [PK_Alumno] PRIMARY KEY CLUSTERED 
(
	[AlumnoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Curso]    Script Date: 12/04/2018 21:24:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curso](
	[CursoID] [int] IDENTITY(1,1) NOT NULL,
	[GradoID] [int] NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Curso] PRIMARY KEY CLUSTERED 
(
	[CursoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Grado]    Script Date: 12/04/2018 21:24:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grado](
	[GradoID] [int] IDENTITY(1,1) NOT NULL,
	[Nivel] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Grado] PRIMARY KEY CLUSTERED 
(
	[GradoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Matricula]    Script Date: 12/04/2018 21:24:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Matricula](
	[MatriculaID] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[GradoID] [int] NOT NULL,
	[SeccionID] [int] NOT NULL,
	[AlumnoID] [int] NOT NULL,
 CONSTRAINT [PK_Matricula] PRIMARY KEY CLUSTERED 
(
	[MatriculaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Notas]    Script Date: 12/04/2018 21:24:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notas](
	[NotaID] [int] IDENTITY(1,1) NOT NULL,
	[AlumnoID] [int] NOT NULL,
	[CursoID] [int] NOT NULL,
	[Nota] [int] NOT NULL,
 CONSTRAINT [PK_Notas] PRIMARY KEY CLUSTERED 
(
	[NotaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Seccion]    Script Date: 12/04/2018 21:24:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seccion](
	[SeccionID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](10) NOT NULL,
	[GradoID] [int] NOT NULL,
 CONSTRAINT [PK_Seccion] PRIMARY KEY CLUSTERED 
(
	[SeccionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Curso]  WITH CHECK ADD  CONSTRAINT [FK_Curso_Grado] FOREIGN KEY([GradoID])
REFERENCES [dbo].[Grado] ([GradoID])
GO
ALTER TABLE [dbo].[Curso] CHECK CONSTRAINT [FK_Curso_Grado]
GO
ALTER TABLE [dbo].[Matricula]  WITH CHECK ADD  CONSTRAINT [FK_Matricula_Alumno] FOREIGN KEY([AlumnoID])
REFERENCES [dbo].[Alumno] ([AlumnoID])
GO
ALTER TABLE [dbo].[Matricula] CHECK CONSTRAINT [FK_Matricula_Alumno]
GO
ALTER TABLE [dbo].[Matricula]  WITH CHECK ADD  CONSTRAINT [FK_Matricula_Grado] FOREIGN KEY([GradoID])
REFERENCES [dbo].[Grado] ([GradoID])
GO
ALTER TABLE [dbo].[Matricula] CHECK CONSTRAINT [FK_Matricula_Grado]
GO
ALTER TABLE [dbo].[Notas]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Alumno] FOREIGN KEY([AlumnoID])
REFERENCES [dbo].[Alumno] ([AlumnoID])
GO
ALTER TABLE [dbo].[Notas] CHECK CONSTRAINT [FK_Notas_Alumno]
GO
ALTER TABLE [dbo].[Notas]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Curso] FOREIGN KEY([CursoID])
REFERENCES [dbo].[Curso] ([CursoID])
GO
ALTER TABLE [dbo].[Notas] CHECK CONSTRAINT [FK_Notas_Curso]
GO
ALTER TABLE [dbo].[Seccion]  WITH CHECK ADD  CONSTRAINT [FK_Seccion_Grado] FOREIGN KEY([GradoID])
REFERENCES [dbo].[Grado] ([GradoID])
GO
ALTER TABLE [dbo].[Seccion] CHECK CONSTRAINT [FK_Seccion_Grado]
GO
use dbColegio
go

select * from dbo.Alumno
select * from Curso;
select * from Grado;
select* from Notas;
go
insert into dbo.Alumno values('Jhonn','CHapeton','Los Olivos','M','1994/05/29')
select AlumnoID,Nombres,Apellidos,Direccion,Sexo,FechaNacimiento from Alumno

insert into Notas values(3,1,20)
go
create procedure SP_MostrarNotasXFiltro 
@grado int,
@curso int
as
begin
	select (a.Nombres+' '+a.Apellidos )as 'NombreCompleto',g.Nivel,c.Nombre as 'Curso',n.Nota from Alumno a 
	join Notas n on n.AlumnoID=a.AlumnoID
	join Curso c on c.CursoID=n.CursoID
	join Grado g on g.GradoID=c.GradoID where g.GradoID=@grado and c.CursoID=@curso
end;
go

execute SP_MostrarNotasXFiltro 2,2
go