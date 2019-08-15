CREATE TABLE product_category (
	id SERIAL PRIMARY KEY,
	category_name VARCHAR(200) UNIQUE NOT NULL
);

CREATE TABLE product (
	id SERIAL PRIMARY KEY,
	product_category_id INTEGER REFERENCES product_category(id) NOT NULL,
	product_name VARCHAR(200) NOT NULL,
	product_description VARCHAR(1000) NOT NULL,
	product_price NUMERIC(10, 2)
);
