/* TABLEを作成 */
CREATE TABLE ft_user (
    user_id int,-- ユーザID
    login_id varchar(30),-- ログインID
    name varchar(30),-- 名前
    password varchar(64)-- パスワード
);

CREATE TABLE ft_food (
    food_id int,-- ご飯ID
    name varchar(30)-- 名前
);

CREATE TABLE ft_user_food (
    user_id int,-- ユーザID
    food_id int,-- ご飯ID
    name varchar(30),-- 名前
    entry_date timestamp-- 登録時刻
);

INSERT INTO
    public .ft_user (user_id, login_id, "name", "password")
VALUES
(1, 'user1', '田中', '1qaz2wsx');

INSERT INTO
    public .ft_food (food_id, "name")
VALUES
(1, '米');

INSERT INTO
    public .ft_user_food (user_id, food_id, "name", entry_date)
VALUES
(1, 1, '白米', '20200525');