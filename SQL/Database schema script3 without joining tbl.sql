-- ----DROP DATABASE---- --
DROP DATABASE IF EXISTS guessthekiller;
CREATE DATABASE guessthekiller;
USE guessthekiller;

-- -----DROP TABLES----- --
DROP TABLE IF EXISTS tbl_comment;
DROP TABLE IF EXISTS tbl_game;
DROP TABLE IF EXISTS tbl_asset;
DROP TABLE IF EXISTS tbl_account;

-- -----CREATE TABLE----- --
-- MySQL doesn't use RowVersion, so i have to use TimeStamp
CREATE TABLE IF NOT EXISTS tbl_account(
acc_name VARCHAR(30) PRIMARY KEY,
acc_password CHAR(40),
acc_status VARCHAR(30),
acc_game_request VARCHAR(30),
acc_score FLOAT(10),
acc_version TIMESTAMP
)ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS tbl_asset(
asset_id INT(5) NOT NULL AUTO_INCREMENT PRIMARY KEY,
ass_name VARCHAR(30),
ass_image LONGBLOB
)ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS tbl_game(
gam_id INT (5) NOT NULL AUTO_INCREMENT PRIMARY Key,
gam_player_1 VARCHAR (30),
gam_player_2 Varchar(30),
gam_whose_turn Varchar(30),
gam_npc_picked VARCHAR (1),
gam_player_1_score FLOAT (5),
gam_player_2_score FLOAT (5),
gam_start_time DATETIME,
FOREIGN KEY fk_ac1(gam_player_1)
REFERENCES tbl_account(acc_name),
FOREIGN KEY fk_ac2(gam_player_2)
REFERENCES tbl_account(acc_name)
ON UPDATE CASCADE
ON DELETE RESTRICT
)ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS tbl_comment(
com_id int(5) not null AUTO_INCREMENT PRIMARY KEY,
com_account VARCHAR(30),
com_comment VARCHAR(255),
com_time TIME,
FOREIGN KEY fk_acc(com_account)
REFERENCES tbl_account(acc_name)
ON UPDATE CASCADE
ON DELETE RESTRICT
)ENGINE=InnoDB;
-- -----INSERT DATA----- --
INSERT
tbl_account()
VALUES
('Admin',sha1("admin123"),'offline',NULL,'0',now()),
('test',sha1("12345678"),'offline',NULL,'0',now()),
('test2',sha1("12345678"),'online',NULL,'0',now()),
('test3',sha1("12345678"),'online',NULL,'0',now());

