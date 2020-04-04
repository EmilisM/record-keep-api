CREATE TABLE user_data (
	id SERIAL PRIMARY KEY,
	user_name varchar(50) NOT NULL UNIQUE,
	password_hash text,
	password_salt text,
	creation_date date
);

CREATE TABLE image (
	id SERIAL PRIMARY KEY,
	url text
);

CREATE TABLE record_type (
	id SERIAL PRIMARY KEY,
	name varchar(50)
);

CREATE TABLE record (
	id SERIAL PRIMARY KEY,
	artist text,
	name text,
	creation_date date,
	record_type_id int,
	FOREIGN KEY (record_type_id) REFERENCES record_type(id)
);

CREATE TABLE collection (
	id SERIAL PRIMARY KEY,
	name text,
	description text,
	creation_date date,
	owner_id int,
	FOREIGN KEY (owner_id) REFERENCES user_data(id)
);

CREATE TABLE collection_records (
	collection_id int,
	record_id int,
	PRIMARY KEY (collection_id, record_id),
	FOREIGN KEY (collection_id) REFERENCES collection(id),
	FOREIGN KEY (record_id) REFERENCES collection(id)
);