CREATE DATABASE IF NOT EXISTS MalshinonDB;
USE MalshinonDB;
DROP TABLE IF EXISTS People;
DROP TABLE IF EXISTS IntelReports;

CREATE TABLE People(
                       id INT AUTO_INCREMENT PRIMARY KEY,
                       first_name VARCHAR(32) NOT NULL UNIQUE,
                       last_name VARCHAR(32),
                       secret_code VARCHAR(32) NOT NULL UNIQUE,
                       type ENUM('Reporter', 'Target', 'Both', 'potential_agent') NOT NULL,
                       num_reports INT DEFAULT 0,
                       num_mentions INT DEFAULT 0
);

CREATE TABLE IntelReports(
                             id_report INT AUTO_INCREMENT PRIMARY KEY,
                             reporter_id INT NOT NULL,
                             target_id INT NOT NULL,
                             text TEXT(256) NOT NULL,
                             timestamp DATETIME DEFAULT CURRENT_TIMESTAMP,
                             FOREIGN KEY (reporter_id) REFERENCES People (id),
                             FOREIGN KEY (target_id) REFERENCES People (id)
);