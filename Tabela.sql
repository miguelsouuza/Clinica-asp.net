create database dbClinica;

use dbClinica;

create table if not exists tbPaciente(
codPaciente int primary key auto_increment,
nomePaciente varchar(50) not null,
enderecoPaciente varchar(50),
telPaciente varchar(14),
celPaciente varchar(11)
);

create table if not exists tbEspecialidade(
codEspecialidade int primary key auto_increment,
Especialidade varchar(80) not null
);

create table if not exists tbMedico(
codMedico int primary key auto_increment,
nomeMedico varchar(80) not null,
codEspecialidade int,
CONSTRAINT foreign key(codEspecialidade) references tbEspecialidade(codEspecialidade)
);

create table if not exists tbAtendimento(
codAtendimento int primary key auto_increment,
dataAtendimento varchar(80) not null,
codPaciente int,
codMedico int,
Diagnostico text,
CONSTRAINT foreign key(codMedico) references tbMedico(codMedico),
CONSTRAINT foreign key(codPaciente) references tbPaciente(codPaciente)
);

SELECT tbMedico.codMedico,
tbMedico.nomeMedico,
tbEspecialidade.Especialidade
FROM tbMedico 
INNER JOIN tbEspecialidade ON tbEspecialidade.codEspecialidade = tbMedico.codEspecialidade;


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