use Manage_Student
create table Subjects(
	subID varchar(15) not null,
	subName nvarchar(50) not null,
	qtyCredit int not null
	primary key (subID)
);
create table Classes(
	classID varchar(15) not null,
	className nvarchar(50) not null,
	schoolYear int not null
	primary key (classID)
);
create table Students(
	studentID varchar(15) not null,
	studentName nvarchar(40) not null,
	studentAddress nvarchar(100) not null,
	classID varchar(15) not null,
	primary key (studentID),
	foreign key (classID) references Classes(classID)
);
create table Scores (
	studentID varchar(15) not null,
	subID varchar(15) not null,
	score float not null,
	foreign key (studentID) references Students(studentID),
	foreign key (subID) references Subjects(subID),
)
