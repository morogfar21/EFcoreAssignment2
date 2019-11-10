# EFcoreAssignment2
Assignment 2 - Entity Framework Core

Gruppe 8

1. Projektet åbnes

2. Følg anvisning i opgavebeskrivelsen: 
- "When reviewing, the connection string should be changed to your local MS SQL Serverinstance for test."

3. Kør programmet med CTRL+F5

4. Se mulige kommandoer i konsollen

	a. Start med "1", indsættelse af DummyData
	b. View data med kommandoer vist i konsollen
	c. Kør' kommando "2" inden konsollen lukkes

NOTE: 

Det er i vores implementering ikke muligt, at indsætte dummydata, lukke konsollen, køre programmet igen og derefter slette/indsætte dummydata.
Vær' derfor sikker på, at kommandoen "2" (Clear Database) bliver kørt, inden du lukker konsollen.

Skulle det ske, at konsollen lukkes efter indsættelse af dummydata uden clearing af databasen,
skal kommandoen "update-database 0" efterfulgt af "update-database" køres i Package Manager Console.

5. Hvis I/du ønsker at create objekter til databasen ud over DummyData, skal det gøres i følgende rækkefølge: 

	a. Create Restaurant
	b. Create Table
	c. Create Dishes
	d. Create Waiter
	e. Create Guest
	f. Create Review

6. God fornøjelse