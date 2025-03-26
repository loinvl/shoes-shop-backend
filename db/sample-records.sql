use shoes_shop;
    
# Password: #Abc_123
insert into storeadmin(HashPassword, Email) value ('$2a$11$37EmIfYc4CwiQGZ0f4UqvO.r/ktc6CqxRwbLc0J3ravi4ni7qK/7i', 'shoesshop.contact@gmail.com');

insert into store(StoreName, Address, Email, Phone) value ('Shoes Shop', 'Số 10, Điện Biên Phủ, Quận 1, tp Hồ Chí Minh', 'shoesshop.contact@gmail.com', '0399049001');

# Customer account, password: #Abc_123
insert into customer(CustomerName, HashPassword, Email, Phone, Address) value ('Nguyễn Văn A', '$2a$11$37EmIfYc4CwiQGZ0f4UqvO.r/ktc6CqxRwbLc0J3ravi4ni7qK/7i', 'a@gmail.com', '0987654321', '123A LHP');
insert into customer(CustomerName, HashPassword, Email, Phone, Address) value ('Nguyễn Văn B', '$2a$11$37EmIfYc4CwiQGZ0f4UqvO.r/ktc6CqxRwbLc0J3ravi4ni7qK/7i', 'b@gmail.com', '0987654322', '123B LHP');
insert into customer(CustomerName, HashPassword, Email, Phone, Address) value ('Nguyễn Văn C', '$2a$11$37EmIfYc4CwiQGZ0f4UqvO.r/ktc6CqxRwbLc0J3ravi4ni7qK/7i', 'c@gmail.com', '0987654323', '123C LHP');
insert into customer(CustomerName, HashPassword, Email, Phone, Address) value ('Dev Test', '$2a$11$37EmIfYc4CwiQGZ0f4UqvO.r/ktc6CqxRwbLc0J3ravi4ni7qK/7i', 'loinv.contact@gmail.com', '1111111113', '123D LHP');

# Admin account, password: #Abc_123
insert into customer(CustomerName, HashPassword, Email, Phone, Address, UserRole) value ('Admin', '$2a$11$37EmIfYc4CwiQGZ0f4UqvO.r/ktc6CqxRwbLc0J3ravi4ni7qK/7i', 'shoesshop.contact@gmail.com', '0399049001', 'Hải An - Hải Lăng - Quảng Trị', 1);


insert into brand(BrandName) value ('ADIDAS');
insert into brand(BrandName) value ('NIKE');
insert into brand(BrandName) value ('MLB');
insert into brand(BrandName) value ('CONVERSE');
insert into brand(BrandName) value ('SNEAKER');
insert into brand(BrandName) value ('VALENTINO');
insert into brand(BrandName) value ('BALENCIAGA');
insert into brand(BrandName) value ('PUMA');
insert into brand(BrandName) value ('NEW BALENCE');
insert into brand(BrandName) value ('REEBOK');
insert into brand(BrandName) value ('FILA');
insert into brand(BrandName) value ('SUPREME');
insert into brand(BrandName) value ('COMMON PROJECTS');
insert into brand(BrandName) value ('MCQEEN');
insert into brand(BrandName) value ('ASICS');
insert into brand(BrandName) value ('GUCCI');
insert into brand(BrandName) value ('DOLCE & GABBANA');
insert into brand(BrandName) value ('ANTA');
insert into brand(BrandName) value ('DOMBA');
insert into brand(BrandName) value ('Y-3');
insert into brand(BrandName) value ('KHÁC');

insert into shoesmodel(ShoesModelName, BrandID, ShoesModelDescription) value ('Giày MC Queen gót nhùng, đế cao 4cm,da trắng mịn, full phụ kiện', 14, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.
Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.');
insert into shoesmodel(ShoesModelName, BrandID, ShoesModelDescription) value ('Giày Nike_air force 1 low to bigbang, af1 dây thừng, chất liệu vải thổ cẩm, giày nam nữ cổ thấp, đế air tăng chiều cao', 2, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.
Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.');
insert into shoesmodel(ShoesModelName, BrandID, ShoesModelDescription) value ('Giày Adidas superstar, giày thể thao adidas mũi sò, cổ thấp, đế bệt, 2 bản màu xanh hồng, bản best full phụ kiện', 1, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.
Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.');
insert into shoesmodel(ShoesModelName, BrandID, ShoesModelDescription) value ('Giày Thể Thao Nam Nữ Louis Vuitton LV Trainer 3 màu, Giày LV Bản best da thật, đế tăng chiều cao, full phụ kiện.', 21, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.
Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.');
insert into shoesmodel(ShoesModelName, BrandID, ShoesModelDescription) value ('Giày thể thao , AF1 GC xanh đỏ bản cao cấp', 16, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.
Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.');
insert into shoesmodel(ShoesModelName, BrandID, ShoesModelDescription) value ('Giày MLB Chunky Liner New York đủ 3 phối màu, giày thể thao nam nữ MLB Chunky cổ thấp, đế tăng chiều cao, bả Best', 3, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.
Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.');
insert into shoesmodel(ShoesModelName, BrandID, ShoesModelDescription) value ('Giày Nike_Air Max 1 Patta Waves Noise Aqua ( without Bracelet ) - Phiên bản high quality', 2, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.
Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.');
insert into shoesmodel(ShoesModelName, BrandID, ShoesModelDescription) value ('Giày Adidas superstar, giày thể thao adidas mũi sò, cổ thấp, đế bệt, 2 bản màu xanh hồng, bản best full phụ kiện', 1, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.
Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.');
insert into shoesmodel(ShoesModelName, BrandID, ShoesModelDescription) value ('Giày Jodan 1 High Panda, JD1 cổ cao đen trắng bản chuẩn Trung xịn, tặng box bảo vệ', 2, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.
Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.');
insert into shoesmodel(ShoesModelName, BrandID, ShoesModelDescription) value ('Giày thể thao air force 1 bản vải màu be, AF1 vàng cát vệt xanh cao cấp, tặng box bảo vệ giày', 2, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.
Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.');
insert into shoesmodel(ShoesModelName, BrandID, ShoesModelDescription) value ('Giày MLB chunky High New York Yankess black, mlb đen cổ cao, bản chuẩn', 3, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.
Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.');
insert into shoesmodel(ShoesModelName, BrandID, ShoesModelDescription) value ('Giày Jordan 1 High Retro University Blue,JD1 cổ cao trắng xanh bản chuẩn Trung xịn, tặng box bảo vệ', 2, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.
Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.');
insert into shoesmodel(ShoesModelName, BrandID, ShoesModelDescription) value ('Giày Sneaker Ga Rhyton, Gu NY chuẩn Sc Trung ful Bill tặng Box bảo vệ và túi giấy', 5, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.
Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.');
insert into shoesmodel(ShoesModelName, BrandID, ShoesModelDescription) value ('Giày jordan4 Vàng Cát Retro Sail, JD 4 nam nữ (full Box Bill)', 2, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.
Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.');
insert into shoesmodel(ShoesModelName, BrandID, ShoesModelDescription) value ('Giày NA trắng nâu, NA, giày thể thao nam nữ cổ thấp, đế air tăng chiều cao, bản Best', 21,'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.
Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.');
insert into shoesmodel(ShoesModelName, BrandID, ShoesModelDescription) value ('Giày thể thao nam nữ Air Force 1, Sneaker AF1 trắng chuẩn SC Trung phồi đồ gì cũng hợp', 5, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.
Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.');
insert into shoesmodel(ShoesModelName, BrandID, ShoesModelDescription) value ('Giày Air Force 1 Low x Louis_Vuitton Monogram Brown, bản Best', 2, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.
Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.');
insert into shoesmodel(ShoesModelName, BrandID, ShoesModelDescription) value ('Giày Jordan 1 High Mocha, JD1 cổ cao trắng nâu, bản chuẩn tặng box bảo vệ', 2, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.
Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.');
insert into shoesmodel(ShoesModelName, BrandID, ShoesModelDescription) value ('Giày thể thao nam nữ Air Force 1 Low ’07 ‘Cosmic Bonsai’, af1 trắng xanh cổ thấp, đế bệt, bản best', 2, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.
Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.');
insert into shoesmodel(ShoesModelName, BrandID, ShoesModelDescription) value ('Giày Jordan 1 low light smoke grey, JD1 đen xám bản chuẩn Trung tặng box bảo vệ giày', 2, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.
Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.');
insert into shoesmodel(ShoesModelName, BrandID, ShoesModelDescription) value ('Giày Gucci Ace For Love, giày thể nao nam nữ gucci môi cách điệu, thười trang, bản Best', 16, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.
Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.');
insert into shoesmodel(ShoesModelName, BrandID, ShoesModelDescription) value ('Giày AF1 vệt nâu, vệt đen bản trung SC, Sneaker Air Force 1 nâu trắng dành cho nam nữ, full bill box bảo vệ', 5, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.
Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.');
insert into shoesmodel(ShoesModelName, BrandID, ShoesModelDescription) value ('Giày sục hở mũi bán mì, sục vải buộc dây đế cao 3cm, đủ màu', 21, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.
Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.');
insert into shoesmodel(ShoesModelName, BrandID, ShoesModelDescription) value ('Giày New Balance CRT3000000 2.0 đủ màu, giày NB CRT 3000000 nam nữ full phụ kiện', 9, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.
Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.');
insert into shoesmodel(ShoesModelName, BrandID, ShoesModelDescription) value ('Giày Thể Thao Sneaker Nam Nữ Alphabounce Beyond Trắng Full Cực Êm Thoáng Khí  Clever Man Store', 1, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.
Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.');
insert into shoesmodel(ShoesModelName, BrandID, ShoesModelDescription) value ('Giày Adidas Superstar bản mới nhất 2022 3 màu, giày Superstar nam nữ full phụ kiện', 1, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.
Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.');
insert into shoesmodel(ShoesModelName, BrandID, ShoesModelDescription) value ('Giày thể thao vải nam nữ độn đế mũi viền kẻ Caro 2 màu siêu hot', 21, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.
Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.');
insert into shoesmodel(ShoesModelName, BrandID, ShoesModelDescription) value ('Giày thể thao nữ TED viền lúa độn đế cao 5cm chất liệu da siêu đẹp mẫu mới nhất 2022 hot trend, seaker nữ đi học đế bằng', 21, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.
Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.');
insert into shoesmodel(ShoesModelName, BrandID, ShoesModelDescription) value ('Giày _Converse Chuck Taylor All Star 1970s Full Size Nam Nữ, Giày _Converse Cổ Cao, Cổ Thấp Full Box + Bill', 4, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.
Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.');
insert into shoesmodel(ShoesModelName, BrandID, ShoesModelDescription) value ('Giày Balenciaga Speed Đen Cổ Chun Cao Cấp Nam Nữ, Giày Balen Cổ Cao Hàng Đẹp', 7, 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.
Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.
Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.');


insert into shoesmodelimage(ShoesModelID, ImageLink) value (1, "/image/shoes20.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (1, "/image/shoes36.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (1, "/image/shoes17.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (1, "/image/shoes8.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (1, "/image/shoes38.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (2, "/image/shoes13.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (2, "/image/shoes20.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (2, "/image/shoes40.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (2, "/image/shoes34.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (2, "/image/shoes44.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (3, "/image/shoes17.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (3, "/image/shoes8.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (3, "/image/shoes45.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (3, "/image/shoes3.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (3, "/image/shoes33.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (4, "/image/shoes9.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (4, "/image/shoes13.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (4, "/image/shoes36.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (4, "/image/shoes22.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (4, "/image/shoes38.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (5, "/image/shoes19.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (5, "/image/shoes4.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (5, "/image/shoes1.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (5, "/image/shoes40.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (5, "/image/shoes6.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (6, "/image/shoes28.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (6, "/image/shoes21.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (6, "/image/shoes34.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (6, "/image/shoes9.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (6, "/image/shoes7.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (7, "/image/shoes21.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (7, "/image/shoes5.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (7, "/image/shoes33.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (7, "/image/shoes10.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (7, "/image/shoes41.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (8, "/image/shoes28.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (8, "/image/shoes19.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (8, "/image/shoes19.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (8, "/image/shoes24.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (8, "/image/shoes29.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (9, "/image/shoes9.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (9, "/image/shoes4.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (9, "/image/shoes37.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (9, "/image/shoes33.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (9, "/image/shoes49.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (10, "/image/shoes20.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (10, "/image/shoes49.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (10, "/image/shoes12.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (10, "/image/shoes41.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (10, "/image/shoes26.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (11, "/image/shoes38.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (11, "/image/shoes43.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (11, "/image/shoes20.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (11, "/image/shoes6.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (11, "/image/shoes5.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (12, "/image/shoes29.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (12, "/image/shoes17.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (12, "/image/shoes43.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (12, "/image/shoes11.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (12, "/image/shoes3.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (13, "/image/shoes33.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (13, "/image/shoes30.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (13, "/image/shoes14.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (13, "/image/shoes5.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (13, "/image/shoes34.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (14, "/image/shoes44.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (14, "/image/shoes48.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (14, "/image/shoes35.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (14, "/image/shoes3.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (14, "/image/shoes14.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (15, "/image/shoes45.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (15, "/image/shoes2.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (15, "/image/shoes17.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (15, "/image/shoes10.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (15, "/image/shoes19.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (16, "/image/shoes30.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (16, "/image/shoes44.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (16, "/image/shoes22.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (16, "/image/shoes18.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (16, "/image/shoes26.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (17, "/image/shoes6.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (17, "/image/shoes8.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (17, "/image/shoes17.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (17, "/image/shoes21.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (17, "/image/shoes27.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (18, "/image/shoes23.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (18, "/image/shoes38.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (18, "/image/shoes49.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (18, "/image/shoes9.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (18, "/image/shoes48.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (19, "/image/shoes49.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (19, "/image/shoes29.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (19, "/image/shoes37.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (19, "/image/shoes45.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (19, "/image/shoes16.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (20, "/image/shoes8.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (20, "/image/shoes12.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (20, "/image/shoes9.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (20, "/image/shoes38.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (20, "/image/shoes7.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (21, "/image/shoes3.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (21, "/image/shoes30.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (21, "/image/shoes11.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (21, "/image/shoes37.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (21, "/image/shoes20.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (22, "/image/shoes20.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (22, "/image/shoes20.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (22, "/image/shoes18.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (22, "/image/shoes26.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (22, "/image/shoes49.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (23, "/image/shoes50.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (23, "/image/shoes4.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (23, "/image/shoes48.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (23, "/image/shoes10.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (23, "/image/shoes29.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (24, "/image/shoes33.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (24, "/image/shoes20.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (24, "/image/shoes19.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (24, "/image/shoes21.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (24, "/image/shoes7.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (25, "/image/shoes13.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (25, "/image/shoes34.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (25, "/image/shoes37.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (25, "/image/shoes3.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (25, "/image/shoes42.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (26, "/image/shoes1.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (26, "/image/shoes31.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (26, "/image/shoes32.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (26, "/image/shoes41.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (26, "/image/shoes23.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (27, "/image/shoes41.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (27, "/image/shoes37.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (27, "/image/shoes12.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (27, "/image/shoes18.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (27, "/image/shoes3.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (28, "/image/shoes40.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (28, "/image/shoes33.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (28, "/image/shoes30.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (28, "/image/shoes21.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (28, "/image/shoes33.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (29, "/image/shoes45.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (29, "/image/shoes49.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (29, "/image/shoes26.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (29, "/image/shoes18.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (29, "/image/shoes39.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (30, "/image/shoes12.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (30, "/image/shoes3.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (30, "/image/shoes30.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (30, "/image/shoes8.webp");
insert into shoesmodelimage(ShoesModelID, ImageLink) value (30, "/image/shoes12.webp");


insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(1, "Trắng", 38, 5000000, 10);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(1, "Đen", 39, 8000000, 5);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(1, "Xanh", 40, 3000000, 1);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(2, "Trắng", 38, 8000000, 10);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(2, "Đen", 39, 4000000, 5);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(2, "Xanh", 40, 5000000, 1);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(3, "Trắng", 38, 3000000, 10);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(3, "Đen", 39, 9000000, 5);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(3, "Xanh", 40, 5000000, 1);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(4, "Trắng", 38, 4000000, 10);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(4, "Đen", 39, 1000000, 5);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(4, "Xanh", 40, 1000000, 1);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(5, "Trắng", 38, 5000000, 10);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(5, "Đen", 39, 6000000, 5);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(5, "Xanh", 40, 9000000, 1);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(6, "Trắng", 38, 7000000, 10);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(6, "Đen", 39, 5000000, 5);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(6, "Xanh", 40, 7000000, 1);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(7, "Trắng", 38, 3000000, 10);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(7, "Đen", 39, 1000000, 5);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(7, "Xanh", 40, 5000000, 1);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(8, "Trắng", 38, 4000000, 10);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(8, "Đen", 39, 9000000, 5);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(8, "Xanh", 40, 7000000, 1);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(9, "Trắng", 38, 4000000, 10);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(9, "Đen", 39, 9000000, 5);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(9, "Xanh", 40, 7000000, 1);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(10, "Trắng", 38, 4000000, 10);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(10, "Đen", 39, 1000000, 5);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(10, "Xanh", 40, 3000000, 1);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(11, "Trắng", 38, 1000000, 10);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(11, "Đen", 39, 8000000, 5);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(11, "Xanh", 40, 7000000, 1);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(12, "Trắng", 38, 9000000, 10);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(12, "Đen", 39, 4000000, 5);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(12, "Xanh", 40, 4000000, 1);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(13, "Trắng", 38, 7000000, 10);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(13, "Đen", 39, 4000000, 5);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(13, "Xanh", 40, 4000000, 1);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(14, "Trắng", 38, 7000000, 10);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(14, "Đen", 39, 5000000, 5);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(14, "Xanh", 40, 6000000, 1);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(15, "Trắng", 38, 9000000, 10);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(15, "Đen", 39, 1000000, 5);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(15, "Xanh", 40, 4000000, 1);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(16, "Trắng", 38, 5000000, 10);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(16, "Đen", 39, 4000000, 5);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(16, "Xanh", 40, 4000000, 1);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(17, "Trắng", 38, 7000000, 10);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(17, "Đen", 39, 4000000, 5);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(17, "Xanh", 40, 7000000, 1);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(18, "Trắng", 38, 4000000, 10);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(18, "Đen", 39, 4000000, 5);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(18, "Xanh", 40, 5000000, 1);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(19, "Trắng", 38, 6000000, 10);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(19, "Đen", 39, 9000000, 5);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(19, "Xanh", 40, 7000000, 1);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(20, "Trắng", 38, 8000000, 10);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(20, "Đen", 39, 5000000, 5);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(20, "Xanh", 40, 2000000, 1);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(21, "Trắng", 38, 1000000, 10);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(21, "Đen", 39, 5000000, 5);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(21, "Xanh", 40, 8000000, 1);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(22, "Trắng", 38, 7000000, 10);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(22, "Đen", 39, 4000000, 5);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(22, "Xanh", 40, 5000000, 1);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(23, "Trắng", 38, 1000000, 10);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(23, "Đen", 39, 4000000, 5);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(23, "Xanh", 40, 1000000, 1);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(24, "Trắng", 38, 2000000, 10);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(24, "Đen", 39, 1000000, 5);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(24, "Xanh", 40, 5000000, 1);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(25, "Trắng", 38, 7000000, 10);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(25, "Đen", 39, 9000000, 5);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(25, "Xanh", 40, 5000000, 1);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(26, "Trắng", 38, 5000000, 10);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(26, "Đen", 39, 4000000, 5);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(26, "Xanh", 40, 5000000, 1);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(27, "Trắng", 38, 2000000, 10);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(27, "Đen", 39, 5000000, 5);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(27, "Xanh", 40, 5000000, 1);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(28, "Trắng", 38, 3000000, 10);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(28, "Đen", 39, 8000000, 5);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(28, "Xanh", 40, 5000000, 1);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(29, "Trắng", 38, 3000000, 10);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(29, "Đen", 39, 8000000, 5);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(29, "Xanh", 40, 5000000, 1);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(30, "Trắng", 38, 3000000, 10);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(30, "Đen", 39, 4000000, 5);
insert into shoes(ShoesModelID, Color, Size, UnitPrice, Quantity) value(30, "Xanh", 40, 8000000, 1);

insert into cartdetail(CustomerID, ShoesID, Quantity) value(4, 79, 2); 
insert into cartdetail(CustomerID, ShoesID, Quantity) value(4, 15, 5); 
insert into cartdetail(CustomerID, ShoesID, Quantity) value(4, 23, 2); 
insert into cartdetail(CustomerID, ShoesID, Quantity) value(1, 32, 1); 
insert into cartdetail(CustomerID, ShoesID, Quantity) value(1, 15, 3); 
insert into cartdetail(CustomerID, ShoesID, Quantity) value(1, 5, 4); 
insert into cartdetail(CustomerID, ShoesID, Quantity) value(3, 19, 4); 
insert into cartdetail(CustomerID, ShoesID, Quantity) value(1, 6, 2); 
insert into cartdetail(CustomerID, ShoesID, Quantity) value(3, 10, 1); 
insert into cartdetail(CustomerID, ShoesID, Quantity) value(1, 19, 5); 
insert into cartdetail(CustomerID, ShoesID, Quantity) value(3, 77, 5); 
insert into cartdetail(CustomerID, ShoesID, Quantity) value(1, 30, 4); 
insert into cartdetail(CustomerID, ShoesID, Quantity) value(4, 61, 5); 
insert into cartdetail(CustomerID, ShoesID, Quantity) value(2, 46, 3); 
insert into cartdetail(CustomerID, ShoesID, Quantity) value(2, 22, 4); 
insert into cartdetail(CustomerID, ShoesID, Quantity) value(4, 5, 1); 
insert into cartdetail(CustomerID, ShoesID, Quantity) value(2, 43, 3); 
insert into cartdetail(CustomerID, ShoesID, Quantity) value(2, 50, 5); 
insert into cartdetail(CustomerID, ShoesID, Quantity) value(1, 74, 3); 
insert into cartdetail(CustomerID, ShoesID, Quantity) value(4, 85, 2); 

insert into purchaseorder(CustomerID, CustomerName, Phone, Email, OrderTime, Address, OrderStatus) value(3, 'Nguyễn Văn A', '0123456789', 'demo@gmail.com', '20230309', '76, Đào Trinh Nhất, An Bình, Dĩ An, Bình Dương', 3); 
insert into purchaseorder(CustomerID, CustomerName, Phone, Email, OrderTime, Address, OrderStatus) value(2, 'Nguyễn Văn A', '0123456789', 'demo@gmail.com', '20230309', '76, Đào Trinh Nhất, An Bình, Dĩ An, Bình Dương', 4); 
insert into purchaseorder(CustomerID, CustomerName, Phone, Email, OrderTime, Address, OrderStatus) value(1, 'Nguyễn Văn A', '0123456789', 'demo@gmail.com', '20230309', '76, Đào Trinh Nhất, An Bình, Dĩ An, Bình Dương', 1); 
insert into purchaseorder(CustomerID, CustomerName, Phone, Email, OrderTime, Address, OrderStatus) value(3, 'Nguyễn Văn A', '0123456789', 'demo@gmail.com', '20230309', '76, Đào Trinh Nhất, An Bình, Dĩ An, Bình Dương', 4); 
insert into purchaseorder(CustomerID, CustomerName, Phone, Email, OrderTime, Address, OrderStatus) value(2, 'Nguyễn Văn A', '0123456789', 'demo@gmail.com', '20230309', '76, Đào Trinh Nhất, An Bình, Dĩ An, Bình Dương', 2); 
insert into purchaseorder(CustomerID, CustomerName, Phone, Email, OrderTime, Address, OrderStatus) value(3, 'Nguyễn Văn A', '0123456789', 'demo@gmail.com', '20230309', '76, Đào Trinh Nhất, An Bình, Dĩ An, Bình Dương', 3); 
insert into purchaseorder(CustomerID, CustomerName, Phone, Email, OrderTime, Address, OrderStatus) value(1, 'Nguyễn Văn A', '0123456789', 'demo@gmail.com', '20230309', '76, Đào Trinh Nhất, An Bình, Dĩ An, Bình Dương', 2); 
insert into purchaseorder(CustomerID, CustomerName, Phone, Email, OrderTime, Address, OrderStatus) value(2, 'Nguyễn Văn A', '0123456789', 'demo@gmail.com', '20230309', '76, Đào Trinh Nhất, An Bình, Dĩ An, Bình Dương', 2); 
insert into purchaseorder(CustomerID, CustomerName, Phone, Email, OrderTime, Address, OrderStatus) value(4, 'Nguyễn Văn A', '0123456789', 'demo@gmail.com', '20230309', '76, Đào Trinh Nhất, An Bình, Dĩ An, Bình Dương', 3); 
insert into purchaseorder(CustomerID, CustomerName, Phone, Email, OrderTime, Address, OrderStatus) value(3, 'Nguyễn Văn A', '0123456789', 'demo@gmail.com', '20230309', '76, Đào Trinh Nhất, An Bình, Dĩ An, Bình Dương', 3); 
insert into purchaseorder(CustomerID, CustomerName, Phone, Email, OrderTime, Address, OrderStatus) value(4, 'Nguyễn Văn A', '0123456789', 'demo@gmail.com', '20230309', '76, Đào Trinh Nhất, An Bình, Dĩ An, Bình Dương', 2); 
insert into purchaseorder(CustomerID, CustomerName, Phone, Email, OrderTime, Address, OrderStatus) value(4, 'Nguyễn Văn A', '0123456789', 'demo@gmail.com', '20230309', '76, Đào Trinh Nhất, An Bình, Dĩ An, Bình Dương', 5); 
insert into purchaseorder(CustomerID, CustomerName, Phone, Email, OrderTime, Address, OrderStatus) value(2, 'Nguyễn Văn A', '0123456789', 'demo@gmail.com', '20230309', '76, Đào Trinh Nhất, An Bình, Dĩ An, Bình Dương', 2); 
insert into purchaseorder(CustomerID, CustomerName, Phone, Email, OrderTime, Address, OrderStatus) value(2, 'Nguyễn Văn A', '0123456789', 'demo@gmail.com', '20230309', '76, Đào Trinh Nhất, An Bình, Dĩ An, Bình Dương', 1); 
insert into purchaseorder(CustomerID, CustomerName, Phone, Email, OrderTime, Address, OrderStatus) value(1, 'Nguyễn Văn A', '0123456789', 'demo@gmail.com', '20230309', '76, Đào Trinh Nhất, An Bình, Dĩ An, Bình Dương', 2); 
insert into purchaseorder(CustomerID, CustomerName, Phone, Email, OrderTime, Address, OrderStatus) value(2, 'Nguyễn Văn A', '0123456789', 'demo@gmail.com', '20230309', '76, Đào Trinh Nhất, An Bình, Dĩ An, Bình Dương', 3); 
insert into purchaseorder(CustomerID, CustomerName, Phone, Email, OrderTime, Address, OrderStatus) value(4, 'Nguyễn Văn A', '0123456789', 'demo@gmail.com', '20230309', '76, Đào Trinh Nhất, An Bình, Dĩ An, Bình Dương', 5); 
insert into purchaseorder(CustomerID, CustomerName, Phone, Email, OrderTime, Address, OrderStatus) value(4, 'Nguyễn Văn A', '0123456789', 'demo@gmail.com', '20230309', '76, Đào Trinh Nhất, An Bình, Dĩ An, Bình Dương', 3); 
insert into purchaseorder(CustomerID, CustomerName, Phone, Email, OrderTime, Address, OrderStatus) value(4, 'Nguyễn Văn A', '0123456789', 'demo@gmail.com', '20230309', '76, Đào Trinh Nhất, An Bình, Dĩ An, Bình Dương', 1); 
insert into purchaseorder(CustomerID, CustomerName, Phone, Email, OrderTime, Address, OrderStatus) value(3, 'Nguyễn Văn A', '0123456789', 'demo@gmail.com', '20230309', '76, Đào Trinh Nhất, An Bình, Dĩ An, Bình Dương', 2); 

insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (1, 20, 5000000, 1); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (1, 33, 5000000, 2); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (2, 87, 4000000, 2); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (3, 17, 5000000, 1); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (4, 30, 3000000, 2); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (4, 21, 5000000, 2); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (4, 45, 5000000, 2); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (5, 79, 3000000, 2); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (6, 41, 5000000, 2); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (6, 66, 4000000, 1); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (7, 90, 5000000, 1); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (7, 28, 4000000, 2); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (7, 34, 4000000, 2); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (8, 38, 4000000, 1); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (8, 22, 3000000, 1); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (8, 45, 3000000, 2); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (9, 18, 5000000, 2); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (10, 72, 5000000, 2); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (10, 14, 5000000, 1); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (11, 83, 4000000, 2); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (11, 16, 3000000, 2); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (11, 29, 5000000, 1); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (12, 1, 3000000, 1); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (12, 73, 3000000, 2); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (13, 11, 5000000, 1); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (14, 71, 3000000, 1); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (15, 71, 3000000, 2); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (16, 19, 3000000, 2); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (16, 61, 5000000, 1); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (17, 67, 4000000, 1); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (18, 89, 5000000, 2); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (18, 29, 3000000, 2); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (18, 90, 3000000, 1); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (19, 52, 5000000, 1); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (19, 27, 4000000, 2); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (20, 58, 5000000, 1); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (20, 37, 4000000, 1); 
insert into orderdetail(PurchaseOrderID, ShoesID, UnitPrice ,Quantity) value (20, 56, 5000000, 2); 

# generate data for rate table
insert into rate(PurchaseOrderID, ShoesID, CustomerID, RateStar, Content, RateTime, ImageLink)
(select orderdetail.PurchaseOrderID, orderdetail.ShoesID, purchaseorder.CustomerID, 
(select floor(rand()*5) + 1) as RateStar, 
(select "'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.'")
as Content,
(select now()) as RateTime,
(select elt(floor(rand() * 5 + 1), '/image/shoes1.webp', '/image/shoes2.webp', '/image/shoes3.webp', '/image/shoes4.webp', null) ) as ImageLink
from orderdetail join purchaseorder on orderdetail.PurchaseOrderID = purchaseorder.PurchaseOrderID
join shoes on shoes.ShoesID = orderdetail.ShoesID);

## Test sample data
select * from storeadmin;
select * from store;
select * from customer;
select * from shoesmodel;
select * from shoes;
select * from brand;
select * from purchaseorder;
select * from orderdetail;
select * from cartdetail;
select * from shoesmodelimage;
select * from rate;

