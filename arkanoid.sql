drop table if exists usuario cascade;
create table usuario(
	id_u serial not null,
	nombre varchar(100) unique not null,
	constraint pk_suministrador primary key(id_u));

drop table if exists puntuacion cascade;
create table puntuacion(
	id_p	serial not null,
	id_u int not null,
	puntaje int not null,
	constraint pk_pieza primary key (id_p),
	constraint fk_puntuacion_usuario foreign key (id_u)
	references usuario(id_u) on delete cascade on update cascade);

select * from puntuacion;