use Manage_Student
Insert into Subjects(subID,subName,qtyCredit) values ('1000128',N'Mạng máy tính',2);
Insert into Subjects(subID,subName,qtyCredit) values ('1000129',N'Cấu trúc dữ liệu và giải thuật',3);
Insert into Subjects(subID,subName,qtyCredit) values ('1000130',N'Kỹ thuật lập trình',3);
Insert into Subjects(subID,subName,qtyCredit) values ('1000131',N'Quản trị mạng',3);
Insert into Subjects(subID,subName,qtyCredit) values ('1000132',N'Lập trình hướng đối tượng',3);
Insert into Subjects(subID,subName,qtyCredit) values ('1000133',N'Cơ sở dữ liệu',3);
Insert into Subjects(subID,subName,qtyCredit) values ('1000134',N'Mạng không dây',2);
Insert into Subjects(subID,subName,qtyCredit) values ('1000135',N'An ninh mạng',3);
Insert into Subjects(subID,subName,qtyCredit) values ('1000136',N'Hệ thống số',2);
Insert into Subjects(subID,subName,qtyCredit) values ('1000137',N'Thực tập tốt nghiệp',3);
Insert into Classes(classID,className,schoolYear) values ('KM20B',N'Mạng máy tính và truyền thông dữ liệu',2020);
Insert into Classes(classID,className,schoolYear) values ('KM20A',N'Mạng máy tính và truyền thông dữ liệu',2020);
Insert into Classes(classID,className,schoolYear) values ('CN20A',N'Công nghệ thông tin',2020);
Insert into Classes(classID,className,schoolYear) values ('CN19A',N'Công nghệ thông tin',2019);
Insert into Classes(classID,className,schoolYear) values ('CN19B',N'Công nghệ thông tin',2019);
Insert into Classes(classID,className,schoolYear) values ('KM19B',N'Mạng máy tính và truyền thông dữ liệu',2019);
Insert into Classes(classID,className,schoolYear) values ('KM19A',N'Mạng máy tính và truyền thông dữ liệu',2019);
Insert into Classes(classID,className,schoolYear) values ('CN21',N'Công nghệ thông tin',2021);
Insert into Classes(classID,className,schoolYear) values ('KM21',N'Mạng máy tính và truyền thông dữ liệu',2021);
Insert into Students(studentID,studentName,studentAddress,classID) values ('2051150321',N'Sỳ Nguyễn Huy Vinh',N'Thành phố HCM','KM20B');
Insert into Students(studentID,studentName,studentAddress,classID) values ('2051150322',N'Trần Hoàng Huy',N'Thành phố HCM','KM20B');
Insert into Students(studentID,studentName,studentAddress,classID) values ('2051150323',N'Nguyễn Hoàng Phúc',N'Thành phố HCM','KM20B');
Insert into Students(studentID,studentName,studentAddress,classID) values ('2051150325',N'Nguyễn Văn Tỵ',N'Bến Tre','KM20B');
Insert into Students(studentID,studentName,studentAddress,classID) values ('2051150326',N'Trần Công Trực',N'Vũng Tàu','KM20B');
Insert into Students(studentID,studentName,studentAddress,classID) values ('2051150327',N'Hồ Hoàn Vũ',N'Thành phố HCM','KM20B');
Insert into Students(studentID,studentName,studentAddress,classID) values ('2051150328',N'Nguyễn Đình Phong',N'Cà Mau','KM20B');
Insert into Students(studentID,studentName,studentAddress,classID) values ('2051150329',N'Trần Quốc Trường',N'Bình Thuận','KM20B');
Insert into Students(studentID,studentName,studentAddress,classID) values ('2051120001',N'Nguyễn Hoàng An',N'Bình Phước','CN20A');
Insert into Students(studentID,studentName,studentAddress,classID) values ('2051120002',N'Nguyễn Võ Đình Anh',N'Tây Ninh','CN20A');
Insert into Students(studentID,studentName,studentAddress,classID) values ('2051120003',N'Dương Phú Cường',N'Phú Yên','CN20A');
Insert into Students(studentID,studentName,studentAddress,classID) values ('2051120004',N'Nguyễn Thành Hưng',N'Bến Tre','CN20A');
Insert into Students(studentID,studentName,studentAddress,classID) values ('2051120005',N'Trần Quốc Huy',N'Tiền Giang','CN20A');
Insert into Students(studentID,studentName,studentAddress,classID) values ('2051120006',N'Lê Đức Huy',N'Thành phố HCM','CN20A');
Insert into Students(studentID,studentName,studentAddress,classID) values ('2051120007',N'Nguyễn Ngọc Huy',N'Thành phố HCM','CN20A');
Insert into Scores(studentID,subID,score) values ('2051150321','1000128',9.5);
Insert into Scores(studentID,subID,score) values ('2051150321','1000129',8.0);
Insert into Scores(studentID,subID,score) values ('2051150321','1000130',7.2);
Insert into Scores(studentID,subID,score) values ('2051150321','1000131',6.8);
Insert into Scores(studentID,subID,score) values ('2051150321','1000132',9.7);
Insert into Scores(studentID,subID,score) values ('2051150321','1000133',5.3);
Insert into Scores(studentID,subID,score) values ('2051150321','1000134',4.5);
Insert into Scores(studentID,subID,score) values ('2051150321','1000135',3.2);
Insert into Scores(studentID,subID,score) values ('2051150321','1000136',5.8);
Insert into Scores(studentID,subID,score) values ('2051150321','1000137',5.9);

use Manage_Student
Select * from Subjects

Select studentName from Students,Scores where (Scores.score > 8) and (Scores.studentID = Students.studentID)

create table userAdmin(
	username varchar(30) not null,
	passw varchar(30) not null,
	lastLogin datetime not null,
	lastModify datetime not null,
	primary key(username)

)
Insert into userAdmin(username,passw,lastLogin,lastModify) values ('vinhadmin','123456a@','2023-09-08T13:25:10','2023-09-08T13:27:10');
Insert into userAdmin(username,passw,lastLogin,lastModify) values ('admin','123456a@','2023-09-08T13:25:10','2023-09-08T13:27:10');
Insert into userAdmin(username,passw,lastLogin,lastModify) values ('admin2','123456a@','2023-09-08T13:25:10','2023-09-08T13:27:10');
Insert into userAdmin(username,passw,lastLogin,lastModify) values ('admin3','123456a@','2023-09-08T13:25:10','2023-09-08T13:27:10');