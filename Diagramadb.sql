CREATE TABLE Role (
  id   SERIAL NOT NULL, 
  type varchar(255), 
  PRIMARY KEY (id));
CREATE TABLE Auth (
  email       varchar(255), 
  password    varchar(255), 
  Useruser_id uuid NOT NULL);
CREATE TABLE User (
  user_id         uuid NOT NULL, 
  user_name       varchar(255), 
  date_of_birth   date, 
  account_balance float4, 
  fullname        varchar(255), 
  Roleid          int4 NOT NULL, 
  PRIMARY KEY (user_id));
CREATE TABLE incident (
  id          SERIAL NOT NULL, 
  Triptrip_id uuid NOT NULL, 
  type        varchar(255), 
  description varchar(255), 
  datetime    timestamp, 
  location    point, 
  PRIMARY KEY (id));
CREATE TABLE Trip (
  trip_id              uuid NOT NULL, 
  vehicle_id           uuid NOT NULL, 
  user_id              uuid NOT NULL, 
  location_id          int4 NOT NULL, 
  cost                 float4, 
  length               int4, 
  duration             int4, 
  start_time           timestamp NOT NULL, 
  end_time             timestamp NOT NULL, 
  rating               int2, 
  feedback_description varchar(255), 
  path                 lseg, 
  PRIMARY KEY (trip_id));
CREATE TABLE Vehicle (
  vehicle_id      uuid NOT NULL, 
  location_id     int4 NOT NULL, 
  name            varchar(255), 
  model           varchar(255), 
  brand           varchar(255), 
  autonomy        int4, 
  startdate       timestamp, 
  hour_rate       float4, 
  state           varchar(255), 
  battery_level   int4, 
  currentlocation point, 
  PRIMARY KEY (vehicle_id));
CREATE TABLE Location (
  location_id SERIAL NOT NULL, 
  name        varchar(255), 
  coordinates polygon, 
  PRIMARY KEY (location_id));
CREATE TABLE notifications (
  Useruser_id uuid NOT NULL, 
  id          SERIAL NOT NULL, 
  type        varchar(255), 
  description varchar(255), 
  state       varchar(255));
CREATE TABLE Payment (
  payment_id  SERIAL NOT NULL, 
  method      int4 NOT NULL, 
  value       int4 NOT NULL, 
  Useruser_id uuid NOT NULL, 
  PRIMARY KEY (payment_id));
ALTER TABLE Auth ADD CONSTRAINT FKAuth219078 FOREIGN KEY (Useruser_id) REFERENCES User (user_id);
ALTER TABLE incident ADD CONSTRAINT FKincident615622 FOREIGN KEY (Triptrip_id) REFERENCES Trip (trip_id);
ALTER TABLE Trip ADD CONSTRAINT FKTrip957630 FOREIGN KEY (vehicle_id) REFERENCES Vehicle (vehicle_id);
ALTER TABLE Trip ADD CONSTRAINT FKTrip4755 FOREIGN KEY (user_id) REFERENCES User (user_id);
ALTER TABLE notifications ADD CONSTRAINT FKnotificati83664 FOREIGN KEY (Useruser_id) REFERENCES User (user_id);
ALTER TABLE Payment ADD CONSTRAINT FKPayment701187 FOREIGN KEY (Useruser_id) REFERENCES User (user_id);
ALTER TABLE User ADD CONSTRAINT FKUser347743 FOREIGN KEY (Roleid) REFERENCES Role (id);
ALTER TABLE Vehicle ADD CONSTRAINT FKVehicle82489 FOREIGN KEY (location_id) REFERENCES Location (location_id);
ALTER TABLE Trip ADD CONSTRAINT FKTrip26466 FOREIGN KEY (location_id) REFERENCES Location (location_id);
