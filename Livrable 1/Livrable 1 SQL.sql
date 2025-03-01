USE LivInParis;

-- Table Client
CREATE TABLE Client (
    id_client INT PRIMARY KEY AUTO_INCREMENT,
    nom VARCHAR(100) NOT NULL,
    prenom VARCHAR(100) NOT NULL,
    adresse VARCHAR(255) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    telephone VARCHAR(20) UNIQUE NOT NULL,
    note_moyenne DECIMAL(3,2) DEFAULT 0,
    mot_de_passe VARCHAR(255) NOT NULL
);

-- Table Cuisinier
CREATE TABLE Cuisinier (
    id_cuisinier INT PRIMARY KEY AUTO_INCREMENT,
    nom VARCHAR(100) NOT NULL,
    prenom VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    telephone VARCHAR(20) UNIQUE NOT NULL,
    adresse VARCHAR(255) NOT NULL,
    specialite_culinaire VARCHAR(100),
    note_moyenne DECIMAL(3,2) DEFAULT 0
);

-- Table Plat
CREATE TABLE Plat (
    id_plat INT PRIMARY KEY AUTO_INCREMENT,
    nom VARCHAR(100) NOT NULL,
    photo VARCHAR(255),
    nombre_personne INT NOT NULL,
    type_plat VARCHAR(50) NOT NULL,
    nationalite_plat VARCHAR(50) NOT NULL,
    prix DECIMAL(10,2) NOT NULL,
    ingredients TEXT NOT NULL,
    temps_livraison INT NOT NULL,
    date_peremption DATE NOT NULL
);

-- Table Commande
CREATE TABLE Commande (
    id_commande INT PRIMARY KEY AUTO_INCREMENT,
    id_client INT NOT NULL,
    id_cuisinier INT NOT NULL,
    date_heure_commande DATETIME NOT NULL,
    nombre_portion INT NOT NULL,
    statut_commande ENUM('En attente', 'En cours', 'Livré', 'Annulé') DEFAULT 'En attente',
    adresse_livraison VARCHAR(255) NOT NULL,
    FOREIGN KEY (id_client) REFERENCES Client(id_client),
    FOREIGN KEY (id_cuisinier) REFERENCES Cuisinier(id_cuisinier)
);

-- Table Notation
CREATE TABLE Notation (
    id_notation INT PRIMARY KEY AUTO_INCREMENT,
    id_client INT NOT NULL,
    id_cuisinier INT NOT NULL,
    note_attribuee DECIMAL(2,1) CHECK (note_attribuee BETWEEN 0 AND 5),
    commentaire TEXT,
    date_note DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (id_client) REFERENCES Client(id_client),
    FOREIGN KEY (id_cuisinier) REFERENCES Cuisinier(id_cuisinier)
);

-- Table relationnelle entre Cuisinier et Plat
CREATE TABLE Cuisiner (
    id_cuisinier INT NOT NULL,
    id_plat INT NOT NULL,
    PRIMARY KEY (id_cuisinier, id_plat),
    FOREIGN KEY (id_cuisinier) REFERENCES Cuisinier(id_cuisinier),
    FOREIGN KEY (id_plat) REFERENCES Plat(id_plat)
);

-- Requêtes de test pour insérer des données d'exemple
INSERT INTO Client (nom, prenom, adresse, email, telephone, mot_de_passe) VALUES
('Dupont', 'Jean', '12 Rue de Paris', 'jean.dupont@email.com', '0600000000', 'mdp123');

INSERT INTO Cuisinier (nom, prenom, adresse, email, telephone, specialite_culinaire) VALUES
('Martin', 'Sophie', '20 Rue de Lyon', 'sophie.martin@email.com', '0611111111', 'Cuisine Française');

INSERT INTO Plat (nom, nombre_personne, type_plat, nationalite_plat, prix, ingredients, temps_livraison, date_peremption) VALUES
('Ratatouille', 2, 'Plat principal', 'Française', 12.50, 'Aubergines, Courgettes, Poivrons', 30, '2025-03-10');

INSERT INTO Commande (id_client, id_cuisinier, date_heure_commande, nombre_portion, statut_commande, adresse_livraison) VALUES
(1, 1, NOW(), 2, 'En attente', '12 Rue de Paris');

INSERT INTO Notation (id_client, id_cuisinier, note_attribuee, commentaire) VALUES
(1, 1, 4.5, 'Très bon repas !');

INSERT INTO Cuisiner (id_cuisinier, id_plat) VALUES (1, 1);

-- Quelques requêtes de test
SELECT * FROM Client;
SELECT * FROM Cuisinier;
SELECT * FROM Commande WHERE statut_commande = 'En attente';
SELECT AVG(note_attribuee) AS moyenne_notes FROM Notation WHERE id_cuisinier = 1;
