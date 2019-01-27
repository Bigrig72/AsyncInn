# AsyncInn
Hotel Management Systems

## What is the the Async Inn
Async inn is an MVC built web application with the ability to keep track, create, read, update and delate information regarding the hotel.
It will utilize a relational database that utilizes several home controllers to control how these databases operate. Through SQL we will be able to communicate with this database. This application will be styled using a combination of a Bootstrap library and standar CSS.

## Home Page
Basic html and styling that links the index action of each of the other controllers within the Home page.

## Hotel Page
Here we will be able to utilize a CRUD stategy to provide updated information about the Hotel.
## Hotel-Room Page
Here we will have information in a CRUD format to gather and update more specific details on the Hotel room, 
It will have Composite keys of HotelID and Room ID.
## Room Page
This is where all the information or blueprint of the room will be. This will consist of a foreign Key for Room amentities and 
an enum to have a list of options regarding room type- EX..Studio, One Bedroom, Two Bedroom.

## Room Amentities Page
This will be where two composite keys of Amentities ID and Room ID will be created to combine the two to give a more specific
outline for the room amentities.

## Amentities
Here is where it is very specidic to the actual amentity.

## Example of what each table will generally look like--
![edit](https://github.com/Bigrig72/AsyncInn/blob/master/HotelManagementSystems/assets/BasicTemplateForHotelEdit.PNG)
![create](https://github.com/Bigrig72/AsyncInn/blob/master/HotelManagementSystems/assets/BasicTemplateWithNavBarHotel.PNG)
![delete](https://github.com/Bigrig72/AsyncInn/blob/master/HotelManagementSystems/assets/DeleteHotel.PNG)
![details](https://github.com/Bigrig72/AsyncInn/blob/master/HotelManagementSystems/assets/DetailsPageHotel.PNG)



