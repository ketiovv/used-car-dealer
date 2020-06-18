-- -----------------------------------------------------------------------
-- to copy paste
-- -----------------------------------------------------------------------
-- source D:/GitHub/used_car_dealer/used_car_dealer.sql


-- -----------------------------------------------------------------------
-- creating database
-- -----------------------------------------------------------------------
DROP DATABASE IF EXISTS used_car_dealer;
CREATE DATABASE used_car_dealer;
USE used_car_dealer;


-- -----------------------------------------------------------------------
-- creating a manufacturer table
-- -----------------------------------------------------------------------
DROP TABLE IF EXISTS car_manufacturer;
CREATE TABLE car_manufacturer
(
    manufacturer_id     TINYINT(3) UNSIGNED NOT NULL AUTO_INCREMENT,
    manufacturer_name   CHAR(25)            NOT NULL,
    manufacturer_origin CHAR(20)            NOT NULL,
    PRIMARY KEY (manufacturer_id)
)
    ENGINE = InnoDB
    DEFAULT CHARACTER SET utf8
    COLLATE = utf8_unicode_ci;

-- -----------------------------------------------------------------------
-- inserting manufacturers
-- -----------------------------------------------------------------------
INSERT INTO car_manufacturer
VALUES (1, 'Abarth', 'Italy'),
       (2, 'Acura', 'Japan'),
       (3, 'Alfa Romeo', 'Italy'),
       (4, 'AMC', 'United State'),
       (5, 'Aston Martin', 'United Kingdom'),
       (6, 'Audi', 'Germany'),
       (7, 'Austin', 'United Kingdom'),
       (8, 'Austin-Healey', 'United Kingdom'),
       (9, 'Bentley', 'United Kingdom'),
       (10, 'BMW', 'Germany'),
       (11, 'Bufori', 'United Kingdom'),
       (12, 'Bugatti', 'France'),
       (13, 'Buick', 'United States'),
       (14, 'Cadillac', 'United States'),
       (15, 'Chana', 'China'),
       (16, 'Changfeng', 'China'),
       (17, 'Chery', 'China'),
       (18, 'Chevrolet', 'United States'),
       (19, 'Chrysler', 'United States'),
       (20, 'Citroen', 'France'),
       (21, 'Dacia', 'Romania'),
       (22, 'Daewoo', 'South Korea'),
       (23, 'Daihatsu', 'Japan'),
       (24, 'Dodge', 'United States'),
       (25, 'Dongfeng', 'China'),
       (26, 'Elfin', 'Australia'),
       (27, 'Ferrari', 'Italy'),
       (28, 'Fiat', 'Italy'),
       (29, 'Ford', 'United States'),
       (30, 'GM', 'United States'),
       (31, 'GMC', 'United States'),
       (32, 'GreatWall', 'China'),
       (33, 'Hafei', 'China'),
       (34, 'Haima', 'China'),
       (35, 'Holden', 'Australia'),
       (36, 'Honda', 'Japan'),
       (37, 'Hongqi', 'China'),
       (38, 'Hummer', 'United States'),
       (39, 'Hyundai', 'South Korea'),
       (40, 'Infiniti', 'Japan'),
       (41, 'Isuzu', 'Japan'),
       (42, 'Innosson Vehicle Manufacturing', 'Nigeria'),
       (43, 'Jaguar', 'United Kingdom'),
       (44, 'Jeep', 'United States'),
       (45, 'Kia', 'South Korea'),
       (46, 'Koenigsegg', 'Sweden'),
       (47, 'Kantanka cars', 'Ghana'),
       (48, 'Lada', 'Russia'),
       (49, 'Lamborghini', 'Italy'),
       (50, 'Lancia', 'Italy'),
       (51, 'Land Rover', 'United Kingdom'),
       (52, 'Lexus', 'Japan'),
       (53, 'Leyland', 'United Kingdom'),
       (54, 'Lincoln', 'United States'),
       (55, 'Lotus', 'United Kingdom'),
       (56, 'Mahindra', 'India'),
       (57, 'Maserati', 'Italy'),
       (58, 'Maybach', 'Germany'),
       (59, 'Mazda', 'Japan'),
       (60, 'McLaren', 'United Kingdom'),
       (61, 'Mercedes-Benz', 'Germany'),
       (62, 'Mercury', 'United States'),
       (63, 'MG', 'United Kingdom'),
       (64, 'MINI', 'United Kingdom'),
       (65, 'Mitsubishi', 'Japan'),
       (66, 'Mitsuoka', 'Japan'),
       (67, 'Morgan', 'United Kingdom'),
       (68, 'Nissan', 'Japan'),
       (69, 'Oldsmobile', 'United States'),
       (70, 'Opel', 'Germany'),
       (71, 'Orion', 'Canada'),
       (72, 'Pagani', 'Italy'),
       (73, 'Perodua', 'Malaysia'),
       (74, 'Peugeot', 'France'),
       (75, 'Plymouth', 'United States'),
       (76, 'Pontiac', 'United States'),
       (77, 'Porsche', 'Germany'),
       (78, 'Proton', 'Malaysia'),
       (79, 'Ram', 'United States'),
       (80, 'Renault', 'France'),
       (81, 'Rolls-Royce', 'United Kingdom'),
       (82, 'Saab', 'Sweden'),
       (83, 'Saleen', 'United States'),
       (84, 'Saturn', 'United States'),
       (85, 'Scania', 'Sweden'),
       (86, 'Scion', 'United States'),
       (87, 'SEAT', 'Spain'),
       (88, 'Setra', 'Germany'),
       (89, 'Skoda', 'Czech Replublic'),
       (90, 'Smart', 'Germany'),
       (91, 'SsangYong', 'South Korea'),
       (92, 'Subaru', 'Japan'),
       (93, 'Suzuki', 'Japan'),
       (94, 'Tata', 'India'),
       (95, 'Tesla', 'United States'),
       (96, 'Toyota', 'Japan'),
       (97, 'Triumph', 'United Kingdom'),
       (98, 'TVR', 'United Kingdom'),
       (99, 'Vauxhall', 'United Kingdom'),
       (100, 'Volkswagen', 'Germany'),
       (101, 'Volvo', 'Sweden'),
       (102, 'Wuling', 'China'),
       (103, 'Zhongxing', 'China');


-- -----------------------------------------------------------------------
-- creating a model table
-- -----------------------------------------------------------------------
DROP TABLE IF EXISTS car_model;
CREATE TABLE car_model
(
    model_id              TINYINT(5) UNSIGNED NOT NULL AUTO_INCREMENT,
    model_name            CHAR(25)            NOT NULL,
    model_manufacturer_id TINYINT(3) UNSIGNED NOT NULL,
    PRIMARY KEY (model_id),
    FOREIGN KEY (model_manufacturer_id) REFERENCES car_manufacturer (manufacturer_id)
)
    ENGINE = InnoDB
    DEFAULT CHARACTER SET utf8
    COLLATE = utf8_unicode_ci;

-- -----------------------------------------------------------------------
-- inserting models
-- -----------------------------------------------------------------------

-- id60 - Audi
INSERT INTO car_model(model_name, model_manufacturer_id)
VALUES ('A1', 6),
       ('A2', 6),
       ('A3', 6),
       ('A4', 6),
       ('A5', 6),
       ('A6', 6),
       ('A7', 6),
       ('A8', 6),
       ('R8', 6),
       ('TT', 6),
       ('Q2', 6),
       ('Q3', 6),
       ('Q5', 6),
       ('Q7', 6),
       ('Q8', 6),
       ('80', 6),
       ('100', 6);

-- id70 - Opel
INSERT INTO car_model(model_name, model_manufacturer_id)
VALUES ('Agila', 70),
       ('Astra', 70),
       ('Calibra', 70),
       ('Combo', 70),
       ('Corsa', 70),
       ('Insignia', 70),
       ('Kadett', 70),
       ('Meriva', 70),
       ('Omega', 70),
       ('Tigra', 70),
       ('Vectra', 70),
       ('Vivaro', 70),
       ('Zafira', 70);

-- -----------------------------------------------------------------------
-- creating a car table
-- -----------------------------------------------------------------------

DROP TABLE IF EXISTS car;
CREATE TABLE car
(
    car_id       TINYINT(6) UNSIGNED NULL AUTO_INCREMENT,
    car_model_id TINYINT(5) UNSIGNED NOT NULL,
    PRIMARY KEY (car_id),
    FOREIGN KEY (car_model_id) REFERENCES car_model (model_id)
)
    ENGINE = InnoDB
    DEFAULT CHARACTER SET utf8
    COLLATE = utf8_unicode_ci;

-- -----------------------------------------------------------------------
-- inserting cars
-- -----------------------------------------------------------------------

INSERT INTO car(car_model_id)
    VALUES (1),
           (12),
           (22),
           (3),
           (30),
           (7),
           (27),
           (10),
           (20),
           (15),
           (13),
           (26),
           (17);

-- -----------------------------------------------------------------------
-- creating a customer table
-- -----------------------------------------------------------------------
/*
DROP TABLE IF EXISTS customer;
CREATE TABLE customer
(
    customer_id TINYINT UNSIGNED NOT NULL AUTO_INCREMENT,
    PRIMARY KEY (customer_id)
)
    ENGINE = InnoDB
    DEFAULT CHARACTER SET utf8
    COLLATE = utf8_unicode_ci;
*/


-- -----------------------------------------------------------------------
-- creating a transaction table
-- -----------------------------------------------------------------------
/*
DROP TABLE IF EXISTS deal;
CREATE TABLE deal
(
    deal_id TINYINT UNSIGNED NOT NULL AUTO_INCREMENT,
    PRIMARY KEY (deal_id)
)
    ENGINE = InnoDB
    DEFAULT CHARACTER SET utf8
    COLLATE = utf8_unicode_ci;
*/

-- -----------------------------------------------------------------------
-- tests
-- -----------------------------------------------------------------------

SELECT car_id as id, manufacturer_name as manufacturer, model_name as model
FROM car
         INNER JOIN car_model
                    ON car.car_model_id = car_model.model_id
         INNER JOIN car_manufacturer
                    ON car_model.model_manufacturer_id = car_manufacturer.manufacturer_id
ORDER BY car_id;
