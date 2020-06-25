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
    manufacturer_id     INT UNSIGNED NOT NULL AUTO_INCREMENT,
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
    model_id              INT UNSIGNED NOT NULL AUTO_INCREMENT,
    model_name            CHAR(25)            NOT NULL,
    model_manufacturer_id INT UNSIGNED NOT NULL,
    PRIMARY KEY (model_id),
    FOREIGN KEY (model_manufacturer_id) REFERENCES car_manufacturer (manufacturer_id)
)
    ENGINE = InnoDB
    DEFAULT CHARACTER SET utf8
    COLLATE = utf8_unicode_ci;

-- -----------------------------------------------------------------------
-- inserting models
-- -----------------------------------------------------------------------

-- id6 - Audi
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

-- id20 - Citroen
INSERT INTO car_model(model_name, model_manufacturer_id)
VALUES ('Berlingo', 20),
       ('C1', 20),
       ('C2', 20),
       ('C3', 20),
       ('C4', 20),
       ('C5', 20),
       ('C6', 20),
       ('C7', 20),
       ('C8', 20),
       ('DS3', 20),
       ('DS4', 20),
       ('DS5', 20),
       ('Saxo', 20),
       ('Xsara Picasso', 20);

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

-- id89 - Skoda
INSERT INTO car_model(model_name, model_manufacturer_id)
VALUES ('Citigo', 89),
       ('Fabia', 89),
       ('Felicia', 89),
       ('Kamiq', 89),
       ('Karoq', 89),
       ('Kodiaq', 89),
       ('Octavia', 89),
       ('Rapid', 89),
       ('Scala', 89),
       ('SuperB', 89),
       ('Yeti', 89);

-- id3 - Alfa Romeo
INSERT INTO car_model(model_name, model_manufacturer_id)
VALUES ('147', 3),
       ('156', 3),
       ('159', 3),
       ('Brera', 3),
       ('Giulia', 3),
       ('Giulietta', 3),
       ('GT', 3),
       ('Mito', 3),
       ('Spider', 3),
       ('Stelvio', 3);
       
-- id10 - BMW
INSERT INTO car_model(model_name, model_manufacturer_id)
VALUES ('3GT', 10),
       ('i3', 10),
       ('M3', 10),
       ('M5', 10),
       ('Seria 1', 10),
       ('Seria 3', 10),
       ('Seria 5', 10),
       ('Seria 7', 10),
       ('X3', 10),
       ('X5', 10),
       ('X6', 10);
       
-- id18 - Chevrolet
INSERT INTO car_model(model_name, model_manufacturer_id)
VALUES ('Aveo', 18),
       ('Camaro', 18),
       ('Captiva', 18),
       ('Corvette', 18),
       ('Cruze', 18),
       ('Kalos', 18),
       ('Matiz', 18),
       ('Orlando', 18),
       ('Spark', 18),
       ('Trax', 18);

-- id21 - Dacia
INSERT INTO car_model(model_name, model_manufacturer_id)
VALUES ('Dokker', 21),
       ('Duster', 21),
       ('Lodgy', 21),
       ('Logan', 21),
       ('Sandero', 21),
       ('Sandero Stepway', 21);

-- id28 - Fiat
INSERT INTO car_model(model_name, model_manufacturer_id)
VALUES ('125p', 28),
       ('500', 28),
       ('Bravo', 28),
       ('Cinquecento', 28),
       ('Doblo', 28),
       ('Grande Punto', 28),
       ('Panda', 28),
       ('Punto', 28),
       ('Seicento', 28),
       ('Stilo', 28),
       ('Tipo', 28);
       
-- id29 - Ford
INSERT INTO car_model(model_name, model_manufacturer_id)
VALUES ('C-MAX', 29),
       ('EcoSport', 29),
       ('EDGE', 29),
       ('Fiesta', 29),
       ('Focus', 29),
       ('Fusion', 29),
       ('Galaxy', 29),
       ('Kuga', 29),
       ('Mondeo', 29),
       ('Mustang', 29),
       ('S-Max', 29);

-- id36 - Honda
INSERT INTO car_model(model_name, model_manufacturer_id)
VALUES ('Accord', 36),
       ('City', 36),
       ('Civic', 36),
       ('CR-V', 36),
       ('FR-V', 36),
       ('HR-V', 36),
       ('Insight', 36),
       ('Jazz', 36),
       ('Odyssey', 36);
       
-- id39 - Hyundai
INSERT INTO car_model(model_name, model_manufacturer_id)
VALUES ('Coupe', 39),
       ('Elantra', 39),
       ('Getz', 39),
       ('M5', 39),
       ('i10', 39),
       ('i20', 39),
       ('i30', 39),
       ('i40', 39),
       ('ix35', 39),
       ('Santa Fe', 39),
       ('Tucson', 39);
       
-- id44 - Jeep
INSERT INTO car_model(model_name, model_manufacturer_id)
VALUES ('Cherokee', 44),
       ('Commander', 44),
       ('Compass', 44),
       ('Grand Cherokee', 44),
       ('Liberty', 44),
       ('Patriot', 44),
       ('Renegade', 44),
       ('Wrangler', 44);

-- id45 - Kia
INSERT INTO car_model(model_name, model_manufacturer_id)
VALUES ('Carens', 45),
       ('Ceed', 45),
       ('Niro', 45),
       ('Optima', 45),
       ('Picanto', 45),
       ('Pro_cee d', 45),
       ('Rio', 45),
       ('Sorento', 45),
       ('Sportage', 45),
       ('Stonic', 45),
       ('Venga', 45);
       
-- id59 - Mazda
INSERT INTO car_model(model_name, model_manufacturer_id)
VALUES ('2', 59),
       ('3', 59),
       ('5', 59),
       ('6', 59),
       ('CX-3', 59),
       ('CX-5', 59),
       ('CX-7', 59),
       ('MX-5', 59),
       ('Premacy', 59);
       
-- id61 - Mercedes-Benz
INSERT INTO car_model(model_name, model_manufacturer_id)
VALUES ('CLA', 61),
       ('CLS', 61),
       ('GLA', 61),
       ('GLC', 61),
       ('GLE', 61),
       ('Klasa A', 61),
       ('Klasa B', 61),
       ('Klasa C', 61),
       ('Klasa E', 61),
       ('Klasa S', 61),
       ('ML', 61);
       
-- id68 - Nissan
INSERT INTO car_model(model_name, model_manufacturer_id)
VALUES ('Almera', 68),
       ('Juke', 68),
       ('Leaf', 68),
       ('Micra', 68),
       ('Navara', 68),
       ('Note', 68),
       ('Patrol', 68),
       ('Primera', 68),
       ('Qashqai', 68),
       ('Qashqai+2', 68),
       ('X-Trail', 68);
       
-- id74 - Peugot
INSERT INTO car_model(model_name, model_manufacturer_id)
VALUES ('2008', 74),
       ('206', 74),
       ('207', 74),
       ('208', 74),
       ('3008', 74),
       ('307', 74),
       ('308', 74),
       ('407', 74),
       ('5008', 74),
       ('508', 74),
       ('Partner', 74);
       
-- id93 - Suzuki
INSERT INTO car_model(model_name, model_manufacturer_id)
VALUES ('Baleno', 93),
       ('Grand Vitara', 93),
       ('Ignis', 93),
       ('Jimny', 93),
       ('Splash', 93),
       ('Swift', 93),
       ('SX4', 93),
       ('SX4 S-Cross', 93),
       ('Vitara', 93);

-- id96 - Toyota
INSERT INTO car_model(model_name, model_manufacturer_id)
VALUES ('Auris', 96),
       ('Avensis', 96),
       ('Aygo', 96),
       ('C-HR', 96),
       ('Corolla', 96),
       ('Corolla Verso', 96),
       ('Land Cruiser', 96),
       ('Prius', 96),
       ('RAV4', 96),
       ('Verso', 96),
       ('Yaris', 96);

-- id100 - Volkswagen
INSERT INTO car_model(model_name, model_manufacturer_id)
VALUES ('Caddy', 100),
       ('Caravelle', 100),
       ('Golf', 100),
       ('Golf Plus', 100),
       ('Jetta', 100),
       ('Multivan', 100),
       ('Passat', 100),
       ('Polo', 100),
       ('Tiguran', 100),
       ('Touran', 100),
       ('Vento', 100);
       
 -- id101 - Volvo
INSERT INTO car_model(model_name, model_manufacturer_id)
VALUES ('S40', 101),
       ('S60', 101),
       ('S80', 101),
       ('S90', 101),
       ('V40', 101),
       ('V50', 101),
       ('V60', 101),
       ('V70', 101),
       ('XC 40', 101),
       ('XC 60', 101),
       ('XC 90', 101);

-- -----------------------------------------------------------------------
-- creating a car table
-- -----------------------------------------------------------------------

DROP TABLE IF EXISTS car;
CREATE TABLE car
(
    car_id              INT UNSIGNED                                                           NULL AUTO_INCREMENT,
    car_model_id        INT UNSIGNED                                                           NOT NULL,

    car_price           INT UNSIGNED                                                           NOT NULL,

    car_type            ENUM ('coupe','hatchback','minivan','pickup','sedan','suv','van','wagon') NOT NULL,
    car_color           CHAR(20)                                                                  NOT NULL, -- maybe new table?

    car_mileage         INT UNSIGNED                                                       NOT NULL,
    car_year_from       INT UNSIGNED                                                       NOT NULL,

    car_engine_capacity INT UNSIGNED                                                       NOT NULL,
    car_fuel            ENUM ('diesel','petrol','petrol-gas','petrol-electric','electric'),
    car_power           INT UNSIGNED                                                       NOT NULL,
    car_transmission    ENUM ('automatic','semi-automatic','manual')                              NOT NULL,

    PRIMARY KEY (car_id),
    FOREIGN KEY (car_model_id) REFERENCES car_model (model_id)
)
    ENGINE = InnoDB
    DEFAULT CHARACTER SET utf8
    COLLATE = utf8_unicode_ci;

-- -----------------------------------------------------------------------
-- inserting cars
-- -----------------------------------------------------------------------

INSERT INTO car
VALUES (1, 31, 5000, 'minivan', 'silver', 215000, 2005, 1997, 'diesel', 90, 'manual'),
       (2, 44, 7500, 'minivan', 'black', 220000, 2004, 2172, 'diesel', 125, 'manual');

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

SELECT car_id as id, manufacturer_name as manufacturer, model_name as model, car_price as price
FROM car
         INNER JOIN car_model
                    ON car.car_model_id = car_model.model_id
         INNER JOIN car_manufacturer
                    ON car_model.model_manufacturer_id = car_manufacturer.manufacturer_id
ORDER BY car_id;

