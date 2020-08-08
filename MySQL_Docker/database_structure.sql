# Creates the student address table
create table student_address
(
    PK_STUDENT_ADDRESS_ID int auto_increment
        primary key,
    ADDRESS_1             varchar(120) charset utf8 not null,
    ADDRESS_2             varchar(120) charset utf8 null,
    CITY                  varchar(100) charset utf8 not null,
    REGION                varchar(100) charset utf8 not null,
    COUNTRY               varchar(100) charset utf8 not null,
    POSTAL_CODE           varchar(20) charset utf8  not null
);

# Creates the student table
create table student
(
    PK_STUDENT_ID         int auto_increment
        primary key,
    USER_NAME             varchar(100)              not null,
    FIRST_NAME            varchar(50)               not null,
    LAST_NAME             varchar(100) charset utf8 not null,
    BIRTH_DATE            date                      not null,
    FK_STUDENT_ADDRESS_ID int                       null,
    constraint student_ibfk_1
        foreign key (FK_STUDENT_ADDRESS_ID) references student_address (PK_STUDENT_ADDRESS_ID)
);

# Adds indexes
create index FK_STUDENT_ADDRESS_ID
    on student (FK_STUDENT_ADDRESS_ID);

create index student_PK_STUDENT_ID_index
    on student (PK_STUDENT_ID);