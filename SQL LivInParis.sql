CREATE DATABASE IF NOT EXISTS LivInParis;


USE LivInParis;
DROP TABLE commande_plat;
DROP TABLE Commande;
DROP TABLE Notation;
DROP TABLE Client;
DROP TABLE Cuisiner;
DROP TABLE plat;
DROP TABLE Cuisinier;

CREATE TABLE Client (
    id_client INT PRIMARY KEY AUTO_INCREMENT,
    nom VARCHAR(100) NOT NULL,
    prenom VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    rue VARCHAR(100),
    numeroRue VARCHAR(10),
    codePostal INT,
    ville VARCHAR(100),
    metroLePlusProche VARCHAR(100) NOT NULL,
    telephone VARCHAR(20) UNIQUE NOT NULL,
    -- note_moyenne DECIMAL(3,2) DEFAULT 0,
    mot_de_passe VARCHAR(255) NOT NULL
);

CREATE TABLE Cuisinier (
    id_cuisinier INT PRIMARY KEY AUTO_INCREMENT,
    nom VARCHAR(100) NOT NULL,
    prenom VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    telephone VARCHAR(20) UNIQUE NOT NULL,
    rue VARCHAR(100),
    numeroRue VARCHAR(10),
    codePostal INT,
    ville VARCHAR(100),
    metroLePlusProche VARCHAR(100) NOT NULL,
    specialite_culinaire VARCHAR(100),
    mot_de_passe VARCHAR(255) NOT NULL,
    note_moyenne DECIMAL(3,2) DEFAULT 0
);

CREATE TABLE Plat (
    id_plat INT PRIMARY KEY AUTO_INCREMENT,
    id_cuisinier INT NOT NULL,
    nom VARCHAR(100) NOT NULL,
    photo VARCHAR(255),
    nombre_personne INT NOT NULL,
    type_plat VARCHAR(50) NOT NULL,
    nationalite_plat VARCHAR(50) NOT NULL,
    prix DECIMAL(10,2) NOT NULL,
    ingredients TEXT NOT NULL,
    date_fabrication DATE NOT NULL,
    date_peremption DATE NOT NULL,
	FOREIGN KEY (id_cuisinier) REFERENCES Cuisinier(id_cuisinier) ON DELETE CASCADE

);

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
-- table pour gérer les plats commandés
CREATE TABLE Commande_Plat (
    id_commande INT NOT NULL,
    id_plat INT NOT NULL,
    quantite INT NOT NULL DEFAULT 1,
    PRIMARY KEY (id_commande, id_plat),
    FOREIGN KEY (id_commande) REFERENCES Commande(id_commande) ON DELETE CASCADE,
    FOREIGN KEY (id_plat) REFERENCES Plat(id_plat) ON DELETE CASCADE
);

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
INSERT INTO Client (nom, prenom, rue , numeroRue , codePostal , ville , metroLePlusProche , email, telephone, mot_de_passe) VALUES
('Dupont', 'Jean', 'Rue Cardinet' , '15' , 75017 , 'Paris' , 'Cardinet' , 'jean.dupont@email.com', '0600000000', 'test');
INSERT INTO Client (nom, prenom, rue, numeroRue, codePostal, ville, metroLePlusProche, email, telephone, mot_de_passe) VALUES
('Durand', 'Alice', 'Rue Lafayette', '10', 75009, 'Paris', 'Cadet', 'alice.durand@email.com', '0601234567', 'test'),
('Bernard', 'Lucas', 'Avenue de Clichy', '25', 75017, 'Paris', 'Brochant', 'lucas.bernard@email.com', '0612345678', 'test'),
('Morel', 'Sophie', 'Boulevard Haussmann', '50', 75008, 'Paris', 'Havre-Caumartin', 'sophie.morel@email.com', '0623456789', 'test'),
('Rousseau', 'Pierre', 'Rue de Rennes', '5', 75006, 'Paris', 'Saint-Placide', 'pierre.rousseau@email.com', '0634567890', 'test'),
('Mot', 'ju','Rue de Nantes','24', 75009, 'Paris', 'Cadet', 'ju.mot@e.com', '0685930589', 'test');
INSERT INTO Cuisinier (nom, prenom, rue, numeroRue, codePostal, ville, metroLePlusProche, email, telephone, specialite_culinaire, mot_de_passe, note_moyenne) VALUES
('Mart', 'ju', 'Rue de Lyon', '20', 75012, 'Paris', 'Gare de Lyon', 'ju@e.com', '0611111111', 'Cuisine Française', 'test', 0.0);

INSERT INTO Plat (nom, nombre_personne, type_plat, nationalite_plat, prix, ingredients,  date_fabrication, date_peremption, id_cuisinier) VALUES
('Ratatouille', 2, 'Plat principal', 'Française', 12.50, 'Aubergines, Courgettes, Poivrons', '2025-03-08', '2025-03-10', 1);

INSERT INTO Commande (id_client, id_cuisinier, date_heure_commande, nombre_portion, statut_commande, adresse_livraison) VALUES
(1, 1, NOW(), 2, 'En attente', '12 Rue de Paris');


INSERT INTO Notation (id_client, id_cuisinier, note_attribuee, commentaire) VALUES
(1, 1, 4.5, 'Très bon repas !');

INSERT INTO Cuisinier (nom, prenom, rue, numeroRue, codePostal, ville, metroLePlusProche, email, telephone, specialite_culinaire, mot_de_passe, note_moyenne) VALUES
('Lemoine', 'Thomas', 'Rue Oberkampf', '15', 75011, 'Paris', 'Oberkampf', 'thomas.lemoine@email.com', '0602857491', 'Cuisine Italienne', 'test', 0.0),
('Dubois', 'Emma', 'Boulevard Saint-Michel', '30', 75005, 'Paris', 'Cluny-La Sorbonne', 'emma.dubois@email.com', '0657829578', 'Cuisine Asiatique', 'test', 0.0),
('Girard', 'Paul', 'Avenue de la République', '5', 75010, 'Paris', 'République', 'paul.girard@email.com', '0626475619', 'Cuisine Végétarienne', 'test', 0.0);
INSERT INTO Cuisinier (id_cuisinier, nom, prenom, rue, numeroRue, codePostal, ville, metroLePlusProche, email, telephone, specialite_culinaire, mot_de_passe, note_moyenne) VALUES
(5, 'Leclerc', 'Jean', 'Rue de Rivoli', '45', 75004, 'Paris', 'Châtelet', 'jean.leclerc@email.com', '0689583705', 'Cuisine Italienne', 'test', 0.0),
(6, 'Tanaka', 'Hiroshi', 'Rue Saint-Honoré', '88', 75001, 'Paris', 'Palais Royal', 'hiroshi.tanaka@email.com', '0627185746', 'Cuisine Japonaise', 'test', 0.0),
(7, 'Patel', 'Aisha', 'Boulevard Voltaire', '12', 75011, 'Paris', 'Oberkampf', 'aisha.patel@email.com', '0607869572', 'Cuisine Indienne', 'test', 0.0);

INSERT INTO Plat (nom, nombre_personne, type_plat, nationalite_plat, prix, ingredients, date_fabrication, date_peremption, id_cuisinier) VALUES
('Boeuf Bourguignon', 2, 'Plat principal', 'Française', 15.00, 'Boeuf, Vin rouge, Carottes, Oignons', '2025-03-08', '2025-03-10', 1),
('Tarte Tatin', 4, 'Dessert', 'Française', 8.50, 'Pommes, Sucre, Beurre', '2025-03-09', '2025-03-11', 1),
('Pâtes Carbonara', 3, 'Plat principal', 'Italienne', 12.00, 'Pâtes, Œufs, Lardons, Parmesan', '2025-03-08', '2025-03-10', 2),
('Tiramisu', 2, 'Dessert', 'Italienne', 7.00, 'Mascarpone, Café, Biscuits', '2025-03-08', '2025-03-10', 2),
('Sushi Varié', 2, 'Plat principal', 'Japonaise', 18.00, 'Saumon, Riz, Algues', '2025-03-07', '2025-03-09', 3),
('Ramen au Porc', 1, 'Plat principal', 'Japonaise', 14.50, 'Nouilles, Porc, Bouillon, Œuf', '2025-03-07', '2025-03-09', 3),
('Salade de Quinoa', 3, 'Entrée', 'Végétarienne', 10.00, 'Quinoa, Tomates, Avocats', '2025-03-08', '2025-03-10', 4),
('Curry de Légumes', 2, 'Plat principal', 'Indienne', 13.50, 'Légumes, Curry, Lait de Coco','2025-03-08', '2025-03-10', 4);

INSERT INTO Commande (id_client, id_cuisinier, date_heure_commande, nombre_portion, statut_commande, adresse_livraison) VALUES
(1, 1, NOW(), 2, 'Livré', '10 Rue Lafayette, 75009 Paris'),
(1, 6, NOW(), 1, 'En attente', '10 Rue Lafayette, 75009 Paris'),
(2, 7, NOW(), 2, 'En cours', '25 Avenue de Clichy, 75017 Paris'),
(3, 7, NOW(), 3, 'Livré', '50 Boulevard Haussmann, 75008 Paris'),
(4, 1, NOW(), 1, 'Livré', '5 Rue de Rennes, 75006 Paris');

-- ⭐ Ajouter des Notations
INSERT INTO Notation (id_client, id_cuisinier, note_attribuee, commentaire) VALUES
(1, 1, 5.0, 'Excellente cuisine française, super boeuf bourguignon !'),
(2, 3, 4.5, 'Très bons sushis, j’ai adoré !'),
(3, 4, 4.0, 'Bon plat végétarien, mais un peu trop épicé pour moi.'),
(4, 1, 4.8, 'Délicieux dessert, la tarte tatin était parfaite !'),
(1, 2, 4.2, 'Bonne carbonara mais un peu trop salée.');


INSERT INTO Cuisiner (id_cuisinier, id_plat) VALUES (1, 1);

-- ALTER USER 'root'@'localhost' IDENTIFIED BY '111222';

-- Quelques requêtes de test
SELECT * FROM Client;
SELECT * FROM Cuisinier;
SELECT * FROM Commande WHERE statut_commande = 'En attente';
SELECT * FROM Commande ;


SELECT AVG(note_attribuee) AS moyenne_notes FROM Notation WHERE id_cuisinier = 1;

-- rendre le code avec des fonctions plus basiques Console.WriteLine("\nBonjour Cuisinier "+prenom+" !");Console.WriteLine("\nBonjour Cuisinier "+prenom+" !");

-- envoyer une commande pour cuisinier statut en attent devient en cours client valide la reception statut livré et accès à la notation du cuisinier