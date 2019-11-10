# EFcoreAssignment2
Assignment 2 - Entity Framework Core

Gruppe 8

1. Projektet �bnes

2. F�lg anvisning i opgavebeskrivelsen: 
- "When reviewing, the connection string should be changed to your local MS SQL Serverinstance for test."

3. K�r programmet med CTRL+F5

4. Se mulige kommandoer i konsollen

	a. Start med "1", inds�ttelse af DummyData
	b. View data med kommandoer vist i konsollen
	c. K�r' kommando "2" inden konsollen lukkes

NOTE: 

Det er i vores implementering ikke muligt, at inds�tte dummydata, lukke konsollen, k�re programmet igen og derefter slette/inds�tte dummydata.
V�r' derfor sikker p�, at kommandoen "2" (Clear Database) bliver k�rt, inden du lukker konsollen.

Skulle det ske, at konsollen lukkes efter inds�ttelse af dummydata uden clearing af databasen,
skal kommandoen "update-database 0" efterfulgt af "update-database" k�res i Package Manager Console.

5. Hvis I/du �nsker at create objekter til databasen ud over DummyData, skal det g�res i f�lgende r�kkef�lge: 

	a. Create Restaurant
	b. Create Table
	c. Create Dishes
	d. Create Waiter
	e. Create Guest
	f. Create Review

6. God forn�jelse