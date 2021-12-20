INSERT INTO Role(type) VALUES('User'),('Admin');

INSERT INTO User_acc (user_id,user_name,date_of_birth,account_balance,fullname,roleid)
 VALUES(gen_random_uuid(),'admin','1999-09-25',0,'Paulo Meneses', 2),
        (gen_random_uuid(),'aaddddd','1993-10-25',0,'Maria', 1),
        (gen_random_uuid(),'admaawdadin','1980-12-05',0,'Antonio', 1),
        (gen_random_uuid(),'admawwwwwin','1996-01-25',0,'Jose', 1);


INSERT INTO Payment(method,value,useruser_id) 
VALUES('Credit Card', 35.00, 'f0d430f5-ba40-431b-abea-e43959a5bb10'),
('Credit Card', 30.00, '3d6e77b8-3391-489e-a092-375298c76fed'),
('Credit Card', 33.12, '4c1f3501-d213-46d4-bc1b-345302e8d6e1');


INSERT INTO Location(name, coordinates) VALUES ('Braga', polygon(path '((41.563502, -8.459069),(41.576923, -8.422065),(41.553172, -8.397549),(41.527880, -8.427469))'));

INSERT INTO Location(name, coordinates) VALUES ('Teste', polygon(path '((0,0),(1,1),(2,0))'));