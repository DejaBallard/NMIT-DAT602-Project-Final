USE guessthekiller;

DELIMITER //

-- 1) Show All Online Accounts With Score and Status --
DROP PROCEDURE IF EXISTS ShowOnlinePlayers//
CREATE PROCEDURE ShowOnlinePlayers(prCurrentAccName VARCHAR(30))
BEGIN
	SELECT acc_name,acc_score,acc_status
	FROM guessthekiller.tbl_account
	WHERE acc_status != 'offline'
	AND acc_name != prCurrentAccName
    AND acc_name != 'admin';
END//
CALL ShowOnlinePlayers('deja')//



-- 2) Login
DROP FUNCTION IF EXISTS AccountLogin//
CREATE FUNCTION AccountLogin(prAccName VARCHAR(30), prAccPassword VARCHAR(30)) RETURNS Int(1)
BEGIN
DECLARE UserCorrect BOOL;
DECLARE PassCorrect Bool;
SET UserCorrect = 0;
SET PassCorrect = 0;
-- Checks if username is correct
SELECT EXISTS 
	(SELECT *
	FROM guessthekiller.tbl_account
	WHERE acc_name = prAccName)
	INTO UserCorrect;
    
-- Checks if password is correct
SELECT EXISTS 
	(SELECT *
	FROM guessthekiller.tbl_account
	WHERE acc_name = prAccName
    AND acc_password = sha1(prAccPassword))
	INTO PassCorrect;
    
IF UserCorrect = 1 AND PassCorrect = 1 THEN
CALL SetAccountStatus(prAccName,'2');
	RETURN '2';
    
ELSE IF UserCorrect = 1 AND PassCorrect = 0 Then
	RETURN '1';
    
ELSE
	RETURN '0';
END IF;
END IF;
END//
SELECT AccountLogin('admin','admin')//

DROP FUNCTION IF EXISTS PlayerExists//
CREATE FUNCTION PlayerExists(prAccName Varchar(30)) RETURNS TINYINT
BEGIN
IF((SELECT acc_name FROM tbl_account WHERE acc_name = prAccName) = 1) THEN
RETURN row_count();
ELSE RETURN 0;
END If;
END//

-- 3) Register
DROP FUNCTION IF EXISTS AccountRegister//
CREATE FUNCTION AccountRegister(prAccName VARCHAR(30), prAccPassword VARCHAR(30), prAccScore VARCHAR (10)) RETURNS TINYINT
BEGIN
-- Checks to see if User already exists
IF (SELECT PlayerExists(prAccName) = 1) THEN
	RETURN row_count();
    
-- Creates user
ELSE
	
	INSERT INTO tbl_account (acc_name,acc_password,acc_score,acc_game_request)
	VALUE (prAccName,sha1(prAccPassword),prAccScore,NULL);
    CALL SetAccountStatus(prAccName,'2');
	RETURN row_count();
END IF;
END//
SELECT AccountRegister ('6','1','0')//



-- 4) Log off
DROP FUNCTION IF EXISTS AccountLogOff//
CREATE FUNCTION AccountLogOff(prAccName VARCHAR(30)) RETURNS TINYINT
BEGIN
CALL SetAccountStatus(prAccname,'1');
RETURN row_count();
END//

Select AccountLogOff ('1')//



-- 6) Delete Player
DROP FUNCTION IF EXISTS DeleteAccount//
CREATE FUNCTION DeleteAccount (prAccName VARCHAR(30))RETURNS tinyint
BEGIN
DELETE FROM tbl_account
WHERE acc_name = prAccName;
RETURN row_count();
END//
SELECT DeleteAccount ('tim')//




-- 7) Update Player
DROP FUNCTION IF EXISTS UpdateAccount//
CREATE FUNCTION UpdateAccount (prAccName VARCHAR (30), prNewPass Varchar (30),prNewScore FLOAT(10), prVersion VARCHAR (40)) RETURNS TINYINT
BEGIN
UPDATE tbl_account
-- 				   IF (CONDITION, DO THIS, ELSE THIS) --
SET acc_password = IF(prNewPass ='',sha1(acc_password),sha1(prNewPass)),
acc_score = IF (prNewScore ='',acc_score,acc_score + prNewScore)
WHERE acc_name = prAccName AND acc_version = prVersion;
RETURN row_count();
END//
SELECT UpdateAccount ('1','222','10','2018-05-16 10:44:55')//

-- 8) Get Version before updating
DROP FUNCTION IF EXISTS GetVersion//
CREATE FUNCTION GetVersion (prName Varchar(30)) returns varchar(30)
BEGIN
RETURN (select acc_version
FROM tbl_account
WHERE acc_name = prname);
END//


-- 9) Clear Game
DROP FUNCTION IF EXISTS DeleteGame//
CREATE FUNCTION DeleteGame(prAccName VARCHAR(30)) RETURNS TINYINT
BEGIN
DELETE
FROM tbl_game
WHERE gam_player_1 = prAccName
OR gam_player_2 = prAccName;
RETURN row_count();
END//

SELECT DeleteGame('2')//


-- 10) Setting Account Status --
DROP PROCEDURE IF EXISTS SetAccountStatus//
CREATE PROCEDURE SetAccountStatus (prAccName VARCHAR(30), prStatus INT(1))
BEGIN
if prStatus = 1 THEN
	UPDATE tbl_account
	SET acc_status = 'offline'
	WHERE acc_name = prAccName;
ELSE IF prStatus = 2 THEN
	UPDATE tbl_account
	SET acc_status = 'online'
	WHERE acc_name = prAccName;
ELSE
	UPDATE tbl_account
	SET acc_status = 'in game'
	WHERE acc_name = prAccName;
END If;
END If;
END//
-- 10.1) Setting Account status. for some reason it wont run from application unless in a function
DROP FUNCTION IF EXISTS ChangeStatus//
CREATE FUNCTION ChangeStatus (prName VARCHAR (30), prType VARCHAR (30)) RETURNS varchar(1)
BEGIN
Call SetAccountStatus(prName,prType);
Return 1;
END//

-- Sends the users name into the oponents records as a request
DROP FUNCTION IF EXISTS SendRequest//
CREATE FUNCTION SendRequest (prName VARCHAR(30), prOppName VARCHAR (30)) Returns VARCHAR (30)
BEGIN
UPDATE tbl_account
SET acc_game_request = prName
WHERE acc_name = prOppName;
RETURN prName;
END//

Select SendRequest(1,2)//

-- Checks if the user has a request from anyone
DROP FUNCTION IF EXISTS HaveRequest//
CREATE FUNCTION HaveRequest(prName VARCHAR(30)) Returns VARCHAR (30)
BEGIN
return (Select acc_game_request
FROM tbl_account
WHERE acc_name = prName);
END//

select HaveRequest('2')//


-- Show all players for admin editing
DROP PROCEDURE ShowPlayers//
CREATE PROCEDURE ShowPlayers()
BEGIN
SELECT acc_name, acc_status
FROM tbl_account
WHERE acc_name != 'admin';
END//

-- Show all games for admin editing
DROP PROCEDURE IF EXISTS ShowGames//
CREATE PROCEDURE ShowGames()
BEGIN
SELECT gam_player_1, gam_player_2, gam_start_time
FROM tbl_game;
END//


-- Gets the users score
DROP FUNCTION IF EXISTS GetScore//
CREATE FUNCTION GetScore(prName Varchar (30)) returns FLOAT(10)
BEGIN
RETURN (select acc_score
FROM tbl_account
WHERE acc_name = prName);
END//

-- Create game
DROP FUNCTION IF EXISTS CreateGame//
CREATE FUNCTION CreateGame( prOppName VARCHAR(30), prName VARCHAR(30)) returns tinyint
BEGIN
insert tbl_game(gam_player_1,gam_player_2,gam_npc_picked,gam_start_time,gam_player_1_score,gam_player_2_score,gam_whose_turn)
Values (prOppname, prName,(RAND()*(5-1+1))+1,Now(),0,0,prOppname);
return row_count();
END//

select CreateGame ('1','2')//


-- Collect the Answer 
DROP FUNCTION IF EXISTS GetNpcPicks//
CREATE FUNCTION GetNpcPicks (prName Varchar(30)) returns varchar(3)
BEGIN
RETURN(SELECT gam_npc_picked
FROM tbl_game
WHERE gam_player_1 = prName
OR gam_player_2 = prName);
END//

SELECT GetNpcPicks ('1')//

-- Player one picked
DROP FUNCTION IF EXISTS PlayerOnePicked//
CREATE FUNCTION PlayerOnePicked (prName Varchar(30), prPicked varchar(3))returns VARCHAR (3)
begin
UPDATE tbl_game
SET gam_player_1_picked = concat(gam_player_1_picked,prPicked)
WHERE gam_player_1 = prName;
Return (SELECT gam_player_1_picked
FROM tbl_game
WHERE gam_player_1 = prName);
end//

SELECT playerOnePicked('1','1')//

DROP FUNCTION IF EXISTS PlayerTwoPicked//
CREATE FUNCTION PlayerTwoPicked (prName Varchar(30), prPicked varchar(3))returns VARCHAR (3)
begin
UPDATE tbl_game
SET gam_player_2_picked = concat(gam_player_2_picked,prPicked)
WHERE gam_player_2 = prName;
Return (SELECT gam_player_2_picked
FROM tbl_game
WHERE gam_player_2 = prName);
end//
SELECT playerTwoPicked('2','1')//

DROP FUNCTION IF EXISTS Set1Score//
CREATE FUNCTION Set1Score (prName varchar(30),prScore varchar(30)) Returns varchar(1)
BEGIN
UPDATE tbl_game
SET gam_player_1_score = prScore
WHERE gam_player_1 = prName;
return 1;
END//
select setScore('deja','2')//

DROP FUNCTION IF EXISTS Set2Score//
CREATE FUNCTION Set2Score (prName varchar(30),prScore varchar(30)) Returns varchar(1)
BEGIN
UPDATE tbl_game
SET gam_player_2_score = prScore
WHERE gam_player_2 = prName;
return 1;
END//


DROP FUNCTION IF EXISTS IsGameActive//
CREATE FUNCTION IsGameActive (prName Varchar(30)) returns varchar(1)
BEGIN
	RETURN(SELECT COUNT(*)
    FROM tbl_game
WHERE gam_player_1 = prName
OR gam_player_2 = prName);
END//

SELECT isgameactive ('deja')//


DROP FUNCTION IF EXISTS GetGame1Score//
CREATE FUNCTION GetGame1Score(prName Varchar (30)) returns FLOAT(10)
BEGIN
RETURN (select gam_player_1_score
FROM tbl_game
WHERE gam_player_1 = prName);
END//


DROP FUNCTION IF EXISTS GetGame2Score//
CREATE FUNCTION GetGame2Score(prName Varchar (30)) returns FLOAT(10)
BEGIN
RETURN (select gam_player_2_score
FROM tbl_game
WHERE gam_player_2 = prName);
END//


DROP PROCEDURE IF EXISTS DeleteComments//
CREATE PROCEDURE DeleteComments()
BEGIN
DELETE FROM tbl_comment
  WHERE com_id <= (
    SELECT com_id
    FROM (
      SELECT com_id
      FROM tbl_comment
      ORDER BY com_id DESC
      LIMIT 1 OFFSET 10 -- keep this many records
     )foo
  );
END//

call deletecomments()//

DROP PROCEDURE IF EXISTS GetComments//
CREATE PROCEDURE GetComments ()
BEGIN
SELECT * FROM (
    SELECT * FROM tbl_comment ORDER BY com_id DESC LIMIT 10
) sub
ORDER BY com_id ASC;
END//

CALL GetComments()//


DROP FUNCTION IF EXISTS InsertComment//
CREATE FUNCTION InsertComment (prName Varchar (30), prComment Varchar(255)) returns VARCHAR (1)
BEGIN
insert tbl_comment (com_account,com_comment,com_time)
VALUE (prName,prComment,now());
return row_count();
END//

SELECT InsertComment ('q','	1')//



DROP FUNCTION IF EXISTS GetTurn//
CREATE FUNCTION GetTurn (prName VARCHAR(30)) Returns VARCHAR(30)
BEGIN
return (SELECT gam_whose_turn
FROM tbl_game
where gam_player_1 = prName
OR gam_player_2 = prName);
END//

DROP FUNCTION IF EXISTS UpdateTurn//
CREATE FUNCTION UpdateTurn (prName VARCHAR(30)) Returns VARCHAR(30)
BEGIN
UPDATE tbl_game
set gam_whose_turn = prName
WHERE gam_player_1 = prName
OR gam_player_2 = prName;
RETURN row_count();
END//

select GetTurn('2')//

DROP FUNCTION IF EXISTS GetPlayerOne//
CREATE FUNCTION GetPlayerOne (prName VARCHAR(30)) Returns VARCHAR(30)
BEGIN
return (SELECT gam_player_1
FROM tbl_game
where gam_player_1 = prName
OR gam_player_2 = prName);
END//

select GetPlayerOne('2')//
DELIMITER ;
-- Procedures are called --
SELECT UpdateComments();

CALL ShowPlayers;

CALL ShowGames;

-- Functions are seleted --


