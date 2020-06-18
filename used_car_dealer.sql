DROP DATABASE IF EXISTS used_car_dealer;
CREATE DATABASE used_car_dealer;
USE used_car_dealer;


-- -----------------------------------------------------------------------
-- creating a manufacturer table
-- -----------------------------------------------------------------------
DROP TABLE IF EXISTS car_manufacturer;
CREATE TABLE car_manufacturer
(
    manufacturer_id   TINYINT(3) UNSIGNED NOT NULL AUTO_INCREMENT,
    manufacturer_name CHAR(25)            NOT NULL,
    PRIMARY KEY (manufacturer_id)
)
    ENGINE = InnoDB
    DEFAULT CHARACTER SET utf8
    COLLATE = utf8_unicode_ci;

-- -----------------------------------------------------------------------
-- inserting manufacturers
-- -----------------------------------------------------------------------
INSERT INTO car_manufacturer
VALUES (1, 'Audi'),
       (2, 'Fiat'),
       (3, 'Opel');



-- -----------------------------------------------------------------------
-- creating a model table
-- -----------------------------------------------------------------------
DROP TABLE IF EXISTS car_model;
CREATE TABLE car_model
(
    model_id   TINYINT(3) UNSIGNED NOT NULL AUTO_INCREMENT,
    model_name CHAR(25)            NOT NULL,
    model_manufacturer_id TINYINT(3) UNSIGNED NOT NULL,
    PRIMARY KEY (model_id),
    FOREIGN KEY (model_manufacturer_id) REFERENCES car_manufacturer (manufacturer_id)
)
    ENGINE = InnoDB
    DEFAULT CHARACTER SET utf8
    COLLATE = utf8_unicode_ci;

-- -----------------------------------------------------------------------
-- inserting manufacturers
-- -----------------------------------------------------------------------
INSERT INTO car_model
VALUES (1,'A4',1),
       (2,'A3',1),
       (3,'80',1),
       (4,'Panda',2),
       (5,'Punto',2),
       (6,'Stilo',2),
       (7,'Astra',3),
       (8,'Vectra',3),
       (9,'Zafira',3);



-- -----------------------------------------------------------------------
-- creating a car table
-- -----------------------------------------------------------------------

DROP TABLE IF EXISTS car;
CREATE TABLE car
(
    car_id              TINYINT(3) UNSIGNED NULL AUTO_INCREMENT,
    car_model_id        TINYINT(3) UNSIGNED NOT NULL,
    PRIMARY KEY (car_id),
    FOREIGN KEY (car_model_id) REFERENCES car_model (model_id)
)
    ENGINE = InnoDB
    DEFAULT CHARACTER SET utf8
    COLLATE = utf8_unicode_ci;

-- -----------------------------------------------------------------------
-- inserting manufacturers
-- -----------------------------------------------------------------------
INSERT INTO car
VALUES (1,1),
       (2,4),
       (3,6),
       (4,2),
       (5,9);



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

SELECT car_id, model_name,manufacturer_name
FROM car
INNER JOIN car_model
ON car.car_model_id = car_model.model_id
INNER JOIN car_manufacturer
ON car_model.model_manufacturer_id = car_manufacturer.manufacturer_id;
