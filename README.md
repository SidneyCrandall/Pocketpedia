# Pocketpedia

Pocketpedia is a companion application for the Nintendo Switch game, Animal Crossing: New Horizons. 

Animal Crossing: New Horizons is a game where a player is given the opportunity to choose an island to clean up and create a village for themselves, their villagers, and friends. As the game progresses a player has the ability to catch bugs, fish, and sea creatures along
with purchasing art and unearthing fossils. The goal is for a player to fill a museum up in order to get various in-game prizes. 

Once a user has logged in or registered an account, the application will bring users to a home page where they will be able to navigate through the app by a navigation bar at the top of the page. From their a user can choose between viewing 
a Bug, Fish, Art, Fossil, Villager, or Sea Creature List, that is using `ACNHAPI.com` external API to pull info of that particular creature or thing. Once a user has navigated to one of those pages they will be able to indictae whether they have caught or acquired it. 
Once they have finished, they will be able to navigate to a page that will contain only that current logged in user's collection. A user can alo keep up with all of the villagers that have or are residing on that player's island. The Pocketpedia user also has the ability to 
make a note about any in-game codes, have a list that tracks a villager or villagerss new saying, or a gift the `ACNH` player has given their favorite villagers.  

Pocketpedia is a fun and simple way for players to track what they still need before Blather's (New Horizons owl museum curator) Museum can be complete. 


## Instructions for Installing Pocketpedia

To launch the Pocketpedia app, you will need to have access to command line tools, node package manager, JSON Server. If you do not have access to any of these tools, you can find instructions for installing them below.

Clone this repo on you personal machine using the following command

  `git clone git@github.com:SidneyCrandall/Pocketpedia.git`
  
Install the NPM dependencies for this project using the following commands

  ```sh
    cd Pocketpedia
    npm install
  ```

From your terminal window, type

  ```sh
    npm start
  ```
  
Now that the server is up and running, you can open an internet browser and access the application

  ```sh
    http://localhost:3080/
  ```
  
Congratulations, you are now in Pocketpedia!



## Appendix 2: Set Up Instructions

You will need to have command line tools installed for your computer to use terminal commands.

Linux/ Windows users, please visit the Git page and follow the instructions for set up

Mac users follow the instructions below

Open your terminal and type

   ```sh
    git --version
  ```
  
You will now need to configure your git account. In the terminal window, type:

  ```sh
    git config -global user.name "Your Name"
    git config -global user.email "Your Email"
  ```
  
If you do not have Node.js installed on your machine, visit the Node.js Download Page and follow the instructions. To ensure that it is installed correctly, in your terminal window, type

   ```sh
    echo $PATH
  ```
  
Ensure that the result has the following in the $PATH

  ```sh
    /usr/local/bin
    or
    /usr/local/bin:/usr/bin:/bin:/usr/sbin:/sbin
  ```
  
1) Pull down this repo

2) Run the script that's in the SQL folder. This will create the Pocketpedia database.

3) You will need to set up a Firebase account: do the follow steps in the firebase console:

- Go to [Firebase](https://console.firebase.google.com/u/0/) and add a new project. You can name it whatever you want (Pocketpedia is a good name)
- Go to the Authentication tab, click "Set up sign in method", and enable the Username and Password option.
- Add at least two new users in firebase. Use email addresses that you find in the UserProfile table of your SQL Server database
- Once firebase creates a UID for these users, copy the UID from firebase and update the `FirebaseUserId` column for the same users in your SQL Server database.
- Click the Gear icon in the sidebar to go to Project Settings. You'll need the information on this page for the next few steps

4) Go to the `appSettings.Local.json.example` file. Replace the value for FirebaseProjectId with your own

5) Rename the `appSettings.Local.json.example` file to remove the `.example` extension. This file should now just be called `appSettings.Local.json`

6) Open your `client` directory in VsCode. Open the `.env.local.example` file and replace `__YOUR_API_KEY_HERE__` with your own firebase Web API Key

7) Rename the `.env.local.example` file to remove the .example extension. This file should now just be called `.env.local`

8) Install your dependencies by running `npm install` from the same directory as your `package.json` file

Now you can follow the installation instructions from above to get Pocketpedia up and running on your machine.

This project was bootstrapped with Create React App.


## Technologies Used
  ### Development Languages and Libraries
 * ASP.NET Core Web API, 
 * React, 
 * Reactstrap,
 * SQL
 
 
### Entity Relationship Diagram
  ![Pocketpedia ERD]
  
### Wireframes/Mockups
  ![Pocketpedia Wireframe]
