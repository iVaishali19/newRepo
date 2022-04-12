# SQL Test Assignment

Attached is a mysqldump of a database to be used during the test.

Below are the questions for this test. Please enter a full, complete, working SQL statement under each question. We do not want the answer to the question. We want the SQL command to derive the answer. We will copy/paste these commands to test the validity of the answer.

**Example:**

_Q. Select all users_

- Please return at least first_name and last_name

SELECT first_name, last_name FROM users;


------

**— Test Starts Here —**

1. Select users whose id is either 3,2 or 4
- Please return at least: all user fields
SELECT * FROM users_table WHERE ID IN (3, 2, 4)

2. Count how many basic and premium listings each active user has
- Please return at least: first_name, last_name, basic, premium

 select count(l.status) , l.status from 
 listings as l,users as u where  u.id= l.user_id and u.status=2
 group by l.status 


3. Show the same count as before but only if they have at least ONE premium listing
- Please return at least: first_name, last_name, basic, premium

 select count(l.status),  l.status from 
 listings as l,users as u where u.id= l.user_id and u.status=2  and l.status=3 limit 1

4. How much revenue has each active vendor made in 2013
- Please return at least: first_name, last_name, currency, revenue


select u.first_name,u.last_name , c.currency, c.price
 from clicks as c, listings as l,users as u where  c.listing_id= l.id and u.id= l.user_id and u.status=2
and  year(c.created)=2013


5. Insert a new click for listing id 3, at $4.00
- Find out the id of this new click. Please return at least: id

INSERT INTO clicks(id,listing_id,price,currency,created)
SELECT 
   id,
   listing_id,
   price,
   currency,
   created
FROM 
   clicks
WHERE
   listing_id='3' and price='4.00';
   
 Note:  Executing the following SELECT query to get id of this new click
  SELECT  id  FROM clicks WHERE id=(SELECT LAST_INSERT_ID())



6. Show listings that have not received a click in 2013
- Please return at least: listing_name

select l.name , c.created
 from clicks as c, listings as l where  c.listing_id= l.id 
and  year(c.created) <> 2013


7. For each year show number of listings clicked and number of vendors who owned these listings
- Please return at least: date, total_listings_clicked, total_vendors_affected


 select count(l.id) as total_listings_clicked,count(u.id) as total_vendors_affected , year(c.created) as ldate from clicks as c , listings as l , users as u
where c.listing_id=l.id and l.user_id = u.id group by ldate


8. Return a comma separated string of listing names for all active vendors
- Please return at least: first_name, last_name, listing_names

SELECT users.first_name, users.last_name, listings.listing_names
FROM users
INNER JOIN listings ON 
users.id = listings.user_id
WHERE users.status=2
