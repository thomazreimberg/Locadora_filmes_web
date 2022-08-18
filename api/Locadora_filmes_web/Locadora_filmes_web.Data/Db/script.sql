CREATE DATABASE IF NOT EXISTS
    Locadora_filmes_web;

USE Locadora_filmes_web;

CREATE TABLE IF NOT EXISTS Cliente (
  Id INT NOT NULL AUTO_INCREMENT,
  Nome VARCHAR(200) NULL,
  Cpf VARCHAR(11) NULL,
  DataNascimento DATETIME NULL,
  PRIMARY KEY (Id));

CREATE TABLE IF NOT EXISTS Filme (
  Id INT NOT NULL AUTO_INCREMENT,
  Titulo VARCHAR(100) NULL,
  ClassificacaoIndicada INT NULL,
  Lancamento TINYINT NULL,
  PRIMARY KEY (Id));


CREATE TABLE IF NOT EXISTS Locacao (
  Id INT NOT NULL AUTO_INCREMENT,
  Id_cliente INT NULL,
  Id_filme INT NULL,
  DataLocacao DATETIME NULL,
  DataDevolucao DATETIME NULL,
  PRIMARY KEY (Id),
  INDEX Fk_cliente_idx (Id_cliente ASC) VISIBLE,
  INDEX Fk_filme_idx (Id_filme ASC) VISIBLE,
  CONSTRAINT Fk_cliente
    FOREIGN KEY (Id_cliente)
    REFERENCES Cliente (Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT Fk_filme
    FOREIGN KEY (Id_filme)
    REFERENCES Filme (Id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

INSERT INTO Cliente (Nome, Cpf, DataNascimento) VALUES ('Thomaz', '67621573007', (curdate()));
INSERT INTO Cliente (Nome, Cpf, DataNascimento) VALUES ('Henrique', '96572293084', (curdate() - INTERVAL 18 year));

INSERT INTO Filme (Titulo, ClassificacaoIndicada, Lancamento) VALUES ('Como treinar o seu dragão.', 1, true);
INSERT INTO Filme (Titulo, ClassificacaoIndicada, Lancamento) VALUES ('Vingadores', 1, true);
INSERT INTO Filme (Titulo, ClassificacaoIndicada, Lancamento) VALUES ('Homem de ferro', 1, true);
INSERT INTO Filme (Titulo, ClassificacaoIndicada, Lancamento) VALUES ('Terror', 18, true);
