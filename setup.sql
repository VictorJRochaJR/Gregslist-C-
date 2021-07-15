CREATE TABLE  cars(
  id int NOT NULL primary key AUTO_INCREMENT comment 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'create time',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'update time',
  name varchar(255) comment 'Make',
  name varchar(255) comment 'Model',
  year int COMMENT 'Year',
  price int COMMENT 'Price'
) default charset utf8 comment '';


            INSERT INTO cars(make, model, year, price)
            VALUES("toyota", "corolla", 91, 3000);
            SELECT  LAST_INSERT_ID();

            SELECT * FROM cars;            