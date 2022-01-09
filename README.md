# ImageRepository
This application was created for the Winter 2022 - Shopify Developer Intern Challenge. It is used to safely store images uploaded by users.

# Table of Contents
* [Features](#features)
* [Screenshots](#screenshots)
* [Technologies Used](#technologies-used)
* [BackEnd Functionality](#backend-functionality)

# Features
## Login and Register
The first page of the application will bring the user to the login page to enter the email and password. If the user does not have an existing account, click on the "Register here" link under the Log in button. When registering, you will be asked to enter the email you would like to use for the account and the password. Once you press register, a message will display that your account has been succesfully created and the credentials can now be used in the Sign in page.

## Main Page
Once logged in into the appllication, all the uploaded images will be displayed on the main page. Up to 6 images can be displayed at a time with the name of files underneath them. To see more pictures, theres a scroll feature included to scroll through all the images. If this is a brand new account or no images are currently uploaded, there will be a message displaying, "There are currently no images uploaded!". On the top right corner there is a log out button with the name of the current user logged in next to it.

## Upload Photos
To upload photos, press on the "Select some files" button and select the images you want to upload. Once selected, wait until a preview of all the images appear in the box, and press save. The uploaded images will display on the main page.

## Delete Images
For each image uploaded into the application, the name of the file with a checkbox next to it will be displayed in the Delete Images box. The user can select which images they would like to remove. If the "Select All" option is selected, all the images will be selected. Once the delete button is pressed all the selected file names will permanently be removed from the application. If no images are currently uploaded into the application, the Delete Images box will remain empty.

# Screenshots
![image](https://user-images.githubusercontent.com/62719168/148697611-0b5cce81-60cb-44b8-b690-846fc0356ebc.png)
![image](https://user-images.githubusercontent.com/62719168/148697630-4f03f2e4-7993-48af-a7e8-15ca2ba0a98c.png)
![image](https://user-images.githubusercontent.com/62719168/148697749-6cc400d1-8645-4d03-aed3-af284c12273a.png)
![image](https://user-images.githubusercontent.com/62719168/148697718-ee628948-5f6c-4d0a-845c-8e8009e485b2.png)



# Technologies Used
- ASP.NET MVC 5 Framework
- C#
- Javascript
- HTML
- CSS
- SQL
- Deployed using Azure DevOps

# BackEnd Functionality
The account information containing the emails and passwords set by all accounts are stored into a SQL database. For security purposes, the passwords of all users are encrypted into the database. Each user has its own individual folder named after their email where all images are being stored. The user's folder are automatically created if it does not already exist, once the user logs in into the application
