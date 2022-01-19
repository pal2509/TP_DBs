CREATE TABLE Role (
  id   SERIAL NOT NULL, 
  type varchar(255), 
  PRIMARY KEY (id));
CREATE TABLE Auth (
  user_id       uuid NOT NULL, 
  email         varchar(255), 
  password_hash varchar(255), 
  salt          varchar(255));
CREATE TABLE "User" (
  user_id         uuid NOT NULL, 
  Roleid          int4 NOT NULL, 
  user_name       varchar(255) NOT NULL, 
  date_of_birth   date, 
  account_balance float8, 
  fullname        varchar(255), 
  phone_number    int4 NOT NULL, 
  PRIMARY KEY (user_id));
CREATE TABLE incident (
  id          SERIAL NOT NULL, 
  Triptrip_id uuid NOT NULL, 
  type        varchar(255), 
  description varchar(255), 
  datetime    timestamp, 
  location    int4, 
  PRIMARY KEY (id));
CREATE TABLE Trip (
  trip_id              uuid NOT NULL, 
  vehicle_id           uuid NOT NULL, 
  user_id              uuid NOT NULL, 
  location_id          int4 NOT NULL, 
  disc_id              uuid, 
  cost                 float4, 
  length               int4, 
  duration             int4, 
  start_time           timestamp NOT NULL, 
  end_time             timestamp NOT NULL, 
  rating               int2, 
  feedback_description varchar(255), 
  path                 int4, 
  PRIMARY KEY (trip_id));
CREATE TABLE Vehicle (
  vehicle_id      uuid NOT NULL, 
  location_id     int4 NOT NULL, 
  name            varchar(255), 
  model           varchar(255), 
  brand           varchar(255), 
  autonomy        int4, 
  startdate       timestamp, 
  state           varchar(255), 
  battery_level   int4, 
  currentlocation int4, 
  PRIMARY KEY (vehicle_id));
CREATE TABLE Location (
  location_id SERIAL NOT NULL, 
  name        varchar(255), 
  coordinates int4, 
  hour_rate   float8 NOT NULL, 
  PRIMARY KEY (location_id));
CREATE TABLE Notifications (
  not_id      uuid NOT NULL, 
  id          int4, 
  type        varchar(255), 
  description varchar(255), 
  state       varchar(255), 
  PRIMARY KEY (not_id));
CREATE TABLE Payment (
  payment_id        SERIAL NOT NULL, 
  Useruser_id       uuid NOT NULL, 
  Payment_method_id uuid NOT NULL, 
  trip_id           uuid NOT NULL, 
  value             float8 NOT NULL, 
  "date"            timestamp NOT NULL, 
  PRIMARY KEY (payment_id));
CREATE TABLE Discounts (
  disc_id uuid NOT NULL, 
  type    varchar(255), 
  amount  int4, 
  "date"  timestamp, 
  "desc"  varchar(255), 
  PRIMARY KEY (disc_id));
CREATE TABLE User_Notifications (
  user_id             uuid NOT NULL, 
  notificationsnot_id uuid NOT NULL, 
  PRIMARY KEY (user_id, 
  notificationsnot_id));
CREATE TABLE User_Discounts (
  Useruser_id      uuid NOT NULL, 
  Discountsdisc_id uuid NOT NULL, 
  PRIMARY KEY (Useruser_id, 
  Discountsdisc_id));
CREATE TABLE Payment_Method (
  method_id   uuid NOT NULL, 
  Useruser_id uuid NOT NULL, 
  method      varchar(255), 
  cardnumber  int8, 
  date_added  timestamp NOT NULL, 
  state       bool NOT NULL, 
  PRIMARY KEY (method_id));
CREATE TABLE AuthToken (
  auth_id     BIGSERIAL NOT NULL, 
  Useruser_id uuid NOT NULL, 
  jwtoken     varchar(255) NOT NULL, 
  "date"      timestamp NOT NULL, 
  PRIMARY KEY (auth_id));
CREATE TABLE ParkingSpaces (
  park_id     SERIAL NOT NULL, 
  location_id int4 NOT NULL, 
  coordinates int4, 
  PRIMARY KEY (park_id));
CREATE TABLE Locations_history (
  vehicle_id uuid NOT NULL, 
  "date"     timestamp NOT NULL, 
  point      int4 NOT NULL);
ALTER TABLE Auth ADD CONSTRAINT FKAuth567568 FOREIGN KEY (user_id) REFERENCES "User" (user_id);
ALTER TABLE incident ADD CONSTRAINT FKincident615622 FOREIGN KEY (Triptrip_id) REFERENCES Trip (trip_id);
ALTER TABLE Trip ADD CONSTRAINT "Uma viagem tem um veículo" FOREIGN KEY (vehicle_id) REFERENCES Vehicle (vehicle_id);
ALTER TABLE Trip ADD CONSTRAINT "Um utilizador realiza várias viagens" FOREIGN KEY (user_id) REFERENCES "User" (user_id);
ALTER TABLE Payment ADD CONSTRAINT "Um utilizador faz varios pagamentos" FOREIGN KEY (Useruser_id) REFERENCES "User" (user_id);
ALTER TABLE "User" ADD CONSTRAINT FKUser347743 FOREIGN KEY (Roleid) REFERENCES Role (id);
ALTER TABLE Vehicle ADD CONSTRAINT "Uma localização tem vários veículos" FOREIGN KEY (location_id) REFERENCES Location (location_id);
ALTER TABLE Trip ADD CONSTRAINT "Uma viagem tem uma localização" FOREIGN KEY (location_id) REFERENCES Location (location_id);
ALTER TABLE User_Notifications ADD CONSTRAINT FKUser_Notif843215 FOREIGN KEY (user_id) REFERENCES "User" (user_id);
ALTER TABLE User_Notifications ADD CONSTRAINT FKUser_Notif512287 FOREIGN KEY (notificationsnot_id) REFERENCES Notifications (not_id);
ALTER TABLE User_Discounts ADD CONSTRAINT FKUser_Disco566941 FOREIGN KEY (Useruser_id) REFERENCES "User" (user_id);
ALTER TABLE User_Discounts ADD CONSTRAINT FKUser_Disco234974 FOREIGN KEY (Discountsdisc_id) REFERENCES Discounts (disc_id);
ALTER TABLE Payment_Method ADD CONSTRAINT "Um utilizador tem vários metodos de pagamento" FOREIGN KEY (Useruser_id) REFERENCES "User" (user_id);
ALTER TABLE Payment ADD CONSTRAINT FKPayment121051 FOREIGN KEY (Payment_method_id) REFERENCES Payment_Method (method_id);
ALTER TABLE Trip ADD CONSTRAINT FKTrip117734 FOREIGN KEY (disc_id) REFERENCES Discounts (disc_id);
ALTER TABLE AuthToken ADD CONSTRAINT FKAuthToken684359 FOREIGN KEY (Useruser_id) REFERENCES "User" (user_id);
ALTER TABLE ParkingSpaces ADD CONSTRAINT FKParkingSpa397743 FOREIGN KEY (location_id) REFERENCES Location (location_id);
ALTER TABLE Locations_history ADD CONSTRAINT FKLocations_570199 FOREIGN KEY (vehicle_id) REFERENCES Vehicle (vehicle_id);
ALTER TABLE Payment ADD CONSTRAINT "Uma viagem tem um pagamento" FOREIGN KEY (trip_id) REFERENCES Trip (trip_id);
