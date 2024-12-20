CREATE TABLE Utilisateur(
   id_utilisateur SERIAL,
   email VARCHAR(255) ,
   nom VARCHAR(50) ,
   prénom VARCHAR(50) ,
   PRIMARY KEY(id_utilisateur)
);

CREATE TABLE TransactionMonnaie(
   id_transaction SERIAL,
   montant MONEY,
   isEntrée BOOLEAN,
   id_utilisateur INTEGER NOT NULL,
   PRIMARY KEY(id_transaction),
   FOREIGN KEY(id_utilisateur) REFERENCES Utilisateur(id_utilisateur)
);

CREATE TABLE Transaction_Crypto(
   id_transaction_crypto SERIAL,
   montant MONEY NOT NULL,
   isEntrée VARCHAR(50) ,
   PRIMARY KEY(id_transaction_crypto)
);

CREATE TABLE Cryptomonnaie(
   id_cryptomonnaie SERIAL,
   nom_crypto VARCHAR(50) ,
   valeur_initiale MONEY,
   PRIMARY KEY(id_cryptomonnaie)
);

CREATE TABLE Variation_Cryptomonnaie(
   id_variation_cryptomonnaie SERIAL,
   variation NUMERIC(3,2)  ,
   id_cryptomonnaie INTEGER NOT NULL,
   PRIMARY KEY(id_variation_cryptomonnaie),
   FOREIGN KEY(id_cryptomonnaie) REFERENCES Cryptomonnaie(id_cryptomonnaie)
);

CREATE TABLE Porte_Feuille(
   id_porte_feuille SERIAL,
   id_cryptomonnaie INTEGER NOT NULL,
   id_utilisateur INTEGER NOT NULL,
   PRIMARY KEY(id_porte_feuille),
   FOREIGN KEY(id_cryptomonnaie) REFERENCES Cryptomonnaie(id_cryptomonnaie),
   FOREIGN KEY(id_utilisateur) REFERENCES Utilisateur(id_utilisateur)
);

CREATE TABLE Asso_2(
   id_porte_feuille INTEGER,
   id_transaction_crypto INTEGER,
   PRIMARY KEY(id_porte_feuille, id_transaction_crypto),
   FOREIGN KEY(id_porte_feuille) REFERENCES Porte_Feuille(id_porte_feuille),
   FOREIGN KEY(id_transaction_crypto) REFERENCES Transaction_Crypto(id_transaction_crypto)
);
