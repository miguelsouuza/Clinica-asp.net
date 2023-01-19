create database dbClinica;

use dbClinica;

create table tbPaciente(
codPaciente int identity,
nomePaciente varchar(50) not null,
enderecoPaciente varchar(50),
telPaciente varchar(14),
celPaciente varchar(11)
);

create table tbEspecialidade(
codEspecialidade int  identity,
Especialidade varchar(80) not null
);

create table tbMedico(
codMedico int  identity,
nomeMedico varchar(80) not null,
cod_Especialidade int
);

create table tbAtendimento(
codAtendimento int identity,
dataAtendimento varchar(80) not null,
cod_Paciente int,
cod_Medico int,
Diagnostico varchar(max)
);


/*CREATE PRIMARY KEY*/
alter table tbPaciente add constraint PK_IDPACIENTE
PRIMARY KEY (codPaciente)
go

alter table tbEspecialidade add constraint PK_IDESPECIALIDADE
PRIMARY KEY (codespecialidade)

ALTER TABLE tbMedico add constraint PK_Medico
primary key (codMedico)
go

alter table tbAtendimento add constraint PK_IDATENDIMENTO
primary key (codAtendimento)

/*CREATE FOREIGN KEY*/
alter table tbMedico add constraint FK_Especialidade_Medico
foreign key (cod_Especialidade) references tbEspecialidade(codEspecialidade)
go

alter table tbAtendimento add constraint FK_PACIENTE_ATENDIMENTO
foreign key (cod_PACIENTE) references tbPaciente(codPaciente)

alter table tbAtendimento add constraint FK_MEDICO_ATENDIMENTO
FOREIGN KEY (cod_medico) references tbMedico(codMedico)
go


SELECT tbMedico.codMedico,
tbMedico.nomeMedico,
tbEspecialidade.Especialidade
FROM tbMedico 
INNER JOIN tbEspecialidade ON tbEspecialidade.codEspecialidade = tbMedico.cod_Especialidade;



select * from tbPaciente;


select * from tbPaciente where enderecoPaciente like '%rua%';

select * from tbPaciente where enderecoPaciente like '%@enderecoPaciente';

select * from tbPaciente where enderecoPaciente like '%'+@enderecoPaciente+'%';

select * from tbPaciente where enderecoPaciente like '%''@enderecoPaciente''%';

select * from tbPaciente where enderecoPaciente like '%@enderecoPaciente%';

select * from tbMedico;

select * from tbAtendimento;

select * from tbEspecialidade;
drop table if exists tbPaciente;