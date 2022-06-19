create database IF NOT exists BazaZakupy;

use BazaZakupy;

create table IF NOT exists Produkty(
    id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    cena double not null,
    kraj char(40) not null,
    nazwa char(40) not null,
    rodzaj char(40) not null);

create table IF NOT exists Sklep(
    id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    adres char(40) not null,
    miasto char(40) not null);


create table IF NOT exists Klient(
    id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
    login char(15) not null,
    haslo char(20) not null,
    telefon char(15) not null,
    mail char(40) not null);


create table IF NOT exists Zakupy(
    id_produktu INT NOT NULL,
    id_klienta INT NOT NULL,
    ilosc int,
    id_transakcji int,
    foreign key (id_produktu) references produkty(id),
    foreign key (id_klienta) references klient(id));

create table IF NOT exists czy_jest_produkt(
    id_produktu INT NOT NULL,
    id_sklepu INT NOT NULL,
    ilosc int,
    foreign key (id_produktu) references produkty(id),
    foreign key (id_sklepu) references sklep(id));

