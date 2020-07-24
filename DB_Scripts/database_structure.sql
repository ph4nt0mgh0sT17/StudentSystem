# This script will create new database named student_system

create schema if not exists student_system collate utf8mb4_0900_ai_ci;

# This script will create all the needed tables...
create table if not exists student
(
	PK_STUDENT_ID int auto_increment
		primary key,
	USER_NAME varchar(100) not null,
	FIRST_NAME varchar(50) not null,
	LAST_NAME varchar(50) not null,
	BIRTH_DATE date not null
);

create index student_PK_STUDENT_ID_index
	on student (PK_STUDENT_ID);
